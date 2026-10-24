using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.UI;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;
using ProPresenter.DO.PanelSourcing;

namespace ProPresenter.UI.Thumbnails;

public abstract class UniformDragDropViewPanel<TSource, TControl> : UniformViewPanel<TSource, TControl> where TSource : class, IUniformViewSource where TControl : FrameworkElement, IUniformViewControl, new()
{
	private const double OuterPartitionDivider = 1.0 / 6.0;

	private Vector2<double> _mouseDownPosition = Vector2<double>.Zero;

	private bool _canDrag;

	public static readonly DependencyProperty AllowDragProperty = DependencyProperty.Register("AllowDrag", typeof(bool), typeof(UniformDragDropViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty SelectItemsOnDropProperty = DependencyProperty.Register("SelectItemsOnDrop", typeof(bool), typeof(UniformDragDropViewPanel<TSource, TControl>));

	public static readonly DependencyProperty SelectItemsOnSelfDropProperty = DependencyProperty.Register("SelectItemsOnSelfDrop", typeof(bool), typeof(UniformDragDropViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty CollectionDirectionProperty = DependencyProperty.Register("CollectionDirection", typeof(ListSortDirection), typeof(UniformDragDropViewPanel<TSource, TControl>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)ListSortDirection.Ascending));

	public bool AllowDrag
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowDragProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowDragProperty, (object)value);
		}
	}

	public bool IsDragging => DragSource.IsDragging;

