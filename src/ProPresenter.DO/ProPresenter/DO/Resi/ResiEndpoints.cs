using System;
using Flurl;

namespace ProPresenter.DO.Resi;

public class ResiEndpoints : IResiEndpoints
{
	public const string LoginEndpoint = "/pro/jigsaw/login";

	public const string LogoutEndpoint = "/pro/jigsaw/logout";

	public const string DownloadPluginEndpoint = "/pro/jigsaw/download_plugin";

	public const string HomepageEndpoint = "/pro/jigsaw/homepage";

	public const string MoreInfoEndpoint = "/pro/jigsaw/more_info";

	public const string SupportEndpoint = "/pro/jigsaw/support";

	public const string ManageAccountEndpoint = "/pro/jigsaw/manage_account";

	private readonly string? _moreInfo;

	private readonly string? _support;

	private readonly string? _homePage;

	private readonly string? _manageAccount;

	private readonly string? _login;

	private readonly string? _logout;

	private readonly string? _downloadPlugin;

	private readonly IResiCustomEndpointsStore _store;

	public bool IsCustom { get; }

	public string TargetRedirectHost { get; }

	public string MoreInfo
	{
		get
		{
			if (string.IsNullOrEmpty(_moreInfo))
			{
				return TargetRedirectHost + "/pro/jigsaw/more_info";
			}
			return _moreInfo;
		}
	}

	public string Support
	{
		get
		{
			if (string.IsNullOrEmpty(_support))
			{
				return TargetRedirectHost + "/pro/jigsaw/support";
			}
			return _support;
		}
	}

	public string HomePage
	{
		get
		{
			if (string.IsNullOrEmpty(_homePage))
			{
				return TargetRedirectHost + "/pro/jigsaw/homepage";
			}
			return _homePage;
		}
	}

	public string ManageAccount
	{
		get
		{
			if (string.IsNullOrEmpty(_manageAccount))
			{
				return TargetRedirectHost + "/pro/jigsaw/manage_account";
			}
			return _manageAccount;
		}
	}

	public Uri Login
	{
		get
		{
			if (!Uri.TryCreate(_login, UriKind.Absolute, out Uri result))
			{
				return new Uri(TargetRedirectHost).AppendPathSegment("/pro/jigsaw/login").ToUri();
			}
			return result;
		}
	}

	public Uri Logout
	{
		get
		{
			if (!Uri.TryCreate(_logout, UriKind.Absolute, out Uri result))
			{
				return new Uri(TargetRedirectHost).AppendPathSegment("/pro/jigsaw/logout").ToUri();
			}
			return result;
		}
	}

	public Uri DownloadPlugin
	{
		get
		{
			if (!Uri.TryCreate(_downloadPlugin, UriKind.Absolute, out Uri result))
			{
				return new Uri(TargetRedirectHost).AppendPathSegment("/pro/jigsaw/download_plugin").ToUri();
			}
			return result;
		}
	}

	public ResiEndpoints(IResiCustomEndpointsStore store, string targetDirectHost)
	{
		_store = store;
		_moreInfo = _store.MoreInfo;
		_support = _store.Support;
		_homePage = _store.HomePage;
		_manageAccount = _store.ManageAccount;
		_login = _store.Login;
		_logout = _store.Logout;
		_downloadPlugin = _store.DownloadPlugin;
		IsCustom = !string.IsNullOrEmpty(_moreInfo) || !string.IsNullOrEmpty(_support) || !string.IsNullOrEmpty(_homePage) || !string.IsNullOrEmpty(_manageAccount) || !string.IsNullOrEmpty(_login) || !string.IsNullOrEmpty(_logout) || !string.IsNullOrEmpty(_downloadPlugin);
		TargetRedirectHost = targetDirectHost;
	}
}
