using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.UI.Components;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;
using ProPresenter.DO.Arrangements;

namespace ProPresenter.UI.ArrangementView;

public class ArrangementPanel : WrapPanel
{
	private const double MinimumPanelHeight = 34.0;

	private const double DropIndicatorThickness = 3.0;

	private static readonly Color DropIndicatorColor;

	private readonly DragSource _dragSource;

	private readonly List<GroupToken> _tokens = new List<GroupToken>();

	private bool _canStartDrag;

	private Vector2<double> _mouseDownPosition = Vector2<double>.Zero;

	public static readonly DependencyProperty ArrangementProperty;

	public static readonly DependencyProperty ActiveGroupProperty;

	public static readonly DependencyProperty IsMasterViewProperty;

	public static readonly DependencyProperty FullOpacityProperty;

	public static readonly DependencyProperty MoveGroupCommandProperty;

	public static readonly DependencyProperty RemoveGroupCommandProperty;

	public Arrangement? Arrangement
	{
		get
		{
			return (Arrangement)((DependencyObject)this).GetValue(ArrangementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ArrangementProperty, (object)value);
		}
	}

	public CueGroup? ActiveGroup
	{
		get
		{
			return (CueGroup)((DependencyObject)this).GetValue(ActiveGroupProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveGroupProperty, (object)value);
		}
	}

