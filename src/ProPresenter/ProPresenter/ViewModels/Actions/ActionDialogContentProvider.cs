using System;
using System.Windows;
using Pro.DO.Triggering;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.UI.ActionPalette.ActionDialogs;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.ViewModels.Actions;

public class ActionDialogContentProvider : IActionDialogContentProvider
{
	private readonly IProPresenterResourceService _resourceService;

	private readonly IOutputService _outputService;

	private readonly IPropPrompts _propPrompts;

	private readonly IActionDialogService _dialogService;

	public ActionDialogContentProvider(IProPresenterResourceService resourceService, IOutputService outputService, IPropPrompts propPrompts, IActionDialogService dialogService)
	{
		_resourceService = resourceService;
		_outputService = outputService;
		_propPrompts = propPrompts;
		_dialogService = dialogService;
	}

	public ActionDialogBase? GetContent(ActionType? actionType)
	{
		FrameworkElement frameworkElement;
		switch (actionType)
		{
		case ActionType.StageLayout:
			frameworkElement = new StageDisplayActionDialog().WithDataContext(new StageDisplayDialogVM());
			break;
		case ActionType.Timer:
			frameworkElement = new TimerActionDialog().WithDataContext(new TimerDialogVM());
			break;
		case ActionType.Communication:
			frameworkElement = new CommunicationActionDialog().WithDataContext(new CommunicationDialogVM(_dialogService.Devices));
			break;
		case ActionType.Prop:
			frameworkElement = new PropActionDialog().WithDataContext(new PropDialogVM(_propPrompts));
			break;
		case ActionType.Message:
			frameworkElement = new MessageActionDialog().WithDataContext(new MessageDialogVM());
			break;
		case ActionType.Media:
			frameworkElement = new LiveVideoActionDialog().WithDataContext(new LiveVideoDialogVM(_dialogService));
			break;
		case ActionType.AudienceLook:
			frameworkElement = new AudienceLookDialog().WithDataContext(new AudienceLookDialogVM(_outputService.OutputConfiguration.AudienceLooks));
			break;
		case ActionType.AudioInput:
			frameworkElement = new AudioInputDialog().WithDataContext(new AudioInputDialogVM());
			break;
		case ActionType.VisualPlaylist:
		case ActionType.AudioPlaylist:
			frameworkElement = new PlaylistDialog().WithDataContext(new PlaylistDialogVM(_resourceService));
			break;
		case ActionType.SlideDestination:
			frameworkElement = new SlideDestinationActionDialog().WithDataContext(new SlideDestinationDialogVM());
			break;
		case ActionType.Clear:
			return null;
		case ActionType.Macro:
			frameworkElement = new MacroActionDialog().WithDataContext(new MacroDialogVM());
			break;
		case ActionType.ClearGroup:
			frameworkElement = new ClearGroupActionDialog().WithDataContext(new ClearGroupDialogVM());
			break;
		case ActionType.Capture:
			frameworkElement = new CaptureActionDialog().WithDataContext(new CaptureActionDialogVM(_outputService.OutputConfiguration.CaptureSettings.Presets));
			break;
		default:
			throw new NotSupportedException("Action type does not have an associated dialog");
		}
		return new ActionDialog
		{
			Child = frameworkElement
		}.WithDataContext(frameworkElement.DataContext);
	}

	public IPopup CreatePopup(ActionDialogBase content)
	{
		return new AnchoredPopup
		{
			AllowsTransparency = true,
			HorizontalAlignment = HorizontalAlignment.Center,
			StaysOpen = false,
			Child = content
		};
	}
}
