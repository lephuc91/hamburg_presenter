using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Time;
using ProPresenter.DO.Slide.Links;
using ProPresenter.UI.ViewModels.Editor.Links;

namespace ProPresenter.ViewModels.Editor.Links;

public class ColorTriggerItemVM : LinkedNotifyPropertyChangedBase, IColorTriggerItemVMInternal, IColorTriggerItemVM, INotifyPropertyChanged
{
	private readonly IColorTrigger _colorTrigger;

	public TimeSlice Time
	{
		get
		{
			return _colorTrigger.Time;
		}
		set
		{
			_colorTrigger.Time = value;
		}
	}

	public Color Color
	{
		get
		{
			return _colorTrigger.Color;
		}
		set
		{
			_colorTrigger.Color = value;
		}
	}

	public IColorTrigger ColorTrigger => _colorTrigger;

	public ColorTriggerItemVM(IColorTrigger colorTrigger)
	{
		_colorTrigger = colorTrigger;
		LinkProperties("Time", "Time");
		LinkProperties("Color", "Color");
		_colorTrigger.PropertyChanged += base.RaiseLinkedValues;
	}
}
