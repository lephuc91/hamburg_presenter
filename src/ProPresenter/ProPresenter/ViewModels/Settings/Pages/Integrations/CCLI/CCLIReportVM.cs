using System;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Utility;
using Pro.Localization;
using ProPresenter.DO.Settings.GeneralSettings;
using ProPresenter.DO.SongSelect;
using ProPresenter.UI.ViewModels.Settings.Pages.Integrations.CCLI;

namespace ProPresenter.ViewModels.Settings.Pages.Integrations.CCLI;

public class CCLIReportVM : LinkedNotifyPropertyChangedBase, ICCLIReportVM, INotifyPropertyChanged
{
	private readonly CCLIReport _report;

	private readonly ISongSelectConsumer _songSelectConsumer;

	private readonly IInternetAccess _internetAccess;

	public DateTime DateUsed => _report.DateUsed;

	public string CCLINumber => _report.CCLINumber;

	public string Title => _report.Title;

	public string Author => _report.Author;

	public string Publisher => _report.Publisher;

	public string CopyRight => _report.Copyright;

	public ReportState ReportState => _report.ReportState;

	public bool CanAutoReport
	{
		get
		{
			if (_songSelectConsumer.IsAuthorized)
			{
				return _internetAccess.IsInternetAvailable();
			}
			return false;
		}
	}

	public string ReportStateToolTip => GetToolTip();

	public CCLIReportVM(CCLIReport report, ISongSelectConsumer songSelectConsumer, IInternetAccess internetAccess)
	{
		_report = report;
		_songSelectConsumer = songSelectConsumer;
		_internetAccess = internetAccess;
		LinkProperties("ReportState", new string[2] { "ReportState", "ReportStateToolTip" });
		LinkProperties("IsAuthorized", "CanAutoReport");
		_report.PropertyChanged += base.RaiseLinkedValues;
		_songSelectConsumer.PropertyChanged += base.RaiseLinkedValues;
	}

	private string GetToolTip()
	{
		string result = ReportState switch
		{
			ReportState.Pending => LocalizedStrings.Get("SETTINGS_GENERAL_COPYRIGHT_REPORTING_PENDING_tooltip"), 
			ReportState.Reported => LocalizedStrings.Get("SETTINGS_GENERAL_COPYRIGHT_REPORTING_AUTO_REPORTED_tooltip"), 
			_ => LocalizedStrings.Get("SETTINGS_GENERAL_COPYRIGHT_REPORTING_NOT_AUTO_REPORTED_tooltip"), 
		};
		if (ReportState == ReportState.Pending)
		{
			if (!CanAutoReport)
			{
				result = LocalizedStrings.Get("SETTINGS_GENERAL_COPYRIGHT_REPORTING_LOG_IN_TO_AUTO_REPORT_tooltip");
			}
			IInternetAccess internetAccess = _internetAccess;
			if (internetAccess != null && !internetAccess.IsInternetAvailable())
			{
				result = LocalizedStrings.Get("SETTINGS_GENERAL_COPYRIGHT_REPORTING_NO_CONNECTION_TO_AUTO_REPORT_tooltip");
			}
		}
		return result;
	}
}
