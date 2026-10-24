using System;
using System.IO.Abstractions;
using Jab;
using Pro.Common.Background;
using Pro.Common.Concurrency;
using Pro.Common.ErrorReporting;
using Pro.Common.OAuth.Authenticator;
using Pro.CoreApplication.Document;
using Pro.Data.SQLite;
using Pro.Entity;
using Pro.Entity.Persistence;
using Pro.Interprocess;
using ProPresenter.DO.Analytics.Events.CloudDiagnostics;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.Data.Messages;
using ProPresenter.Data.StartupArguments;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.Data.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Singleton<IDatabaseService, DatabaseService>]
[Jab.Singleton<ISharedData<AppData>>(Factory = "GetSharedAppData")]
[Jab.Singleton<IStartupArgumentsExecutor, FileStartupArgumentExecutor>]
[Jab.Singleton<IMessageHandler, FileMessageHandler>]
[Jab.Singleton<IMessageHandler, FocusWindowMessageHandler>]
[Jab.Singleton<IOAuth2AuthorizationStore, ProContentRegistrationAuthorizationStorage>(Name = "ProContentRegistrationAuthorizationStorageKey")]
[Jab.Transient<IBuildAppMetaDataFile, ApplicationDataFileBuilder>]
[Jab.Transient<IMessageHandler>(Factory = "GetUriMessageHandler")]
[Jab.Singleton<IEntityDocumentRegistry>(Factory = "GetDocumentUpdateProvider")]
[Jab.Singleton<IDocumentDiagnosticsProvider>(Factory = "GetDocumentUpdateProvider")]
internal interface IDataServiceProviderModule
{
	const string ShouldSuppressVisualIndicationKey = "ShouldSuppressVisualIndicationKey";

	static ISharedData<AppData> GetSharedAppData()
	{
		SharedData<AppData> sharedData = new SharedData<AppData>();
		sharedData.Register(AppData.Uri);
		sharedData.Register(AppData.File);
		return sharedData;
	}

	static IMessageHandler GetUriMessageHandler(ISharedData<AppData> sharedData, Func<IRegistrationOperationFactory> getRegistrationOperationFactory, [Jab.FromNamedServices("ShouldSuppressVisualIndicationKey")] Func<bool> shouldSuppressVisualIndication, Func<IMainLayoutVM> getMainLayoutVM)
	{
		return new UriMessageHandler(sharedData, getRegistrationOperationFactory, shouldSuppressVisualIndication, getMainLayoutVM);
	}

	static DocumentUpdateProvider GetDocumentUpdateProvider(IDocumentService documentService, IAsyncExecutor asyncExecutor, IFileSystem fileSystem, IEntityFileLockFactory fileLockFactory, ICommonPathsWrapper paths, IDocumentFactory documentFactory, ICollaborationPeerIdProvider peerIdProvider, IThreadPoolScheduler scheduler, ICloudDiagnosticsPublisher cloudDiagnostics, IErrorReporter errorReporter)
	{
		DocumentUpdateProvider documentUpdateProvider = new DocumentUpdateProvider(documentService, asyncExecutor, fileSystem, fileLockFactory, paths, documentFactory, peerIdProvider, scheduler, cloudDiagnostics, errorReporter);
		ChangeDirectoryPrompt.RegisterDelegate(new ChangeDirectoryListener(documentUpdateProvider.Reset, delegate
		{
		}));
		return documentUpdateProvider;
	}
}
