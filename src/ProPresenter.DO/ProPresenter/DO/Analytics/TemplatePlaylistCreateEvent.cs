using System.Linq;
using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Create;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Analytics;

public record TemplatePlaylistCreateEvent(GeneralPlaylist Playlist) : IAnalyticEvent
{
	public int TotalItemCount { get; } = Playlist.Count;

	public int HeaderCount { get; } = Playlist.Count((ProPresenterCue i) => i.Type == CueType.Header);

	public int PlaceholderCount { get; } = Playlist.Count((ProPresenterCue i) => i.Type == CueType.Placeholder);

	public int PresentationCount { get; } = Playlist.Count((ProPresenterCue i) => i.Type == CueType.Document);

	public int MediaCount { get; } = Playlist.Count((ProPresenterCue i) => i.Type == CueType.Media);

	public static void Publish(GeneralPlaylist playlist)
	{
		EventPublisher.Publish(new TemplatePlaylistCreateEvent(playlist));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.CreateFromTemplatePlaylist = new TemplatePlaylist
			{
				TotalItemCount = TotalItemCount,
				HeaderCount = HeaderCount,
				PlaceholderCount = PlaceholderCount,
				PresentationCount = PresentationCount,
				MediaCount = MediaCount
			};
		});
	}
}
