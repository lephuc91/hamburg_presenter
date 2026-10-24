using System;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Time;
using Pro.Text;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Slide.Links;

public class TimerLinkFormatData : NotifyPropertyChangedBase, ICloneable<TimerLinkFormatData>
{
	private UndoStack? _undoStack;

	private string _text = string.Empty;

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			TimerFormatData style = Style;
			ColorTriggerCollection colorTriggers = ColorTriggers;
			UndoStack undoStack2 = (Tokens.UndoStack = value);
			UndoStack undoStack4 = (colorTriggers.UndoStack = undoStack2);
			UndoStack undoStack6 = (style.UndoStack = undoStack4);
			_undoStack = undoStack6;
		}
	}

	public TimerFormatData Style { get; }

	public ColorTriggerCollection ColorTriggers { get; } = new ColorTriggerCollection();

	public TimerTokenCollection Tokens { get; }

	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			SetValue("Text", ref _text, value, delegate(string o, string n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.LinkFormatText), this, "Text", o, n);
				OnDataModified();
			});
		}
	}

	public Pro.Text.Range TimerPosition { get; private set; }

	public event Action? DataModified;

	public TimerLinkFormatData()
		: this(new TimerFormatData
		{
			HourFormat = TimerFormatStyle.ShortTruncated,
			MinuteFormat = TimerFormatStyle.Short,
			SecondFormat = TimerFormatStyle.Short,
			MillisecondFormat = TimerFormatStyle.None
		})
	{
	}

	private TimerLinkFormatData(TimerFormatData formatData)
	{
		Style = formatData;
		Style.DataModified += OnDataModified;
		Tokens = new TimerTokenCollection(Style);
		Tokens.CollectionModified += OnDataModified;
		ColorTriggers.CollectionModified += OnDataModified;
	}

	public TimerLinkFormatData Clone()
	{
		TimerLinkFormatData timerLinkFormatData = new TimerLinkFormatData(Style.Clone());
		timerLinkFormatData.ColorTriggers.Add(ColorTriggers.CloneItems());
		timerLinkFormatData.Tokens.TimerToken.Index = Tokens.TimerToken.Index;
		timerLinkFormatData.Text = Text;
		return timerLinkFormatData;
	}

	public string FormatTime(TimeSlice time)
	{
		string text = Style.FormatTime(time);
		int num = Math.Min(Text.Length, Tokens.TimerToken.Index);
		int end = num + text.Length;
		TimerPosition = new Pro.Text.Range(num, end);
		return Text.Insert(Math.Max(num, 0), text);
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}
}
