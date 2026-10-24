using System;

namespace ProPresenter.DO.Web;

public interface IWebSourceProvider
{
	Uri MediaStore { get; }

	Uri MigrationHelp { get; }

	Uri InfoCenter { get; }

	Uri UserManual { get; }

	Uri Support { get; }

	Uri SubmitTicket { get; }

	Uri Tutorials { get; }

	Uri Forums { get; }

	Uri ScreenConfiguration { get; }

	Uri WhatsNew { get; }

	Uri OpenFeedback { get; }

	Uri SongSelect { get; }

	Uri ProPresenter { get; }

	Uri SampleContentData { get; }

	Uri VideoTutorials { get; }

	Uri ContactSupport { get; }

	Uri UserGroup { get; }

	Uri KnowledgeBase { get; }

	Uri Blog { get; }

	Uri ProContent { get; }

	Uri DiscoverCloud { get; }

	Uri CloudEarlyAccess { get; }

	Uri UnlockCloud { get; }

	Uri CloudCollaboration { get; }

	Uri CloudTroubleShooting { get; }

	Uri GetReleaseNotes(string? appVersion = null);

	Uri GenerateLink(ResourceType resourceType);

	Uri GenerateLink(InAppStoreType storeType);

	Uri GenerateSampleContentDownloadLink(string resourceKey);

	Uri ProPresenterControlLink(int port);
}
