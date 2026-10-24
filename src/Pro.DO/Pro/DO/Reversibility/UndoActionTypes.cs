using Pro.Localization;

namespace Pro.DO.Reversibility;

public enum UndoActionTypes
{
	[LocalizedString("UNDO_DOCUMENT_PRESENTATION_GROUP_SET_plural")]
	AssignLabel,
	[LocalizedString("UNDO_DOCUMENT_CUE_LABEL_SET_TITLE")]
	AssignSlideLabel,
	[LocalizedString("UNDO_GROUP_SET_COLOR")]
	AssignGroupLabelColor,
	[LocalizedString("UNDO_DOCUMENT_CUE_SET_HOTKEY")]
	AssignHotkey,
	[LocalizedString("UNDO_DOCUMENT_CUE_ACTION_ADD")]
	AddAction,
	[LocalizedString("UNDO_DOCUMENT_CUE_ACTION_REMOVE")]
	RemoveAction,
	[LocalizedString("UNDO_DOCUMENT_CUE_SET_ENABLED")]
	CueEnabled,
	[LocalizedString("UNDO_GLOBAL_TEXT")]
	MoveToken,
	[LocalizedString("UNDO_GLOBAL_TEXT")]
	InsertToken,
	[LocalizedString("UNDO_GLOBAL_TEXT")]
	RemoveToken,
	[LocalizedString("UNDO_MACRO_SET_NAME")]
	MacroName,
	[LocalizedString("UNDO_MACRO_SET_COLOR")]
	MacroColor,
	[LocalizedString("UNDO_DOCUMENT_CUE_SET_NAME")]
	CueName,
	[LocalizedString("UNDO_LABEL_MASTER")]
	MasterLabel,
	[LocalizedString("UNDO_LABEL_TEXT")]
	LabelText,
	[LocalizedString("UNDO_LABEL_COLOR")]
	LabelColor
}
