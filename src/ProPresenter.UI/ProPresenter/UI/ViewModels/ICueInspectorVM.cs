using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.Controller.Outputs;
using ProPresenter.UI.CueInspector;
using ProPresenter.UI.ViewModels.CueInspector;
using ProPresenter.UI.ViewModels.Preview;
using ProPresenter.UI.ViewModels.Thumbnails;

namespace ProPresenter.UI.ViewModels;

public interface ICueInspectorVM : INotifyPropertyChanged
{
	ssAPIOutput OutputController { get; }

	IInspectedMediaCueVM? ActiveMediaCue { get; set; }

	ObservableCollection<IInspectedMediaCueVM> Items { get; }

	bool IsMediaFileValid { get; }

	int ActiveTab { get; set; }

	IInfoVM InfoVM { get; }

	IPropertiesVM PropertiesVM { get; }

	IEffectsVM EffectsVM { get; }

	IAudioVM AudioVM { get; }

	IPlaybackMarkersVM PlaybackMarkersVM { get; }

	ICIMediaControlVM CIMediaControlVM { get; }

	IMediaOverlayVM? OverlayVM { get; }

	IOutputPreviewVM PreviewVM { get; }

	ICommand<InspectorParameter> InspectCuesCommand { get; }

	ICommand<IInspectedMediaCueVM> ChangeActiveMediaCueCommand { get; }

	ICommand<CreateRenderViewParameters> LoadCIOutputCommand { get; }

	ICommand<DestroyRenderViewParameters> UnloadCIOutputCommand { get; }

	ICommand CloseCICommand { get; }

	ICommand RelinkMediaCommand { get; }
}
