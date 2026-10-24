using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Entity;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import.AdditionalInfo;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Import;

public class ImportProcess : NotifyPropertyChangedBase, IImportProcess, INotifyPropertyChanged
{
	public delegate void ResolveAnyConflictDelegate(RequestHandlerType handlerType, IImportRequest request, string name, out bool applyToAll, out bool skip, out bool overwrite, out bool abort);

	private readonly IRequestHandler[] _handlers;

	private readonly IProCoreInstance? _proCore;

	private readonly IMissingFontService _missingFontService;

	private readonly IJobQueue _backgroundQueue;

	private IFontDetectionSession? _fontDetectionSession;

	protected readonly List<IImportRequest> _completedRequests = new List<IImportRequest>();

	protected readonly Dictionary<IImportRequest, IImportResult?> _completedResults = new Dictionary<IImportRequest, IImportResult>();

	private IImportRequest? _currentRequest;

	private double _completedPercentage;

	private bool _importStarted;

	private volatile bool _importCanceled;

	private IDisposable? _missingFontsSubscription;

	internal IUiDispatcher Dispatcher { get; }

	public bool AllowSelectPlaylist { get; }

	public IImportRequest[] Requests { get; }

	public ResolveAnyConflictDelegate ResolveConflictProvider { get; set; } = ImportPrompt.ResolveConflict;

	public IEnumerable<IImportRequest> CompletedRequests => _completedRequests;

	public IImportRequest? CurrentRequest
	{
		get
		{
			return _currentRequest;
		}
		set
		{
			SetValue("CurrentRequest", ref _currentRequest, value);
		}
	}

	public IPowerPointInfo? PowerPointInfo { get; set; }

	public double CompletedPercentage
	{
		get
		{
			return _completedPercentage;
		}
		set
		{
			SetValue("CompletedPercentage", ref _completedPercentage, value);
		}
	}

	public ProPresenter.DO.Librarian.ILibrary? SelectedLibrary { get; set; }

	public IPlaylist<ProPresenterCue>? SelectedPlaylist { get; set; }

	public bool ImportCanceled => _importCanceled;

	public bool ShowProgressDialog { get; set; } = true;

	internal IFileChangedLibrary? FileChangedLibrary { get; }

	public IImportRequest? SelectionRequest { get; set; }

	public IEntityFactory EntityFactory { get; }

	public IEnumerable<MissingFontInfo> DetectedMissingFonts => (IEnumerable<MissingFontInfo>)(((object)_fontDetectionSession?.DetectedMissingFonts) ?? ((object)Array.Empty<MissingFontInfo>()));

	public bool HasMissingFonts => _fontDetectionSession?.HasMissingFonts ?? false;

	public event Action<IImportProcess>? ImportComplete;

	public event Action<IImportProcess, IEnumerable<MissingFontInfo>>? MissingFontsDetected;

	public ImportProcess(IEnumerable<IImportRequest> requests, IRequestHandler[] handlers, IProCoreInstance proCore, IUiDispatcher dispatcher, IEntityFactory entityFactory, IMissingFontService missingFontService, IJobQueue jobQueue, IFileChangedLibrary? fileChangedLibrary = null, bool allowSelectPlaylist = true)
	{
		Requests = requests?.ToArray() ?? Array.Empty<IImportRequest>();
		Dispatcher = dispatcher;
		_handlers = handlers;
		_proCore = proCore;
		_missingFontService = missingFontService ?? throw new ArgumentNullException("missingFontService");
		_backgroundQueue = jobQueue;
		FileChangedLibrary = fileChangedLibrary ?? new MediaFileChangedLibrary();
		EntityFactory = entityFactory;
		AllowSelectPlaylist = allowSelectPlaylist;
	}

