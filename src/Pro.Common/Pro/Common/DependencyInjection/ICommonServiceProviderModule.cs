using Jab;
using Pro.Common.AuthenticatingApiConsumer;
using Pro.Common.Background;
using Pro.Common.Cache.AsyncCache;
using Pro.Common.Concurrency;
using Pro.Common.DataStore;
using Pro.Common.Delay;
using Pro.Common.Downloads;
using Pro.Common.ErrorReporting;
using Pro.Common.FileSystem;
using Pro.Common.HTTP;
using Pro.Common.Internet;
using Pro.Common.Logging;
using Pro.Common.MessageService;
using Pro.Common.Network;
using Pro.Common.OAuth.Authenticator;
using Pro.Common.Startup;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.Common.Utility.Zip;

namespace Pro.Common.DependencyInjection;

[ServiceProviderModule]
[Transient<IFileFilterProvider, FileFilterProvider>]
[Transient<IFileUtility, FileUtility>]
[Transient<IDebouncerFactory, DebouncerFactory>]
[Transient<IZipService, ZipService>]
[Transient<IFileWatcherFactory, FileWatcherFactory>]
[Transient<ILogger, Logger>]
[Singleton<IMessageService, Pro.Common.MessageService.MessageService>]
[Transient<ICurrentTime, CurrentTime>]
[Transient<ICurrentTimeOffset, CurrentTimeOffset>]
[Transient<IAsyncExecutor, AsyncExecutor>]
[Singleton<IAfterStartupCompleteQueue, AfterStartupCompleteQueue>]
[Singleton<IInternetAccessCheck, InternetAccessCheckService>]
[Transient<IHyperlinkService, HyperlinkService>]
[Transient<IErrorReporter, ErrorReporter>]
[Transient<ITimerFactory, TimerFactory>]
[Singleton<IDownloadManager, DownloadManager>]
[Transient<IDelayFactory, DelayFactory>]
[Transient<IDownloadProcessFactory, DownloadProcessFactory>]
[Transient<IAuthenticatorFactory, AuthenticatorFactory>]
[Transient<IAuthenticatingApiConsumerFactory, AuthenticatingApiConsumerFactory>]
[Transient<ISemaphoreFactory, SemaphoreFactory>]
[Transient<IStopwatchFactory, StopwatchFactory>]
[Transient<ICacheFactory, CacheFactory>]
[Singleton<IProcessHelper, ProcessHelper>]
[Transient<IImageLoader, ImageLoader>]
[Transient<IZipHelper, ZipHelperImpl>]
[Transient<INetworkChange, NetworkChange>]
[Transient<IEmbeddedResourceReader, EmbeddedResourceReader>]
[Singleton<IFileObservatory, FileObservatory>]
public interface ICommonServiceProviderModule
{
}
