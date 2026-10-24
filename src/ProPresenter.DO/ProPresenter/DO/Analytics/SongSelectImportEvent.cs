using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Import;

namespace ProPresenter.DO.Analytics;

public record SongSelectImportEvent(bool DidOpenEditView, bool ImportIntoPlaylist, LineDelimiter LineDelimiter, int LineDelimiterCount, int TemplateSlideTextElementCount) : IAnalyticEvent
{
	public static void Publish(bool didOpenEditView, bool importIntoPlaylist, LineDelimiter lineDelimiter, int lineDelimiterCount, int templateSlideTextElementCount)
	{
		EventPublisher.Publish(new SongSelectImportEvent(didOpenEditView, importIntoPlaylist, lineDelimiter, lineDelimiterCount, templateSlideTextElementCount));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			Pro.SerializationInterop.RVProtoData.Analytics.Import.SongSelect songSelect = new Pro.SerializationInterop.RVProtoData.Analytics.Import.SongSelect
			{
				DidOpenEditView = DidOpenEditView,
				ImportIntoPlaylist = ImportIntoPlaylist
			};
			Pro.SerializationInterop.RVProtoData.Analytics.Import.SongSelect songSelect2 = songSelect;
			songSelect2.LineDelimiter = LineDelimiter switch
			{
				LineDelimiter.LineBreak => Pro.SerializationInterop.RVProtoData.Analytics.Import.SongSelect.Types.LineDelimiter.LineBreak, 
				LineDelimiter.ParagraphBreak => Pro.SerializationInterop.RVProtoData.Analytics.Import.SongSelect.Types.LineDelimiter.ParagraphBreak, 
				_ => Pro.SerializationInterop.RVProtoData.Analytics.Import.SongSelect.Types.LineDelimiter.Unknown, 
			};
			songSelect.LineDelimiterCount = LineDelimiterCount;
			songSelect.TemplateSlideTextElementCount = TemplateSlideTextElementCount;
			e.ImportSongselect = songSelect;
		});
	}
}
