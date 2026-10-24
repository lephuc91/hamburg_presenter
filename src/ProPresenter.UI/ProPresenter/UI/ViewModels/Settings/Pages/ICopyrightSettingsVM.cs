using System;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Components.Reversibility;
using Pro.DO.Token;
using Pro.UI.Components;
using ProPresenter.DO.CCLI;
using ProPresenter.DO.Presentation;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings.Pages.Integrations.CCLI;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.UI.ViewModels.Settings.Pages;

public interface ICopyrightSettingsVM : IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	bool EnableCopyrightDisplay { get; set; }

	CopyrightDisplayType CopyrightDisplayType { get; set; }

	string CopyrightLicenseNumber { get; set; }

	string CopyrightLayoutText { get; set; }

	TokenCollection<CCLIToken> CopyrightTokens { get; }

	TokenCollection<CCLIToken> AvailableCopyrightTokens { get; }

	bool EditCopyrightLayoutPopupOpen { get; set; }

	ICommand EditCopyrightTemplateCommand { get; }

	ICommand<bool> DocumentChangeStartedCommand { get; }

	ICommand<bool> DocumentChangeEndedCommand { get; }

	ICommand OpenCopyrightLayoutCommand { get; }

	ICommand GotFocusCommand { get; }

	ICommand HelpCommand { get; }

	ICommand CloseCopyrightLayoutCommand { get; }

	ICCLIReportCollectionVM ReportsVM { get; }

	event Action<ICCLIPresentation>? EditCopyrightTemplate;

	event Action<UndoStack>? StackChanged;
}
