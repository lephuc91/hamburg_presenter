using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using Jab;
using Pro.Common.Async;
using Pro.Common.Background;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.Versioning;
using Pro.CrashRecovery;
using Pro.Interprocess;
using Pro.Reporting;
using Pro.Reporting.UserFeedback;
using Pro.Reporting.UserFeedback.AttachmentUpload;
using ProPresenter.Continuation;
using ProPresenter.DO;
using ProPresenter.DependencyInjection;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter;

public static class Entry
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static DispatcherUnhandledExceptionEventHandler _003C_003E9__3_3;

		internal void _003CMain_003Eb__3_3(object s, DispatcherUnhandledExceptionEventArgs e)
		{
			Dreamcatcher.OnUnhandledException(e.Exception, IntPtr.Zero);
			e.Handled = true;
		}
	}

	private const int NormalExitCode = 0;

	private const int ErrorExitCode = -1;

	private const string LogFileName = "Log";

	public static async Task Main(string[] args)
	{
		MainApp application = null;
		Dreamcatcher.WakeUp += delegate(Crash crash)
		{
			HandleCrash(crash);
			FatalErrorShutdown(application);
		};
		Encoding encoding = Encoding.GetEncoding(Encoding.Default.CodePage, new EncoderReplacementFallback(), new DecoderExceptionFallback());
		string logFileName = LogFileManager.StartLogging(CommonPaths.Logs, "Log", encoding);
		Dreamcatcher.LastLogFileName = logFileName;
		Log.Info("Main Started");
		Log.Info("Assembly: " + Assembly.GetEntryAssembly());
		AppContinuationService continuationService = new AppContinuationService();
		using (InstanceValidator instanceValidator = new InstanceValidator())
		{
			ServiceProvider serviceProvider = new ServiceProvider(continuationService, Environment.MachineName, args, instanceValidator);
			try
			{
				Version oSVersion = GetOSVersion(serviceProvider);
				Log.Info("OS: " + (oSVersion.ToString() ?? "(null)"));
				VersionInfo.SetVersionInfoProvider(GetVersionInfoProvider(serviceProvider));
				Stargazer.AttachmentUploadJobFactory = serviceProvider.GetTypedService<IAttachmentUploadJobFactory>();
				Stargazer.UserFeedbackConsumer = serviceProvider.GetTypedService<IUserFeedbackConsumer>();
				Stargazer.SystemInfoProvider = serviceProvider.GetTypedService<ISystemInfoProvider>();
				string productName = Assembly.GetExecutingAssembly()?.GetCustomAttribute<AssemblyProductAttribute>()?.Product ?? "ProPresenter";
				Stargazer.SetAppInfoProvider(delegate(out string reportRootPath, out string logFile, out string appName)
				{
					reportRootPath = CommonPaths.CrashReports;
					logFile = logFileName;
					appName = productName;
				}, serviceProvider.GetTypedService<IRestClientFactory>());
				ProCore.InitializeGPU(productName);
				Directory.SetCurrentDirectory(Path.GetFullPath(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location ?? string.Empty) ?? string.Empty));
				Thread thread = new Thread((ThreadStart)delegate
				{
					//IL_0070: Unknown result type (might be due to invalid IL or missing references)
					//IL_0075: Unknown result type (might be due to invalid IL or missing references)
					//IL_007b: Expected O, but got Unknown
					application = new MainApp(serviceProvider);
					application.Properties["ApplicationServiceProviderPropertyName"] = serviceProvider;
					serviceProvider.SetMainThreadDispatcher(((DispatcherObject)application).Dispatcher);
					MainApp mainApp = application;
					object obj = _003C_003Ec._003C_003E9__3_3;
					if (obj == null)
					{
						DispatcherUnhandledExceptionEventHandler val = delegate(object s, DispatcherUnhandledExceptionEventArgs e)
						{
							Dreamcatcher.OnUnhandledException(e.Exception, IntPtr.Zero);
							e.Handled = true;
						};
						_003C_003Ec._003C_003E9__3_3 = val;
						obj = (object)val;
					}
					mainApp.DispatcherUnhandledException += (DispatcherUnhandledExceptionEventHandler)obj;
					application.Run();
				});
				thread.SetApartmentState(ApartmentState.STA);
				thread.Name = "UI thread";
				thread.Start();
				thread.Join();
				Shutdown();
			}
			finally
			{
				if (serviceProvider != null)
				{
					await serviceProvider.DisposeAsync();
				}
			}
		}
		Log.Info("Main Ended");
		Log.ShutdownOutputs();
		continuationService.Run();
		Environment.Exit(0);
	}

	private static void Shutdown()
	{
		try
		{
			SharedWorkerPool.ShutdownWorkers();
		}
		catch (Exception ex)
		{
			Log.Warning("Exception occurred in Shutdown: {0}", ex);
		}
	}

	private static void FatalErrorShutdown(MainApp? application)
	{
		try
		{
			if (application != null)
			{
				((DispatcherObject)application).Dispatcher.Invoke((Action)application.Shutdown);
			}
			SharedWorkerPool.AbortWorkers();
		}
		catch (Exception ex)
		{
			Log.Warning("Exception occurred in FatalErrorShutdown: {0}", ex);
		}
		Log.Info("Main Aborted");
		Log.ShutdownOutputs();
		Environment.Exit(-1);
	}

	private static void HandleCrash(Crash crash)
	{
		try
		{
			using PumpingSynchronizationContextExecutor pumpingSynchronizationContextExecutor = new PumpingSynchronizationContextExecutor(() => Stargazer.AttachSystemInfoFileToCrashAsync(crash));
			pumpingSynchronizationContextExecutor.Run();
			CrashHelper.StageCrashReportFiles(Stargazer.LastCrashOutputFolder, crash);
		}
		catch
		{
		}
		try
		{
			Stargazer.ReportCrash(crash);
			CrashHelper.ShowCrashReport("ProPresenter", string.Empty, crash.ReportFile);
		}
		catch
		{
		}
	}

	private static Version GetOSVersion(Jab.INamedServiceProvider<Version> versionProvider)
	{
		return versionProvider.GetService("OSVersion");
	}

	private static IVersionInfoProvider GetVersionInfoProvider(Jab.IServiceProvider<IVersionInfoProvider> versionInfoProvider)
	{
		return versionInfoProvider.GetService();
	}
}
