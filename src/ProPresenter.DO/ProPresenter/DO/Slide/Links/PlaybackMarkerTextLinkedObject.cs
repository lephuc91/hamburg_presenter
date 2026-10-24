using System;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Linq;
using System.Windows.Media;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Slide.Links;

public class PlaybackMarkerTextLinkedObject : LinkedTextObjectBase
{
	private static readonly System.Windows.Media.Color ImplicitMarkerColor = System.Windows.Media.Color.FromRgb(143, 143, 143);

	private PlaybackMarkerIdentifier _markerIdentifier;

	private PlaybackMarkerTextType _textType;

	private TimerFormatData _timerFormat;

	private bool _usesMarkerColor;

	public override LinkedTextType LinkedTextType => LinkedTextType.PlaybackMarkerText;

	public override string DisplayText => LocalizedStrings.Get(TextType switch
	{
		PlaybackMarkerTextType.Name => "TEXT_LINK_PLAYBACK_MARKER_NAME_title", 
		PlaybackMarkerTextType.Time => "TEXT_LINK_PLAYBACK_MARKER_TIME_title", 
		_ => throw new NotSupportedException(), 
	}) + " - " + MarkerIdentifier.DisplayText;

	public override FormattingType FormattingType => FormattingType.Additional;

	public PlaybackMarkerIdentifier MarkerIdentifier
	{
		get
		{
			return _markerIdentifier;
		}
		set
		{
			SetValue("MarkerIdentifier", ref _markerIdentifier, value, delegate(PlaybackMarkerIdentifier o, PlaybackMarkerIdentifier n)
			{
				base.UndoStack?.Commit(UndoActionTypes.PlaybackMarkerIdentifier.ToAction(), this, "MarkerIdentifier", o, n);
				OnDataModified();
			});
		}
	}

	public PlaybackMarkerTextType TextType
	{
		get
		{
			return _textType;
		}
		set
		{
			SetValue("TextType", ref _textType, value, delegate(PlaybackMarkerTextType o, PlaybackMarkerTextType n)
			{
				base.UndoStack?.Commit(UndoActionTypes.PlaybackMarkerTextType.ToAction(), this, "TextType", o, n);
				OnDataModified();
			});
		}
	}

	public TimerFormatData TimerFormat
	{
		get
		{
			return _timerFormat;
		}
		set
		{
			SetValue("TimerFormat", ref _timerFormat, value, delegate(TimerFormatData o, TimerFormatData n)
			{
				base.UndoStack?.Commit(UndoActionTypes.PlaybackMarkerTimerFormat.ToAction(), this, "TimerFormat", o, n);
				OnDataModified();
			});
		}
	}

	public bool UsesMarkerColor
	{
		get
		{
			return _usesMarkerColor;
		}
		set
		{
			SetValue("UsesMarkerColor", ref _usesMarkerColor, value, delegate(bool o, bool n)
			{
				base.UndoStack?.Commit(UndoActionTypes.PlaybackMarkerTextUsesColor.ToAction(), this, "UsesMarkerColor", o, n);
				OnDataModified();
			});
		}
	}

