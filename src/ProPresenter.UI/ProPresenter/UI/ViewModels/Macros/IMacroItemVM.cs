using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using Pro.DO.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Macros;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.UI.ViewModels.MediaLibrary;

namespace ProPresenter.UI.ViewModels.Macros;

public interface IMacroItemVM : ITriggerable, INotifyPropertyChanged, IUniformViewSource
{
	ProPresenterMacro Macro { get; }

	string Name { get; set; }

	Color Color { get; set; }

	IMacroGroupVM? Parent { get; }

	bool TriggerOnStartup { get; }

	bool IsValid { get; }

	string WarningMessage { get; }

	bool IsTriggering { get; set; }

	bool IsSelected { get; set; }

	bool IsListIconPopUpOpen { get; set; }

	bool IsGridIconPopUpOpen { get; set; }

	IEnumerable<IScrimSource> ScrimItems { get; }

	bool IsSetToTriggerInCalendar { get; }

	IMediaCueThumbnailOverlayVM OverlayVM { get; }

	ImageType ImageType { get; set; }
}
