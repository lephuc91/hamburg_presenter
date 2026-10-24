using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Slide.Links;

public class AudioCountdownLinkedObject : LinkedTextObjectBase, ITimerFormattable, ILoopToggle
{
	private const string TokenFormat = "${timer}";

	private bool _ignoreLooping = true;

	public override LinkedTextType LinkedTextType => LinkedTextType.AudioCountdown;

	public override string DisplayText => LocalizedStrings.Get("TEXT_LINK_AUDIO_COUNTDOWN_title");

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
				base.UndoStack?.Commit(UndoActionTypes.IgnoreLoopingAudio.ToAction(), this, "IgnoreLooping", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public static ObjectBinder<AudioCountdownLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown> CreateBinder(IEntityFactory entityFactory, AudioCountdownLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown right)
	{
		ObjectBinder<AudioCountdownLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown> objectBinder = new ObjectBinder<AudioCountdownLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown>(left, right);
		objectBinder.Bind((AudioCountdownLinkedObject l) => l.WhenPropertyChanges("FormatData"), (ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown r) => r.TimerFormat.WhenValueChanges, delegate(AudioCountdownLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown r)
		{
			ITimer.Types.IFormat format = entityFactory.Create<ITimer.Types.IFormat>();
			r.TimerFormat.Set(format);
			ObjectBinder<TimerFormatData, ITimer.Types.IFormat> objectBinder2 = TimerFormatData.CreateBinder(l.FormatData.Style, format);
			objectBinder2.InitializeRightFromLeft();
			format.RegisterLinkedDisposable(objectBinder2);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown r, AudioCountdownLinkedObject l)
		{
			ObjectBinder<TimerFormatData, ITimer.Types.IFormat> objectBinder3 = TimerFormatData.CreateBinder(l.FormatData.Style, r.TimerFormat.Value);
			objectBinder3.InitializeLeftFromRight();
			r.TimerFormat.Value.RegisterLinkedDisposable(objectBinder3);
		}).Bind((AudioCountdownLinkedObject l) => l.WhenPropertyChanges("Text"), (ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown r) => r.TimerFormatString.WhenValueChanges, delegate(AudioCountdownLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown r)
		{
			r.TimerFormatString.Set(l.FormatData.Text.Insert(l.FormatData.Tokens.TimerToken.Index.Clamp(0, l.FormatData.Text.Length), "${timer}"));
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IAudioCountdown r, AudioCountdownLinkedObject l)
		{
			l.FormatData.Tokens.TimerToken.Index = r.TimerFormatString.Value.IndexOf("${timer}");
			l.FormatData.Text = r.TimerFormatString.Value.Replace("${timer}", string.Empty);
		});
		return objectBinder;
	}

	public AudioCountdownLinkedObject()
		: this(new TimerLinkFormatData())
	{
	}

	private AudioCountdownLinkedObject(TimerLinkFormatData linkFormatData)
	{
		FormatData = linkFormatData;
		FormatData.DataModified += delegate
		{
			OnPropertyChanged("FormatData");
		};
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		return other is AudioCountdownLinkedObject;
	}

	public override int GetRenderHashCode()
	{
		return 0;
	}

	public override string GetText(ILinkData? linkData)
	{
		if (linkData?.CountdownInfo == null)
		{
			return FormatData.FormatTime(TimerFormatData.SampleTime);
		}
		CountdownData audio = linkData.CountdownInfo.Audio;
		if (!audio.IsLooping || !IgnoreLooping)
		{
			return FormatData.FormatTime(audio.TimeRemaining);
		}
		return string.Empty;
	}

	public override void FormatText(ILinkData? linkData, TextDocument? text)
	{
		if (linkData?.CountdownInfo == null || linkData.CountdownInfo.Audio.TimeRemaining < TimeSlice.Zero)
		{
			return;
		}
		IColorTrigger colorTrigger = (from t in FormatData.ColorTriggers
			where t.Time >= linkData.CountdownInfo.Audio.TimeRemaining
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

	public override ILinkedTextObject Clone()
	{
		return new AudioCountdownLinkedObject(FormatData.Clone())
		{
			IgnoreLooping = IgnoreLooping
		};
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.AudioCountdown = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AudioCountdown
		{
			TimerFormat = FormatData.Style.Serialize(),
			TimerFormatString = FormatData.Text.Insert(FormatData.Tokens.TimerToken.Index.Clamp(0, FormatData.Text.Length), "${timer}"),
			IgnoreLoopingAudio = _ignoreLooping
		};
		dataLink.AudioCountdown.ColorTriggers.AddRange(FormatData.ColorTriggers.Serialize());
	}

	public static AudioCountdownLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AudioCountdown protoAudioCountdown)
	{
		AudioCountdownLinkedObject audioCountdownLinkedObject = new AudioCountdownLinkedObject();
		audioCountdownLinkedObject.IgnoreLooping = protoAudioCountdown.IgnoreLoopingAudio;
		audioCountdownLinkedObject.FormatData.Tokens.TimerToken.Index = protoAudioCountdown.TimerFormatString.IndexOf("${timer}");
		audioCountdownLinkedObject.FormatData.Text = protoAudioCountdown.TimerFormatString.Replace("${timer}", string.Empty);
		audioCountdownLinkedObject.FormatData.Style.Deserialize(protoAudioCountdown.TimerFormat);
		audioCountdownLinkedObject.FormatData.ColorTriggers.Deserialize(protoAudioCountdown.ColorTriggers);
		return audioCountdownLinkedObject;
	}

	protected override void OnUndoStackChanged(UndoStack? undoStack)
	{
		FormatData.UndoStack = undoStack;
	}
}
