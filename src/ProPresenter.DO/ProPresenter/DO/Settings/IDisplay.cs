using System.ComponentModel;
using System.Windows.Media;
using Pro.DO.Effects;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Settings;

public interface IDisplay : INotifyPropertyChanged
{
	double BlackLevel { get; set; }

	bool CenterCircleOn { get; set; }

	bool CenterLinesOn { get; set; }

	System.Windows.Media.Color CustomPatternColor { get; set; }

	bool DisplayTopMost { get; set; }

	bool EnableCornerPinning { get; set; }

	bool GridOn { get; set; }

	double GridSize { get; set; }

	bool InvertColors { get; set; }

	string OutputDeviceID { get; set; }

	bool ScaleToFit { get; set; }

	System.Windows.Media.Color ScreenColor { get; set; }

	Direction ScreenPosition { get; set; }

	ProClockSource? SelectedClockSource { get; set; }

	string StageDisplayDeviceID { get; set; }

	bool StageDisplayVisible { get; set; }

	double WhiteLevel { get; set; }
}
