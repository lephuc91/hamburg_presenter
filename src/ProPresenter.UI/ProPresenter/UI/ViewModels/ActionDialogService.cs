using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ProPresenter.Controller.Outputs.Communication;
using ProPresenter.DO;
using ProPresenter.DO.Communication;
using ProPresenter.DO.LiveVideo;

namespace ProPresenter.UI.ViewModels;

public class ActionDialogService : IActionDialogService, ICommunicationActionDialogService, ILiveVideoDialogService
{
	private readonly Action<LiveVideoInput> _openSetup;

	private readonly Action<ActionDialogParameter> _showdialog;

	private readonly Action<FrameworkElement> _updatePlacementTarget;

	public IEnumerable<IDevice> Devices { get; }

	public IEnumerable<LiveVideoInput> AvailableInputs
	{
		get
		{
			IEnumerable<LiveVideoInput> availableLiveVideoInputs = OutputVault.AvailableLiveVideoInputs;
			return availableLiveVideoInputs ?? Enumerable.Empty<LiveVideoInput>();
		}
	}

	public ActionDialogService(DeviceCollection devices, Action<LiveVideoInput> openSetup, Action<ActionDialogParameter> showdialog, Action<FrameworkElement> updatePlacementTarget)
	{
		Devices = devices;
		_openSetup = openSetup;
		_showdialog = showdialog;
		_updatePlacementTarget = updatePlacementTarget;
	}

	public void OpenSetup(LiveVideoInput input)
	{
		_openSetup?.Invoke(input);
	}

	public void ShowEditActionDialog(ActionDialogParameter parameter)
	{
		_showdialog?.Invoke(parameter);
	}

	public void UpdateDialogPlacementTarget(FrameworkElement placement)
	{
		_updatePlacementTarget?.Invoke(placement);
	}
}
