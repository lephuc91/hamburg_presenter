using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Time;

namespace ProPresenter.UI.ViewModels.Editor.Links;

public interface IColorTriggerItemVM : INotifyPropertyChanged
{
	TimeSlice Time { get; set; }

	Color Color { get; set; }
}
