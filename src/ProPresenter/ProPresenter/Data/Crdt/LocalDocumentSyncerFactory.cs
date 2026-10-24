using System;
using System.IO.Abstractions;
using Pro.Common.Concurrency;
using Pro.Entity;
using Pro.Entity.Persistence;
using ProPresenter.DO.CommonPathsWrapper;

namespace ProPresenter.Data.Crdt;

public sealed class LocalDocumentSyncerFactory : ILocalDocumentSyncerFactory
{
	private readonly ICommonPathsWrapper _commonPaths;

	private readonly IFileSystem _fileSystem;

	private readonly IThreadPoolScheduler _threadPoolScheduler;

	private readonly ICollaborationPeerIdProvider _peerIdProvider;

	private readonly IDocumentFactory _docFactory;

	private static readonly TimeSpan ThrottleTime = TimeSpan.FromMilliseconds(200L, 0L);

	public LocalDocumentSyncerFactory(ICommonPathsWrapper commonPaths, IFileSystem fileSystem, IThreadPoolScheduler threadPoolScheduler, ICollaborationPeerIdProvider peerIdProvider, IDocumentFactory docFactory)
	{
		_commonPaths = commonPaths;
		_fileSystem = fileSystem;
		_threadPoolScheduler = threadPoolScheduler;
		_peerIdProvider = peerIdProvider;
		_docFactory = docFactory;
	}

	public ILocalDocumentSyncer<ITimersLocalDocumentDoc> CreateTimer()
	{
		string storagePath = _fileSystem.Path.Combine(_commonPaths.Configuration, "Timers.proLocal");
		return new LocalDocumentSyncer<ITimersLocalDocumentDoc>(_fileSystem, storagePath, _threadPoolScheduler, _peerIdProvider, _docFactory, ThrottleTime);
	}

	public ILocalDocumentSyncer<IProPresenterLocalWorkspaceDoc> CreateWorkspace()
	{
		string storagePath = _fileSystem.Path.Combine(_commonPaths.Configuration, "Workspace.proLocal");
		return new LocalDocumentSyncer<IProPresenterLocalWorkspaceDoc>(_fileSystem, storagePath, _threadPoolScheduler, _peerIdProvider, _docFactory, ThrottleTime);
	}

	public ILocalDocumentSyncer<IMessageLocalDocumentDoc> CreateMessages()
	{
		string storagePath = _fileSystem.Path.Combine(_commonPaths.Configuration, "Messages.proLocal");
		return new LocalDocumentSyncer<IMessageLocalDocumentDoc>(_fileSystem, storagePath, _threadPoolScheduler, _peerIdProvider, _docFactory, ThrottleTime);
	}
}
