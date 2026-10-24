using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(AlphaBlendMode), typeof(Pro.SerializationInterop.RVProtoData.Screen.Types.AlphaSettings.Types.Mode), SourceToDestinationMethodName = "ToProto", DestinationDefaultValue = "Unknown", UnmatchedSourceNames = new string[] { "None" }, UnmatchedDestinationNames = new string[] { "Disabled" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(AlphaBlendMode), typeof(IScreen.Types.IAlphaSettings.Types.Mode), SourceToDestinationMethodName = "ToEntity", DestinationDefaultValue = "Unknown", UnmatchedSourceNames = new string[] { "None" }, UnmatchedDestinationNames = new string[] { "Disabled" })]
public static class AlphaBlendModeExtenstions
{
	public static bool ToEnabled(this AlphaBlendMode alphaBlendMode)
	{
		if (alphaBlendMode == AlphaBlendMode.None)
		{
			return false;
		}
		return true;
	}

	public static AlphaBlendMode ToAlphaBlendMode(this Pro.SerializationInterop.RVProtoData.Screen screenProto)
	{
		switch (screenProto.AlphaSettings?.Mode)
		{
		case Pro.SerializationInterop.RVProtoData.Screen.Types.AlphaSettings.Types.Mode.Disabled:
			return AlphaBlendMode.None;
		case Pro.SerializationInterop.RVProtoData.Screen.Types.AlphaSettings.Types.Mode.Premultiplied:
			return AlphaBlendMode.Premultiplied;
		case Pro.SerializationInterop.RVProtoData.Screen.Types.AlphaSettings.Types.Mode.Straight:
			return AlphaBlendMode.Straight;
		default:
			if (screenProto.OutputDisplay?.Blackmagic?.Enabled != true)
			{
				return AlphaBlendMode.None;
			}
			return AlphaBlendMode.Premultiplied;
		}
	}

	public static AlphaBlendMode ToAlphaBlendMode(this IScreen screen)
	{
		switch (screen.AlphaSettings.Value.Mode.Value)
		{
		case IScreen.Types.IAlphaSettings.Types.Mode.Disabled:
			return AlphaBlendMode.None;
		case IScreen.Types.IAlphaSettings.Types.Mode.Premultiplied:
			return AlphaBlendMode.Premultiplied;
		case IScreen.Types.IAlphaSettings.Types.Mode.Straight:
			return AlphaBlendMode.Straight;
		default:
			if (!(screen.OutputDisplay.Value?.HardwareOptions.Value is IOutputDisplay.Types.IHardwareOptions.IBlackmagic blackmagic) || !blackmagic.Value.Enabled.Value)
			{
				return AlphaBlendMode.None;
			}
			return AlphaBlendMode.Premultiplied;
		}
	}

	public static Pro.SerializationInterop.RVProtoData.Screen.Types.AlphaSettings.Types.Mode ToProto(this AlphaBlendMode source)
	{
		return source switch
		{
			AlphaBlendMode.None => Pro.SerializationInterop.RVProtoData.Screen.Types.AlphaSettings.Types.Mode.Disabled, 
			AlphaBlendMode.Premultiplied => Pro.SerializationInterop.RVProtoData.Screen.Types.AlphaSettings.Types.Mode.Premultiplied, 
			AlphaBlendMode.Straight => Pro.SerializationInterop.RVProtoData.Screen.Types.AlphaSettings.Types.Mode.Straight, 
			_ => Pro.SerializationInterop.RVProtoData.Screen.Types.AlphaSettings.Types.Mode.Unknown, 
		};
	}

	public static IScreen.Types.IAlphaSettings.Types.Mode ToEntity(this AlphaBlendMode source)
	{
		return source switch
		{
			AlphaBlendMode.None => IScreen.Types.IAlphaSettings.Types.Mode.Disabled, 
			AlphaBlendMode.Premultiplied => IScreen.Types.IAlphaSettings.Types.Mode.Premultiplied, 
			AlphaBlendMode.Straight => IScreen.Types.IAlphaSettings.Types.Mode.Straight, 
			_ => IScreen.Types.IAlphaSettings.Types.Mode.Unknown, 
		};
	}
}
