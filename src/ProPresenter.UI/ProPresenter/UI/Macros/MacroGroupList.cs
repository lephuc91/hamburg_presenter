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
using ProPresenter.UI.ViewModels.Macros;

namespace ProPresenter.UI.Macros;

public class MacroGroupList : DragDropListBox<IMacroGroupVM>
{
	private static readonly TimeSlice DragOverThreshold = TimeSlice.FromSeconds(SystemParameters.MouseHoverTime.TotalSeconds);

	private int _hoverIndex = -1;

	private readonly Clock _dragOverClock = new Clock();

	public static readonly DependencyProperty CloseCollectionPopupCommandProperty = DependencyProperty.Register("CloseCollectionPopupCommand", typeof(ICommand), typeof(MacroGroupList));

	protected override IDragDropCollection<IMacroGroupVM>? SourceCollection => base.ItemsSource as IDragDropCollection<IMacroGroupVM>;

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

	public MacroGroupList()
	{
		AddDropType(null, null, null, (DraggedItems<IMacroGroupVM> _, DragEventArgs _) => true);
		RegisterMacroDropType();
	}

	private void RegisterMacroDropType()
	{
		DropAction<DraggedItems<IMacroItemVM>> dropAction = base.DropTarget.AddDropType<DraggedItems<IMacroItemVM>>();
		dropAction.SetOnDataEnteredAction(delegate(DraggedItems<IMacroItemVM> source, DragEventArgs e)
		{
			UpdateDrop(e);
		});
		dropAction.SetOnDataDraggedAction(delegate(DraggedItems<IMacroItemVM> source, DragEventArgs e)
		{
			UpdateDrop(e);
		});
		dropAction.SetOnDataLeftAction(delegate(DraggedItems<IMacroItemVM> source, DragEventArgs e)
		{
			ResetDrop(e);
		});
		dropAction.SetOnDataDroppedAction(delegate(DraggedItems<IMacroItemVM> source, DragEventArgs e)
		{
			if (_hoverIndex >= 0 && source.Items.Any())
			{
				IMacroGroupVM macroGroupVM = source.Items.FirstOrDefault()?.Parent;
				IMacroGroupVM macroGroupVM2 = (base.ItemsSource as IEnumerable<IMacroGroupVM>)?.ElementAtOrDefault(_hoverIndex);
				if (macroGroupVM != macroGroupVM2)
				{
					macroGroupVM?.RemoveMacrosCommand?.Invoke(source.Items);
					macroGroupVM2?.AddMacrosCommand?.Invoke(source.Items);
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
			base.SelectedListItem = (base.ItemsSource as IEnumerable<IMacroGroupVM>)?.ElementAtOrDefault(_hoverIndex);
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

	protected override void SetSelection(IEnumerable<IMacroGroupVM> selectedItems, bool leftClick)
	{
		if (leftClick)
		{
			CloseCollectionPopupCommand?.Invoke();
		}
		base.SetSelection(selectedItems, leftClick);
	}
}
