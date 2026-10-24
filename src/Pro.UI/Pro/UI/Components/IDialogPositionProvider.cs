using Pro.Common.Mathematics;
using Pro.Common.Win32;

namespace Pro.UI.Components;

public interface IDialogPositionProvider
{
	bool IsPositionSaved { get; set; }

	SW LastWindowState { get; set; }

	Rect<int> LastWindowRect { get; set; }
}
