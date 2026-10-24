using System;
using System.CodeDom.Compiler;
using System.IO.Abstractions;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Pro.Common.Concurrency;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.Entity.Factory;
using Pro.Entity.Persistence;

namespace ProPresenter.Data.Crdt;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_changeSubscription", "_document" })]
public sealed class LocalDocumentSyncer<T> : ILocalDocumentSyncer<T>, IDisposable where T : IEntityDocument
{
	private readonly IFileSystem _fileSystem;

	private readonly string _documentPath;

	private readonly T _document;

	private readonly IDisposable _changeSubscription;

	private readonly Subject<Unit> _stopSignal = new Subject<Unit>();

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public T Document => _document;

	public LocalDocumentSyncer(IFileSystem fileSystem, string storagePath, IThreadPoolScheduler scheduler, ICollaborationPeerIdProvider peerIdProvider, IDocFactory<T> documentFactory, TimeSpan throttleTimeout)
	{
		_fileSystem = fileSystem;
		_documentPath = storagePath;
		_document = LoadDocument(peerIdProvider, documentFactory);
		_changeSubscription = _document.WhenChangeHappened.TakeUntil(_stopSignal).Throttle(throttleTimeout, scheduler.Scheduler).Subscribe(SaveDocument);
	}

	private T LoadDocument(ICollaborationPeerIdProvider peerIdProvider, IDocFactory<T> documentFactory)
	{
		bool num = _fileSystem.File.Exists(_documentPath);
		T result = documentFactory.CreateInstance(peerIdProvider.CollaborationPeerId);
		if (num)
		{
			try
			{
				ref T reference = ref result;
				T val = default(T);
				if (val == null)
				{
					val = reference;
					reference = ref val;
				}
				reference.Import(_fileSystem.File.ReadAllBytes(_documentPath));
			}
			catch (Exception value)
			{
				Log.Error($"Failed to load local document. - {value}");
			}
		}
		return result;
	}

	private void SaveDocument((ICanExportSnapshot provider, bool _) s)
	{
		try
		{
			byte[] bytes = s.provider.ExportFullSnapshot();
			_fileSystem.Directory.CreateDirectory(_fileSystem.Path.GetDirectoryName(_documentPath));
			_fileSystem.File.WriteAllBytes(_documentPath, bytes);
		}
		catch (Exception value)
		{
			Log.Error($"Failed to save local document. - {value}");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
			_changeSubscription.Dispose();
			_document.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		_stopSignal.OnNext(Unit.Default);
		_stopSignal.OnCompleted();
	}
}
