using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Cache;
using Pro.Common.Logging;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.Outputs.ssAPI;

internal class TransitionPreviewCache : WeakValueCache<TransitionPreviewKey, TransitionPreview>
{
	private const int PreviewFramesPerSecond = 24;

	private const int MinFrameCount = 8;

	private const int MaxFrameCount = 144;

	private readonly Dispatcher _dispatcher;

	private readonly IProCoreInstance _proCore;

	private volatile bool _loadJobRunning;

	private readonly ConcurrentQueue<Tuple<TransitionPreviewKey, TransitionPreview>> _loadQueue = new ConcurrentQueue<Tuple<TransitionPreviewKey, TransitionPreview>>();

	public TransitionPreviewCache(Dispatcher dispatcher, IProCoreInstance proCore)
	{
		_dispatcher = dispatcher;
		_proCore = proCore;
	}

	protected override TransitionPreview GenerateValue(TransitionPreviewKey target)
	{
		TransitionPreview transitionPreview = new TransitionPreview(target.TargetSize);
		_loadQueue.Enqueue(new Tuple<TransitionPreviewKey, TransitionPreview>(target, transitionPreview));
		EnsureLoadJobRunning();
		return transitionPreview;
	}

	private void EnsureLoadJobRunning()
	{
		if (!_loadJobRunning)
		{
			_loadJobRunning = true;
			SharedWorkerPool.Queue.AddJob(new CallbackJob(LoadJobHandler, "Transition Preview Load Job"));
		}
	}

	private ValueTask LoadJobHandler(Worker worker)
	{
		Tuple<TransitionPreviewKey, TransitionPreview> result;
		while (_loadQueue.TryDequeue(out result) && worker.ShouldRun)
		{
			TransitionPreviewKey item = result.Item1;
			TransitionPreview preview = result.Item2;
			BitmapSource[] frames;
			ProResult proResult = _proCore.GenerateTransitionImages(item.Transition.Serialize(), item.StartImage, item.EndImage, item.TargetSize.X, item.TargetSize.Y, Math.Min(Math.Max((int)Math.Ceiling(24.0 * item.Transition.Duration.TotalSeconds), 8), 144), out frames);
			if (proResult == ProResult.Success)
			{
				_dispatcher.InvokeAsync((Action)delegate
				{
					preview.OnFramesLoaded(frames);
				});
			}
			else
			{
				Log.Error("Failed to generate transition preview frames - {0}", proResult);
			}
		}
		_loadJobRunning = false;
		return default(ValueTask);
	}
}
