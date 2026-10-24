using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;
using ProPresenter.DO.Audio;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record AudioInputModeSelectionEvent(BehaviorMode ModeType) : IAnalyticEvent
{
	public static void Publish(BehaviorMode modeType)
	{
		EventPublisher.Publish(new AudioInputModeSelectionEvent(modeType));
	}

	private static AudioInputModeSelection.Types.ModeType TranslateEnumToProtoEnum(BehaviorMode behaviorMode)
	{
		return behaviorMode switch
		{
			BehaviorMode.On => AudioInputModeSelection.Types.ModeType.On, 
			BehaviorMode.AutoOn => AudioInputModeSelection.Types.ModeType.Autoon, 
			BehaviorMode.AutoOff => AudioInputModeSelection.Types.ModeType.Autooff, 
			_ => AudioInputModeSelection.Types.ModeType.Off, 
		};
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.AudioInputModeSelection = new AudioInputModeSelection
			{
				ModeType = TranslateEnumToProtoEnum(ModeType)
			};
		});
	}
}
