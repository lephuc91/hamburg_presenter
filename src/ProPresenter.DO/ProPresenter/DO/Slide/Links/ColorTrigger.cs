using System;
using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

public class ColorTrigger : NotifyPropertyChangedBase, IColorTrigger, INotifyPropertyChanged, ICloneable<IColorTrigger>
{
	private static readonly System.Windows.Media.Color DefaultColor = Colors.Blue;

	private TimeSlice _time;

	private System.Windows.Media.Color _color = DefaultColor;

	public UndoStack? UndoStack { get; set; }

	public TimeSlice Time
	{
		get
		{
			return _time;
		}
		set
		{
			SetValue("Time", ref _time, value, delegate(TimeSlice o, TimeSlice n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ColorTriggerTime), this, "Time", o, n);
				OnDataModified();
			});
		}
	}

	public System.Windows.Media.Color Color
	{
		get
		{
			return _color;
		}
		set
		{
			SetValue("Color", ref _color, value, delegate(System.Windows.Media.Color o, System.Windows.Media.Color n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ColorTriggerColor), this, "Color", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public event System.Action? DataModified;

	public Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.ColorTrigger Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.ColorTrigger
		{
			Time = Time.TotalSeconds,
			Color = Color.ToProtoColor()
		};
	}

	public static IColorTrigger Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.ColorTrigger colorTrigger)
	{
		return new ColorTrigger
		{
			Time = TimeSlice.FromSeconds(colorTrigger.Time),
			Color = (colorTrigger.Color?.ToColor() ?? DefaultColor)
		};
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public string Encode()
	{
		return Time.TotalSeconds + "|" + Color.EncodeColor();
	}

	internal static IColorTrigger Decode(string text)
	{
		string[] array = text.Split('|');
		return new ColorTrigger
		{
			Time = TimeSlice.FromSeconds(double.Parse(array[0])),
			Color = array[1].DecodeColor()
		};
	}

	public IColorTrigger Clone()
	{
		return new ColorTrigger
		{
			_time = _time,
			_color = _color
		};
	}
}
