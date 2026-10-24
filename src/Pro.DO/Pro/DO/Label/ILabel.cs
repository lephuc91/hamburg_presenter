using System.ComponentModel;
using System.Windows.Media;

namespace Pro.DO.Label;

public interface ILabel : INotifyPropertyChanged
{
	string Text { get; set; }

	Color? Color { get; set; }
}
