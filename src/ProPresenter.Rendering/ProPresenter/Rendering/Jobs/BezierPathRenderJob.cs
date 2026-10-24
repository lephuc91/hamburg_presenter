using System;
using System.Threading.Tasks;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Components;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.Rendering.Jobs;

internal class BezierPathRenderJob : IJob
{
	private BezierPath _path;

	private RenderingMode _renderMode;

	private readonly Action<BezierPath, RenderingMode, IBitmapHandle> _completedCallback;

	private Dispatcher _callbackDispatcher;

	public JobPriority Priority => JobPriority.High;

	public string Name => "BezierPathRenderJob";

	public BezierPathRenderJob(BezierPath path, RenderingMode renderMode, Action<BezierPath, RenderingMode, IBitmapHandle> completedCallback, Dispatcher callbackDispatcher)
	{
		_path = path;
		_renderMode = renderMode;
		_completedCallback = completedCallback;
		_callbackDispatcher = callbackDispatcher;
	}

	public ValueTask ExecuteJobAsync(Worker worker)
	{
		IBitmapHandle renderedBitmap = BezierPathRenderer.RenderBezierPath(_path, _renderMode);
		_callbackDispatcher.InvokeAsync((Action)delegate
		{
			_completedCallback(_path, _renderMode, renderedBitmap);
		});
		return default(ValueTask);
	}
}
