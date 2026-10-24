using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Pro.UI.Controls.Windowing;
using ProPresenter.UI.Feedback;
using ProPresenter.UI.ViewModels.UserAttachments;

namespace ProPresenter.UI.ViewModels.FeedbackCrash;

public interface IFeedbackVM
{
	string Email { get; set; }

	string Name { get; set; }

	string Description { get; set; }

	FeedbackRequestType RequestType { get; set; }

	string HardwareId { get; }

	bool NetworkAvailable { get; }

	bool IsInternal { get; }

	IUserAttachmentCollectionVM Attachments { get; set; }

	IAsyncRelayCommand<ICloseable> SubmitCommand { get; }

	void Cleanup();

	Task<bool> ResetDataAsync(bool isReportingIssue);

	Task<bool> ResetDataAsync(bool isReportingIssue, bool isInternal);
}
