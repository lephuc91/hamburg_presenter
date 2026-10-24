using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Bugsnag;
using Bugsnag.Payload;
using Pro.Common.Components.Reversibility;
using Pro.Common.HTTP;
using Pro.Common.HTTP.Results;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Common.Security;
using Pro.Common.Utility;
using Pro.Common.Versioning;
using Pro.Localization;
using Pro.Reporting.BugsnagInternal;
using Pro.Reporting.UserFeedback;
using Pro.Reporting.UserFeedback.AttachmentUpload;
using Pro.Reporting.UserFeedback.AttachmentUpload.Model;

namespace Pro.Reporting;

public static class Stargazer
{
	public delegate void AppInfoProviderDelegate(out string reportRootPath, out string logFileName, out string appName);

	public delegate void LeaveBreadcrumbDelegate(string message, BreadcrumbType type, IDictionary<string, string> metadata);

	private const string DateTimeFormat = "yyyy-MM-dd-HHmm";

	private const string FieldNotAvailable = "not available";

	private static AppInfoProviderDelegate? _appInfoProviderCB;

	private static Bugsnag.Client? _bugSnagClient;

	private static bool _alreadyIncrementedHandledCount;

	private static bool _alreadyIncrementedUnhandledCount;

	public static bool EnableAnalytics { get; set; }

	public static bool EnableCrashReporting { get; set; }

	public static IRegistrationInformationProvider? RegistrationInfoProvider { get; set; }

	public static IAttachmentUploadJobFactory? AttachmentUploadJobFactory { get; set; }

	public static IUserFeedbackConsumer? UserFeedbackConsumer { get; set; }

	public static ISystemInfoProvider? SystemInfoProvider { get; set; }

	public static string LastCrashOutputFolder => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RenewedVision", "ProPresenter", "LastCrashData");

	private static void AddAppInformation(App app)
	{
		app.TryGetValue("version", out var value);
		if (string.IsNullOrEmpty(value as string))
		{
			app.Add("version", VersionInfo.ShortDisplayAppVersion);
		}
		app.Add("bundleVersion", VersionInfo.AppVersion.Build.ToString());
		app.Add("Build Number", VersionInfo.AppVersion.Build.ToString());
		app.Add("clrVersion", Environment.Version.ToString());
		app.Add("appArchitecture", Environment.Is64BitProcess ? "64 bit" : "32 bit");
		app.Add("Install Date", VersionInfo.InstallDate.ToString());
		app.Add("Build Date", VersionInfo.BuildDate.ToString("MM/dd/yyyy"));
		app.Add("Commit Hash", VersionInfo.CommitHash);
	}

	private static void AddDeviceInformation(Device device)
	{
		device.Add("id", new BugsnagUserInfo().Id.ToString());
		device.Add("processorCount", Environment.ProcessorCount + " core(s)");
		device.Add("machineName", Environment.MachineName);
		device.Add("osArchitecture", Environment.Is64BitOperatingSystem ? "64 bit" : "32 bit");
	}

	private static void AddUserRegistrationInformation(User user)
	{
		AddUserRegistrationInformation(user.Add);
	}

	private static void AddUserRegistrationInformation(Metadata metadata)
	{
		AddUserRegistrationInformation(metadata.Add);
	}

	private static void AddUserRegistrationInformation(Action<string, string> addAction)
	{
		RegistrationInfo registrationInfo = RegistrationInfoProvider?.Get();
		if ((registrationInfo?.HardwareIdentifier).NullableIsNullOrEmpty())
		{
			addAction("Registration Data", "not loaded");
			return;
		}
		addAction("Device Name", registrationInfo.DeviceName.NullableIsNullOrEmpty() ? "not available" : registrationInfo.DeviceName);
		addAction("Activation Key", registrationInfo.ActivationKey.NullableIsNullOrEmpty() ? "not available" : registrationInfo.ActivationKey);
		addAction("Hardware Fingerprint", registrationInfo.HardwareFingerprint.NullableIsNullOrEmpty() ? "not available" : registrationInfo.HardwareFingerprint);
		addAction("Hardware Identifier", registrationInfo.HardwareIdentifier);
		addAction("Registration Name", registrationInfo.RegistrationName.NullableIsNullOrEmpty() ? "not available" : registrationInfo.RegistrationName);
		if (!registrationInfo.RegistrationName.NullableIsNullOrEmpty())
		{
			addAction("Registration Code", registrationInfo.RegistrationCode);
		}
	}

	private static User CreateBugsnagUser()
	{
		BugsnagUserInfo bugsnagUserInfo = new BugsnagUserInfo();
		return new User
		{
			Id = bugsnagUserInfo.Id.ToString(),
			Name = Environment.MachineName
		};
	}

