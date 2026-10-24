using Google.Protobuf;
using Pro.Common.Mathematics;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO.Analytics;

public record StartupScreenConfigOutputEvent(ScreenAlignment Alignment, ScreenType ScreenType, OutputType OutputType, bool ColorCorrectionEnabled, bool CornerPinningEnabled, Vector2<int> Size, AlphaBlendMode AlphaBlendMode, AlphaKeyOutputDevice alphaDeviceType) : IAnalyticEvent
{
	public AlphaKeyMode AlphaKeyMode { get; } = ToAlphaKeyMode(AlphaBlendMode);

	public AlphaDeviceType AlphaDeviceType { get; } = ToAlphaDeviceType(alphaDeviceType);

	private static AlphaKeyMode ToAlphaKeyMode(AlphaBlendMode alphaBlendMode)
	{
		return alphaBlendMode switch
		{
			AlphaBlendMode.Premultiplied => AlphaKeyMode.PreMultiplied, 
			AlphaBlendMode.Straight => AlphaKeyMode.Straight, 
			_ => AlphaKeyMode.None, 
		};
	}

	private static AlphaDeviceType ToAlphaDeviceType(AlphaKeyOutputDevice device)
	{
		return device switch
		{
			AlphaKeyOutputDevice.Self => AlphaDeviceType.Self, 
			AlphaKeyOutputDevice.Other => AlphaDeviceType.Other, 
			_ => AlphaDeviceType.None, 
		};
	}

	public static void Publish(ScreenAlignment alignment, ScreenType screenType, OutputType outputType, bool colorCorrectionEnabled, bool cornerPinningEnabled, Vector2<int> size, AlphaBlendMode alphaBlendMode, AlphaKeyOutputDevice alphaDeviceType)
	{
		EventPublisher.Publish(new StartupScreenConfigOutputEvent(alignment, screenType, outputType, colorCorrectionEnabled, cornerPinningEnabled, size, alphaBlendMode, alphaDeviceType));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupScreenConfigurationScreen = new Output
			{
				Alignment = Alignment.ToProtoAlignment(),
				ProscreenType = ScreenType.ToProtoOutputScreenType(),
				OutputType = OutputType.ToProtoOutputType(),
				ColorCorrectionEnabled = ColorCorrectionEnabled,
				CornerPinEnabled = CornerPinningEnabled,
				Width = Size.X,
				Height = Size.Y,
				AlphaKeyMode = AlphaKeyMode.ToProtoAlphaKeyMode(),
				AlphaDevice = AlphaDeviceType.ToProtoAlphaDevice()
			};
		});
	}
}
