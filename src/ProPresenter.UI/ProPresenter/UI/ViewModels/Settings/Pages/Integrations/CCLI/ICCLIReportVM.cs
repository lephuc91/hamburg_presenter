using System;
using System.ComponentModel;
using ProPresenter.DO.Settings.GeneralSettings;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Integrations.CCLI;

public interface ICCLIReportVM : INotifyPropertyChanged
{
	DateTime DateUsed { get; }

	string CCLINumber { get; }

	string Title { get; }

	string Author { get; }

	string Publisher { get; }

	string CopyRight { get; }

	ReportState ReportState { get; }

	bool CanAutoReport { get; }

	string ReportStateToolTip { get; }
}
