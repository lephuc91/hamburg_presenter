using System;
using Pro.Text;
using Pro.Text.Reversibility;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public delegate void ApplyParagraphSettingsDelegate(Action<ParagraphSettings, RunSettings, RangeSelectionType> callback, UndoActionTypes undoActionType, bool autoFinalize);
