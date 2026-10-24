using System;
using Pro.Editor;

namespace ProPresenter.DO.Slide.Custom.Elements;

public class SliderPopoverModel : IPopover
{
	private int _value;

	private Action<int> _sliderChangedCallback;

	public string Label { get; }

	public int MinValue { get; set; }

	public int MaxValue { get; set; }

	public int Value
	{
		get
		{
			return _value;
		}
		set
		{
			if (_value != value)
			{
				_value = value;
				_sliderChangedCallback(_value);
			}
		}
	}

	public SliderPopoverModel(string slidePopoverLabel, Action<int> sliderChangedCallback)
	{
		Label = slidePopoverLabel;
		_sliderChangedCallback = sliderChangedCallback;
	}
}
