using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Pro.UI.Controls.Windowing;
using ProPresenter.UI.ViewModels.UserAttachments;

namespace ProPresenter.UI.ViewModels.FeedbackCrash;

public interface ICrashReportingVM
{
	string Email { get; set; }

	string Name { get; set; }

	string Description { get; set; }

	string HardwareId { get; }

	bool NetworkAvailable { get; }

	IUserAttachmentCollectionVM Attachments { get; set; }

	IAsyncRelayCommand<ICloseable> SubmitCommand { get; }

	Task<bool> ResetDataAsync(bool hasCrashed);

	void Cleanup();
}
