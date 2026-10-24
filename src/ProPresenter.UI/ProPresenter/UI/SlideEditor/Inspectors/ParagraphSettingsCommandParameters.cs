using System;
using Pro.Text;
using Pro.Text.Reversibility;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public class ParagraphSettingsCommandParameters : TextSettingsCommandParameters<Action<ParagraphSettings, RunSettings, RangeSelectionType>, UndoActionTypes>
{
	public ParagraphSettingsCommandParameters(Action<ParagraphSettings, RunSettings, RangeSelectionType> settingsAction, UndoActionTypes undoActionType, bool autoFinalize)
		: base(settingsAction, undoActionType, autoFinalize)
	{
	}
}
