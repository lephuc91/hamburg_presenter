using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.Startup;

namespace ProPresenter.DO.Analytics;

public record StartupContentEvent(int LibraryCount, int LibraryPlaylistCount, int LibraryPlaylistFolderCount, int LibraryPlaylistMaxDepth, int MediaBinPlaylistCount, int MediaBinPlaylistFolderCount, int MediaBinPlaylistMaxDepth, int MediaBinStandardPlaylistCount, int MediaBinSmartPlaylistCount, int MediaBinVideoInputCount, int AudioBinPlaylistCount, int AudioBinPlaylistFolderCount, int AudioBinPlaylistMaxDepth, int TimerCount, int MessagesCount, int PropsCount, int StageLayoutCount, int MacrosCount, int MacrosCollectionsCount, int MacrosCustomIconsCount, int PropsAutoClearCount, int PropCollectionsCount, int PropCollectionsSinglePropEnabledCount) : IAnalyticEvent
{
	public static void Publish(int libraryCount, int libraryPlaylistCount, int libraryPlaylistFolderCount, int libraryPlaylistMaxDepth, int mediaBinPlaylistCount, int mediaBinPlaylistFolderCount, int mediaBinPlaylistMaxDepth, int mediaBinStandardPlaylistCount, int mediaBinSmartPlaylistCount, int mediaBinVideoInputCount, int audioBinPlaylistCount, int audioBinPlaylistFolderCount, int audioBinPlaylistMaxDepth, int timerCount, int messagesCount, int propsCount, int stageLayoutCount, int macroCount, int macrosCollectionsCount, int macrosCustomIconsCount, int propsAutoClearCount, int propCollectionsCount, int propCollectionsSinglePropEnabledCount)
	{
		EventPublisher.Publish(new StartupContentEvent(libraryCount, libraryPlaylistCount, libraryPlaylistFolderCount, libraryPlaylistMaxDepth, mediaBinPlaylistCount, mediaBinPlaylistFolderCount, mediaBinPlaylistMaxDepth, mediaBinStandardPlaylistCount, mediaBinSmartPlaylistCount, mediaBinVideoInputCount, audioBinPlaylistCount, audioBinPlaylistFolderCount, audioBinPlaylistMaxDepth, timerCount, messagesCount, propsCount, stageLayoutCount, macroCount, macrosCollectionsCount, macrosCustomIconsCount, propsAutoClearCount, propCollectionsCount, propCollectionsSinglePropEnabledCount));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.StartupContent = new Content
			{
				LibraryCount = LibraryCount,
				LibraryPlaylistCount = LibraryPlaylistCount,
				LibraryPlaylistFolderCount = LibraryPlaylistFolderCount,
				LibraryPlaylistMaxDepth = LibraryPlaylistMaxDepth,
				MediaBinTotalPlaylistCount = MediaBinPlaylistCount,
				MediaBinPlaylistFolderCount = MediaBinPlaylistFolderCount,
				MediaBinPlaylistMaxDepth = MediaBinPlaylistMaxDepth,
				MediaBinNormalPlaylistCount = MediaBinStandardPlaylistCount,
				MediaBinSmartPlaylistCount = MediaBinSmartPlaylistCount,
				MediaBinVideoInputCount = MediaBinVideoInputCount,
				AudioBinPlaylistCount = AudioBinPlaylistCount,
				AudioBinPlaylistFolderCount = AudioBinPlaylistFolderCount,
				AudioBinPlaylistMaxDepth = AudioBinPlaylistMaxDepth,
				TimerCount = TimerCount,
				MessagesCount = MessagesCount,
				PropsCount = PropsCount,
				StageLayoutCount = StageLayoutCount,
				MacrosCount = MacrosCount,
				MacrosCollectionsCount = MacrosCollectionsCount,
				MacrosCustomIcons = MacrosCustomIconsCount,
				PropsAutoClearCount = PropsAutoClearCount,
				PropCollectionsCount = PropCollectionsCount,
				PropCollectionsSinglePropEnabledCount = PropCollectionsSinglePropEnabledCount
			};
		});
	}
}
