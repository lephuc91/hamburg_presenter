using System.ComponentModel;
using Pro.Text;

namespace ProPresenter.DO.Import;

public interface IFontReplacementOption : INotifyPropertyChanged
{
	string DisplayName { get; set; }

	FontInfo? FontInfo { get; set; }

	bool IsDefault { get; set; }
}
