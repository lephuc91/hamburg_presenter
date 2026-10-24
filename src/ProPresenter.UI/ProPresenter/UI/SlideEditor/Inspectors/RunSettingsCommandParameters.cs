using System;
using Pro.Text;
using Pro.Text.Reversibility;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public class RunSettingsCommandParameters : TextSettingsCommandParameters<Action<RunSettings, RangeSelectionType, TextDocument?>, UndoActionTypes>
{
	public RunSettingsCommandParameters(Action<RunSettings, RangeSelectionType, TextDocument?> settingsAction, UndoActionTypes undoActionType, bool autoFinalize)
		: base(settingsAction, undoActionType, autoFinalize)
	{
	}
}