	public bool SelectItemsOnDrop
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SelectItemsOnDropProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectItemsOnDropProperty, (object)value);
		}
	}

	public bool SelectItemsOnSelfDrop
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SelectItemsOnSelfDropProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectItemsOnSelfDropProperty, (object)value);
		}
	}

	public ListSortDirection CollectionDirection
	{
		get
		{
			return (ListSortDirection)((DependencyObject)this).GetValue(CollectionDirectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CollectionDirectionProperty, (object)value);
		}
	}

	protected abstract IDragDropCollection<TSource> SourceCollection { get; }

	protected DragSource DragSource { get; }

	protected DropTarget DropTarget { get; }

	protected TControl? TargetThumbnail { get; private set; }

	protected TSource? TargetItem => TargetThumbnail?.Source as TSource;

	protected int DropIndex { get; private set; }

	protected bool DroppedBefore { get; private set; }

	protected bool DroppedOutside { get; private set; }

	protected bool DroppedInside { get; private set; }

	protected bool InDeadSpace { get; private set; }

	private bool IsOrientedHorizontally
	{
		get
		{
			if (base.IsThumbnailMode)
			{
				return base.RowCapacity > 1;
			}
			return false;
		}
	}

	protected UniformDragDropViewPanel()
	{
		DragSource = new DragSource((DependencyObject)(object)this);
		DropTarget = new DropTarget((DependencyObject)(object)this);
		base.AllowDrop = true;
	}

	protected void AddDropType<I>(Predicate<IEnumerable<I>>? validate = null, Func<DraggedItems<I>, DragEventArgs, bool>? canCopy = null, Action<DraggedItems<I>, DragEventArgs>? dropInside = null) where I : TSource
	{
		AddDropType((IEnumerable<I> i) => i.Cast<TSource>(), validate, canCopy, dropInside);
	}

	protected void AddDropType<I>(Func<IEnumerable<I>, IEnumerable<TSource>> convert, Predicate<IEnumerable<I>>? validate = null, Func<DraggedItems<I>, DragEventArgs, bool>? canCopy = null, Action<DraggedItems<I>, DragEventArgs>? dropInside = null)
	{
		DropAction<DraggedItems<I>> dropAction = DropTarget.AddDropType<DraggedItems<I>>();
		bool canDropInside = dropInside != null;
		dropAction.SetIsValidDataPredicate((DraggedItems<I> source, DragEventArgs e) => SourceCollection != null && (validate?.Invoke(source.Items) ?? true));
		dropAction.SetCanCopyPredicate((DraggedItems<I> source, DragEventArgs e) => canCopy?.Invoke(source, e) ?? false);
		dropAction.SetOnDataEnteredAction(delegate(DraggedItems<I> source, DragEventArgs e)
		{
			UpdateDropIndex(e);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			ResetDropIndex();
		});
		dropAction.SetOnDataDraggedAction(delegate(DraggedItems<I> source, DragEventArgs e)
		{
			if (!e.Effects.HasFlag(DragDropEffects.Copy) && source.Items.Cast<TSource>().Contains(TargetThumbnail?.Source))
			{
				ResetDropIndex();
			}
			else
			{
				UpdateDropIndex(e, canDropInside);
			}
		});
		dropAction.SetOnDataDroppedAction(delegate(DraggedItems<I> source, DragEventArgs e)
		{
			if (DropIndex >= 0)
			{
				if (canDropInside && DroppedInside)
				{
					dropInside?.Invoke(source, e);
				}
				else
				{
					DropHelper.DoDropData(source, SourceCollection, convert, DropIndex, e, out IEnumerable<TSource> _);
				}
				ResetDropIndex();
			}
		});
	}

	protected void AddCustomDrop<C>(Action<DraggedTreeItemsCollection<C>, DragEventArgs> drop, Func<DraggedTreeItemsCollection<C>, DragEventArgs, bool>? validate = null, bool canDropInside = false, bool canDropOutside = true) where C : IDragDropTreeCollection<C>, IIdentifiable
	{
		DropAction<DraggedTreeItemsCollection<C>> dropAction = DropTarget.AddDropType<DraggedTreeItemsCollection<C>>();
		dropAction.SetIsValidDataPredicate((DraggedTreeItemsCollection<C> source, DragEventArgs e) => validate?.Invoke(source, e) ?? true);
		dropAction.SetOnDataEnteredAction(delegate(DraggedTreeItemsCollection<C> source, DragEventArgs e)
		{
			UpdateDropIndex(e, canDropInside, canDropOutside);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			((DependencyObject)(object)this).ResetDropIndicator();
		});
		dropAction.SetOnDataDraggedAction(delegate(DraggedTreeItemsCollection<C> source, DragEventArgs e)
		{
			UpdateDropIndex(e, canDropInside, canDropOutside);
		});
		dropAction.SetOnDataDroppedAction(delegate(DraggedTreeItemsCollection<C> source, DragEventArgs e)
		{
			((DependencyObject)(object)this).ResetDropIndicator();
			drop?.Invoke(source, e);
		});
	}

	protected void AddCustomDrop<C>(Action<DraggedItems<C>, DragEventArgs> drop, Func<DraggedItems<C>, DragEventArgs, bool>? validate = null, Func<DraggedItems<C>, DragEventArgs, bool>? canCopy = null, Func<DraggedItems<C>, DragEventArgs, bool>? canDropInside = null, bool canDropOutside = true)
	{
		DropAction<DraggedItems<C>> dropAction = DropTarget.AddDropType<DraggedItems<C>>();
		dropAction.SetIsValidDataPredicate((DraggedItems<C> source, DragEventArgs e) => validate?.Invoke(source, e) ?? true);
		dropAction.SetCanCopyPredicate((DraggedItems<C> source, DragEventArgs e) => canCopy?.Invoke(source, e) ?? false);
		dropAction.SetOnDataEnteredAction(delegate(DraggedItems<C> source, DragEventArgs e)
		{
			UpdateDropIndex(e, canDropInside?.Invoke(source, e) ?? false, canDropOutside);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			((DependencyObject)(object)this).ResetDropIndicator();
		});
		dropAction.SetOnDataDraggedAction(delegate(DraggedItems<C> source, DragEventArgs e)
		{
			UpdateDropIndex(e, canDropInside?.Invoke(source, e) ?? false, canDropOutside);
		});
		dropAction.SetOnDataDroppedAction(delegate(DraggedItems<C> source, DragEventArgs e)
		{
			((DependencyObject)(object)this).ResetDropIndicator();
			drop?.Invoke(source, e);
		});
	}

	protected void AddFileDrop(Action<FileInfo[], DragEventArgs> drop, Func<FileInfo[], DragEventArgs, bool>? validate = null, bool canDropInside = false)
	{
		DropAction<FileInfo[]> dropAction = DropTarget.AddFileDrop();
		dropAction.SetIsValidDataPredicate((FileInfo[] source, DragEventArgs e) => validate?.Invoke(source, e) ?? true);
		dropAction.SetOnDataEnteredAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			UpdateDropIndex(e, canDropInside);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			((DependencyObject)(object)this).ResetDropIndicator();
		});
		dropAction.SetOnDataDraggedAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			UpdateDropIndex(e, canDropInside);
		});
		dropAction.SetOnDataDroppedAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			((DependencyObject)(object)this).ResetDropIndicator();
			drop?.Invoke(source, e);
		});
	}

	protected void AddWebDropType(Action<FileInfo[], DragEventArgs> onDataDropped, Func<FileInfo[], DragEventArgs, bool> isValid, bool canDropInside = false)
	{
		DropAction<FileInfo[]> dropAction = DropTarget.AddWebMediaDrop();
		dropAction.SetIsValidDataPredicate(isValid);
		dropAction.SetOnDataEnteredAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			UpdateDropIndex(e, canDropInside);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			((DependencyObject)(object)this).ResetDropIndicator();
		});
		dropAction.SetOnDataDraggedAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			UpdateDropIndex(e, canDropInside);
		});
		dropAction.SetOnDataDroppedAction(delegate(FileInfo[] source, DragEventArgs e)
		{
			((DependencyObject)(object)this).ResetDropIndicator();
			onDataDropped(source, e);
		});
	}

	protected void AddRemoteFileDrop(Action<IRemoteFile, DragEventArgs> drop, Func<IRemoteFile, DragEventArgs, bool>? validate = null, bool canDropInside = false)
	{
		DropAction<IRemoteFile> dropAction = DropTarget.AddDropType<IRemoteFile>();
		dropAction.SetIsValidDataPredicate((IRemoteFile source, DragEventArgs e) => validate?.Invoke(source, e) ?? true);
		dropAction.SetOnDataEnteredAction(delegate(IRemoteFile source, DragEventArgs e)
		{
			UpdateDropIndex(e, canDropInside);
		});
		dropAction.SetOnDataLeftAction(delegate
		{
			((DependencyObject)(object)this).ResetDropIndicator();
		});
		dropAction.SetOnDataDraggedAction(delegate(IRemoteFile source, DragEventArgs e)
		{
			UpdateDropIndex(e, canDropInside);
		});
		dropAction.SetOnDataDroppedAction(delegate(IRemoteFile source, DragEventArgs e)
		{
			((DependencyObject)(object)this).ResetDropIndicator();
			drop?.Invoke(source, e);
		});
	}

	protected override void OnThumbnailDragged(TControl? thumbnail, MouseEventArgs mouseArgs)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		TSource val = (TSource)(thumbnail?.Source);
		if (AllowDrag && thumbnail != null && val != null)
		{
			IEnumerable<TSource> enumerable2;
			if (base.SelectedItems == null || !base.SelectedItems.Contains(val))
			{
				IEnumerable<TSource> enumerable = new TSource[1] { val };
				enumerable2 = enumerable;
			}
			else
			{
				IEnumerable<TSource> enumerable = base.SelectedItems;
				enumerable2 = enumerable;
			}
			IEnumerable<TSource> enumerable3 = enumerable2;
			if (!enumerable3.Contains<TSource>(base.SelectedItem))
			{
				base.SelectedItem = val;
			}
			DragSource.StartDrag(new DraggedItems<TSource>(SourceCollection, enumerable3.ToArray()), CreateDragVisual(enumerable3, thumbnail), DragDropEffects.Copy | DragDropEffects.Move, (Vector2<double>)mouseArgs.GetPosition(thumbnail));
		}
	}

	protected virtual Visual CreateDragVisual(IEnumerable<TSource> draggedItems, TControl draggedThumbnail)
	{
		return draggedThumbnail.ToDragVisual(draggedItems.Count(), null);
	}

	private void UpdateDropIndex(DragEventArgs e, bool canDropInside = false, bool canDropOutside = true)
	{
		UniformViewPanel<TSource, TControl>.ThumbnailData? thumbnailData = FindThumbnail(e);
		TargetThumbnail = ((thumbnailData != null) ? thumbnailData.Control : null);
		InDeadSpace = TargetThumbnail == null;
		if (InDeadSpace && canDropOutside)
		{
			ThumbnailData? thumbnailData2 = base.Thumbnails.LastOrDefault();
			TargetThumbnail = ((thumbnailData2 != null) ? thumbnailData2.Control : null);
		}
		UpdateDropIndicator(e, canDropInside, canDropOutside);
		DropIndex = FindDropIndex(e);
	}

	private void ResetDropIndex()
	{
		DropIndex = -1;
		((DependencyObject)(object)this).ResetDropIndicator();
	}

	private int FindDropIndex(DragEventArgs e)
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		DroppedBefore = false;
		int num = base.Items?.Count() ?? 0;
		int num2 = num;
		if (TargetThumbnail != null && !InDeadSpace)
		{
			num2 = ((TargetItem != null) ? SourceCollection.IndexOf(TargetItem) : (-1));
			Point position;
			bool droppedBefore;
			if (!IsOrientedHorizontally)
			{
				position = e.GetPosition(TargetThumbnail);
				droppedBefore = ((Point)(ref position)).Y < TargetThumbnail.ActualHeight / 2.0;
			}
			else
			{
				position = e.GetPosition(TargetThumbnail);
				droppedBefore = ((Point)(ref position)).X < TargetThumbnail.ActualWidth / 2.0;
			}
			DroppedBefore = droppedBefore;
			if (num2 < 0)
			{
				return base.Items?.Count() ?? 0;
			}
		}
		num2 = (DroppedBefore ? num2 : (num2 + 1));
		return num2.Clamp(0, num);
	}

	private void UpdateDropIndicator(DragEventArgs e, bool canDropInside = false, bool canDropOutside = true)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if (TargetThumbnail != null)
		{
			((DependencyObject)(object)this).ResetDropIndicator();
			bool isOrientedHorizontally = IsOrientedHorizontally;
			Point position;
			double num;
			if (!isOrientedHorizontally)
			{
				position = e.GetPosition(TargetThumbnail);
				num = ((Point)(ref position)).Y;
			}
			else
			{
				position = e.GetPosition(TargetThumbnail);
				num = ((Point)(ref position)).X;
			}
			double position2 = num;
			AdornerPosition adornerPosition = (InDeadSpace ? AdornerPosition.Right : FindDropAdornerPosition(position2, TargetThumbnail.ActualWidth, isHorizontal: true, canDropInside));
			AdornerPosition adornerPosition2 = (InDeadSpace ? AdornerPosition.Bottom : FindDropAdornerPosition(position2, TargetThumbnail.ActualHeight, isHorizontal: false, canDropInside));
			AdornerPosition adornerPosition3 = (isOrientedHorizontally ? adornerPosition : adornerPosition2);
			AdornerPosition adornerPosition4 = (canDropOutside ? adornerPosition3 : AdornerPosition.Inside);
			DroppedOutside = InDeadSpace || adornerPosition4 != AdornerPosition.Inside;
			DroppedInside = !InDeadSpace && adornerPosition4 == AdornerPosition.Inside;
			ShowDropIndicator(adornerPosition4);
		}
	}

	private AdornerPosition FindDropAdornerPosition(double position, double dimension, bool isHorizontal, bool canDropInside = false)
	{
		bool num = position < dimension * (1.0 / 6.0);
		bool flag = position.IsInRangeInclusive(dimension / 2.0, dimension * (1.0 / 6.0));
		bool flag2 = position.IsInRangeInclusive(dimension - dimension / 2.0, dimension - dimension * (1.0 / 6.0));
		DroppedOutside = !flag && !flag2;
		DroppedInside = flag || flag2;
		if (num)
		{
			if (!isHorizontal)
			{
				return AdornerPosition.Top;
			}
			return AdornerPosition.Left;
		}
		if (flag)
		{
			AdornerPosition result = ((!isHorizontal) ? AdornerPosition.Top : AdornerPosition.Left);
			if (!canDropInside)
			{
				return result;
			}
			return AdornerPosition.Inside;
		}
		if (flag2)
		{
			AdornerPosition result2 = (isHorizontal ? AdornerPosition.Right : AdornerPosition.Bottom);
			if (!canDropInside)
			{
				return result2;
			}
			return AdornerPosition.Inside;
		}
		if (!isHorizontal)
		{
			return AdornerPosition.Bottom;
		}
		return AdornerPosition.Right;
	}

	protected virtual void ShowDropIndicator(AdornerPosition dropPosition)
	{
		TargetThumbnail?.ShowDropIndicator(dropPosition, Colors.Aqua, 3.0);
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		_mouseDownPosition = (Vector2<double>)e.GetPosition(this);
		ref bool canDrag = ref _canDrag;
		object originalSource = e.OriginalSource;
		canDrag = (((DependencyObject)((originalSource is DependencyObject) ? originalSource : null))?.FindAllVisualParents(typeof(Button)))?.Empty() ?? true;
	}

	protected override void OnPreviewMouseMove(MouseEventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		if (_canDrag && e.LeftButton == MouseButtonState.Pressed && e.CanDrag(this, _mouseDownPosition))
		{
			HitTestResult hitTestResult = VisualTreeHelper.HitTest(this, _mouseDownPosition);
			object obj;
			if (hitTestResult == null)
			{
				obj = null;
			}
			else
			{
				DependencyObject visualHit = hitTestResult.VisualHit;
				obj = ((visualHit != null) ? visualHit.FindVisualParent<TControl>() : null);
			}
			TControl thumbnail = (TControl)obj;
			OnThumbnailDragged(thumbnail, e);
			_canDrag = false;
			e.Handled = true;
		}
	}

	protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
	{
		_canDrag = false;
	}
}
