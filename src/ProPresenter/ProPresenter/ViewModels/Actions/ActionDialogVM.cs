using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using Pro.Common.Components;
using Pro.DO.Triggering;
using Pro.UI.Controls;
using ProPresenter.DO.Actions;
using ProPresenter.UI.ActionPalette.ActionDialogs;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Actions;

public class ActionDialogVM : NotifyPropertyChangedBase
{
	private IPopup? _dialog;

	private readonly IActionDialogContentProvider _provider;

	public ActionDialogVM(IActionDialogContentProvider provider)
	{
		_provider = provider;
	}

	public void ShowActionDialog(FrameworkElement? placementTarget, IAction? action, IActionRepository? actionStore, IEnumerable<IActionRepository>? otherActionStores, PlacementMode placementMode = PlacementMode.Bottom, HorizontalAlignment horizontalAlignment = HorizontalAlignment.Center, VerticalAlignment verticalAlignment = VerticalAlignment.Stretch)
	{
		ActionType? actionType = action?.ActionType;
		ActionDialogBase content = _provider.GetContent(actionType);
		if (content != null)
		{
			content.Placement = placementMode;
			if (content.DataContext is ActionDialogContentVM actionDialogContentVM)
			{
				ActionDialogContext context = new ActionDialogContext(actionStore, action, otherActionStores);
				actionDialogContentVM.SetContext(context);
			}
			TeardownDialog();
			SetupDialog(content, placementMode, horizontalAlignment, verticalAlignment, placementTarget);
		}
	}

	public void UpdatePlacementTarget(FrameworkElement? placementTarget)
	{
		if (_dialog != null)
		{
			_dialog.PlacementTarget = placementTarget;
			_dialog.IsOpen = true;
		}
	}

	private void Dialog_Closed(object? sender, EventArgs e)
	{
		TeardownDialog();
	}

	private void TeardownDialog()
	{
		if (_dialog != null)
		{
			_dialog.Closed -= Dialog_Closed;
			if (_dialog.Child is ActionDialogBase { DataContext: ActionDialogContentVM dataContext })
			{
				dataContext.OnDone();
			}
			_dialog.Child = null;
			_dialog = null;
		}
	}

	private void SetupDialog(ActionDialogBase content, PlacementMode placementMode, HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment, FrameworkElement? placementTarget)
	{
		_dialog = _provider.CreatePopup(content);
		_dialog.Closed += Dialog_Closed;
		_dialog.Placement = placementMode;
		_dialog.HorizontalAlignment = horizontalAlignment;
		_dialog.VerticalAlignment = verticalAlignment;
		_dialog.PlacementTarget = placementTarget;
		if (placementTarget != null)
		{
			_dialog.IsOpen = true;
		}
	}
}
