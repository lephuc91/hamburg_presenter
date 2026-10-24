using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.PCO;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(PCOLiveTheme), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.Theme), SourceToDestinationMethodName = "ToProtoPCOLiveTheme", DestinationDefaultValue = "PcoliveThemeLight", DestinationToSourceMethodName = "ToPCOLiveTheme", SourceDefaultValue = "Light", UnmatchedSourceNames = new string[] { "Light", "Dark" }, UnmatchedDestinationNames = new string[] { "PcoliveThemeLight", "PcoliveThemeDark" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(PCOLiveTheme), typeof(ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.Theme), SourceToDestinationMethodName = "ToEntityPCOLiveTheme", DestinationDefaultValue = "PcoliveThemeLight", DestinationToSourceMethodName = "ToPCOLiveTheme", SourceDefaultValue = "Light", UnmatchedSourceNames = new string[] { "Light", "Dark" }, UnmatchedDestinationNames = new string[] { "PcoliveThemeLight", "PcoliveThemeDark" })]
public static class PCOLiveThemeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.Theme ToProtoPCOLiveTheme(this PCOLiveTheme source)
	{
		return source switch
		{
			PCOLiveTheme.Light => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.Theme.PcoliveThemeLight, 
			PCOLiveTheme.Dark => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.Theme.PcoliveThemeDark, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.Theme.PcoliveThemeLight, 
		};
	}

	public static PCOLiveTheme ToPCOLiveTheme(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.Theme source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.Theme.PcoliveThemeLight => PCOLiveTheme.Light, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.Theme.PcoliveThemeDark => PCOLiveTheme.Dark, 
			_ => PCOLiveTheme.Light, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.Theme ToEntityPCOLiveTheme(this PCOLiveTheme source)
	{
		return source switch
		{
			PCOLiveTheme.Light => ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.Theme.PcoliveThemeLight, 
			PCOLiveTheme.Dark => ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.Theme.PcoliveThemeDark, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.Theme.PcoliveThemeLight, 
		};
	}

	public static PCOLiveTheme ToPCOLiveTheme(this ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.Theme source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.Theme.PcoliveThemeLight => PCOLiveTheme.Light, 
			ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.Theme.PcoliveThemeDark => PCOLiveTheme.Dark, 
			_ => PCOLiveTheme.Light, 
		};
	}
}
