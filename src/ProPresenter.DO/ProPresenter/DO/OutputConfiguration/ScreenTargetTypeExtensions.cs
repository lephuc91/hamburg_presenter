using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ScreenTargetType), typeof(ProPresenterScreen.Types.ScreenType), SourceToDestinationMethodName = "ToProtoScreenType", DestinationToSourceMethodName = "ToScreenTargetType", ExcludeDestinationNames = new string[] { "Unknown" }, SourceDefaultValue = "Audience", DestinationDefaultValue = "Audience")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ScreenTargetType), typeof(IProPresenterScreen.Types.ScreenType), SourceToDestinationMethodName = "ToEntityScreenType", DestinationToSourceMethodName = "ToScreenTargetType", ExcludeDestinationNames = new string[] { "Unknown" }, SourceDefaultValue = "Audience", DestinationDefaultValue = "Audience")]
public static class ScreenTargetTypeExtensions
{
	public static ProPresenterScreen.Types.ScreenType ToProtoScreenType(this ScreenTargetType source)
	{
		return source switch
		{
			ScreenTargetType.Audience => ProPresenterScreen.Types.ScreenType.Audience, 
			ScreenTargetType.Stage => ProPresenterScreen.Types.ScreenType.Stage, 
			_ => ProPresenterScreen.Types.ScreenType.Audience, 
		};
	}

	public static ScreenTargetType ToScreenTargetType(this ProPresenterScreen.Types.ScreenType source)
	{
		return source switch
		{
			ProPresenterScreen.Types.ScreenType.Audience => ScreenTargetType.Audience, 
			ProPresenterScreen.Types.ScreenType.Stage => ScreenTargetType.Stage, 
			_ => ScreenTargetType.Audience, 
		};
	}

	public static IProPresenterScreen.Types.ScreenType ToEntityScreenType(this ScreenTargetType source)
	{
		return source switch
		{
			ScreenTargetType.Audience => IProPresenterScreen.Types.ScreenType.Audience, 
			ScreenTargetType.Stage => IProPresenterScreen.Types.ScreenType.Stage, 
			_ => IProPresenterScreen.Types.ScreenType.Audience, 
		};
	}

	public static ScreenTargetType ToScreenTargetType(this IProPresenterScreen.Types.ScreenType source)
	{
		return source switch
		{
			IProPresenterScreen.Types.ScreenType.Audience => ScreenTargetType.Audience, 
			IProPresenterScreen.Types.ScreenType.Stage => ScreenTargetType.Stage, 
			_ => ScreenTargetType.Audience, 
		};
	}
}
