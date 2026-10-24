using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Feathers;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Custom.Elements.Strokes;
using ProPresenter.DO.Slide.Links;
using ProPresenter.Rendering.Drawing.Feathers;
using ProPresenter.Rendering.Drawing.Fills;
using ProPresenter.Rendering.Drawing.Links;
using ProPresenter.Rendering.Drawing.Links.Text;
using ProPresenter.Rendering.Drawing.Shadows;
using ProPresenter.Rendering.Drawing.Strokes;

namespace ProPresenter.Rendering.Drawing;

internal class DrawerSet
{
	public ReadOnlyDictionary<FillType, IDrawer<IFill>> FillDrawers { get; }

	public ReadOnlyDictionary<ShadowType, IDrawer<IShadow>> ShadowDrawers { get; }

	public ReadOnlyDictionary<StrokeType, IDrawer<IStroke>> StrokeDrawers { get; }

	public ReadOnlyDictionary<FeatherType, IDrawer<IFeather>> FeatherDrawers { get; }

	public ReadOnlyDictionary<LinkedTextType, IDrawer<ILinkedTextObject>> TextLinkDrawers { get; }

	public ReadOnlyDictionary<LinkedFillType, IDrawer<ILinkedFillObject>> FillLinkDrawers { get; }

	public ReadOnlyDictionary<MiscellaneousDrawerType, IDrawer<MiscellaneousDrawerType>> MiscellaneousDrawers { get; }

	public DrawerSet()
	{
		FillDrawers = new ReadOnlyDictionary<FillType, IDrawer<IFill>>(new Dictionary<FillType, IDrawer<IFill>>
		{
			{
				FillType.Solid,
				new SolidFillDrawer()
			},
			{
				FillType.Gradient,
				new GradientFillDrawer()
			},
			{
				FillType.Media,
				new MediaFillDrawer()
			},
			{
				FillType.Live,
				new LiveVideoFillDrawer()
			},
			{
				FillType.HTML,
				new HTMLFillDrawer()
			},
			{
				FillType.SlidePreview,
				new SlidePreviewFillDrawer()
			},
			{
				FillType.OutputScreen,
				new OutputScreenFillDrawer()
			},
			{
				FillType.PDF,
				new PDFFillDrawer()
			},
			{
				FillType.Bitmap,
				new BitmapFillDrawer()
			},
			{
				FillType.BackgroundEffectBlur,
				new BackgroundEffectsFillDrawer()
			},
			{
				FillType.BackgroundEffectInvert,
				new BackgroundEffectsFillDrawer()
			}
		});
		ShadowDrawers = new ReadOnlyDictionary<ShadowType, IDrawer<IShadow>>(new Dictionary<ShadowType, IDrawer<IShadow>> { 
		{
			ShadowType.Drop,
			new DropShadowDrawer()
		} });
		StrokeDrawers = new ReadOnlyDictionary<StrokeType, IDrawer<IStroke>>(new Dictionary<StrokeType, IDrawer<IStroke>> { 
		{
			StrokeType.Default,
			new StrokeDrawer()
		} });
		FeatherDrawers = new ReadOnlyDictionary<FeatherType, IDrawer<IFeather>>(new Dictionary<FeatherType, IDrawer<IFeather>> { 
		{
			FeatherType.Inside,
			new InsideFeatherDrawer()
		} });
		TextLinkDrawers = new ReadOnlyDictionary<LinkedTextType, IDrawer<ILinkedTextObject>>(new Dictionary<LinkedTextType, IDrawer<ILinkedTextObject>>
		{
			{
				LinkedTextType.CCLITemplate,
				new CCLITextDrawer()
			},
			{
				LinkedTextType.Clock,
				new ClockDrawer()
			},
			{
				LinkedTextType.Element,
				new ElementTextDrawer()
			},
			{
				LinkedTextType.Timer,
				new TimerDrawer()
			},
			{
				LinkedTextType.StageMessage,
				new StageMessageDrawer()
			},
			{
				LinkedTextType.CurrentSlide,
				new SlideTextDrawer()
			},
			{
				LinkedTextType.NextSlide,
				new SlideTextDrawer()
			},
			{
				LinkedTextType.SlideLabel,
				new SlideLabelTextDrawer()
			},
			{
				LinkedTextType.VideoCountdown,
				new VideoCountdownDrawer()
			},
			{
				LinkedTextType.AudioCountdown,
				new AudioCountdownDrawer()
			},
			{
				LinkedTextType.GroupName,
				new GroupNameDrawer()
			},
			{
				LinkedTextType.PlaylistItem,
				new PlaylistItemDrawer()
			},
			{
				LinkedTextType.AutoAdvanceTimeRemaing,
				new AutoAdvanceDrawer()
			},
			{
				LinkedTextType.PresentationName,
				new PresentationNameDrawer()
			},
			{
				LinkedTextType.PresentationNotes,
				new PresentationNotesDrawer()
			},
			{
				LinkedTextType.Capture,
				new CaptureTextDrawer()
			},
			{
				LinkedTextType.SlideCount,
				new SlideCountDrawer()
			},
			{
				LinkedTextType.FileFeed,
				new FileFeedDrawer()
			},
			{
				LinkedTextType.RssFeed,
				new RssFeedDrawer()
			},
			{
				LinkedTextType.PlaybackMarkerText,
				new PlaybackMarkerTextDrawer()
			},
			{
				LinkedTextType.TimecodeText,
				new TimecodeTextDrawer()
			}
		});
		FillLinkDrawers = new ReadOnlyDictionary<LinkedFillType, IDrawer<ILinkedFillObject>>(new Dictionary<LinkedFillType, IDrawer<ILinkedFillObject>>
		{
			{
				LinkedFillType.ChordChart,
				new ChordChartDrawer()
			},
			{
				LinkedFillType.Element,
				new ElementDrawer()
			},
			{
				LinkedFillType.PreviewScreen,
				new PreviewScreenDrawer()
			},
			{
				LinkedFillType.PCOLive,
				new PCOLiveDrawer()
			},
			{
				LinkedFillType.SlidePreview,
				new SlidePreviewDrawer()
			},
			{
				LinkedFillType.GroupColor,
				new GroupColorDrawer()
			},
			{
				LinkedFillType.SlideLabelColor,
				new SlideLabelColorDrawer()
			},
			{
				LinkedFillType.CaptureStatusColor,
				new CaptureStatusColorDrawer()
			},
			{
				LinkedFillType.PlaybackMarkerColor,
				new PlaybackMarkerColorDrawer()
			},
			{
				LinkedFillType.TimecodeStatusColor,
				new TimecodeStatusColorDrawer()
			}
		});
		MiscellaneousDrawers = new ReadOnlyDictionary<MiscellaneousDrawerType, IDrawer<MiscellaneousDrawerType>>(new Dictionary<MiscellaneousDrawerType, IDrawer<MiscellaneousDrawerType>> { 
		{
			MiscellaneousDrawerType.LinkInfo,
			new LinkInfoDrawer()
		} });
	}

