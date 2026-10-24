using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Internet;
using Pro.Common.Logging;
using Pro.Common.MessageService;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.Common.Utility;
using ProPresenter.DO.SongSelect;

namespace ProPresenter.DO.Settings.GeneralSettings;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_saveReportsDebouncer", "_sendReportTokenSemaphore" })]
public class ReportRepository : LinkedNotifyPropertyChangedBase, IReportRepository, INotifyPropertyChanged, IDisposable
{
	private const string CCLIReportFile = "CCLIData.txt";

	private readonly string _file;

	private readonly IApp _appSettings;

	private readonly IFileService _fileService;

	private readonly ILogger _logger;

	private readonly ISongSelectConsumer? _songSelectConsumer;

	private readonly IFileSystem _fileSystem;

	private readonly IDebouncer<ICCLIReportCollection> _saveReportsDebouncer;

	private readonly SemaphoreSlim _sendReportTokenSemaphore = new SemaphoreSlim(1);

	private readonly CCLIReportCollection _reports = new CCLIReportCollection();

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public INotifyEnumerableChanged<CCLIReport> Reports => _reports;

	public ReportRepository(ISongSelectConsumer songSelectConsumer, IFileSystem fileSystem, IApp app, IFileService fileService, IMessageService messageService, IDebouncerFactory debouncerFactory, IAsyncExecutor asyncExecutor, ILogger logger, string? sourceDirectory = null)
	{
		ReportRepository reportRepository = this;
		_songSelectConsumer = songSelectConsumer;
		_fileSystem = fileSystem;
		_appSettings = app;
		_fileService = fileService;
		_logger = logger;
		_songSelectConsumer = songSelectConsumer;
		_file = Path.Combine(sourceDirectory ?? CommonPaths.Logs, "CCLIData.txt");
		_saveReportsDebouncer = debouncerFactory.Create(delegate(ICCLIReportCollection r)
		{
			asyncExecutor.ExecuteAsync(() => reportRepository.SaveReports(r));
		});
		Load().ForEach(delegate(CCLIReport report)
		{
			if (!IsWithinTheLastSevenDays(report))
			{
				report.ReportState = ReportState.Skipped;
			}
			reportRepository._reports.Add(report);
		});
		LinkAction("IsAuthorized", OnIsAuthorizedChanged);
		if (_songSelectConsumer != null)
		{
			_songSelectConsumer.PropertyChanged += base.RaiseLinkedValues;
		}
		_reports.DataModified += Save;
		messageService?.SubscribeToMessage<InternetAccessMessage>(OnInternetAccessChanged);
	}

	private void OnInternetAccessChanged(IMessage message)
	{
		if (message is InternetAccessMessage { IsInternetAccessAvailable: not false })
		{
			SendReportsAsync().ExecuteAsync();
		}
	}

	private IEnumerable<CCLIReport> Load()
	{
		EnsureFileExists();
		List<CCLIReport> reports = new List<CCLIReport>();
		AccessFile(delegate
		{
			reports.AddRange(_fileSystem.File.ReadAllLines(_file).Select(CCLIReport.Decode).NonNull());
		});
		return reports;
	}

	public void Add(CCLIReport report)
	{
		if (!string.IsNullOrEmpty(report.CCLINumber))
		{
			lock (_reports)
			{
				report = _reports.Add(report);
				Save();
			}
			IApp appSettings = _appSettings;
			if (appSettings != null && appSettings.SongSelectAutoReportSongUsage)
			{
				SendReportsAsync(report).ExecuteAsync();
			}
			else
			{
				report.ReportState = ReportState.Skipped;
			}
		}
	}

	private void OnIsAuthorizedChanged()
	{
		SendReportsAsync().ExecuteAsync();
	}

	private async Task SendReportsAsync(CCLIReport? report = null)
	{
		await _sendReportTokenSemaphore.WaitAsync();
		CCLIReport[] array;
		lock (_reports)
		{
			IEnumerable<CCLIReport> enumerable = from r in _reports
				select (r) into r
				where IsWithinTheLastSevenDays(r) && r.ReportState == ReportState.Pending
				select r;
			if (report != null && !IsReportSubmitted(_reports, report))
			{
				enumerable = enumerable.Concat(report.ToEnumerable());
			}
			enumerable = enumerable.Distinct((CCLIReport r) => r.CCLINumber);
			array = enumerable.ToArray();
		}
		if (array.Any())
		{
			await OnSendReportAsync(array);
		}
		_sendReportTokenSemaphore.Release();
	}

	private async Task OnSendReportAsync(IEnumerable<CCLIReport> reports)
	{
		ISongSelectConsumer? songSelectConsumer = _songSelectConsumer;
		if (songSelectConsumer == null || !songSelectConsumer.IsAuthorized)
		{
			return;
		}
		(await _songSelectConsumer.ReportUsagesAsync(reports.Select((CCLIReport r) => new SongSelectUsageReport
		{
			CCLINumber = r.CCLINumber,
			UsageDay = r.DateUsed
		}))).ForEach(delegate(string success)
		{
			CCLIReport cCLIReport = reports.FirstOrDefault((CCLIReport r) => r.CCLINumber == success);
			if (cCLIReport != null)
			{
				cCLIReport.ReportState = ReportState.Reported;
			}
		});
	}

	private void Save()
	{
		EnsureFileExists();
		_saveReportsDebouncer.Invoke(_reports);
	}

	private async Task SaveReports(ICCLIReportCollection reports)
	{
		IEnumerable<string> contents = reports.SelectMany((CCLIReport r) => r.Encode().ToEnumerable());
		await Task.Run(delegate
		{
			AccessFile(delegate(string s)
			{
				_fileSystem.File.WriteAllText(s, string.Join(Environment.NewLine, contents));
			});
		});
	}

	public async Task ClearAsync()
	{
		lock (_reports)
		{
			_reports.Clear();
		}
		await Task.Run(delegate
		{
			AccessFile(_fileSystem.File.Delete);
		});
	}

	public async Task ExportAsync(string file, bool excludeAutoReported)
	{
		await Task.Run(delegate
		{
			string[] contents;
			lock (_reports)
			{
				contents = _reports.Where((CCLIReport r) => !(r.ReportState.IsAnyOf(ReportState.Reported, ReportState.Pending) && excludeAutoReported)).SelectMany((CCLIReport r) => r.EncodeForExport().ToEnumerable()).ToArray();
			}
			AccessFile(delegate
			{
				_fileSystem.File.WriteAllText(file, string.Join(Environment.NewLine, contents));
			});
		});
	}

	private void EnsureFileExists()
	{
		try
		{
			using (_fileSystem.File?.Open(_file, FileMode.OpenOrCreate))
			{
			}
		}
		catch (Exception value)
		{
			_logger?.Error($"Unable to access file {_file} with error: {value}");
		}
	}

	private void AccessFile(Action<string> action)
	{
		if (((bool?)_fileService?.WaitForFileAccess(_file, enforceFileExists: false, TimeSlice.FromSeconds(5.0))) ?? false)
		{
			action(_file);
		}
	}

	private static bool IsReportSubmitted(ICCLIReportCollection reports, CCLIReport report)
	{
		return reports.Any((CCLIReport r) => r.CCLINumber == report.CCLINumber && r.ReportState == ReportState.Reported);
	}

	private static bool IsWithinTheLastSevenDays(CCLIReport report)
	{
		if (report.DateUsed > DateTime.Now)
		{
			return false;
		}
		return (DateTime.Now - report.DateUsed).Days <= 7;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_saveReportsDebouncer.Dispose();
			_sendReportTokenSemaphore.Dispose();
		}
	}
}