	public void StartImport()
	{
		if (_importStarted)
		{
			throw new InvalidOperationException();
		}
		_importStarted = true;
		if (Requests.Any((IImportRequest request) => (request is FileImportRequest fileImportRequest && (!fileImportRequest.Filename.IsMediaFile() || fileImportRequest.Filename.IsProThemeFile())) || request is GeneratedPresentationRequest))
		{
			_fontDetectionSession = _missingFontService.CreateDetectionSession();
			_missingFontsSubscription = _fontDetectionSession.WhenMissingFontsDetected.Subscribe<IEnumerable<MissingFontInfo>>((Action<IEnumerable<MissingFontInfo>>)OnMissingFontsDetected, (Action)delegate
			{
				_fontDetectionSession?.Dispose();
				_fontDetectionSession = null;
				_missingFontsSubscription?.Dispose();
				_missingFontsSubscription = null;
			});
		}
		_backgroundQueue.AddJob(async delegate
		{
			bool applyToAll = false;
			bool skip = false;
			bool overwrite = false;
			bool abort = false;
			List<IImportRequest> remainingRequests = new List<IImportRequest>(Requests);
			Dictionary<IImportRequest, List<IImportRequest>> childRequestMap = new Dictionary<IImportRequest, List<IImportRequest>>();
			List<IImportRequest> importErrorRequests = new List<IImportRequest>();
			UpdateStatusDelegate updateStatus = delegate(IImportRequest request, ImportStatus status)
			{
				InvokeWithDispatcherAndCatchDispatcherShutDown(delegate
				{
					request.Status = status;
					CurrentRequest = request;
				});
			};
			Action<IImportRequest, IImportResult?> finishRequest = delegate(IImportRequest request, IImportResult? result)
			{
				remainingRequests.Remove(request);
				_completedRequests.Add(request);
				_completedResults[request] = result;
				_fontDetectionSession?.TrackPresentation(request, result);
				InvokeWithDispatcherAndCatchDispatcherShutDown(delegate
				{
					if (request.Status != ImportStatus.Failed)
					{
						request.Status = ImportStatus.Succeeded;
					}
					CompletedPercentage = GetCompletedPercentage(Requests, remainingRequests, childRequestMap, includeParent: false);
				});
			};
			HandlingCompleteDelegate completeRequest = delegate(IImportRequest request, RequestHandlerType handlerType, IImportResult? result)
			{
				if (!_importCanceled && remainingRequests.Contains(request))
				{
					FileImportRequest fileRequest = request as FileImportRequest;
					if (result != null && !(result is NOPResult) && !(result is ErrorResult))
					{
						MediaManagementFileImportResult importResult = result as MediaManagementFileImportResult;
						if (importResult != null && fileRequest != null)
						{
							InvokeWithDispatcherAndCatchDispatcherShutDown(delegate
							{
								fileRequest.CompleteCallback?.Invoke(fileRequest.FullName, fileRequest.FinalName ?? fileRequest.FullName, importResult.CreatedMedia);
							});
							finishRequest(request, result);
							return;
						}
						string name = request.SanitizedFilename;
						bool fileExist = false;
						InvokeWithDispatcherAndCatchDispatcherShutDown(delegate
						{
							request.Status = ImportStatus.Importing;
							CurrentRequest = request;
							fileExist = ImportPrompt.ItemExists(this, handlerType, name, request) == true;
							if (fileExist)
							{
								if (!applyToAll)
								{
									ResolveConflictProvider(handlerType, request, name, out applyToAll, out skip, out overwrite, out abort);
								}
								if (abort)
								{
									CancelImport();
								}
								else if (!skip && !overwrite && !_importCanceled)
								{
									name = ImportPrompt.DuplicateName(this, handlerType, name, request);
									request.FinalName = name ?? string.Empty;
									FileChangedLibrary?.UpdateName(request, name ?? string.Empty);
								}
								else if (skip)
								{
									request.Status = ImportStatus.Skipped;
								}
							}
						});
						if (!_importCanceled)
						{
							request.FinalName = (string.IsNullOrWhiteSpace(request.FinalName) ? name : request.FinalName);
							if (!(skip && fileExist))
							{
								result.CompleteImport(this, request, request.FinalName, overwrite, Dispatcher, fileRequest?.ContainerId ?? string.Empty);
							}
							FileImportRequest fileImportRequest2 = request as FileImportRequest;
							if (fileImportRequest2 != null)
							{
								fileImportRequest2.OverWrite = overwrite;
								if (fileImportRequest2.CompleteCallback != null)
								{
									Dispatcher.InvokeAsync(delegate
									{
										fileImportRequest2.CompleteCallback(fileImportRequest2.FullName, result.GetTargetFilename(request), null);
									});
								}
							}
							else
							{
								MemoryImportRequest memoryImportRequest = request as MemoryImportRequest;
								if (memoryImportRequest != null && memoryImportRequest.CompleteCallback != null)
								{
									Dispatcher.InvokeAsync(delegate
									{
										memoryImportRequest.CompleteCallback(result.GetTargetFilename(request));
									});
								}
							}
						}
					}
					else if (result is ErrorResult)
					{
						result.CompleteImport(this, request, request.FinalName, overwrite, Dispatcher, fileRequest?.ContainerId ?? string.Empty);
						updateStatus(request, ImportStatus.Failed);
						importErrorRequests.Add(request);
					}
					else if (result == null)
					{
						updateStatus(request, ImportStatus.Failed);
						importErrorRequests.Add(request);
					}
					if (!_importCanceled)
					{
						finishRequest(request, result);
					}
				}
			};
			IRequestHandler[] handlers = _handlers;
			foreach (IRequestHandler handler in handlers)
			{
				if (_importCanceled || !remainingRequests.Any())
				{
					break;
				}
				IImportRequest[] array = remainingRequests.Where((IImportRequest r) => handler.CanHandle(r)).ToArray();
				if (array.Any())
				{
					try
					{
						await handler.HandleAsync(this, _proCore, array, updateStatus, completeRequest, delegate(IImportRequest orignalRequest, IImportRequest newRequest)
						{
							if (!childRequestMap.TryGetValue(orignalRequest, out List<IImportRequest> value))
							{
								value = new List<IImportRequest>();
								childRequestMap.Add(orignalRequest, value);
							}
							remainingRequests.Add(newRequest);
							value.Add(newRequest);
						});
					}
					catch (Exception exception)
					{
						Log.Error(exception);
						break;
					}
				}
			}
			remainingRequests.ToArray().ForEach(delegate(IImportRequest r)
			{
				completeRequest(r, RequestHandlerType.Unknown, null);
			});
			InvokeWithDispatcherAndCatchDispatcherShutDown(delegate
			{
				ImportHelper.ShowImportFileNotSupportedDialog(importErrorRequests.Where((IImportRequest r) => r.Status == ImportStatus.Failed && r is FileImportRequest));
			});
			InvokeWithDispatcherAndCatchDispatcherShutDown(delegate
			{
				_importStarted = false;
				this.ImportComplete?.Invoke(this);
				ImportPrompt.ImportCompleted(this);
			});
		});
		InvokeWithDispatcherAndCatchDispatcherShutDown(delegate
		{
			ImportPrompt.ImportStarted(this);
		});
	}