	public static ObjectBinder<PlaybackMarkerTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText> CreateBinder(IEntityFactory entityFactory, PlaybackMarkerTextLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText right)
	{
		ObjectBinder<PlaybackMarkerTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText> objectBinder = new ObjectBinder<PlaybackMarkerTextLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText>(left, right);
		objectBinder.Bind((PlaybackMarkerTextLinkedObject l) => l.WhenPropertyChanges("MarkerIdentifier"), (ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText r) => r.Identifier.WhenAnyValueChanges, delegate(PlaybackMarkerTextLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText r)
		{
			r.Identifier.Value.Destination.Set(l.MarkerIdentifier.Destination.ToEntityPlaybackMarkerIdentificationDestination());
			r.Identifier.Value.Type.Set(l.MarkerIdentifier.Type.ToEntityPlaybackMarkerIdentifierType());
			r.Identifier.Value.Name.Set(l.MarkerIdentifier.Name);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText r, PlaybackMarkerTextLinkedObject l)
		{
			l.MarkerIdentifier = new PlaybackMarkerIdentifier(r.Identifier.Value.Destination.Value.ToPlaybackMarkerIdentifierDestination(), r.Identifier.Value.Type.Value.ToPlaybackMarkerIdentifierType(), r.Identifier.Value.Name.Value);
		}).Bind((PlaybackMarkerTextLinkedObject l) => l.WhenPropertyChanges("UsesMarkerColor"), (ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText r) => r.ShouldUseMarkerColor.WhenValueChanges, delegate(PlaybackMarkerTextLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText r)
		{
			r.ShouldUseMarkerColor.Set(l.UsesMarkerColor);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText r, PlaybackMarkerTextLinkedObject l)
		{
			l.UsesMarkerColor = r.ShouldUseMarkerColor.Value;
		}).Bind((PlaybackMarkerTextLinkedObject l) => l.WhenPropertyChanges("TextType").ToUnit().Merge(l.WhenPropertyChanges("TimerFormat").ToUnit()), (ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText r) => r.TextType.WhenValueChanges, delegate(PlaybackMarkerTextLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText r)
		{
			switch (l.TextType)
			{
			case PlaybackMarkerTextType.Name:
				r.TextType.Set(entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITextType.IName>());
				break;
			case PlaybackMarkerTextType.Time:
			{
				ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITextType.ITime time = entityFactory.Create<ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITextType.ITime>();
				r.TextType.Set(time);
				ObjectBinder<TimerFormatData, ITimer.Types.IFormat> objectBinder2 = TimerFormatData.CreateBinder(l.TimerFormat, time.Value.Format.Value);
				objectBinder2.InitializeRightFromLeft();
				time.Value.Format.Value.RegisterLinkedDisposable(objectBinder2);
				break;
			}
			}
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText r, PlaybackMarkerTextLinkedObject l)
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITextType value = r.TextType.Value;
			if (!(value is ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITextType.IName))
			{
				if (value is ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerText.Types.ITextType.ITime time2)
				{
					l.TextType = PlaybackMarkerTextType.Time;
					l.TimerFormat = new TimerFormatData();
					ObjectBinder<TimerFormatData, ITimer.Types.IFormat> objectBinder3 = TimerFormatData.CreateBinder(l.TimerFormat, time2.Value.Format.Value);
					objectBinder3.InitializeLeftFromRight();
					time2.Value.Format.Value.RegisterLinkedDisposable(objectBinder3);
				}
			}
			else
			{
				l.TextType = PlaybackMarkerTextType.Name;
			}
		});
		return objectBinder;
	}

	public PlaybackMarkerTextLinkedObject()
	{
		_markerIdentifier = new PlaybackMarkerIdentifier(PlaybackMarkerIdentifierDestination.Presentation, PlaybackMarkerIdentifierType.Next);
		_textType = PlaybackMarkerTextType.Time;
		_timerFormat = new TimerFormatData(TimerFormatStyle.Long, TimerFormatStyle.Long, TimerFormatStyle.Long, TimerFormatStyle.Long);
		_usesMarkerColor = true;
	}

	public PlaybackMarkerTextLinkedObject(PlaybackMarkerIdentifier markerIdentifier, PlaybackMarkerTextType textType, TimerFormatData timerFormat, bool usesMarkerColor)
	{
		_markerIdentifier = markerIdentifier;
		_textType = textType;
		_timerFormat = timerFormat;
		_usesMarkerColor = usesMarkerColor;
	}

	public override string GetText(ILinkData? linkData)
	{
		if (linkData == null)
		{
			if (TextType == PlaybackMarkerTextType.Time)
			{
				return TimerFormat.FormatTime(TimerFormatData.SampleTime);
			}
			return LocalizedStrings.Get("TEXT_LINK_PLAYBACK_MARKER_NAME_title");
		}
		string result = string.Empty;
		TimeSlice? time = TimeSlice.Zero;
		IPlaybackMarkerInformation playbackMarkerInformation = MarkerIdentifier.SelectLinkData(linkData);
		if (playbackMarkerInformation != null)
		{
			IPlaybackMarker playbackMarker = playbackMarkerInformation.FindMarker(MarkerIdentifier, ImplicitMarkerColor);
			if (playbackMarker != null)
			{
				result = playbackMarker.Name;
				time = playbackMarker.Timestamp - playbackMarkerInformation.Elapsed;
			}
			else if (MarkerIdentifier.Type == PlaybackMarkerIdentifierType.Name && TextType == PlaybackMarkerTextType.Time)
			{
				time = null;
			}
		}
		if (TextType != 0)
		{
			return TimerFormat.FormatTime(time, returnEmptyWhenNull: true);
		}
		return result;
	}

	public override void FormatText(ILinkData? linkData, TextDocument? document)
	{
		if (linkData == null || !UsesMarkerColor)
		{
			return;
		}
		IPlaybackMarkerInformation playbackMarkerInformation = MarkerIdentifier.SelectLinkData(linkData);
		if (playbackMarkerInformation != null)
		{
			System.Windows.Media.Color color = ImplicitMarkerColor;
			IPlaybackMarker playbackMarker = playbackMarkerInformation.FindMarker(MarkerIdentifier, ImplicitMarkerColor);
			if (playbackMarker != null)
			{
				color = playbackMarker.Color;
			}
			document?.IterateRuns(Pro.Text.Range.All, splitRuns: false, delegate(RunBase r)
			{
				r.Settings.Fill = new SolidTextFill(color);
			});
		}
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		if (other is PlaybackMarkerTextLinkedObject { MarkerIdentifier: var markerIdentifier } playbackMarkerTextLinkedObject && markerIdentifier.Equals(MarkerIdentifier) && playbackMarkerTextLinkedObject.TextType.Equals(TextType) && playbackMarkerTextLinkedObject.TimerFormat.Equals(TimerFormat))
		{
			return playbackMarkerTextLinkedObject.UsesMarkerColor == UsesMarkerColor;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(MarkerIdentifier, TextType, TimerFormat, UsesMarkerColor);
	}

	public override ILinkedTextObject Clone()
	{
		return new PlaybackMarkerTextLinkedObject(MarkerIdentifier.Clone(), TextType, TimerFormat.Clone(), UsesMarkerColor);
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.PlaybackMarkerText = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerText
		{
			Identifier = MarkerIdentifier.Serialize(),
			ShouldUseMarkerColor = UsesMarkerColor
		};
		if (TextType == PlaybackMarkerTextType.Name)
		{
			dataLink.PlaybackMarkerText.Name = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerText.Types.Name();
			return;
		}
		dataLink.PlaybackMarkerText.Time = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerText.Types.Time
		{
			Format = TimerFormat.Serialize()
		};
	}

	public static PlaybackMarkerTextLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerText proto)
	{
		PlaybackMarkerTextLinkedObject playbackMarkerTextLinkedObject = new PlaybackMarkerTextLinkedObject
		{
			MarkerIdentifier = proto.Identifier.Deserialize(),
			TextType = proto.TextTypeCase.ToPlaybackMarkerTextType(),
			UsesMarkerColor = proto.ShouldUseMarkerColor
		};
		if (playbackMarkerTextLinkedObject.TextType == PlaybackMarkerTextType.Time)
		{
			playbackMarkerTextLinkedObject.TimerFormat = proto.Time.Format.Deserialize();
		}
		return playbackMarkerTextLinkedObject;
	}
}
