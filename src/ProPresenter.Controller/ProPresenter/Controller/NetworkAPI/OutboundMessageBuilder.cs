using Pro.Common.Versioning;
using Pro.DO.Application;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.NetworkLink;

namespace ProPresenter.Controller.NetworkAPI;

public class OutboundMessageBuilder
{
	private readonly ProApiOut _proAPIOut = new ProApiOut();

	public ProApiOut Build()
	{
		return _proAPIOut;
	}

	public OutboundMessageBuilder Handler()
	{
		ProApiOut proAPIOut = _proAPIOut;
		if (proAPIOut.HandlerOut == null)
		{
			ProLink.Types.HandlerOut handlerOut2 = (proAPIOut.HandlerOut = new ProLink.Types.HandlerOut());
		}
		return this;
	}

	public OutboundMessageBuilder GroupName(string? name)
	{
		_proAPIOut.HandlerOut.GroupName = new ProLink.Types.HandlerOut.Types.GroupName
		{
			Name = (name ?? string.Empty)
		};
		return this;
	}

	public OutboundMessageBuilder GroupJoin(bool didAccept)
	{
		_proAPIOut.HandlerOut.GroupJoinConfirmation = new ProLink.Types.HandlerOut.Types.GroupJoinConfirmation
		{
			Accept = didAccept
		};
		return this;
	}

	public OutboundMessageBuilder GroupDefinition(ProPresenter.DO.NetworkLink.Group group)
	{
		_proAPIOut.HandlerOut.GroupDefinition = group.Serialize();
		return this;
	}

	public OutboundMessageBuilder GroupJoinPassword(string password)
	{
		_proAPIOut.HandlerOut.GroupJoinPassword = new ProLink.Types.HandlerOut.Types.GroupJoinPassword
		{
			Password = (password ?? string.Empty)
		};
		return this;
	}

	public OutboundMessageBuilder ProPresenterInfo()
	{
		return ProPresenterInfo(PlatformType.Win32, $"{VersionInfo.OSVersion.Major}.{VersionInfo.OSVersion.Minor}.{VersionInfo.OSVersion.Build}", LocalizedStrings.Get("MAIN_MENU_APPLICATION_title") + " " + VersionInfo.ShortDisplayAppVersion);
	}

	public OutboundMessageBuilder ProPresenterInfo(PlatformType platform, string osVersion, string hostDescription)
	{
		_proAPIOut.HandlerOut.PropresenterInfo = new ProLink.Types.HandlerOut.Types.ProPresenterInfo
		{
			Platform = ApplicationData.GetProtoPlatformType(platform),
			OsVersion = osVersion,
			HostDescription = hostDescription
		};
		return this;
	}
}