	public void CancelImport()
	{
		_importCanceled = true;
		_fontDetectionSession?.Cancel();
		_fontDetectionSession?.Dispose();
		_fontDetectionSession = null;
		_missingFontsSubscription?.Dispose();
		_missingFontsSubscription = null;
	}

	public IImportResult? GetResultOfRequest(IImportRequest request)
	{
		if (_completedResults.TryGetValue(request, out IImportResult value))
		{
			return value;
		}
		return null;
	}

	private void OnMissingFontsDetected(IEnumerable<MissingFontInfo> missingFonts)
	{
		this.MissingFontsDetected?.Invoke(this, missingFonts);
	}

	private double GetCompletedPercentage(IEnumerable<IImportRequest> initialRequests, IEnumerable<IImportRequest> remainingRequests, Dictionary<IImportRequest, List<IImportRequest>> childRequestMap, bool includeParent)
	{
		double num = 1.0 / (double)(initialRequests.Count() + (includeParent ? 1 : 0));
		double num2 = (includeParent ? num : 0.0);
		foreach (IImportRequest initialRequest in initialRequests)
		{
			num2 += GetCompletedPercentage(initialRequest, remainingRequests, childRequestMap) * num;
		}
		return num2;
	}

	private double GetCompletedPercentage(IImportRequest request, IEnumerable<IImportRequest> remainingRequests, Dictionary<IImportRequest, List<IImportRequest>> childRequestMap)
	{
		if (remainingRequests.Contains(request))
		{
			return 0.0;
		}
		if (childRequestMap.TryGetValue(request, out List<IImportRequest> value))
		{
			return GetCompletedPercentage(value, remainingRequests, childRequestMap, includeParent: true);
		}
		return 1.0;
	}

	private void InvokeWithDispatcherAndCatchDispatcherShutDown(Action actionToInvoke)
	{
		try
		{
			Dispatcher.Invoke(actionToInvoke);
		}
		catch (TaskCanceledException)
		{
		}
	}
}
