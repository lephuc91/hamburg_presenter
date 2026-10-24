using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Slide.Links;

public class TimerLinkedObject : LinkedTextObjectBase, ITimerFormattable
{
	private const string TokenFormat = "${timer}";

	private TimerData? _timerData;

	private Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.TimerText? _fallbackTimerText;

	private Guid? _timerID;

	private string? _timerName;

	public override LinkedTextType LinkedTextType => LinkedTextType.Timer;

	public override string DisplayText => TimerData?.Name ?? _fallbackTimerText?.TimerName ?? string.Empty;

	public override FormattingType FormattingType => FormattingType.Additional;

	public Guid? TimerID => _timerID ?? TimerData?.ID;

	public string? TimerName
	{
		get
		{
			string text = _timerName;
			if (text == null)
			{
				TimerData? timerData = TimerData;
				if (timerData == null)
				{
					return null;
				}
				text = timerData.Name;
			}
			return text;
		}
	}

	public TimerData? TimerData
	{
		get
		{
			return _timerData;
		}
		set
		{
			SetValue<TimerData>("TimerData", ref _timerData, value, delegate(TimerData o, TimerData n)
			{
				base.UndoStack?.Commit(UndoActionTypes.LinkTextObject.ToAction(), this, "TimerData", o, n);
			});
		}
	}

	public TimerLinkFormatData FormatData { get; }

	public static ObjectBinder<TimerLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ITimerText> CreateBinder(IEntityFactory entityFactory, TimerLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.ITimerText right)
	{
		ObjectBinder<TimerLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ITimerText> objectBinder = new ObjectBinder<TimerLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.ITimerText>(left, right);
		objectBinder.Bind((TimerLinkedObject l) => l.WhenPropertyChanges("TimerData"), (ISlide.Types.IElement.Types.IDataLink.Types.ITimerText r) => r.TimerUuid.WhenValueChanges.ToUnit().Merge(r.TimerName.WhenValueChanges.ToUnit()), delegate(TimerLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.ITimerText r)
		{
			r.TimerUuid.Set(l.TimerData?.ID);
			r.TimerName.Set(l.TimerData?.Name);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.ITimerText r, TimerLinkedObject l)
		{
			l._timerID = r.TimerUuid.ToGuidOrEmpty();
			l._timerName = r.TimerName.Value;
		}).Bind((TimerLinkedObject l) => (from _ in l.WhenPropertyChanges("FormatData")
			select l.FormatData.WhenPropertyChanges("Style").ToUnit().Prepend(Unit.Default)).Switch(), (ISlide.Types.IElement.Types.IDataLink.Types.ITimerText r) => r.TimerFormat.WhenValueChanges, delegate(TimerLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.ITimerText r)
		{
			ITimer.Types.IFormat format = entityFactory.Create<ITimer.Types.IFormat>();
			r.TimerFormat.Set(format);
			ObjectBinder<TimerFormatData, ITimer.Types.IFormat> objectBinder2 = TimerFormatData.CreateBinder(l.FormatData.Style, format);
			objectBinder2.InitializeRightFromLeft();
			format.RegisterLinkedDisposable(objectBinder2);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.ITimerText r, TimerLinkedObject l)
		{
			ObjectBinder<TimerFormatData, ITimer.Types.IFormat> objectBinder3 = TimerFormatData.CreateBinder(l.FormatData.Style, r.TimerFormat.Value);
			objectBinder3.InitializeLeftFromRight();
			r.TimerFormat.Value.RegisterLinkedDisposable(objectBinder3);
		}).Bind((TimerLinkedObject l) => (from _ in l.WhenPropertyChanges("FormatData")
			select l.FormatData.WhenPropertyChanges("Text").ToUnit().Prepend(Unit.Default)).Switch(), (ISlide.Types.IElement.Types.IDataLink.Types.ITimerText r) => r.TimerFormatString.WhenValueChanges, delegate(TimerLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.ITimerText r)
		{
			r.TimerFormatString.Set(l.FormatData.Text.Insert(l.FormatData.Tokens.TimerToken.Index.Clamp(0, l.FormatData.Text.Length), "${timer}"));
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.ITimerText r, TimerLinkedObject l)
		{
			l.FormatData.Tokens.TimerToken.Index = r.TimerFormatString.Value.IndexOf("${timer}");
			l.FormatData.Text = r.TimerFormatString.Value.Replace("${timer}", string.Empty);
		});
		return objectBinder;
	}

	public TimerLinkedObject(TimerData? timerData)
		: this(timerData, new TimerLinkFormatData())
	{
	}

