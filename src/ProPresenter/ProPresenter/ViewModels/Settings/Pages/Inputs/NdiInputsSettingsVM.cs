using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.HTTP;
using Pro.Common.Utility;
using Pro.Localization.Services;
using Pro.UI.Components;
using Pro.UI.Themes;
using ProPresenter.Controller;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Pages.Inputs;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages.Inputs;

public class NdiInputsSettingsVM : ChildPageSettingsVMBase, INdiInputsSettingsVM, IChildPageSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private readonly IAdvanced _advanced;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	private readonly IDebouncer<IAdvanced> _ndiConfigChangedDebouncer;

	private readonly ILocalization _localization;

	private readonly INdiInputsSettingsDialogService _ndiInputsSettingsDialogService;

	public override string Name { get; }

	public override IEnumerable<ISettingsSearchPageField> Fields { get; }

	public override ISettingsSearchPageField PageField { get; }

	public bool ShowSources
	{
		get
		{
			return _advanced.NDIShowLocalSources;
		}
		set
		{
			_advanced.NDIShowLocalSources = value;
		}
	}

	public string ReceiveGroups
	{
		get
		{
			return _advanced.NDIInputGroups;
		}
		set
		{
			_advanced.NDIInputGroups = value;
		}
	}

	public string AdditionalSearchIPs
	{
		get
		{
			return _advanced.NDIExtraIPs;
		}
		set
		{
			bool ipError;
			string nDIExtraIPs = CheckIpAddresses(value, out ipError);
			if (!ipError)
			{
				_advanced.NDIExtraIPs = nDIExtraIPs;
			}
		}
	}

	public ICommand UpdateNdiFinderSettingsCommand => new RelayCommand(OnUpdateNdiFinderSettings);

	public ICommand HelpCommand => new RelayCommand(delegate
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpTroubleShootingNdi));
	});

	public override ImageSource? Icon => Icons.GetIcon(Icons.SettingsNdi);

	public NdiInputsSettingsVM(IAdvanced advanced, ILocalization localization, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ISettingsSearchFactory settingsSearchFactory, ICoreManager coreManager, IDebouncerFactory debouncerFactory, INdiInputsSettingsDialogService ndiInputsSettingsDialogService)
	{
		NdiInputsSettingsVM ndiInputsSettingsVM = this;
		_advanced = advanced;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		_localization = localization;
		_ndiInputsSettingsDialogService = ndiInputsSettingsDialogService;
		Name = _localization.Get("SETTINGS_INPUTS_NDI_INPUT_PAGE_title");
		LinkProperties("NDIShowLocalSources", "ShowSources");
		LinkProperties("NDIInputGroups", "ReceiveGroups");
		LinkProperties("NDIExtraIPs", "AdditionalSearchIPs");
		LinkAction(new string[3] { "NDIShowLocalSources", "NDIInputGroups", "NDIExtraIPs" }, OnUpdateNdiFinderSettings);
		_advanced.PropertyChanged += base.RaiseLinkedValues;
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		Fields = settingsSearchFactory.GetFields("SETTINGS_INPUTS_NDI_INPUT_PAGE_title", this, isComponent: false, PageField).Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_NDI_INPUT_SHOW_SOURCES_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_NDI_INPUT_RECIEVE_GROUPS_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_INPUTS_NDI_INPUT_ADDITIONAL_SEARCH_IPS_title", this, isComponent: true));
		_ndiConfigChangedDebouncer = debouncerFactory.Create<IAdvanced>(delegate
		{
			coreManager.UpdateNDIFinderSettings(ndiInputsSettingsVM.ShowSources, ndiInputsSettingsVM.ReceiveGroups, ndiInputsSettingsVM.AdditionalSearchIPs);
		}, 1000.0);
		OnUpdateNdiFinderSettings();
	}

	[GeneratedRegex("\\s+")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex WhitespaceRegex()
	{
		return _003CRegexGenerator_g_003EF62454C50F463B9CE37DD14A1C5571B2BF6929D8FCBB1DC4C52D5DAF781FD22BB__WhitespaceRegex_0.Instance;
	}

	private void OnUpdateNdiFinderSettings()
	{
		_ndiConfigChangedDebouncer.Invoke(_advanced);
	}

	private string CheckIpAddresses(string value, out bool ipError)
	{
		ipError = false;
		if (string.IsNullOrEmpty(value.Trim()))
		{
			return string.Empty;
		}
		string[] array = WhitespaceRegex().Replace(value, "").Split(',');
		List<string> list = new List<string>();
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (!NetworkHelper.ValidateIpAddress(text.Trim()))
			{
				list.Add(text);
			}
		}
		if (list.Count == 0)
		{
			if (array.Length != 1)
			{
				return string.Join(",", array);
			}
			return array[0];
		}
		ipError = true;
		if (list.Count == 1)
		{
			_ndiInputsSettingsDialogService.ShowInvalidIpError(list[0]);
		}
		else
		{
			string messageContent = JoinWithCommaAnd(list);
			_ndiInputsSettingsDialogService.ShowInvalidMultiIpError(messageContent);
		}
		return string.Empty;
	}

	private static string JoinWithCommaAnd(List<string> errors)
	{
		if (errors == null || errors.Count == 0)
		{
			return string.Empty;
		}
		switch (errors.Count)
		{
		case 1:
			return errors[0];
		case 2:
			return errors[0] + " and " + errors[1];
		default:
			return string.Join(", ", errors.GetRange(0, errors.Count - 1)) + " and " + errors[errors.Count - 1];
		}
	}
}
