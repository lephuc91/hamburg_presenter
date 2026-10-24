using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Pro.UI.Components;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.Import;
using ProPresenter.DO.Media;
using ProPresenter.DO.PCO;
using ProPresenter.UI.PresentationView;

namespace ProPresenter.UI.ViewModels;

public interface IPCOLiveVM : INotifyPropertyChanged
{
	IPCOConsumer PCOConsumer { get; }

	PCOOrganization PCOOrganization { get; }

	PCOObject? ActivePlan { get; set; }

	PCOObject? SelectedPlan { get; set; }

	ICommand LogoutCommand { get; }

	ICommand<LinkCommandParameters> LinkNewPresentationCommand { get; }

	ICommand<LinkCommandParameters> LinkImportCommand { get; }

	ICommand<LinkCommandParameters> LinkDocumentCommand { get; }

	ICommand<LinkCommandParameters> LinkMediaCommand { get; }

	ICommand<LinkCommandParameters> LinkDropFilesCommand { get; }

	ICommand<LinkCommandParameters> LinkSongSelectItemCommand { get; }

	ICommand<ProPresenterCue> UnlinkItemCommand { get; }

	ICommand<ProPresenterCue> OpenAttachmentsCommand { get; }

	ICommand<ProPresenterCue> OpenSearchCommand { get; }

	ICommand<PCOPlan> ImportPCOPlanCommand { get; }

	ICommand ShowPlanBrowserCommand { get; }

	Task EnsureAuthorized(Action<bool> authorizedCallback);

	void LinkImportedFile(PCOCueBase pcoCue, string filename, IImportProcess process, PlaceholderLinkSource linkSource, FileMediaBase? existingMedia);

	void ToggleAuthorization();
}
