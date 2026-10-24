using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Pro.Common.Components;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.DO.Transitions;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Messages;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Builds;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Scrollers;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Themes;
using ProPresenter.Rendering;

namespace ProPresenter.Controller.Triggering;

public class SlidePool : ISlidePool
{
	private sealed record SlideEntry(CustomSlide Slide)
	{
		public Guid[] PathIDs { get; set; } = Array.Empty<Guid>();
	}

	private sealed record PathEntry(BezierPath path)
	{
		public BezierPath Path { get; set; }

		public PathEntry(BezierPath path)
		{
			Path = path;
			base._002Ector();
		}
	}

	private readonly ConcurrentDictionary<Guid, SlideEntry> _slides = new ConcurrentDictionary<Guid, SlideEntry>();

	private readonly ConcurrentDictionary<Guid, PathEntry> _paths = new ConcurrentDictionary<Guid, PathEntry>();

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	public SlidePool(IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions)
	{
		_factoryProvider = factoryProvider;
		_transitionDescriptions = transitionDescriptions;
	}

	public CustomSlide? AddSlide(CustomSlide? slide)
	{
		if (slide == null)
		{
			return null;
		}
		SlideEntry value = new SlideEntry(slide);
		if (_slides.TryAdd(slide.ID, value))
		{
			return slide;
		}
		return null;
	}

	public Slide? AddAltTemplateSlide(CustomSlide? slide, TemplateSlide? templateSlide, Vector2<double> screenSize)
	{
		if (slide == null)
		{
			return null;
		}
		SlideEntry slideEntry = new SlideEntry(slide);
		Guid key = Guid.NewGuid();
		if (!_slides.TryAdd(key, slideEntry))
		{
			return null;
		}
		lock (slideEntry)
		{
			slide.ChangeSize(screenSize);
			if (templateSlide != null)
			{
				slide.ApplyTemplate(templateSlide, TemplateOptions.RefreshAllSlideIDs | TemplateOptions.MaintainOriginalSlideBuild);
			}
			AddPaths(slideEntry, slide);
			return slide.SerializeSlide();
		}
	}

	public Slide? AddMessageSlide(ProPresenter.DO.Messages.Message? message, TemplateSlide? templateSlide)
	{
		if (message == null || templateSlide == null)
		{
			return null;
		}
		CustomSlide customSlide = new CustomSlide(_factoryProvider, _transitionDescriptions);
		SlideEntry slideEntry = new SlideEntry(customSlide);
		Guid guid = Guid.NewGuid();
		if (!_slides.TryAdd(guid, slideEntry))
		{
			return null;
		}
		lock (slideEntry)
		{
			customSlide.ResetID(guid);
			customSlide.ApplyTemplate(templateSlide, TemplateOptions.RetainTemplateIDs);
			message.ResolveText(customSlide.GetPrimaryTextElement(useDisplayText: false));
			return customSlide.SerializeSlide();
		}
	}

	public Slide? AddCCLISlide(TemplateSlide? templateSlide, CCLIData? data, Vector2<double> screenSize)
	{
		if (templateSlide == null || data == null)
		{
			return null;
		}
		CustomSlide customSlide = new CustomSlide(_factoryProvider, _transitionDescriptions);
		SlideEntry slideEntry = new SlideEntry(customSlide);
		Guid guid = Guid.NewGuid();
		if (!_slides.TryAdd(guid, slideEntry))
		{
			return null;
		}
		lock (slideEntry)
		{
			customSlide.ResetID(guid);
			customSlide.ChangeSize(screenSize);
			customSlide.ApplyTemplate(templateSlide, TemplateOptions.RetainTemplateText);
			AddPaths(slideEntry, customSlide);
			return customSlide.SerializeSlide();
		}
	}

	public void BeginRender(Guid slideID)
	{
		if (!_slides.TryGetValue(slideID, out SlideEntry value))
		{
			return;
		}
		lock (value)
		{
			AddPaths(value, value.Slide);
		}
	}

	private void AddPaths(SlideEntry slideEntry, CustomSlide slide)
	{
		BezierPath[] array = slide.Elements.OfType<BezierPath>().ToArray();
		slideEntry.PathIDs = array.Select((BezierPath p) => p.ID).ToArray();
		BezierPath[] array2 = array;
		foreach (BezierPath bezierPath in array2)
		{
			if (_paths.TryGetValue(bezierPath.ID, out PathEntry value))
			{
				lock (value)
				{
					value.Path = bezierPath;
				}
			}
			else
			{
				value = new PathEntry(bezierPath);
				_paths.TryAdd(bezierPath.ID, value);
			}
		}
	}

