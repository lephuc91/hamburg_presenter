using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.TestPattern.State;

public static class LogoTypeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.LogoType ToProtoLogoType(this LogoType logoType)
	{
		return logoType switch
		{
			LogoType.None => Pro.SerializationInterop.RVProtoData.LogoType.None, 
			LogoType.Propresenter => Pro.SerializationInterop.RVProtoData.LogoType.Propresenter, 
			LogoType.User => Pro.SerializationInterop.RVProtoData.LogoType.User, 
			_ => Pro.SerializationInterop.RVProtoData.LogoType.None, 
		};
	}

	public static LogoType ToLogoType(this Pro.SerializationInterop.RVProtoData.LogoType protoLogoType)
	{
		return protoLogoType switch
		{
			Pro.SerializationInterop.RVProtoData.LogoType.None => LogoType.None, 
			Pro.SerializationInterop.RVProtoData.LogoType.Propresenter => LogoType.Propresenter, 
			Pro.SerializationInterop.RVProtoData.LogoType.User => LogoType.User, 
			_ => LogoType.None, 
		};
	}
}
