using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.DO.Token;
using Pro.UI.Controls.Tokens;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

public abstract class TokenListBox<T, L> : ListBox where T : TokenBase where L : class, IEnumerable<T>, INotifyCollectionChanged
{
	private readonly DragSource _dragSource;

	private bool _canStartDrag;

	private Vector2<double> _mouseDownPos = Vector2<double>.Zero;

	public static readonly DependencyProperty TokensProperty = DependencyProperty.Register("Tokens", typeof(L), typeof(TokenListBox<T, L>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTokensChanged)));

	public L Tokens
	{
		get
		{
			return (L)((DependencyObject)this).GetValue(TokensProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TokensProperty, (object)value);
		}
	}

	private static void OnTokensChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((TokenListBox<T, L>)(object)callerObject).ReloadTokens(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as L, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as L);
	}

	protected TokenListBox()
	{
		base.AllowDrop = false;
		base.SelectionMode = SelectionMode.Extended;
		base.Style = Application.Current?.Resources[typeof(ListBox)] as Style;
		_dragSource = new DragSource((DependencyObject)(object)this);
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		object originalSource = e.OriginalSource;
		IEnumerable<DependencyObject> enumerable = ((DependencyObject)((originalSource is DependencyObject) ? originalSource : null))?.FindAllVisualParents(typeof(Button), typeof(PathControl));
		_canStartDrag = (enumerable == null || !enumerable.Any()) && !((DependencyObject)(object)this).FindVisualChildren<EditableTextBlock>().Any((EditableTextBlock b) => b.IsInEditMode);
		_mouseDownPos = (Vector2<double>)e.GetPosition(this);
		base.OnPreviewMouseLeftButtonDown(e);
	}

	protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		_canStartDrag = false;
		base.OnPreviewMouseLeftButtonUp(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		if (_canStartDrag && e.LeftButton == MouseButtonState.Pressed && e.CanDrag(this, _mouseDownPos))
		{
			TokenControl tokenControl = e.FindHitElement<TokenControl>(this);
			if (tokenControl != null)
			{
				_dragSource.StartDrag(new DraggedItems<T>(null, new T[1] { (T)tokenControl.Token }), tokenControl.ToDragVisual(1, null), DragDropEffects.Copy, (Vector2<double>)e.GetPosition(tokenControl));
			}
		}
	}

	protected virtual TokenControl OnGenerateToken(T tokenData)
	{
		return new TokenControl();
	}

	private TokenControl GenerateToken(T tokenData)
	{
		TokenControl tokenControl = OnGenerateToken(tokenData);
		tokenControl.Token = tokenData;
		return tokenControl;
	}

	private void ReloadTokens(L? oldItems, L? newItems)
	{
		if (oldItems != null)
		{
			oldItems.CollectionChanged -= TokenCollectionChanged;
			oldItems.ForEach(RemoveToken);
		}
		if (newItems != null)
		{
			newItems.CollectionChanged += TokenCollectionChanged;
			newItems.ForEach(AddToken);
		}
	}

	private void TokenCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.Cast<T>().ForEach(RemoveToken);
		e.NewItems?.Cast<T>().ForEach(delegate(T t)
		{
			InsertToken(e.NewStartingIndex, t);
		});
	}

	private void RemoveToken(T tokenData)
	{
		base.Items.Remove(base.Items.FirstOrDefaultOf((TokenControl t) => t.Token == tokenData));
	}

	private void AddToken(T tokenData)
	{
		InsertToken(base.Items.Count, tokenData);
	}

	private void InsertToken(int index, T tokenData)
	{
		base.Items.Insert(index, GenerateToken(tokenData));
	}
}