	public void EndRender(Guid slideID)
	{
		if (!_slides.TryGetValue(slideID, out SlideEntry value))
		{
			return;
		}
		lock (value)
		{
			Guid[] pathIDs = value.PathIDs;
			foreach (Guid key in pathIDs)
			{
				_paths.TryRemove(key, out PathEntry _);
			}
		}
	}

	public bool DoesPathHaveText(Guid pathID, Action<BezierPath?> resolveLinkedData)
	{
		if (!_paths.TryGetValue(pathID, out PathEntry value))
		{
			return false;
		}
		lock (value)
		{
			lock (value.Path)
			{
				BezierPath bezierPath = value.Path.Clone() as BezierPath;
				resolveLinkedData(bezierPath);
				return (bezierPath as ClosedBezierPath)?.DisplayText?.AllText?.Trim().Any((char c) => c != '\u200b') == true;
			}
		}
	}

	public bool TryGetSegments(Guid pathID, RenderingMode mode, Action<BezierPath> resolveLinkedData, out IBitmapHandle[] bitmaps, out bool isVertical)
	{
		IBitmapHandle[] array = Array.Empty<RenderedBitmapHandle>();
		bitmaps = array;
		isVertical = false;
		if (!_paths.TryGetValue(pathID, out PathEntry value))
		{
			return false;
		}
		lock (value)
		{
			lock (value.Path)
			{
				resolveLinkedData(value.Path);
				isVertical = (value.Path as ClosedBezierPath)?.TextScroller?.ScrollDirection.IsVertical() == true;
				BezierPathRenderParams renderParams = new BezierPathRenderParams(includeText: true, highlight: false, includeRotation: false, includePosition: false, includeTextPlaceholder: false, 1.0, useFullsizeMedia: false, mode);
				try
				{
					array = BezierPathRenderer.DrawBezierPathSegmented(value.Path, renderParams);
					bitmaps = array;
				}
				catch (Exception ex)
				{
					Log.Warning("Failed to draw in TryGetBitmap: {0}", ex);
				}
			}
		}
		return true;
	}

	public bool TryGetBitmap(Guid pathID, RenderingMode mode, int textIndex, Action<BezierPath> resolveLinkedData, [NotNullWhen(true)] out IBitmapHandle? bitmap)
	{
		bitmap = null;
		if (!_paths.TryGetValue(pathID, out PathEntry value))
		{
			return false;
		}
		lock (value)
		{
			lock (value.Path)
			{
				resolveLinkedData(value.Path);
				BezierPathRenderParams renderParams = new BezierPathRenderParams(includeText: true, highlight: false, includeRotation: false, includePosition: false, includeTextPlaceholder: false, 1.0, useFullsizeMedia: false, mode, textIndex);
				try
				{
					bitmap = BezierPathRenderer.DrawBezierPath(value.Path, renderParams);
				}
				catch (Exception ex)
				{
					Log.Warning("Failed to draw in TryGetBitmap: {0}", ex);
					return false;
				}
			}
		}
		return true;
	}

	public bool TryGetNonResolvedPath(Guid pathID, [NotNullWhen(true)] out BezierPath? path)
	{
		path = null;
		if (!_paths.TryGetValue(pathID, out PathEntry value))
		{
			return false;
		}
		lock (value)
		{
			lock (value.Path)
			{
				path = (BezierPath)value.Path.Clone();
				return true;
			}
		}
	}

	public TextLayerInfo[] GetTextLayers(Guid pathID, Action<BezierPath> resolveLinkedData)
	{
		if (!_paths.TryGetValue(pathID, out PathEntry value))
		{
			return Array.Empty<TextLayerInfo>();
		}
		lock (value)
		{
			lock (value.Path)
			{
				if (value.Path is ClosedBezierPath closedBezierPath)
				{
					ITextScroller textScroller = closedBezierPath.TextScroller;
					if (textScroller != null && textScroller.ShouldScrollText)
					{
						return Array.Empty<TextLayerInfo>();
					}
					TextDocument textDocument = closedBezierPath.Text;
					if (closedBezierPath.RevealType == RevealType.None)
					{
						resolveLinkedData(value.Path);
						textDocument = closedBezierPath.DisplayText;
						TextLink textLink = closedBezierPath.TextLink;
						if (textLink != null && textLink.IsEnabled && !textDocument.HasText)
						{
							textDocument.InsertText(0, " ");
						}
					}
					return BezierPathRenderer.GetTextLayers(textDocument, closedBezierPath.Size, closedBezierPath.RevealType, closedBezierPath.ChildBuilds.Select((ChildBuild b) => b.Range).ToArray(), !BezierPathRenderer.DoesPathRequireLayers(closedBezierPath));
				}
				return Array.Empty<TextLayerInfo>();
			}
		}
	}
}