	public IDrawer<IFill> GetFillDrawer(FillType type)
	{
		if (!FillDrawers.TryGetValue(type, out IDrawer<IFill> value))
		{
			throw new Exception(type.ToString() + " fill type is not supported");
		}
		return value;
	}

	public IDrawer<IShadow> GetShadowDrawer(ShadowType type)
	{
		if (!ShadowDrawers.TryGetValue(type, out IDrawer<IShadow> value))
		{
			throw new Exception(type.ToString() + " shadow type is not supported");
		}
		return value;
	}

	public IDrawer<IStroke> GetStrokeDrawer(StrokeType type)
	{
		if (!StrokeDrawers.TryGetValue(type, out IDrawer<IStroke> value))
		{
			throw new Exception(type.ToString() + " stroke type is not supported");
		}
		return value;
	}

	public IDrawer<IFeather> GetFeatherDrawer(FeatherType type)
	{
		if (!FeatherDrawers.TryGetValue(type, out IDrawer<IFeather> value))
		{
			throw new Exception(type.ToString() + " feather type is not supported");
		}
		return value;
	}

	public IDrawer<ILinkedTextObject> GetTextLinkDrawer(LinkedTextType type)
	{
		if (!TextLinkDrawers.TryGetValue(type, out IDrawer<ILinkedTextObject> value))
		{
			throw new Exception(type.ToString() + " text link type is not supported");
		}
		return value;
	}

	public IDrawer<ILinkedFillObject> GetFillLinkDrawer(LinkedFillType type)
	{
		if (!FillLinkDrawers.TryGetValue(type, out IDrawer<ILinkedFillObject> value))
		{
			throw new Exception(type.ToString() + " fill link type is not supported");
		}
		return value;
	}

	public IDrawer<MiscellaneousDrawerType> GetMiscellaneousDrawer(MiscellaneousDrawerType type)
	{
		if (!MiscellaneousDrawers.TryGetValue(type, out IDrawer<MiscellaneousDrawerType> value))
		{
			throw new Exception(type.ToString() + " miscellaneous type is not supported");
		}
		return value;
	}
}
