using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Components;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.Rendering.Jobs;

internal class SlidePreviewRenderJob : IJob
{
	private readonly CustomSlide _slide;

	private SlidePreviewRenderParams _renderParams;

	private CustomSlide _renderSlide;

	private SlideElementBase[] _renderSlideElements;

	private readonly Action<CustomSlide, IBitmapHandle> _completedCallback;

	private readonly Dispatcher _callbackDispatcher;

	private volatile bool _changesOccurred;

	public JobPriority Priority => JobPriority.Normal;

	public string Name => "SlidePreviewRenderJob";

	public SlidePreviewRenderJob(CustomSlide slide, SlidePreviewRenderParams renderParams, Action<CustomSlide, IBitmapHandle> completedCallback, Dispatcher callbackDispatcher)
	{
		_slide = slide;
		_renderParams = renderParams;
		_renderSlide = CopySlide(_slide, _renderParams, out _renderSlideElements);
		_completedCallback = completedCallback;
		_callbackDispatcher = callbackDispatcher;
		slide.VisualInvalidated += Slide_VisualInvalidated;
	}

	public ValueTask ExecuteJobAsync(Worker worker)
	{
		bool flag = false;
		while (!flag)
		{
			if (_changesOccurred)
			{
				InvokeDispatcher(delegate
				{
					_renderSlide = CopySlide(_slide, _renderParams, out _renderSlideElements);
					_changesOccurred = false;
				});
			}
			SlidePreviewRenderParams renderParams = _renderParams with
			{
				SlideElements = _renderSlideElements
			};
			IBitmapHandle renderedBitmap = SlidePreviewRenderer.RenderSlidePreview(_renderSlide, renderParams);
			if (!_changesOccurred)
			{
				_slide.VisualInvalidated -= Slide_VisualInvalidated;
				flag = true;
				InvokeDispatcher(delegate
				{
					_completedCallback(_slide, renderedBitmap);
				});
			}
		}
		return default(ValueTask);
	}

	private static CustomSlide CopySlide(CustomSlide original, SlidePreviewRenderParams renderParams, out SlideElementBase[] renderSlideElements)
	{
		List<SlideElementBase> clonedSlideElements = new List<SlideElementBase>();
		CustomSlide customSlide = original.Clone(delegate(SlideElementBase? o, SlideElementBase n)
		{
			SlideElementBase[]? slideElements = renderParams.SlideElements;
			if (slideElements != null && slideElements.Contains<SlideElementBase>(o))
			{
				clonedSlideElements.Add(n);
			}
		}, preserveID: true, userInitiated: true, includeBackgroundMedia: true, ignoreMediaNotifications: true);
		if (!customSlide.UseBackgroundColor && renderParams.IncludeBackground)
		{
			customSlide.UseBackgroundColor = true;
			customSlide.BackgroundColor = renderParams.SecondaryBackground;
		}
		renderSlideElements = clonedSlideElements.ToArray();
		return customSlide;
	}

	private void Slide_VisualInvalidated()
	{
		_changesOccurred = true;
	}

	private void InvokeDispatcher(Action action)
	{
		try
		{
			_callbackDispatcher.Invoke(action);
		}
		catch (TaskCanceledException)
		{
		}
	}
}
