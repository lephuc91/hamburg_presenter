using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Components;
using Pro.Common.Logging;
using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.DO.Export;

public class ExportProcess : NotifyPropertyChangedBase, IExportProcess
{
	private readonly IEnumerable<IRequestHandler> _handlers;

	private readonly IExportRequest[] _requests;

	private IExportRequest? _currentRequest;

	private bool _exportStarted;

	private int _completedCount;

	private bool _applyToAll;

	private ConflictResolveResult _conflictResolveResult;

	internal Dispatcher Dispatcher { get; }

	public string Destination { get; }

	public bool ExportCanceled { get; private set; }

	public int CompletedCount
	{
		get
		{
			return _completedCount;
		}
		private set
		{
			SetValue("CompletedCount", ref _completedCount, value);
		}
	}

	public IExportRequest? CurrentRequest
	{
		get
		{
			return _currentRequest;
		}
		private set
		{
			SetValue("CurrentRequest", ref _currentRequest, value);
		}
	}

	public event Action? ExportComplete;

	public ExportProcess(IEnumerable<IExportRequest> requests, string destination, IEnumerable<IRequestHandler> handlers, Dispatcher? dispatcher = null)
	{
		_handlers = handlers;
		_requests = requests.ToArray();
		Dispatcher = dispatcher ?? Dispatcher.CurrentDispatcher;
		Destination = destination;
	}

	public void StartExport()
	{
		if (_exportStarted)
		{
			throw new InvalidOperationException();
		}
		_exportStarted = true;
		SharedWorkerPool.Queue.AddJob(delegate
		{
			foreach (IRequestHandler handler in _handlers)
			{
				if (ExportCanceled)
				{
					break;
				}
				foreach (IExportRequest item in _requests.Where(handler.CanHandle))
				{
					if (_conflictResolveResult == ConflictResolveResult.Abort)
					{
						break;
					}
					Handle(handler, item, ResolveConflict);
				}
				if (_conflictResolveResult == ConflictResolveResult.Abort)
				{
					break;
				}
			}
			Dispatcher.Invoke((Action)delegate
			{
				this.ExportComplete?.Invoke();
			});
		});
		ExportPrompt.ExportStarted(this);
	}

	private ConflictResolveResult ResolveConflict(string name, string folder)
	{
		if (!_applyToAll)
		{
			Dispatcher.Invoke((Action)delegate
			{
				(ConflictResolveResult, bool) tuple = ExportHelper.ResolveConflict(name, folder);
				_conflictResolveResult = tuple.Item1;
				_applyToAll = tuple.Item2;
			});
		}
		return _conflictResolveResult;
	}

	private void Handle(IRequestHandler handler, IExportRequest request, ResolveConflictDelegate resolveConflict)
	{
		try
		{
			handler.Handle(this, request, UpdateStatus, resolveConflict);
		}
		catch (Exception ex)
		{
			Log.Error("There was an error in " + handler.GetType().FullName + " when exporting " + request.CurrentItemName);
			Log.Error(ex.Message);
			Dispatcher.Invoke((Action)delegate
			{
				MessageDialogService.ShowAlert(LocalizedStrings.Get("EXPORT_ERROR_GENERAL_ERROR_message", new object[1] { request.CurrentItemName }));
			});
			CancelExport();
		}
	}

	private void UpdateStatus(IExportRequest request)
	{
		Dispatcher.Invoke((Action)delegate
		{
			CurrentRequest = request;
			int completedCount = CompletedCount;
			CompletedCount = completedCount + 1;
		});
	}

	public void CancelExport()
	{
		ExportCanceled = true;
	}
}
