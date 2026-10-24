using System.ComponentModel;
using System.Windows.Media;

namespace ProPresenter.DO;

public interface IPanelViewSettings : INotifyPropertyChanged
{
	PanelViewType ViewType { get; }

	bool ByGroups { get; set; }

	bool UseBackgroundColor { get; set; }

	Color BackgroundColor { get; set; }

	bool UsePreviewColor { get; set; }

	Color PreviewColor { get; set; }

	bool ShowMediaActions { get; set; }
}
