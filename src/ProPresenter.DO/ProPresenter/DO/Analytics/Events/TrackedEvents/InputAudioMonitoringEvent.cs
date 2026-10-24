using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record InputAudioMonitoringEvent(InputTypes InputType) : IAnalyticEvent
{
	public enum InputTypes
	{
		Audio,
		Video
	}

	private static InputAudioMonitoring.Types.InputType TranslateEnumToProtoEnum(InputTypes inputType)
	{
		return inputType switch
		{
			InputTypes.Audio => InputAudioMonitoring.Types.InputType.Audio, 
			InputTypes.Video => InputAudioMonitoring.Types.InputType.Video, 
			_ => InputAudioMonitoring.Types.InputType.Audio, 
		};
	}

	public static void Publish(InputTypes inputType)
	{
		EventPublisher.Publish(new InputAudioMonitoringEvent(inputType));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.InputAudioMonitoring = new InputAudioMonitoring
			{
				Type = TranslateEnumToProtoEnum(InputType)
			};
		});
	}
}
