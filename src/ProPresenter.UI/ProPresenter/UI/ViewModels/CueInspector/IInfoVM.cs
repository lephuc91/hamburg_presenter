using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Time;
using Pro.UI.Components;
using ProPresenter.DO.Cues;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.ViewModels.CueInspector;

public interface IInfoVM : INotifyPropertyChanged
{
	MediaCue? ActiveMediaCue { get; set; }

	MediaBase? Media { get; }

	MediaType MediaType { get; }

	string FilePath { get; }

	string Name { get; set; }

	string FileType { get; }

	TimeSlice Duration { get; }

	Vector2<int> Size { get; }

	double FPS { get; }

	bool IsHdrContent { get; }

	GammaVariant GammaVariant { get; }

	ILiveVideoInputCollection AvailableVideoInputs { get; }

	LiveVideoInput? VideoInput { get; set; }

	Color DisplayColor { get; set; }

	ICommand UpdateMediaCommand { get; }

	ICommand ShowFileCommand { get; }

	ICommand<string> RenameMediaCommand { get; }

	ICommand SetToCurrentFrameCommand { get; }

	ICommand OpenVideoInputSetupCommand { get; }

	event Action<LiveVideoInput>? OpenVideoInputSetup;
}