	private static NoStoreSessionTracker StartSessionTracker(IConfiguration configuration, ProBugsnagDelivery delivery)
	{
		NoStoreSessionTracker noStoreSessionTracker = new NoStoreSessionTracker();
		noStoreSessionTracker.CreateSession();
		Session session = noStoreSessionTracker.CurrentSession;
		session.Add("user", CreateBugsnagUser());
		Task.Run(delegate
		{
			App app = new App(configuration);
			AddAppInformation(app);
			Device device = new Device();
			AddDeviceInformation(device);
			delivery.Send(new SessionPayload(configuration, session, app, device));
		});
		return noStoreSessionTracker;
	}

	private static void ModifyEventReport(Report report)
	{
		try
		{
			report.Event.Context = Application.Current.Windows.OfType<Window>().SingleOrDefault((Window x) => x.IsActive)?.Title;
		}
		catch
		{
		}
		if (report.Event["session"] is Session session && session["events"] is SessionEvents sessionEvents)
		{
			if (report.Event.IsHandled)
			{
				if (!_alreadyIncrementedHandledCount)
				{
					sessionEvents.IncrementHandledCount();
					_alreadyIncrementedHandledCount = true;
				}
			}
			else if (!_alreadyIncrementedUnhandledCount)
			{
				sessionEvents.IncrementUnhandledCount();
				_alreadyIncrementedUnhandledCount = true;
			}
		}
		report.Event.User = CreateBugsnagUser();
		AddUserRegistrationInformation(report.Event.User);
		AddUserRegistrationInformation(report.Event.Metadata);
		string text = ConfigurationManager.AppSettings["machineIdentifier"];
		if (text != null)
		{
			report.Event.Metadata.Add("Machine Identifier", text);
		}
		AddAppInformation(report.Event.App);
		AddDeviceInformation(report.Event.Device);
	}

	private static string BugsnagReleaseStage(string? requestedStage)
	{
		if (!string.IsNullOrEmpty(requestedStage))
		{
			return requestedStage;
		}
		string fullDisplayAppVersion = VersionInfo.FullDisplayAppVersion;
		if (fullDisplayAppVersion == "LOCAL_DEBUG")
		{
			return "debug";
		}
		if (fullDisplayAppVersion.StartsWith("main"))
		{
			return "main";
		}
		if (VersionInfo.AppVersion.Major >= 2000)
		{
			return "daily";
		}
		return "production";
	}

	private static void Startup(IRestClientFactory restClientFactory)
	{
		Log.Info("Bugsnag Startup");
		TimeSpan createdWithin = TimeSpan.FromMinutes(10L);
		Log.Info("Bugsnag Unsent reports (less than {0} minutes old): {1}", createdWithin.TotalMinutes, CountOfUnsentReports(createdWithin));
		if (VersionInfo.EnableCrashReporting)
		{
			NameValueCollection appSettings = ConfigurationManager.AppSettings;
			string text = appSettings["bugsnagApiKey"];
			string requestedStage = appSettings["bugsnagReleaseStage"];
			if (!text.NullableIsNullOrEmpty())
			{
				Bugsnag.Configuration configuration = new Bugsnag.Configuration(text);
				configuration.AutoNotify = false;
				configuration.MaximumBreadcrumbs = 50;
				configuration.ProjectNamespaces = new string[3] { "Pro.", "ProPresenter.", "ProPresenterCore." };
				configuration.AppVersion = VersionInfo.ShortDisplayAppVersion;
				configuration.ReleaseStage = BugsnagReleaseStage(requestedStage);
				Bugsnag.Configuration configuration2 = configuration;
				ProBugsnagDelivery delivery = new ProBugsnagDelivery(restClientFactory, configuration2);
				NoStoreSessionTracker sessionTracking = StartSessionTracker(configuration2, delivery);
				_bugSnagClient = new Bugsnag.Client(configuration2, delivery, new Breadcrumbs(configuration2), sessionTracking);
				Log.BreadcrumbCallback = LogBreadcrumb;
				UndoStack.Undoing += Undoing;
				UndoStack.Redoing += Redoing;
				UndoStack.Doing += Doing;
				_bugSnagClient.BeforeNotify(ModifyEventReport);
			}
		}
		else
		{
			Log.Info("Bugsnag Startup skipped, Crash Reporting Disabled");
		}
	}

	private static string? GetEnumKey(Enum e, out Dictionary<string, string>? metadata)
	{
		metadata = null;
		LocalizedStringAttribute attribute = e.GetAttribute<Enum, LocalizedStringAttribute>();
		if (attribute != null)
		{
			string text = LocalizedStrings.Get(attribute.Key);
			if (text != null)
			{
				metadata = new Dictionary<string, string> { { "Action key", attribute.Key } };
				return text;
			}
			return attribute.Key;
		}
		return null;
	}

