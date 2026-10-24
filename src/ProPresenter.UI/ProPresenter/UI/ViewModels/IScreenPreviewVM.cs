using System.Windows.Input;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.DO.Actions;
using ProPresenter.DO.ClearGroups;
using ProPresenter.UI.ViewModels.Preview;

namespace ProPresenter.UI.ViewModels;

public interface IScreenPreviewVM
{
	bool IsOutputOn { get; }

	bool IsClearAllAvailable { get; }

	bool IsMusicLayerActive { get; set; }

	bool IsMessageLayerActive { get; set; }

	bool IsPropsLayerActive { get; set; }

	bool IsAnnouncementLayerActive { get; }

	bool IsSlideLayerActive { get; set; }

	bool IsBackgroundLayerActive { get; set; }

	bool IsLiveVideoLayerActive { get; set; }

	bool AudienceEnable { get; }

	bool StageEnable { get; }

	IOutputScreenVM? SelectedPreviewScreen { get; }

	MediaAction? Logo { get; }

	ClearGroup[] ClearGroups { get; }

	ClearType[] ActiveLayers { get; }

	ICommand<CreateRenderViewParameters> LoadPreviewCommand { get; }

	ICommand<DestroyRenderViewParameters> UnloadPreviewCommand { get; }

	ICommand ToggleOutputCommand { get; }

	ICommand TriggerLogoCommand { get; }

	ICaptureVM CaptureVM { get; }

	IOutputPreviewVM PreviewVM { get; }

	ICommand<IOutputScreenVM> SetScreenIDCommand { get; }
}
