using System;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;

namespace ProPresenter.DO.Analytics;

public static class ProtoScreenConfigEventExtensions
{
	public static Output.Types.Alignment ToProtoAlignment(this ScreenAlignment alignment)
	{
		return alignment switch
		{
			ScreenAlignment.Full => Output.Types.Alignment.Full, 
			ScreenAlignment.TwoByOne => Output.Types.Alignment._2X1, 
			ScreenAlignment.TwoByTwo => Output.Types.Alignment._2X2, 
			ScreenAlignment.ThreeByOne => Output.Types.Alignment._3X1, 
			ScreenAlignment.Custom => Output.Types.Alignment.Custom, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static Output.Types.ProScreenType ToProtoOutputScreenType(this ScreenType screenType)
	{
		return screenType switch
		{
			ScreenType.Single => Output.Types.ProScreenType.Single, 
			ScreenType.Mirrored => Output.Types.ProScreenType.Mirrored, 
			ScreenType.EdgeBlend => Output.Types.ProScreenType.EdgeBlend, 
			ScreenType.Grouped => Output.Types.ProScreenType.Grouped, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static Output.Types.OutputType ToProtoOutputType(this OutputType outputType)
	{
		return outputType switch
		{
			OutputType.SDI => Output.Types.OutputType.Sdi, 
			OutputType.NDI => Output.Types.OutputType.Ndi, 
			OutputType.Syphon => Output.Types.OutputType.Syphon, 
			OutputType.System => Output.Types.OutputType.System, 
			OutputType.Placeholder => Output.Types.OutputType.Placeholder, 
			OutputType.DVI => Output.Types.OutputType.Dvi, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Analytics.Startup.ScreenType ToProtoScreenType(this ProScreenType screenType)
	{
		return screenType switch
		{
			ProScreenType.Audience => Pro.SerializationInterop.RVProtoData.Analytics.Startup.ScreenType.Audience, 
			ProScreenType.Stage => Pro.SerializationInterop.RVProtoData.Analytics.Startup.ScreenType.Stage, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static Output.Types.AlphaKeyMode ToProtoAlphaKeyMode(this AlphaKeyMode alphaKeyMode)
	{
		return alphaKeyMode switch
		{
			AlphaKeyMode.PreMultiplied => Output.Types.AlphaKeyMode.Premultiplied, 
			AlphaKeyMode.Straight => Output.Types.AlphaKeyMode.Straight, 
			_ => Output.Types.AlphaKeyMode.None, 
		};
	}

	public static Output.Types.AlphaDevice ToProtoAlphaDevice(this AlphaDeviceType alphaDeviceType)
	{
		return alphaDeviceType switch
		{
			AlphaDeviceType.Self => Output.Types.AlphaDevice.Self, 
			AlphaDeviceType.Other => Output.Types.AlphaDevice.Other, 
			_ => Output.Types.AlphaDevice.None, 
		};
	}
}
