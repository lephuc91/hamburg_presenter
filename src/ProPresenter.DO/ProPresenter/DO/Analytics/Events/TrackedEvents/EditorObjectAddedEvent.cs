using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;
using ProPresenter.DO.Analytics.Events.TrackedEvents.EditorToolbar;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record EditorObjectAddedEvent(InsertEditorObjectSourceType FromSource, InsertedTypes InsertedType) : IAnalyticEvent
{
	public static void Publish(InsertEditorObjectSourceType fromSource, InsertedTypes insertedType)
	{
		EventPublisher.Publish(new EditorObjectAddedEvent(fromSource, insertedType));
	}

	public IMessage Serialize()
	{
		EditorObjectAdded.Types.FromInsertionSource source = FromSource switch
		{
			InsertEditorObjectSourceType.EditorToolbar => EditorObjectAdded.Types.FromInsertionSource.EditorToolbar, 
			InsertEditorObjectSourceType.EditorMainMenu => EditorObjectAdded.Types.FromInsertionSource.EditorMainMenu, 
			InsertEditorObjectSourceType.EditorHotkey => EditorObjectAdded.Types.FromInsertionSource.EditorHotkey, 
			_ => EditorObjectAdded.Types.FromInsertionSource.EditorCopyPaste, 
		};
		EditorObjectAdded.Types.InsertedType typeInserted = InsertedType switch
		{
			InsertedTypes.EditorText => EditorObjectAdded.Types.InsertedType.EditorText, 
			InsertedTypes.EditorShape => EditorObjectAdded.Types.InsertedType.EditorShape, 
			InsertedTypes.EditorCustomShape => EditorObjectAdded.Types.InsertedType.EditorCustomShape, 
			InsertedTypes.EditorMedia => EditorObjectAdded.Types.InsertedType.EditorMedia, 
			InsertedTypes.EditorVideoInput => EditorObjectAdded.Types.InsertedType.EditorVideoInput, 
			InsertedTypes.EditorWeb => EditorObjectAdded.Types.InsertedType.EditorWeb, 
			InsertedTypes.EditorCurrentSlide => EditorObjectAdded.Types.InsertedType.EditorCurrentSlide, 
			InsertedTypes.EditorNextSlide => EditorObjectAdded.Types.InsertedType.EditorNextSlide, 
			InsertedTypes.EditorScreenPreview => EditorObjectAdded.Types.InsertedType.EditorScreenPreview, 
			InsertedTypes.EditorTimer => EditorObjectAdded.Types.InsertedType.EditorTimer, 
			InsertedTypes.EditorSystemClock => EditorObjectAdded.Types.InsertedType.EditorSystemClock, 
			InsertedTypes.EditorVideoCountdown => EditorObjectAdded.Types.InsertedType.EditorVideoCountdown, 
			InsertedTypes.EditorAudioCountdown => EditorObjectAdded.Types.InsertedType.EditorAudioCountdown, 
			InsertedTypes.EditorPlaybackMarker => EditorObjectAdded.Types.InsertedType.EditorPlaybackMarker, 
			InsertedTypes.EditorChordChart => EditorObjectAdded.Types.InsertedType.EditorChordChart, 
			InsertedTypes.EditorStageMessage => EditorObjectAdded.Types.InsertedType.EditorStageMessage, 
			InsertedTypes.EditorPlanningCenterLive => EditorObjectAdded.Types.InsertedType.EditorPlanningCenterLive, 
			InsertedTypes.EditorTimecode => EditorObjectAdded.Types.InsertedType.EditorTimecode, 
			InsertedTypes.EditorGroup => EditorObjectAdded.Types.InsertedType.EditorGroup, 
			InsertedTypes.EditorLabel => EditorObjectAdded.Types.InsertedType.EditorLabel, 
			_ => EditorObjectAdded.Types.InsertedType.EditorCaptureStatus, 
		};
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.EditorObjectAdded = new EditorObjectAdded
			{
				FromInsertionSource = source,
				InsertedType = typeInserted
			};
		});
	}
}
