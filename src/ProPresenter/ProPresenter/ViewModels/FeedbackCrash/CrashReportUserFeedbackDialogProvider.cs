using System;
using System.Threading.Tasks;
using System.Windows;
using Pro.Common.Logging;
using Pro.Localization.Services;
using ProPresenter.UI.Feedback;
using ProPresenter.UI.ViewModels.FeedbackCrash;

namespace ProPresenter.ViewModels.FeedbackCrash;

public class CrashReportUserFeedbackDialogProvider : ICrashReportUserFeedbackDialogProvider
{
	private readonly ICrashReportingVM _crashReportingVM;

	private readonly IFeedbackVM _feedbackVM;

	private readonly ILogger _logger;

	private readonly ILocalization _localization;

	public CrashReportUserFeedbackDialogProvider(ICrashReportingVM crashReportingVM, IFeedbackVM feedbackVM, ILogger logger, ILocalization localization)
	{
		_crashReportingVM = crashReportingVM;
		_feedbackVM = feedbackVM;
		_logger = logger;
		_localization = localization;
	}

	public async Task ShowCrashReport(Window parentWindow, bool hasCrashed)
	{
		try
		{
			if (await _crashReportingVM.ResetDataAsync(hasCrashed))
			{
				CrashReportingDialog crashReportingDialog = new CrashReportingDialog
				{
					DataContext = _crashReportingVM
				};
				if (parentWindow?.IsLoaded ?? false)
				{
					crashReportingDialog.Owner = parentWindow;
					crashReportingDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
				}
				crashReportingDialog.ShowDialog();
				_crashReportingVM.Cleanup();
			}
		}
		catch (Exception ex)
		{
			_logger.Error(ex);
		}
	}

	public async Task ShowUserFeedback(Window parentWindow, bool isReportingIssue)
	{
		try
		{
			if (await _feedbackVM.ResetDataAsync(isReportingIssue))
			{
				FeedbackDialog feedbackDialog = new FeedbackDialog
				{
					DataContext = _feedbackVM
				};
				if (parentWindow?.IsLoaded ?? false)
				{
					feedbackDialog.Owner = parentWindow;
					feedbackDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
				}
				feedbackDialog.ShowDialog();
				_feedbackVM.Cleanup();
			}
		}
		catch (Exception ex)
		{
			_logger.Error(ex);
		}
	}

	public async Task ShowInternalFeedback(Window parentWindow)
	{
		try
		{
			if (await _feedbackVM.ResetDataAsync(isReportingIssue: true, isInternal: true))
			{
				FeedbackDialog feedbackDialog = new FeedbackDialog
				{
					DataContext = _feedbackVM,
					Title = _localization.Get("USER_FEEDBACK_INTERNAL_WINDOW_title")
				};
				if (parentWindow?.IsLoaded ?? false)
				{
					feedbackDialog.Owner = parentWindow;
					feedbackDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
				}
				feedbackDialog.ShowDialog();
				_feedbackVM.Cleanup();
			}
		}
		catch (Exception ex)
		{
			_logger.Error(ex);
		}
	}
}
