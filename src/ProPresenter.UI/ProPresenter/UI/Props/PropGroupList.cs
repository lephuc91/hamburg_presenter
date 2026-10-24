using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.Common.Time;
using Pro.UI;
using Pro.UI.Controls;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.UI.Props;

public class PropGroupList : DragDropListBox<IPropGroupVM>
{
	private static readonly TimeSlice DragOverThreshold = TimeSlice.FromSeconds(SystemParameters.MouseHoverTime.TotalSeconds);

	private int _hoverIndex = -1;

	private readonly Clock _dragOverClock = new Clock();

	public static readonly DependencyProperty CloseCollectionPopupCommandProperty = DependencyProperty.Register("CloseCollectionPopupCommand", typeof(ICommand), typeof(PropGroupList));

	protected override IDragDropCollection<IPropGroupVM>? SourceCollection => base.ItemsSource as IDragDropCollection<IPropGroupVM>;

	public ICommand CloseCollectionPopupCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CloseCollectionPopupCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CloseCollectionPopupCommandProperty, (object)value);
		}
	}

	public event DragEventHandler? DragStarted;

	public event DragEventHandler? DragEnded;

	public PropGroupList()
	{
		AddDropType(null, null, null, (DraggedItems<IPropGroupVM> _, DragEventArgs _) => true);
		RegisterDropType();
	}

	private void RegisterDropType()
	{
		DropAction<DraggedItems<IPropCueVM>> dropAction = base.DropTarget.AddDropType<DraggedItems<IPropCueVM>>();
		dropAction.SetOnDataEnteredAction(delegate(DraggedItems<IPropCueVM> source, DragEventArgs e)
		{
			UpdateDrop(e);
		});
		dropAction.SetOnDataDraggedAction(delegate(DraggedItems<IPropCueVM> source, DragEventArgs e)
		{
			UpdateDrop(e);
		});
		dropAction.SetOnDataLeftAction(delegate(DraggedItems<IPropCueVM> source, DragEventArgs e)
		{
			ResetDrop(e);
		});
		dropAction.SetOnDataDroppedAction(delegate(DraggedItems<IPropCueVM> source, DragEventArgs e)
		{
			if (_hoverIndex >= 0 && source.Items.Any())
			{
				IPropGroupVM propGroupVM = source.Items.FirstOrDefault()?.Parent;
				IPropGroupVM propGroupVM2 = (base.ItemsSource as IEnumerable<IPropGroupVM>)?.ElementAtOrDefault(_hoverIndex);
				if (propGroupVM != propGroupVM2)
				{
					propGroupVM?.RemovePropsCommand?.Invoke(source.Items);
					propGroupVM2?.AddPropsCommand?.Invoke(source.Items);
				}
			}
			ResetDrop(e);
		});
	}

	private void UpdateDrop(DragEventArgs e)
	{
		UpdateDropIndex(e, insideOnly: true);
		this.DragStarted?.Invoke(this, e);
		int num = FindDropIndex(e, insideOnly: true);
		if (_hoverIndex != num)
		{
			_dragOverClock.Restart();
			_hoverIndex = num;
		}
		if (_hoverIndex >= 0 && _dragOverClock.ElapsedTime >= DragOverThreshold)
		{
			base.SelectedListItem = (base.ItemsSource as IEnumerable<IPropGroupVM>)?.ElementAtOrDefault(_hoverIndex);
			_dragOverClock.Stop();
		}
		e.Effects = DragDropEffects.Move;
	}

	private void ResetDrop(DragEventArgs e)
	{
		ResetDropIndex(insideOnly: true);
		this.DragEnded?.Invoke(this, e);
		_hoverIndex = -1;
		_dragOverClock.Stop();
	}

	protected override void SetSelection(IEnumerable<IPropGroupVM> selectedItems, bool leftClick)
	{
		if (leftClick)
		{
			CloseCollectionPopupCommand?.Invoke();
		}
		base.SetSelection(selectedItems, leftClick);
	}
}
