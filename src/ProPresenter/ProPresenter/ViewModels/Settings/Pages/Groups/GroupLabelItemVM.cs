using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Utility;
using Pro.DO.Label;
using ProPresenter.UI.ViewModels.Settings.Pages.Groups;

namespace ProPresenter.ViewModels.Settings.Pages.Groups;

public class GroupLabelItemVM : LinkedNotifyPropertyChangedBase, IGroupLabelItemVMInternal, IGroupLabelItemVM, INotifyPropertyChanged
{
	private readonly GroupLabel _label;

	public GroupLabel Label => _label;

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

	public GroupLabelItemVM(GroupLabel label)
	{
		_label = label;
		LinkProperties("Text", "Text");
		LinkProperties("Color", "Color");
		label.PropertyChanged += base.RaiseLinkedValues;
	}
}
