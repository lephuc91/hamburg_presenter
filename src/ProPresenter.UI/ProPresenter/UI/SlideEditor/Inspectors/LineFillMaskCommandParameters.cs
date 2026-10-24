using System;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public class LineFillMaskCommandParameters : TextSettingsCommandParameters<Action<LineFillMask, RangeSelectionType>, UndoActionTypes>
{
	public LineFillMaskCommandParameters(Action<LineFillMask, RangeSelectionType> settingsAction, UndoActionTypes undoActionType, bool autoFinalize)
		: base(settingsAction, undoActionType, autoFinalize)
	{
	}
}
