using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.UI.Components;
using Pro.ssAPI.Devices;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Custom.Elements.Strokes;

namespace ProPresenter.UI.ViewModels.Editor;

public interface IShapeInspectorVM : INotifyPropertyChanged
{
	IVisibilityLinkVM VisibilityLinkVM { get; }

	IFillLinkVM FillLinkVM { get; }

	EditMode EditMode { get; set; }

	CustomSlide? SelectedSlide { get; set; }

	bool CanElementArrange { get; }

	string ElementName { get; set; }

	Angle<double> Rotation { get; set; }

	double Opacity { get; set; }

	double FeatherRadius { get; set; }

	double Left { get; set; }

	double Top { get; set; }

	double Width { get; set; }

	double Height { get; set; }

	bool FeatherEnabled { get; set; }

	bool IsLocked { get; set; }

	bool IsAspectRatioLocked { get; }

	bool FlipHorizontally { get; set; }

	bool FlipVertically { get; set; }

	bool IsLockEnabled { get; }

	bool IsFillVisible { get; }

	bool IsStrokeVisible { get; set; }

	bool IsShadowVisible { get; set; }

	bool IsFillOptionVisible { get; }

	bool ShowFullInspector { get; }

	bool ShowStroke { get; }

	bool ShowShadow { get; }

	bool ShowFeatheringOption { get; }

	bool ShowVisibility { get; }

	FillType FillType { get; set; }

	IEnumerable<FillType> AvailableFillTypes { get; }

	StrokeStyle StrokeStyle { get; set; }

	Color StrokeColor { get; set; }

	double StrokeThickness { get; set; }

	ShadowType ShadowType { get; set; }

	VideoInputDeviceCollection AvailableVideoInputs { get; }

	AudioInputDeviceCollection AvailableAudioInputs { get; }

	ILiveVideoInputCollection AvailableInputs { get; }

	IEnumerable<MediaCue> SelectedMedia { get; }

	dynamic Fill { get; }

	dynamic Shadow { get; }

	bool ShowBackgroundEffects { get; }

	ICommand<ZOrderDirection> ChangeZOrderCommand { get; }

	ICommand<AlignmentType> AlignCommand { get; }

	ICommand<DistributionType> DistributeCommand { get; }

	ICommand SwapGradientColorsCommand { get; }

	ICommand CreateMediaFillCommand { get; }

	ICommand ShowInFileExplorerCommand { get; }

	ICommand OpenSetupCommand { get; }

	ICommand HideCommand { get; }

	ICommand UnlockAllCommand { get; }

	ICommand<SlideElementBase> UnlockCommand { get; }

	ICommand<FillType> UpdateFillCommand { get; }

	event Action<LiveVideoInput>? OpenLiveVideoSetup;
}
