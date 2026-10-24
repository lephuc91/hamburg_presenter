using System;
using Pro.Text;
using Pro.Text.Reversibility;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public class DocumentSettingsCommandParameters : TextSettingsCommandParameters<Action<TextDocumentSettings, RangeSelectionType>, UndoActionTypes>
{
	public DocumentSettingsCommandParameters(Action<TextDocumentSettings, RangeSelectionType> settingsAction, UndoActionTypes undoActionType, bool autoFinalize)
		: base(settingsAction, undoActionType, autoFinalize)
	{
	}
}
