using System;
using Pro.Text;
using Pro.Text.Reversibility;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public delegate void ApplyRunSettingsDelegate(Action<RunSettings, RangeSelectionType, TextDocument?> callback, UndoActionTypes undoActionType, bool autoFinalize);