	public TimerLinkedObject(TimerData? timerData, IEnumerable<IColorTrigger> colorTriggers)
		: this(timerData)
	{
		FormatData.ColorTriggers.Add(colorTriggers);
	}

	private TimerLinkedObject(TimerData? timerData, TimerLinkFormatData linkFormatData)
	{
		TimerData = timerData;
		FormatData = linkFormatData;
		FormatData.DataModified += delegate
		{
			OnPropertyChanged("FormatData");
		};
	}

	private TimerLinkedObject(TimerData? timerData, Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.TimerText protoTimerText)
		: this(timerData)
	{
		_fallbackTimerText = protoTimerText;
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		return other is TimerLinkedObject;
	}

	public override int GetRenderHashCode()
	{
		return GetHashCode();
	}

	public override string GetText(ILinkData? linkData)
	{
		if (linkData != null)
		{
			if (linkData.Timers?.FirstOrDefaultBy(delegate(TimerData t)
			{
				Guid iD = t.ID;
				Guid? obj = TimerData?.ID;
				return iD == obj;
			}, (TimerData t) => t.Name == TimerData?.Name) == null)
			{
				return string.Empty;
			}
			return FormatData.FormatTime(TimerData?.Active?.RunningTime ?? TimeSlice.Zero);
		}
		return FormatData.FormatTime(TimerFormatData.SampleTime);
	}

	public override void FormatText(ILinkData? linkData, TextDocument? document)
	{
		if (linkData != null)
		{
			ResolveColorTrigger(document);
		}
		document?.IterateRuns(FormatData.TimerPosition, splitRuns: true, delegate(RunBase r)
		{
			r.Settings.TabularNumbers = true;
		});
	}

	public override ILinkedTextObject Clone()
	{
		return new TimerLinkedObject(TimerData, FormatData.Clone())
		{
			_fallbackTimerText = _fallbackTimerText
		};
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.TimerText = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.TimerText
		{
			TimerUuid = (TimerData?.ID.ToUUID() ?? _fallbackTimerText?.TimerUuid),
			TimerName = (TimerData?.Name ?? _fallbackTimerText?.TimerName ?? string.Empty),
			TimerFormat = FormatData.Style.Serialize(),
			TimerFormatString = FormatData.Text.Insert(FormatData.Tokens.TimerToken.Index.Clamp(0, FormatData.Text.Length), "${timer}")
		};
		dataLink.TimerText.ColorTriggers.AddRange(FormatData.ColorTriggers.Serialize());
	}

	public static TimerLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.TimerText timerText, IEnumerable<TimerData>? timers)
	{
		TimerLinkedObject timerLinkedObject = new TimerLinkedObject((timers ?? Enumerable.Empty<TimerData>()).FirstOrDefaultBy((TimerData t) => t.ID == timerText.TimerUuid.ToGuid(), (TimerData t) => t.Name == timerText.TimerName), timerText);
		timerLinkedObject.FormatData.Tokens.TimerToken.Index = timerText.TimerFormatString.IndexOf("${timer}");
		timerLinkedObject.FormatData.Text = timerText.TimerFormatString.Replace("${timer}", string.Empty);
		timerLinkedObject.FormatData.Style.Deserialize(timerText.TimerFormat);
		timerLinkedObject.FormatData.ColorTriggers.Deserialize(timerText.ColorTriggers);
		return timerLinkedObject;
	}

	protected override void OnUndoStackChanged(UndoStack? undoStack)
	{
		FormatData.UndoStack = undoStack;
	}

	private void Timer_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		OnPropertyChanged("TimerData");
	}

	private void ResolveColorTrigger(TextDocument? document)
	{
		if (TimerData == null)
		{
			return;
		}
		TimerBase source = TimerData.Source;
		IColorTrigger colorTrigger = ((source != null && source.IsForward) ? FormatData.ColorTriggers.OrderBy((IColorTrigger ct) => ct.Time).LastOrDefault((IColorTrigger ct) => TimerData.Active?.RunningTime >= ct.Time) : FormatData.ColorTriggers.OrderByDescending((IColorTrigger ct) => ct.Time).LastOrDefault(delegate(IColorTrigger ct)
		{
			TimeSlice time = ct.Time;
			TimeSlice? obj = TimerData.Active?.RunningTime;
			return time >= obj;
		}));
		if (colorTrigger != null)
		{
			document?.IterateRuns(FormatData.TimerPosition, splitRuns: true, delegate(RunBase r)
			{
				r.AssignSettings(r.Settings);
				r.Settings.Fill = new SolidTextFill(colorTrigger.Color);
			});
		}
	}
}
