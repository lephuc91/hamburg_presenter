using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Slide.Links;

public class VideoCountdownLinkedObject : LinkedTextObjectBase, ITimerFormattable, ILoopToggle, ICountdownSource
{
	private const string TokenFormat = "${timer}";

	private bool _ignoreLooping = true;

	private SourceType _source;

	public override LinkedTextType LinkedTextType => LinkedTextType.VideoCountdown;

	public override string DisplayText => LocalizedStrings.Get("TEXT_LINK_VIDEO_COUNTDOWN_title");

	public override FormattingType FormattingType => FormattingType.Additional;

	public TimerLinkFormatData FormatData { get; }

	public bool IgnoreLooping
	{
		get
		{
			return _ignoreLooping;
		}
		set
		{
			SetValue("IgnoreLooping", ref _ignoreLooping, value, delegate(bool o, bool n)
			{
				base.UndoStack?.Commit(UndoActionTypes.IgnoreLoopingVideos.ToAction(), this, "IgnoreLooping", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public SourceType Source
	{
		get
		{
			return _source;
		}
		set
		{
			SetValue("Source", ref _source, value, delegate(SourceType o, SourceType n)
			{
				base.UndoStack?.Commit(UndoActionTypes.VideoCountdownSource.ToAction(), this, "Source", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public static ObjectBinder<VideoCountdownLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown> CreateBinder(IEntityFactory entityFactory, VideoCountdownLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown right)
	{
		ObjectBinder<TimerLinkFormatData, ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown> formatBinder = CreateTimerLinkFormatDataBinder(left.FormatData, right, entityFactory);
		ObjectBinder<VideoCountdownLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown> objectBinder = new ObjectBinder<VideoCountdownLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown>(left, right);
		objectBinder.Bind((VideoCountdownLinkedObject l) => l.WhenPropertyChanges("IgnoreLooping"), (ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown r) => r.IgnoreLoopingVideos.WhenValueChanges, delegate(VideoCountdownLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown r)
		{
			r.IgnoreLoopingVideos.Set(l.IgnoreLooping);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown r, VideoCountdownLinkedObject l)
		{
			l.IgnoreLooping = r.IgnoreLoopingVideos.Value;
		}).Bind((VideoCountdownLinkedObject l) => l.WhenPropertyChanges("Source"), (ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown r) => r.VideoCountdownSource.WhenValueChanges, delegate(VideoCountdownLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown r)
		{
			r.VideoCountdownSource.Set(l.Source.ToEntityVideoCountdownSource());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown r, VideoCountdownLinkedObject l)
		{
			l.Source = r.VideoCountdownSource.Value.ToSourceType();
		}).DoOnInitializeLeftFromRight(formatBinder.InitializeLeftFromRight)
			.DoOnInitializeRightFromLeft(formatBinder.InitializeRightFromLeft)
			.RegisterChildDisposable(() => formatBinder);
		return objectBinder;
	}

	public static ObjectBinder<TimerLinkFormatData, ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown> CreateTimerLinkFormatDataBinder(TimerLinkFormatData linkFormatData, ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown videoCountdown, IEntityFactory entityFactory)
	{
		ObjectBinder<TimerLinkFormatData, ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown> objectBinder = new ObjectBinder<TimerLinkFormatData, ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown>(linkFormatData, videoCountdown);
		objectBinder.Bind((TimerLinkFormatData l) => l.WhenPropertyChanges("Style"), (ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown r) => r.TimerFormat.WhenValueChanges, delegate(TimerLinkFormatData l, ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown r)
		{
			ITimer.Types.IFormat format = entityFactory.Create<ITimer.Types.IFormat>();
			r.TimerFormat.Set(format);
			ObjectBinder<TimerFormatData, ITimer.Types.IFormat> objectBinder2 = TimerFormatData.CreateBinder(l.Style, format);
			objectBinder2.InitializeRightFromLeft();
			format.RegisterLinkedDisposable(objectBinder2);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown r, TimerLinkFormatData l)
		{
			ObjectBinder<TimerFormatData, ITimer.Types.IFormat> objectBinder3 = TimerFormatData.CreateBinder(l.Style, r.TimerFormat.Value);
			objectBinder3.InitializeLeftFromRight();
			r.TimerFormat.Value.RegisterLinkedDisposable(objectBinder3);
		}).Bind((TimerLinkFormatData l) => l.WhenPropertyChanges("Text"), (ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown r) => r.TimerFormatString.WhenValueChanges.ToUnit(), delegate(TimerLinkFormatData l, ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown r)
		{
			r.TimerFormatString.Set(l.Text.Insert(l.Tokens.TimerToken.Index.Clamp(0, l.Text.Length), "${timer}"));
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown r, TimerLinkFormatData l)
		{
			l.Tokens.TimerToken.Index = r.TimerFormatString.Value.IndexOf("${timer}");
			l.Text = r.TimerFormatString.Value.Replace("${timer}", string.Empty);
		});
		return objectBinder;
	}

	public VideoCountdownLinkedObject()
		: this(new TimerLinkFormatData())
	{
	}

	private VideoCountdownLinkedObject(TimerLinkFormatData linkFormatData)
	{
		FormatData = linkFormatData;
		FormatData.DataModified += delegate
		{
			OnPropertyChanged("FormatData");
		};
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		return other is VideoCountdownLinkedObject;
	}

	public override int GetRenderHashCode()
	{
		return GetHashCode();
	}

	public override string GetText(ILinkData? linkData)
	{
		if (linkData?.CountdownInfo == null)
		{
			return FormatData.FormatTime(TimerFormatData.SampleTime);
		}
		CountdownData countdownData = GetCountdownData(linkData.CountdownInfo);
		if (!countdownData.IsLooping || !IgnoreLooping)
		{
			return FormatData.FormatTime(countdownData.TimeRemaining);
		}
		return string.Empty;
	}

	public override void FormatText(ILinkData? linkData, TextDocument? text)
	{
		if (linkData?.CountdownInfo == null)
		{
			return;
		}
		CountdownData data = GetCountdownData(linkData.CountdownInfo);
		IColorTrigger colorTrigger = (from t in FormatData.ColorTriggers
			where t.Time >= data.TimeRemaining
			orderby t.Time
			select t).FirstOrDefault();
		if (colorTrigger != null)
		{
			text?.IterateRuns(Range.All, splitRuns: false, delegate(RunBase r)
			{
				r.Settings.Fill = new SolidTextFill(colorTrigger.Color);
			});
		}
		text?.IterateRuns(FormatData.TimerPosition, splitRuns: true, delegate(RunBase r)
		{
			r.Settings.TabularNumbers = true;
		});
	}

	private CountdownData GetCountdownData(ICountdownInfo info)
	{
		return Source switch
		{
			SourceType.Presentation => info.Presentation, 
			SourceType.Announcement => info.Announcement, 
			_ => default(CountdownData), 
		};
	}

	public override ILinkedTextObject Clone()
	{
		return new VideoCountdownLinkedObject(FormatData.Clone())
		{
			IgnoreLooping = IgnoreLooping,
			Source = Source
		};
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.VideoCountdown = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VideoCountdown
		{
			TimerFormat = FormatData.Style.Serialize(),
			TimerFormatString = FormatData.Text.Insert(FormatData.Tokens.TimerToken.Index.Clamp(0, FormatData.Text.Length), "${timer}"),
			IgnoreLoopingVideos = IgnoreLooping,
			VideoCountdownSource = Source.ToProtoVideoCountdownSource()
		};
		dataLink.VideoCountdown.ColorTriggers.AddRange(FormatData.ColorTriggers.Serialize());
	}

	public static VideoCountdownLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VideoCountdown protoVideoCountdown)
	{
		VideoCountdownLinkedObject videoCountdownLinkedObject = new VideoCountdownLinkedObject();
		videoCountdownLinkedObject.IgnoreLooping = protoVideoCountdown.IgnoreLoopingVideos;
		videoCountdownLinkedObject.FormatData.Tokens.TimerToken.Index = protoVideoCountdown.TimerFormatString.IndexOf("${timer}");
		videoCountdownLinkedObject.FormatData.Text = protoVideoCountdown.TimerFormatString.Replace("${timer}", string.Empty);
		videoCountdownLinkedObject.FormatData.Style.Deserialize(protoVideoCountdown.TimerFormat);
		videoCountdownLinkedObject.FormatData.ColorTriggers.Deserialize(protoVideoCountdown.ColorTriggers);
		videoCountdownLinkedObject.Source = protoVideoCountdown.VideoCountdownSource.ToSourceType();
		return videoCountdownLinkedObject;
	}

	protected override void OnUndoStackChanged(UndoStack? undoStack)
	{
		FormatData.UndoStack = undoStack;
	}
}
