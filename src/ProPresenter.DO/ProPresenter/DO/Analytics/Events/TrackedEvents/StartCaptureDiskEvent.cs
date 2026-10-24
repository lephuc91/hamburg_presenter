using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;
using ProPresenter.DO.Capture;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record StartCaptureDiskEvent(ProPresenter.DO.Capture.Codec CODEC, uint ResolutionWidth, uint ResolutionHeight, ProPresenter.DO.Capture.FrameRate FrameRate, bool StreamStarted, uint Bitrate) : IAnalyticEvent
{
	public static void Publish(ProPresenter.DO.Capture.Codec codec, uint resolutionWidth, uint resolutionHeight, ProPresenter.DO.Capture.FrameRate frameRate, bool streamStarted, uint bitrate)
	{
		EventPublisher.Publish(new StartCaptureDiskEvent(codec, resolutionWidth, resolutionHeight, frameRate, streamStarted, bitrate));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartCaptureDisk = new StartCaptureDisk
			{
				Codec = EnumToProtoEnum.TranslateCodec(CODEC),
				ResolutionWidth = ResolutionWidth,
				ResolutionHeight = ResolutionHeight,
				FrameRate = EnumToProtoEnum.TranslateFrameRate(FrameRate),
				StreamStarted = StreamStarted,
				VideoBitrate = Bitrate
			};
		});
	}
}
