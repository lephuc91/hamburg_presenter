using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Time;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Slide.Builds;

public class ChildBuild : LinkedNotifyPropertyChangedBase, IBuild, IRenderEquatable<IBuild>, IRenderHashable, INotifyPropertyChanged
{
	private readonly ClosedBezierPath _element;

	private Pro.Text.Range _range;

	private TimeSlice _delay;

	private StartMode _start;

	public Guid ID { get; private set; } = Guid.NewGuid();

	public string Name => _element.Text?.GetText(Range) ?? string.Empty;

	public string DisplayName => $"{Index + 1}: {Name}";

	public string Description => Element.BuildIn?.Description ?? string.Empty;

	public SlideElementBase Element => _element;

	public UndoStack? UndoStack { get; set; }

	public int Index { get; private set; }

	public Pro.Text.Range Range
	{
		get
		{
			return _range;
		}
		set
		{
			_range = value;
			OnPropertyChanged("Name");
			OnPropertyChanged("DisplayName");
		}
	}

	public StartMode Start
	{
		get
		{
			return _start;
		}
		set
		{
			SetValue("Start", ref _start, value, delegate(StartMode o, StartMode n)
			{
				UndoStack?.Commit(UndoActionTypes.BuildStartMode.ToAction(), this, "Start", o, n);
				OnDataModified();
			});
		}
	}

	public TimeSlice Delay
	{
		get
		{
			return _delay;
		}
		set
		{
			SetValue("Delay", ref _delay, value, delegate(TimeSlice o, TimeSlice n)
			{
				UndoStack?.Commit(UndoActionTypes.BuildDelay.ToAction(), this, "Delay", o, n);
				OnDataModified();
			});
		}
	}

	public event System.Action? DataModified;

	public ChildBuild(ClosedBezierPath element, int index)
	{
		_element = element;
		Index = index;
		LinkProperties("SelectedTransition", "Description");
		if (_element.BuildIn != null)
		{
			_element.BuildIn.PropertyChanged += base.RaiseLinkedValues;
		}
	}

	public ChildBuild(ClosedBezierPath element, ChildBuild other)
		: this(element, other.Index)
	{
		Start = other.Start;
		Delay = other.Delay;
	}

	public double GetBuildDuration()
	{
		return (Element.BuildIn?.SelectedTransition?.Duration.TotalSeconds).GetValueOrDefault() + Delay.TotalSeconds;
	}

	public bool RenderEquals([NotNullWhen(true)] IBuild? other)
	{
		if (other is ChildBuild childBuild && Index == childBuild.Index && _range == childBuild._range && _start == childBuild._start)
		{
			return _delay == childBuild._delay;
		}
		return false;
	}

	public int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(Index, _range, _start, _delay);
	}

	public Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.ChildBuild Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.ChildBuild
		{
			Uuid = ID.ToUUID(),
			Index = (uint)Index,
			DelayTime = Delay.TotalSeconds,
			Start = Start.Serialize()
		};
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.ChildBuild data)
	{
		ID = data.Uuid.ToGuid();
		Index = (int)data.Index;
		Delay = TimeSlice.FromSeconds(data.DelayTime);
		Start = data.Start.Deserialize();
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}
}
