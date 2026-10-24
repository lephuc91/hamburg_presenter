using System.ComponentModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.UserAttachments;

public interface IUserAttachmentsVM : INotifyPropertyChanged
{
	bool IsValid { get; }

	IUserAttachmentCollectionVM Attachments { get; }

	IAsyncRelayCommand AttachSystemDiagnosticsCommand { get; }

	IAsyncRelayCommand AttachSystemInformationCommand { get; }

	IAsyncRelayCommand AttachCrashReportCommand { get; }

	IAsyncRelayCommand AttachProgramFileLogCommand { get; }

	IAsyncRelayCommand AttachWorkspaceCommand { get; }

	IAsyncRelayCommand AttachCloudDocumentsCommand { get; }

	IAsyncRelayCommand AttachChooseFileCommand { get; }

	Task PrepareAttachmentUploads();

	void CleanupWorkspaceAttachment();
}