	private static void BreadcrumbFromUndoStackEvent(Enum? e, string? prefix)
	{
		if (e != null)
		{
			Dictionary<string, string> metadata;
			string enumKey = GetEnumKey(e, out metadata);
			if (enumKey != null)
			{
				LeaveBreadcrumb((prefix != null) ? (prefix + " " + enumKey) : enumKey, BreadcrumbType.User, metadata);
				return;
			}
		}
		if (prefix != null)
		{
			LeaveBreadcrumb(prefix, BreadcrumbType.User);
		}
	}

	private static void Undoing(Enum? e)
	{
		BreadcrumbFromUndoStackEvent(e, "Undo");
	}

	private static void Redoing(Enum? e)
	{
		BreadcrumbFromUndoStackEvent(e, "Redo");
	}

	private static void Doing(Enum? e)
	{
		BreadcrumbFromUndoStackEvent(e, null);
	}

	private static void LogBreadcrumb(string type, string config, string message)
	{
		Dictionary<string, string> metadata = new Dictionary<string, string>
		{
			["Logged type"] = type,
			["Build configuration"] = config,
			["Thread ID"] = Environment.CurrentManagedThreadId.ToString()
		};
		_bugSnagClient?.Breadcrumbs.Leave(message, type.Contains("ERROR") ? BreadcrumbType.Error : BreadcrumbType.Log, metadata);
	}

	public static void LeaveBreadcrumb(string message, BreadcrumbType breadcrumbType, params (string key, string value)[] properties)
	{
		LeaveBreadcrumb(message, breadcrumbType, properties.ToDictionary(((string key, string value) p) => p.key, ((string key, string value) p) => p.value));
	}

	public static void LeaveBreadcrumb(string message, BreadcrumbType type, IDictionary<string, string> metadata)
	{
		_bugSnagClient?.Breadcrumbs.Leave(message, type, metadata);
	}

	public static void SetAppInfoProvider(AppInfoProviderDelegate appInfoProviderCB, IRestClientFactory restClientFactory)
	{
		if (_appInfoProviderCB != null)
		{
			throw new InvalidOperationException();
		}
		_appInfoProviderCB = appInfoProviderCB;
		Startup(restClientFactory);
	}

