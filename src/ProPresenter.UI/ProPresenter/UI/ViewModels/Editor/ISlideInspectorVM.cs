using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using Pro.DO.Label;
using Pro.UI.Components;
using ProPresenter.DO.Actions;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.UI.ViewModels.Thumbnails;

namespace ProPresenter.UI.ViewModels.Editor;

public interface ISlideInspectorVM
{
	CustomPresentation? Presentation { get; set; }

	CustomSlide? SelectedSlide { get; set; }

	IEnumerable<ActionLabel> ActionLabels { get; }

	Key Hotkey { get; set; }

	bool ItemEnabled { get; set; }

	bool GraphicMediaActionPresent { get; }

	MediaAction? GraphicMediaAction { get; }

	bool VideoInputMediaActionPresent { get; }

	MediaAction? VideoInputMediaAction { get; }

	ActionLabel? SelectedLabel { get; set; }

	IMediaOverlayVM? OverlayVM { get; }

	ICommand ChangeChordChartCommand { get; }

	ICommand RemoveChordChartCommand { get; }

	ICommand<Color> SlideColorChangedCommand { get; }

	ICommand<FileInfo> DropChordChartCommand { get; }

	ICommand ShowInFileExplorerCommand { get; }

	ICommand ShowCordChartInFileExplorerCommand { get; }

	ICommand ChooseGraphicMediaFileCommand { get; }

	ICommand OpenLiveVideoSetupCommand { get; }

	ICommand AddMediaActionCommand { get; }

	ICommand RemoveMediaActionCommand { get; }

	ICommand AddVideoInputActionCommand { get; }

	ICommand RemoveVideoInputActionCommand { get; }

	ILiveVideoInputCollection AvailableInputs { get; }

	bool IgnoreBackgroundColors { get; }

	event Action<LiveVideoInput>? OpenLiveVideoSetup;
}
