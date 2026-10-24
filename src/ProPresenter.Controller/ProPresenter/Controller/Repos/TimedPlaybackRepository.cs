using System;
using System.CodeDom.Compiler;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.SourceGenerator.Attributes;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller.Repos;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_updateSemaphore" })]
public class TimedPlaybackRepository : ITimedPlaybackRepository, IDisposable
{
	private sealed class AsyncSemaphoreSession : IDisposable
	{
		private readonly SemaphoreSlim _semaphore;

		public AsyncSemaphoreSession(SemaphoreSlim semaphore)
		{
			_semaphore = semaphore;
		}

		public void Dispose()
		{
			_semaphore.Release();
		}

		public Task WaitAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return _semaphore.WaitAsync(cancellationToken);
		}
	}

	private readonly IProCoreInstance _proCoreInstance;

	private readonly SemaphoreSlim _updateSemaphore = new SemaphoreSlim(1);

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public TimedPlaybackRepository(IProCoreInstance proCoreInstance)
	{
		_proCoreInstance = proCoreInstance;
	}

	public async Task<TriggerHandle> CreateTimedPlaybackSessionAsync(TimedPlayback data)
	{
		using (await GetExclusiveTimelineAccess())
		{
			return await Task.Run(() => _proCoreInstance.CreateTimedPlaybackSession(data));
		}
	}

	public async Task<ProResult> DestroyTimedPlaybackSessionAsync(TriggerHandle handle)
	{
		using (await GetExclusiveTimelineAccess())
		{
			return await Task.Run(() => _proCoreInstance.DestroyTimedPlaybackSession(handle));
		}
	}

	public async Task<TimedPlaybackStatus> GetTimedPlaybackSessionStatusAsync(TriggerHandle? handle)
	{
		using ProPresenterCore.ProCore.Interop.TimedPlaybackStatus timedPlaybackStatus = await Task.Run(() => _proCoreInstance.GetTimedPlaybackSessionStatus(handle));
		return new TimedPlaybackStatus(timedPlaybackStatus.Time, timedPlaybackStatus.State, timedPlaybackStatus.Framerate);
	}

	public async Task UpdateTimedPlaybackSessionAsync(TriggerHandle handle, TimedPlayback.Types.Update update)
	{
		using (await GetExclusiveTimelineAccess())
		{
			await Task.Run(() => _proCoreInstance.UpdateTimedPlaybackSession(handle, update));
		}
	}

	private async Task<IDisposable> GetExclusiveTimelineAccess()
	{
		AsyncSemaphoreSession session = new AsyncSemaphoreSession(_updateSemaphore);
		await session.WaitAsync();
		return session;
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
			_updateSemaphore.Dispose();
		}
	}
}
