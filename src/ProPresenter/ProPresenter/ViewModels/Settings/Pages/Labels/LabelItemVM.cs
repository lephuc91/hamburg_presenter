using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Utility;
using Pro.DO.Label;
using ProPresenter.UI.ViewModels.Settings.Pages.Labels;

namespace ProPresenter.ViewModels.Settings.Pages.Labels;

public class LabelItemVM : LinkedNotifyPropertyChangedBase, ILabelItemVMInternal, ILabelItemVM, INotifyPropertyChanged
{
	private readonly ActionLabel _label;

	public string Text
	{
		get
		{
			return _label.Text;
		}
		set
		{
			_label.Text = value;
		}
	}

	public Color? Color
	{
		get
		{
			return _label.Color;
		}
		set
		{
			_label.Color = _label.Color.EvaluateColor(value);
		}
	}

	public ActionLabel Label => _label;

	public LabelItemVM(ActionLabel label)
	{
		_label = label;
		LinkProperties("Text", "Text");
		LinkProperties("Color", "Color");
		label.PropertyChanged += base.RaiseLinkedValues;
	}
}