	private static void DefaultAppInfoProvider(out string reportRootPath, out string logFileName, out string appName)
	{
		reportRootPath = string.Empty;
		logFileName = string.Empty;
		appName = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly()?.Location) ?? string.Empty;
	}

	internal static void GetAppInfo(out string reportRootPath, out string logFileName, out string appName)
	{
		(_appInfoProviderCB ?? new AppInfoProviderDelegate(DefaultAppInfoProvider))(out reportRootPath, out logFileName, out appName);
	}

	internal static int CountOfUnsentReports(TimeSpan createdWithin)
	{
		string reportRootPath = string.Empty;
		(_appInfoProviderCB ?? new AppInfoProviderDelegate(DefaultAppInfoProvider))(out reportRootPath, out var _, out var _);
		DateTime limit = DateTime.Now.AddMinutes(0.0 - createdWithin.TotalMinutes);
		if (reportRootPath != string.Empty && Directory.Exists(reportRootPath))
		{
			return (from file in Directory.EnumerateFiles(reportRootPath, "*.unsent")
				where new FileInfo(file).CreationTime > limit
				select file).ToList().Count;
		}
		return 0;
	}

	internal static string GetReportName(string appName)
	{
		return GetReportName(appName, DateTime.Now);
	}

	private static string GetReportName(string appName, DateTime reportTime)
	{
		_003C_003Ey__InlineArray5<string> buffer = default(_003C_003Ey__InlineArray5<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 0) = appName;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 1) = reportTime.ToString("yyyy-MM-dd-HHmm");
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 2) = VersionInfo.FullDisplayAppVersion.Replace(' ', '_').Replace('.', '_').Replace("(", "")
			.Replace(")", "");
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 3) = VersionInfo.CommitHash;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 4) = Environment.MachineName;
		return string.Join("_", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<string>, string>(in buffer, 5));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ReportError(string error, params (string key, string value)[] properties)
	{
		ReportError(new ReportedException(error, new System.Diagnostics.StackTrace(1, fNeedFileInfo: true).ToString()), properties);
	}

	public static void ReportError(System.Exception error, params (string key, string value)[] properties)
	{
		if (!VersionInfo.EnableCrashReporting || !EnableCrashReporting)
		{
			return;
		}
		_bugSnagClient?.Notify(error, HandledState.ForHandledException(), delegate(Report report)
		{
			Bugsnag.Payload.Exception[] exceptions = report.Event.Exceptions;
			foreach (Bugsnag.Payload.Exception obj in exceptions)
			{
				IEnumerable<StackTraceLine> source = obj.StackTrace.SkipWhile((StackTraceLine traceLine) => traceLine.MethodName.Contains("Pro.Reporting."));
				obj["stacktrace"] = source.ToArray();
			}
			if (properties.Any())
			{
				report.Event.Metadata.Add("Resources", properties.ToDictionary(((string key, string value) p) => p.key, ((string key, string value) p) => p.value));
			}
		});
	}

	public static void ReportCrash(Crash crash)
	{
		if (!VersionInfo.EnableCrashReporting || !EnableCrashReporting)
		{
			return;
		}
		if (crash.Exception.GetType() == typeof(ApplicationException))
		{
			string message = crash.Exception.Message;
			if (message != null && message.Equals("This is a test"))
			{
				return;
			}
		}
		_bugSnagClient?.Notify(crash.Exception, HandledState.ForUnhandledException(), delegate(Report report)
		{
			Bugsnag.Payload.Exception[] exceptions = report.Event.Exceptions;
			foreach (Bugsnag.Payload.Exception obj in exceptions)
			{
				IEnumerable<StackTraceLine> source = obj.StackTrace.SkipWhile((StackTraceLine traceLine) => traceLine.MethodName.Contains("Crash crash") || traceLine.MethodName.Contains("Pro.Reporting."));
				obj["stacktrace"] = source.ToArray();
			}
			if (crash.Exception.GetType() == typeof(UnmanagedException))
			{
				string miniDumpFile = crash.MiniDumpFile;
				Uri endpoint = new Uri(report.Endpoint.ToString() + "minidump?api_key=" + report.Configuration.ApiKey + "|" + miniDumpFile);
				report.Endpoint = endpoint;
				StringBuilder stringBuilder = new StringBuilder();
				foreach (StackTraceLine item in report.Event.Exceptions[0].StackTrace)
				{
					if (item["lineNumber"] is int num && num != 0)
					{
						stringBuilder.Append($"at {item.MethodName} in {item.FileName}: line {num}\n");
					}
					else
					{
						stringBuilder.Append($"at {item.MethodName}\n");
					}
				}
				report.Event.Metadata.Add("Managed stack", new KeyValuePair<string, string>("stack", stringBuilder.ToString()));
			}
			UploadCrashFiles(crash, report);
		});
	}

	public static async Task AttachSystemInfoFileToCrashAsync(Crash crash, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (crash == null || SystemInfoProvider == null)
		{
			return;
		}
		try
		{
			string text = await SystemInfoProvider.CreateSystemInfoFileAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (!string.IsNullOrEmpty(text))
			{
				crash.Add(text);
			}
		}
		catch (System.Exception)
		{
		}
	}

	private static void UploadCrashFiles(Crash crash, Report report)
	{
		if (UserFeedbackConsumer == null || AttachmentUploadJobFactory == null)
		{
			return;
		}
		try
		{
			string[] array = (from f in crash.GetValidFiles()
				where f != null
				select f).ToArray();
			foreach (string text in array)
			{
				try
				{
					string filename = Path.GetFileName(text);
					long fileSize = new FileInfo(text).Length;
					string fileHash = string.Empty;
					using (FileStream data = File.OpenRead(text))
					{
						fileHash = data.Hash();
					}
					AttachmentUploadResponse attachmentUploadResponse = (Task.Run(async () => await UserFeedbackConsumer.PostCreateAttachmentUploadAsync(new AttachmentUploadRequest(new AttachmentMetadata(filename, fileHash, fileSize), SkipTicketAssociation: true))).Result as SuccessResult<AttachmentUploadResponse>)?.Data;
					if (attachmentUploadResponse != null && AttachmentUploadJobFactory.CreateAttachmentUploadJob(new AttachmentUploadDefinition(text, new Uri(attachmentUploadResponse.UploadUrl), fileSize, attachmentUploadResponse.UploadHeaders.ToDictionary((UploadHeader t) => t.Key, (UploadHeader t) => t.Value))).Upload().Successful)
					{
						report.Event.Metadata.Add(filename, attachmentUploadResponse.ViewUrl);
					}
				}
				catch
				{
				}
			}
		}
		catch (System.Exception exception)
		{
			Log.Error(exception);
		}
	}

	public static bool HadCrashHappened()
	{
		if (Directory.Exists(LastCrashOutputFolder))
		{
			return Directory.GetFiles(LastCrashOutputFolder).Length != 0;
		}
		return false;
	}
}
