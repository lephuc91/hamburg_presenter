using Pro.SerializationInterop.RVProtoData.Analytics.Startup;
using ProPresenter.DO.Registration.Model;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Analytics.Events.Startup;

public static class PreferencesRenderModeExtensions
{
	public static Preferences.Types.RenderMode ToProto(this RenderModeValue renderMode)
	{
		return renderMode switch
		{
			RenderModeValue.OpenGL => Preferences.Types.RenderMode.Opengl, 
			RenderModeValue.DirectX => Preferences.Types.RenderMode.Directx, 
			_ => Preferences.Types.RenderMode.Unknown, 
		};
	}

	public static Preferences.Types.CopyrightStyle ToProto(this CopyRightStyleValue copyRightStyleValue)
	{
		return copyRightStyleValue switch
		{
			CopyRightStyleValue.CopyrightStyleFirst => Preferences.Types.CopyrightStyle.First, 
			CopyRightStyleValue.CopyrightStyleLast => Preferences.Types.CopyrightStyle.Last, 
			CopyRightStyleValue.CopyrightStyleFirstAndLast => Preferences.Types.CopyrightStyle.FirstAndLast, 
			CopyRightStyleValue.CopyrightStyleAllSlides => Preferences.Types.CopyrightStyle.AllSlides, 
			_ => Preferences.Types.CopyrightStyle.Unknown, 
		};
	}

	public static CopyRightStyleValue ToCopyRightStyleValue(this CCLIDisplayType ccliDisplayType)
	{
		return ccliDisplayType switch
		{
			CCLIDisplayType.First => CopyRightStyleValue.CopyrightStyleFirst, 
			CCLIDisplayType.Last => CopyRightStyleValue.CopyrightStyleLast, 
			CCLIDisplayType.FirstAndLast => CopyRightStyleValue.CopyrightStyleFirstAndLast, 
			CCLIDisplayType.AllSlides => CopyRightStyleValue.CopyrightStyleAllSlides, 
			_ => CopyRightStyleValue.Unknown, 
		};
	}

	public static Preferences.Types.UpdateChannel ToProto(this UpdateChannelValue updateChannel)
	{
		return updateChannel switch
		{
			UpdateChannelValue.UpdateChannelRelease => Preferences.Types.UpdateChannel.Release, 
			UpdateChannelValue.UpdateChannelBeta => Preferences.Types.UpdateChannel.Beta, 
			_ => Preferences.Types.UpdateChannel.Unknown, 
		};
	}

	public static UpdateChannelValue ToUpdateChannelValue(this UpdateChannel updateChannel)
	{
		return updateChannel switch
		{
			UpdateChannel.Beta => UpdateChannelValue.UpdateChannelBeta, 
			UpdateChannel.Production => UpdateChannelValue.UpdateChannelRelease, 
			_ => UpdateChannelValue.Unknown, 
		};
	}
}
