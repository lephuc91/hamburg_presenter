using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record VideoInputTriggeredEvent(AudioSources AudioSource) : IAnalyticEvent
{
	public enum AudioSources
	{
		Other,
		Self,
		None
	}

	public static void Publish(AudioSources audioSource)
	{
		EventPublisher.Publish(new VideoInputTriggeredEvent(audioSource));
	}

	public IMessage Serialize()
	{
		VideoInputTriggered.Types.AudioSource source = AudioSource switch
		{
			AudioSources.Other => VideoInputTriggered.Types.AudioSource.Other, 
			AudioSources.Self => VideoInputTriggered.Types.AudioSource.Self, 
			_ => VideoInputTriggered.Types.AudioSource.None, 
		};
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.VideoInputTriggered = new VideoInputTriggered
			{
				AudioSource = source
			};
		});
	}
}
