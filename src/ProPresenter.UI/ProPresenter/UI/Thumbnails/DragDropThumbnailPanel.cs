using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.UI;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;
using ProPresenter.DO.PanelSourcing;

namespace ProPresenter.UI.Thumbnails;

public abstract class DragDropThumbnailPanel<T> : CutPasteThumbnailPanel<T> where T : class, IThumbnailSource
{
	private const double OuterPartitionDivider = 1.0 / 6.0;

	public static readonly DependencyProperty AllowDragProperty = DependencyProperty.Register("AllowDrag", typeof(bool), typeof(ThumbnailPanel<T>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

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

	protected abstract IDragDropCollection<T>? SourceCollection { get; }

	protected DragSource DragSource { get; }

	protected DropTarget DropTarget { get; }

	protected Thumbnail? TargetThumbnail { get; private set; }

	protected T? TargetItem => TargetThumbnail?.Source as T;

	protected int DropIndex { get; private set; }

	protected bool DroppedBefore { get; private set; }

	protected bool DroppedOutside { get; private set; }

	protected bool DroppedInside { get; private set; }

	protected bool InDeadSpace { get; private set; }

	protected bool IsCopying { get; private set; }

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

	protected DragDropThumbnailPanel()
	{
		DragSource = new DragSource((DependencyObject)(object)this);
		DropTarget = new DropTarget((DependencyObject)(object)this);
		base.AllowDrop = true;
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

	protected void AddDropType<I>(Predicate<IEnumerable<I>>? validate = null, Func<DraggedItems<I>, DragEventArgs, bool>? canCopy = null) where I : T
	{
		AddDropType((IEnumerable<I> i) => i.Cast<T>(), validate, canCopy);
	}

	protected void AddDropType<I>(Func<IEnumerable<I>, IEnumerable<T>> convert, Predicate<IEnumerable<I>>? validate = null, Func<DraggedItems<I>, DragEventArgs, bool>? canCopy = null)
	{
		DropAction<DraggedItems<I>> dropAction = DropTarget.AddDropType<DraggedItems<I>>();
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
			if (!e.Effects.HasFlag(DragDropEffects.Copy) && source.Items.Cast<T>().Contains(TargetThumbnail?.Source))
			{
				ResetDropIndex();
			}
			else
			{
				UpdateDropIndex(e);
			}
		});
		dropAction.SetOnDataDroppedAction(delegate(DraggedItems<I> source, DragEventArgs e)
		{
			if (DropIndex >= 0)
			{
				IsCopying = e.Effects.HasFlag(DragDropEffects.Copy);
				IEnumerable<T> enumerable = null;
				if (source.SourceCollection != SourceCollection)
				{
					enumerable = convert(source.Items);
					source.SourceCollection?.DraggedFrom(source.Items);
					SourceCollection?.DroppedInto(enumerable.AsEnumerable().OrderBy(SourceCollection.IndexOf), DropIndex, IsCopying);
				}
				else if (SourceCollection != null)
				{
					enumerable = source.Items.Cast<T>().OrderBy(SourceCollection.IndexOf);
					if (IsCopying)
					{
						SourceCollection.DroppedInto(enumerable, DropIndex, IsCopying);
					}
					else
					{
						SourceCollection.MoveTo(enumerable, DropIndex);
					}
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

	protected override void OnThumbnailDragged(Thumbnail thumbnail, MouseEventArgs e)
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		if (AllowDrag && thumbnail.Source is T val)
		{
			IEnumerable<T> enumerable2;
			if (base.SelectedItems == null || !base.SelectedItems.Contains(val))
			{
				IEnumerable<T> enumerable = new T[1] { val };
				enumerable2 = enumerable;
			}
			else
			{
				IEnumerable<T> enumerable = base.SelectedItems;
				enumerable2 = enumerable;
			}
			IEnumerable<T> enumerable3 = enumerable2;
			if (!enumerable3.Contains<T>(base.SelectedItem))
			{
				base.SelectedItem = val;
			}
			DragSource.StartDrag(new DraggedItems<T>(SourceCollection, enumerable3.ToArray()), CreateDragVisual(enumerable3, thumbnail), DragDropEffects.Copy | DragDropEffects.Move, (Vector2<double>)e.GetPosition(thumbnail));
		}
	}

	protected virtual Visual CreateDragVisual(IEnumerable<T> draggedItems, Thumbnail draggedThumbnail)
	{
		return draggedThumbnail.ToDragVisual(draggedItems.Count(), null);
	}

	private void UpdateDropIndex(DragEventArgs e, bool canDropInside = false, bool canDropOutside = true)
	{
		TargetThumbnail = FindThumbnail(e)?.Control;
		InDeadSpace = TargetThumbnail == null;
		if (InDeadSpace && canDropOutside)
		{
			TargetThumbnail = base.Thumbnails.LastOrDefault()?.Control;
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
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		DroppedBefore = false;
		int num = base.Items?.Count() ?? 0;
		if (TargetThumbnail != null && !InDeadSpace)
		{
			num = ((TargetItem == null) ? (-1) : (SourceCollection?.IndexOf(TargetItem) ?? (-1)));
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
			if (num < 0)
			{
				return base.Items?.Count() ?? 0;
			}
		}
		if (!DroppedBefore)
		{
			return num + 1;
		}
		return num;
	}

	private void UpdateDropIndicator(DragEventArgs e, bool canDropInside = false, bool canDropOutside = true)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
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
			if (InDeadSpace)
			{
				DroppedOutside = true;
				DroppedInside = false;
			}
			AdornerPosition dropPosition = ((!canDropOutside) ? AdornerPosition.Inside : ((!isOrientedHorizontally) ? (InDeadSpace ? AdornerPosition.Bottom : FindDropAdornerPosition(position2, TargetThumbnail.ActualHeight, isHorizontal: false, canDropInside)) : (InDeadSpace ? AdornerPosition.Right : FindDropAdornerPosition(position2, TargetThumbnail.ActualWidth, isHorizontal: true, canDropInside))));
			ShowDropIndicator(dropPosition);
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
			if (!canDropInside)
			{
				if (!isHorizontal)
				{
					return AdornerPosition.Top;
				}
				return AdornerPosition.Left;
			}
			return AdornerPosition.Inside;
		}
		if (flag2)
		{
			if (!canDropInside)
			{
				if (!isHorizontal)
				{
					return AdornerPosition.Bottom;
				}
				return AdornerPosition.Right;
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
}