	public bool IsMasterView
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsMasterViewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsMasterViewProperty, (object)value);
		}
	}

	public bool FullOpacity
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(FullOpacityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FullOpacityProperty, (object)value);
		}
	}

	public ICommand<ArrangementDragCommandParameters>? MoveGroupCommand
	{
		get
		{
			return (ICommand<ArrangementDragCommandParameters>)((DependencyObject)this).GetValue(MoveGroupCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MoveGroupCommandProperty, (object)value);
		}
	}

	public ICommand<CueGroup>? RemoveGroupCommand
	{
		get
		{
			return (ICommand<CueGroup>)((DependencyObject)this).GetValue(RemoveGroupCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RemoveGroupCommandProperty, (object)value);
		}
	}

	static ArrangementPanel()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		DropIndicatorColor = Colors.Yellow;
		ArrangementProperty = DependencyProperty.Register("Arrangement", typeof(Arrangement), typeof(ArrangementPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((ArrangementPanel)(object)s).ReloadGroups((Arrangement)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (Arrangement)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}));
		ActiveGroupProperty = DependencyProperty.Register("ActiveGroup", typeof(CueGroup), typeof(ArrangementPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((ArrangementPanel)(object)s).ReloadActiveItem((CueGroup)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}));
		IsMasterViewProperty = DependencyProperty.Register("IsMasterView", typeof(bool), typeof(ArrangementPanel), new PropertyMetadata((object)false));
		FullOpacityProperty = DependencyProperty.Register("FullOpacity", typeof(bool), typeof(ArrangementPanel), new PropertyMetadata((object)false));
		MoveGroupCommandProperty = DependencyProperty.Register("MoveGroupCommand", typeof(ICommand<ArrangementDragCommandParameters>), typeof(ArrangementPanel));
		RemoveGroupCommandProperty = DependencyProperty.Register("RemoveGroupCommand", typeof(ICommand<CueGroup>), typeof(ArrangementPanel));
		FrameworkElement.MinHeightProperty.OverrideMetadata(typeof(ArrangementPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)34.0));
	}

	public ArrangementPanel()
	{
		base.AllowDrop = true;
		_dragSource = new DragSource((DependencyObject)(object)this);
		DropAction<GroupToken> dropAction = new DropTarget((DependencyObject)(object)this).AddDropType<GroupToken>();
		dropAction.SetOnDataDroppedAction(OnDataDropped);
		dropAction.SetOnDataEnteredAction(delegate(GroupToken t, DragEventArgs e)
		{
			UpdateDropIndicator(e);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			((DependencyObject)(object)this).ResetDropIndicator();
		});
		dropAction.SetIsValidDataPredicate((GroupToken t, DragEventArgs e) => !IsMasterView || _tokens.Contains(t));
	}

	private void ReloadGroups(Arrangement oldValue, Arrangement newValue)
	{
		if (oldValue != null)
		{
			oldValue.CollectionChanged -= ItemsChanged;
			oldValue.ForEach(RemoveItem);
		}
		if (newValue != null && (IsMasterView || !newValue.IsMaster))
		{
			newValue.CollectionChanged += ItemsChanged;
			newValue.ForEach(AddItem);
		}
		ReloadActiveItem(ActiveGroup);
	}

	private void ReloadActiveItem(CueGroup? activeGroup)
	{
		_tokens.ForEach(delegate(GroupToken t)
		{
			t.IsActive = t.ArrangementGroup == activeGroup || (IsMasterView && t.ArrangementGroup?.Label.Text == activeGroup?.Label.Text);
		});
	}

	private void ItemsChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Reset)
		{
			base.Children.RemoveRange(base.Children.OfType<GroupToken>());
		}
		e.OldItems?.Cast<CueGroup>().ForEach(RemoveItem);
		e.NewItems?.Cast<CueGroup>().ForEach(delegate(CueGroup g)
		{
			InsertItem(g, e.NewStartingIndex);
		});
		ReloadActiveItem(ActiveGroup);
	}

	private void AddItem(CueGroup group)
	{
		InsertItem(group, _tokens.Count);
	}

	private void InsertItem(CueGroup group, int index)
	{
		GroupToken groupToken = new GroupToken(group)
		{
			RemoveArrangementGroupCommand = RemoveGroupCommand,
			ShowCloseButton = ((!(Arrangement?.IsMaster)) ?? false)
		};
		groupToken.SetBinding(GroupToken.FullOpacityProperty, new Binding("FullOpacity")
		{
			Source = this
		});
		_tokens.Insert(index, groupToken);
		base.Children.Insert(index, groupToken);
	}

	private void RemoveToken(GroupToken token)
	{
		base.Children.Remove(token);
		_tokens.Remove(token);
	}

	private void RemoveItem(CueGroup group)
	{
		_tokens.Where((GroupToken t) => t.ArrangementGroup == group).ToArray().ForEach(RemoveToken);
	}

	protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
	{
		_canStartDrag = false;
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		_canStartDrag = e.FindHitElement<GroupToken>(this) != null;
		_mouseDownPosition = (Vector2<double>)e.GetPosition(this);
	}

	protected override void OnPreviewMouseMove(MouseEventArgs e)
	{
		if (!_canStartDrag || e.LeftButton != MouseButtonState.Pressed || !e.CanDrag(this, _mouseDownPosition))
		{
			return;
		}
		GroupToken groupToken = e.FindHitElement<GroupToken>(this);
		if (groupToken != null)
		{
			_canStartDrag = false;
			if (!StartDrag(groupToken, e))
			{
				((DependencyObject)(object)this).ResetDropIndicator();
			}
			base.OnPreviewMouseMove(e);
		}
	}

	private DragResult StartDrag(GroupToken token, MouseEventArgs e)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		return _dragSource.StartDrag(token, token.ToDragVisual(1, null), DragDropEffects.Move, (Vector2<double>)e.GetPosition(token));
	}

	private void MoveGroup(GroupToken data, GroupToken? targetToken, bool isLeftSideDrag)
	{
		int dropIndex = ((targetToken != null) ? (_tokens.IndexOf(targetToken) + ((!isLeftSideDrag) ? 1 : 0)) : 0);
		MoveGroupCommand?.Invoke(new ArrangementDragCommandParameters(Arrangement, data.ArrangementGroup.ToEnumerable(), dropIndex, _tokens.Contains(data)));
	}

	private void OnDataDropped(GroupToken data, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
		if (!TryFindToken(e, out GroupToken token, out bool isLeftSideDrag))
		{
			token = null;
		}
		if (data != token)
		{
			MoveGroup(data, token, isLeftSideDrag);
		}
	}

	private void UpdateDropIndicator(DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
		if (TryFindToken(e, out GroupToken token, out bool isLeftSideDrag))
		{
			token.ShowDropIndicator((!isLeftSideDrag) ? AdornerPosition.Right : AdornerPosition.Left, DropIndicatorColor, 3.0);
		}
	}

	private bool TryFindToken(DragEventArgs e, [NotNullWhen(true)] out GroupToken? token, out bool isLeftSideDrag)
	{
		token = e.FindHitElement<GroupToken>(this) ?? _tokens.LastOrDefault();
		isLeftSideDrag = IsLeftSideDrag(e, token);
		return token != null;
	}

	private static bool IsLeftSideDrag(DragEventArgs e, GroupToken? token)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		if (token != null)
		{
			Point position = e.GetPosition(token);
			return ((Point)(ref position)).X < token.ActualWidth / 2.0;
		}
		return false;
	}
}
