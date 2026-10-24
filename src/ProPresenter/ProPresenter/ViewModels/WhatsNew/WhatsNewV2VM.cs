using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Components;
using Pro.Common.FeatureFlag;
using Pro.Common.HTTP;
using Pro.Common.Versioning;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Web;
using ProPresenter.DO.WhatsNew;
using ProPresenter.UI.ViewModels.WhatsNew;
using ProPresenter.WhatsNew;

namespace ProPresenter.ViewModels.WhatsNew;

public class WhatsNewV2VM : LinkedObservableObjectBase, IWhatsNewV2VM
{
	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	private readonly IApp _app;

	private readonly IFlagService _flagService;

	private readonly IVersionInfoProvider _versionInfoProvider;

	[ObservableProperty]
	private Version? _version;

	[ObservableProperty]
	private Color _accentColor;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? gotoLinkCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<ICloseable>? getStartedCommand;

	public IEnumerable<IFeatureItemVM> Features { get; set; }

	public bool ShouldAutoShowWhatsNew
	{
		get
		{
			if (Version != null && Version > _app.LastVersion)
			{
				if (_versionInfoProvider.AppVersion.Major == 22)
				{
					return !_flagService.IsFlagEnabled(Flag.Cloud);
				}
				return true;
			}
			return false;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Version? Version
	{
		get
		{
			return _version;
		}
		set
		{
			if (!EqualityComparer<System.Version>.Default.Equals(_version, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Version);
				_version = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Version);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Color AccentColor
	{
		get
		{
			return _accentColor;
		}
		set
		{
			if (!EqualityComparer<Color>.Default.Equals(_accentColor, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AccentColor);
				_accentColor = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AccentColor);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand GotoLinkCommand => gotoLinkCommand ?? (gotoLinkCommand = new RelayCommand(GotoLink));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<ICloseable> GetStartedCommand => getStartedCommand ?? (getStartedCommand = new RelayCommand<ICloseable>(GetStarted));

	public WhatsNewV2VM(IWhatsNewContentProviderFromJson whatsNewContentProviderFromJson, IFeatureFactory featureFactory, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, IApp app, IFlagService flagService, IVersionInfoProvider versionInfoProvider)
	{
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		_app = app;
		_flagService = flagService;
		_versionInfoProvider = versionInfoProvider;
		List<IFeatureItemVM> list = new List<IFeatureItemVM>();
		foreach (IFeatureItem feature in whatsNewContentProviderFromJson.GetFeatures())
		{
			IFeatureItemVM item = featureFactory.Create(feature);
			list.Add(item);
		}
		Features = list;
		AccentColor = whatsNewContentProviderFromJson.AccentColor;
		Version = whatsNewContentProviderFromJson.Version;
	}

	[RelayCommand]
	private void GotoLink()
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.ReleaseNotes));
	}

	[RelayCommand]
	private void GetStarted(ICloseable window)
	{
		window.Close();
	}
}
