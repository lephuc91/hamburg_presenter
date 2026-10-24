using System.Threading.Tasks;
using System.Windows;

namespace ProPresenter.ViewModels.FeedbackCrash;

public interface ICrashReportUserFeedbackDialogProvider
{
	Task ShowCrashReport(Window parentWindow, bool hasCrashed);

	Task ShowUserFeedback(Window parentWindow, bool isReportingIssue);

	Task ShowInternalFeedback(Window parentWindow);
}
