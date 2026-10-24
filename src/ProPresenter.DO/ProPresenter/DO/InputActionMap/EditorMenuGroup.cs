using System.Collections.Generic;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Localization;
using Pro.UI.InputActions;

namespace ProPresenter.DO.InputActionMap;

public class EditorMenuGroup : InputActionGroupBase
{
	public InputAction InsertText { get; }

	public InputAction InsertShapeRectangle { get; }

	public InputAction InsertShapeRoundedRectangle { get; }

	public InputAction InsertShapeEllipse { get; }

	public InputAction InsertShapeIsoscelesTriangle { get; }

	public InputAction InsertShapeRightTriangle { get; }

	public InputAction InsertShapeRhombus { get; }

	public InputAction InsertShapePolygon { get; }

	public InputAction InsertShapeStar { get; }

	public InputAction InsertShapeCustom { get; }

	public InputAction InsertShapeDoubleArrow { get; }

	public InputAction InsertShapeArrow { get; }

	public InputAction InsertMedia { get; }

	public InputAction InsertVideoInput { get; }

	public InputAction InsertWeb { get; }

	public InputAction TextApplyTextStyleToAllSlides { get; }

	public InputAction TextChangeFont { get; }

	public InputAction TextBold { get; }

	public InputAction TextItalic { get; }

	public InputAction TextUnderline { get; }

	public InputAction TextStrikeThrough { get; }

	public InputAction TextBigger { get; }

	public InputAction TextSmaller { get; }

	public InputAction TextCharSpaceDefault { get; }

	public InputAction TextCharSpaceTighten { get; }

	public InputAction TextCharSpaceLoosen { get; }

	public InputAction TextLigatureDefault { get; }

	public InputAction TextLigatureNone { get; }

	public InputAction TextBaselineDefault { get; }

	public InputAction TextBaselineUseSuperscript { get; }

	public InputAction TextBaselineUseSubscript { get; }

	public InputAction TextBaselineRaise { get; }

	public InputAction TextBaselineLower { get; }

	public InputAction TextCapNone { get; }

	public InputAction TextCapAll { get; }

	public InputAction TextCapTitle { get; }

	public InputAction TextCapStart { get; }

	public InputAction TextAlignmentLeft { get; }

	public InputAction TextAlignmentCenter { get; }

	public InputAction TextAlignmentRight { get; }

	public InputAction TextAlignmentJustify { get; }

	public InputAction TextAlignmentTop { get; }

	public InputAction TextAlignmentMiddle { get; }

	public InputAction TextAlignmentBottom { get; }

	public InputAction ArrangementBringForward { get; }

	public InputAction ArrangementBringToFront { get; }

	public InputAction ArrangementSendBackward { get; }

	public InputAction ArrangementSendToBack { get; }

	public InputAction ArrangementAlignObjLeft { get; }

	public InputAction ArrangementAlignObjCenter { get; }

	public InputAction ArrangementAlignObjRight { get; }

	public InputAction ArrangementAlignObjTop { get; }

	public InputAction ArrangementAlignObjMiddle { get; }

	public InputAction ArrangementAlignObjBottom { get; }

	public InputAction FlipVertical { get; }

	public InputAction FlipHorizontal { get; }

	public InputAction EventDistributeElements { get; }

	public InputAction HorizontalDistributeElements { get; }

	public InputAction VerticalDistributeElements { get; }

	public InputAction Lock { get; }

	public InputAction UnlockAll { get; }

	public InputAction ShowRulers { get; }

	public InputAction ShowTemplateGuides { get; }

	public InputAction ShowSlideGuides { get; }

	public InputAction ZoomIn { get; }

	public InputAction ZoomOut { get; }

	public InputAction ZoomActualSize { get; }

	public InputAction ZoomFitSlide { get; }

	public InputAction ZoomFitCanvas { get; }

	public InputAction InsertCurrentSlideText { get; }

	public InputAction InsertCurrentSlideNote { get; }

	public InputAction InsertCurrentSlideImage { get; }

	public InputAction InsertCurrentSlideTextAndChords { get; }

	public InputAction InsertNextSlideText { get; }

	public InputAction InsertNextSlideNote { get; }

	public InputAction InsertNextSlideImage { get; }

	public InputAction InsertNextSlideTextAndChords { get; }

	public InputAction InsertChordChart { get; }

	public InputAction InsertStageMessage { get; }

	public InputAction InsertPCSLive { get; }

	public InputAction InsertSystemClock { get; }

	public InputAction InsertVideoCountdown { get; }

	public InputAction InsertAudioCountdown { get; }

	public InputAction InsertPlaybackMarkerFirst { get; }

	public InputAction InsertPlaybackMarkerPrevious { get; }

	public InputAction InsertPlaybackMarkerNext { get; }

	public InputAction InsertPlaybackMarkerLast { get; }

	public InputAction InsertTimecode { get; }

	public InputAction InsertGroupCurrentSlide { get; }

	public InputAction InsertGroupNextSlide { get; }

	public InputAction InsertGroupNextArrangement { get; }

	public InputAction InsertLabelCurrentSlide { get; }

	public InputAction InsertLabelNextSlide { get; }

	public InputAction InsertCaptureStatus { get; }

	public InputAction InsertImage { get; }

	public InputAction AddScreenPreviewElement { get; }

	public InputAction AddTimerStageItem { get; }

	public InputAction Unlock { get; }

	public InputAction Hide { get; }

	public InputAction FitToText { get; }

	public InputAction OverlayEdit { get; }

	public EditorMenuGroup(string label, InputActionGroupCollectionBase parent)
		: base(label, parent)
	{
		IEnumerable<string> accessPath = LocalizedStrings.Get("MAIN_MENU_EDITOR_INSERT_title").ToEnumerable();
		InsertText = Add("EDITOR_MENU_INSERT_TEXT_title", LocalizedStrings.Get("EDITOR_MENU_INSERT_TEXT_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.T, (ModifierKeys)0).ToEnumerable(), accessPath, requireModifiers: false);
		string[] accessPath2 = new string[2]
		{
			LocalizedStrings.Get("MAIN_MENU_EDITOR_INSERT_title"),
			LocalizedStrings.Get("EDITOR_MENU_INSERT_SHAPE_title")
		};
		InsertShapeRoundedRectangle = Add("GLOBAL_SHAPE_ROUNDED_RECTANGLE", LocalizedStrings.Get("GLOBAL_SHAPE_ROUNDED_RECTANGLE"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.O, (ModifierKeys)0).ToEnumerable(), accessPath, requireModifiers: false);
		InsertShapeRectangle = Add("GLOBAL_SHAPE_RECTANGLE", LocalizedStrings.Get("GLOBAL_SHAPE_RECTANGLE"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.R, (ModifierKeys)0).ToEnumerable(), accessPath, requireModifiers: false);
		InsertShapeEllipse = Add("GLOBAL_SHAPE_ELLIPSE", LocalizedStrings.Get("GLOBAL_SHAPE_ELLIPSE"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.E, (ModifierKeys)0).ToEnumerable(), accessPath, requireModifiers: false);
		InsertShapeIsoscelesTriangle = Add("GLOBAL_SHAPE_ISOSCELES_TRIANGLE", LocalizedStrings.Get("GLOBAL_SHAPE_ISOSCELES_TRIANGLE"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.G, (ModifierKeys)0).ToEnumerable(), accessPath, requireModifiers: false);
		InsertShapeRightTriangle = Add("GLOBAL_SHAPE_RIGHT_TRIANGLE", LocalizedStrings.Get("GLOBAL_SHAPE_RIGHT_TRIANGLE"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.L, (ModifierKeys)0).ToEnumerable(), accessPath, requireModifiers: false);
		InsertShapeRhombus = Add("GLOBAL_SHAPE_RHOMBUS", LocalizedStrings.Get("GLOBAL_SHAPE_RHOMBUS"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.H, (ModifierKeys)0).ToEnumerable(), accessPath, requireModifiers: false);
		InsertShapePolygon = Add("GLOBAL_SHAPE_POLYGON", LocalizedStrings.Get("GLOBAL_SHAPE_POLYGON"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.P, (ModifierKeys)0).ToEnumerable(), accessPath, requireModifiers: false);
		InsertShapeStar = Add("GLOBAL_SHAPE_STAR", LocalizedStrings.Get("GLOBAL_SHAPE_STAR"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.S, (ModifierKeys)0).ToEnumerable(), accessPath, requireModifiers: false);
		InsertShapeCustom = Add("GLOBAL_SHAPE_CUSTOM", LocalizedStrings.Get("GLOBAL_SHAPE_CUSTOM"), null, accessPath2, requireModifiers: false);
		InsertShapeDoubleArrow = Add("GLOBAL_SHAPE_DOUBLE_ARROW", LocalizedStrings.Get("GLOBAL_SHAPE_DOUBLE_ARROW"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.D, (ModifierKeys)0).ToEnumerable(), accessPath, requireModifiers: false);
		InsertShapeArrow = Add("GLOBAL_SHAPE_ARROW", LocalizedStrings.Get("GLOBAL_SHAPE_ARROW"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.A, (ModifierKeys)0).ToEnumerable(), accessPath, requireModifiers: false);
		InsertMedia = Add("EDITOR_MENU_INSERT_MEDIA_title", LocalizedStrings.Get("EDITOR_MENU_INSERT_MEDIA_title"), null, accessPath);
		InsertVideoInput = Add("EDITOR_MENU_INSERT_VIDEO_INPUT_title", LocalizedStrings.Get("EDITOR_MENU_INSERT_VIDEO_INPUT_title"), null, accessPath);
		InsertWeb = Add("EDITOR_MENU_INSERT_WEB_title", LocalizedStrings.Get("EDITOR_MENU_INSERT_WEB_title"), null, accessPath);
		string[] accessPath3 = new string[2]
		{
			LocalizedStrings.Get("MAIN_MENU_EDITOR_INSERT_title"),
			LocalizedStrings.Get("EDITOR_MENU_INSERT_CURRENT_SLIDE_ITEM_title")
		};
		InsertCurrentSlideText = Add("EDITOR_MENU_INSERT_TEXT_title(current)", LocalizedStrings.Get("EDITOR_MENU_INSERT_SLIDE_PREVIEW_TEXT_title"), null, accessPath3);
		InsertCurrentSlideNote = Add("EDITOR_MENU_INSERT_SLIDE_PREVIEW_IMAGE_title (current)", LocalizedStrings.Get("EDITOR_MENU_INSERT_SLIDE_NOTES_title"), null, accessPath3);
		InsertCurrentSlideImage = Add("EDITOR_MENU_INSERT_SLIDE_NOTES_title (current)", LocalizedStrings.Get("EDITOR_MENU_INSERT_SLIDE_PREVIEW_IMAGE_title"), null, accessPath3);
		InsertCurrentSlideTextAndChords = Add("EDITOR_MENU_INSERT_SLIDE_TEXT_AND_CORDS_title (current)", LocalizedStrings.Get("EDITOR_MENU_INSERT_SLIDE_PREVIEW_TEXT_AND_CHORDS_title"), null, accessPath3);
		string[] accessPath4 = new string[2]
		{
			LocalizedStrings.Get("MAIN_MENU_EDITOR_INSERT_title"),
			LocalizedStrings.Get("EDITOR_MENU_INSERT_NEXT_SLIDE_ITEM_title")
		};
		InsertNextSlideText = Add("EDITOR_MENU_INSERT_TEXT_title(next)", LocalizedStrings.Get("EDITOR_MENU_INSERT_SLIDE_PREVIEW_TEXT_title"), null, accessPath4);
		InsertNextSlideNote = Add("EDITOR_MENU_INSERT_SLIDE_PREVIEW_IMAGE_title (next)", LocalizedStrings.Get("EDITOR_MENU_INSERT_SLIDE_NOTES_title"), null, accessPath4);
		InsertNextSlideImage = Add("EDITOR_MENU_INSERT_SLIDE_NOTES_title (next)", LocalizedStrings.Get("EDITOR_MENU_INSERT_SLIDE_PREVIEW_IMAGE_title"), null, accessPath4);
		InsertNextSlideTextAndChords = Add("EDITOR_MENU_INSERT_SLIDE_TEXT_AND_CORDS_title (next)", LocalizedStrings.Get("EDITOR_MENU_INSERT_SLIDE_PREVIEW_TEXT_AND_CHORDS_title"), null, accessPath4);
		InsertChordChart = Add("EDITOR_MENU_INSERT_CHORD_CHART_title", LocalizedStrings.Get("EDITOR_MENU_INSERT_CHORD_CHART_title"), null, accessPath);
		InsertStageMessage = Add("EDITOR_MENU_INSERT_STAGE_MESSAGE_title", LocalizedStrings.Get("EDITOR_MENU_INSERT_STAGE_MESSAGE_title"), null, accessPath);
		InsertPCSLive = Add("EDITOR_MENU_INSERT_PLANNING_CENTER_LIVE_title", LocalizedStrings.Get("EDITOR_MENU_INSERT_PLANNING_CENTER_LIVE_title"), null, accessPath);
		InsertSystemClock = Add("EDITOR_MENU_INSERT_SYSTEM_CLOCK_title", LocalizedStrings.Get("EDITOR_MENU_INSERT_SYSTEM_CLOCK_title"), null, accessPath);
		InsertVideoCountdown = Add("EDITOR_MENU_INSERT_VIDEO_COUNTDOWN_title", LocalizedStrings.Get("EDITOR_MENU_INSERT_VIDEO_COUNTDOWN_title"), null, accessPath);
		InsertAudioCountdown = Add("EDITOR_MENU_INSERT_AUDIO_COUNTDOWN_title", LocalizedStrings.Get("EDITOR_MENU_INSERT_AUDIO_COUNTDOWN_title"), null, accessPath);
		string[] accessPath5 = new string[2]
		{
			LocalizedStrings.Get("MAIN_MENU_EDITOR_INSERT_title"),
			LocalizedStrings.Get("EDITOR_MENU_INSERT_PLAYBACK_MARKER_title")
		};
		InsertPlaybackMarkerFirst = Add("EDITOR_MENU_INSERT_PLAYBACK_MARKER_FIRST_title", LocalizedStrings.Get("EDITOR_MENU_INSERT_PLAYBACK_MARKER_FIRST_title"), null, accessPath5);
		InsertPlaybackMarkerPrevious = Add("EDITOR_MENU_INSERT_PLAYBACK_MARKER_PREVIOUS_title", LocalizedStrings.Get("EDITOR_MENU_INSERT_PLAYBACK_MARKER_PREVIOUS_title"), null, accessPath5);
		InsertPlaybackMarkerNext = Add("EDITOR_MENU_INSERT_PLAYBACK_MARKER_NEXT_title", LocalizedStrings.Get("EDITOR_MENU_INSERT_PLAYBACK_MARKER_NEXT_title"), null, accessPath5);
		InsertPlaybackMarkerLast = Add("EDITOR_MENU_INSERT_PLAYBACK_MARKER_LAST_title", LocalizedStrings.Get("EDITOR_MENU_INSERT_PLAYBACK_MARKER_LAST_title"), null, accessPath5);
		InsertTimecode = Add("EDITOR_MENU_INSERT_TIMECODE_title", LocalizedStrings.Get("EDITOR_MENU_INSERT_TIMECODE_title"), null, accessPath);
		string[] accessPath6 = new string[2]
		{
			LocalizedStrings.Get("MAIN_MENU_EDITOR_INSERT_title"),
			LocalizedStrings.Get("LABEL_PREFERENCES_GROUP_DEFAULT_name")
		};
		InsertGroupCurrentSlide = Add("TEXT_LINK_GROUP_NAME_CURRENT_SLIDE_title", LocalizedStrings.Get("TEXT_LINK_GROUP_NAME_CURRENT_SLIDE_title"), null, accessPath6);
		InsertGroupNextSlide = Add("TEXT_LINK_GROUP_NAME_NEXT_SLIDE_title", LocalizedStrings.Get("TEXT_LINK_GROUP_NAME_NEXT_SLIDE_title"), null, accessPath6);
		InsertGroupNextArrangement = Add("TEXT_LINK_GROUP_NAME_NEXT_GROUP_title", LocalizedStrings.Get("TEXT_LINK_GROUP_NAME_NEXT_GROUP_title"), null, accessPath6);
		string[] accessPath7 = new string[2]
		{
			LocalizedStrings.Get("MAIN_MENU_EDITOR_INSERT_title"),
			LocalizedStrings.Get("EDITOR_MENU_INSERT_SLIDE_LABEL_title")
		};
		InsertLabelCurrentSlide = Add("TEXT_LINK_SLIDE_LABEL_CURRENT_SLIDE_title", LocalizedStrings.Get("TEXT_LINK_SLIDE_LABEL_CURRENT_SLIDE_title"), null, accessPath7);
		InsertLabelNextSlide = Add("TEXT_LINK_SLIDE_LABEL_NEXT_SLIDE_title", LocalizedStrings.Get("TEXT_LINK_SLIDE_LABEL_NEXT_SLIDE_title"), null, accessPath7);
		InsertCaptureStatus = Add("EDITOR_MENU_INSERT_CAPTURE_STATUS_title", LocalizedStrings.Get("EDITOR_MENU_INSERT_CAPTURE_STATUS_title"), null, accessPath);
		InsertImage = Add("EDITOR_MENU_INSERT_IMAGE_title", LocalizedStrings.Get("EDITOR_MENU_INSERT_IMAGE_title"), null, accessPath);
		IEnumerable<string> accessPath8 = LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_SUBMENU_title").ToEnumerable();
		TextApplyTextStyleToAllSlides = Add("MAIN_MENU_EDITOR_TEXT_APPLY_TEXT_STYLE_TO_ALL_SLIDES_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_APPLY_TEXT_STYLE_TO_ALL_SLIDES_title"), null, accessPath8);
		TextChangeFont = Add("MAIN_MENU_EDITOR_TEXT_CHANGE_FONT_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_CHANGE_FONT_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.T, (ModifierKeys)2).ToEnumerable(), accessPath8);
		TextBold = Add("MAIN_MENU_EDITOR_TEXT_BOLD_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_BOLD_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.B, (ModifierKeys)2).ToEnumerable(), accessPath8);
		TextItalic = Add("MAIN_MENU_EDITOR_TEXT_ITALIC_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_ITALIC_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.I, (ModifierKeys)2).ToEnumerable(), accessPath8);
		TextUnderline = Add("MAIN_MENU_EDITOR_TEXT_UNDERLINE_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_UNDERLINE_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.U, (ModifierKeys)2).ToEnumerable(), accessPath8);
		TextStrikeThrough = Add("MAIN_MENU_EDITOR_TEXT_STRIKETHROUGH_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_STRIKETHROUGH_title"), null, accessPath8);
		TextBigger = Add("MAIN_MENU_EDITOR_TEXT_BIGGER_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_BIGGER_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.Plus, (ModifierKeys)2).ToEnumerable(), accessPath8);
		TextSmaller = Add("MAIN_MENU_EDITOR_TEXT_SMALLER_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_SMALLER_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.Minus, (ModifierKeys)2).ToEnumerable(), accessPath8);
		string[] accessPath9 = new string[2]
		{
			LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_SUBMENU_title"),
			LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_CHARACTER_SPACING_SUBMENU_title")
		};
		TextCharSpaceDefault = Add("MAIN_MENU_EDITOR_TEXT_CHARACTER_SPACING_DEFAULT_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_CHARACTER_SPACING_DEFAULT_title"), null, accessPath9);
		TextCharSpaceTighten = Add("MAIN_MENU_EDITOR_TEXT_CHARACTER_SPACING_TIGHTEN_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_CHARACTER_SPACING_TIGHTEN_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.OpenBrackets, (ModifierKeys)5).ToEnumerable(), accessPath9);
		TextCharSpaceLoosen = Add("MAIN_MENU_EDITOR_TEXT_CHARACTER_SPACING_LOOSEN_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_CHARACTER_SPACING_LOOSEN_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.CloseBrackets, (ModifierKeys)5).ToEnumerable(), accessPath9);
		string[] accessPath10 = new string[2]
		{
			LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_SUBMENU_title"),
			LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_LIGATURE_SUBMENU_title")
		};
		TextLigatureDefault = Add("MAIN_MENU_EDITOR_TEXT_LIGATURE_USE_DEFAULT_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_LIGATURE_USE_DEFAULT_title"), null, accessPath10);
		TextLigatureNone = Add("MAIN_MENU_EDITOR_TEXT_LIGATURE_USE_NONE_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_LIGATURE_USE_NONE_title"), null, accessPath10);
		string[] accessPath11 = new string[2]
		{
			LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_SUBMENU_title"),
			LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_BASELINE_SUBMENU_title")
		};
		TextBaselineDefault = Add("MAIN_MENU_EDITOR_TEXT_BASELINE_DEFAULT_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_BASELINE_DEFAULT_title"), null, accessPath11);
		TextBaselineUseSuperscript = Add("MAIN_MENU_EDITOR_TEXT_BASELINE_SUPERSCRIPT_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_BASELINE_SUPERSCRIPT_title"), null, accessPath11);
		TextBaselineUseSubscript = Add("MAIN_MENU_EDITOR_TEXT_BASELINE_SUBSCRIPT_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_BASELINE_SUBSCRIPT_title"), null, accessPath11);
		TextBaselineRaise = Add("MAIN_MENU_EDITOR_TEXT_BASELINE_RAISE_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_BASELINE_RAISE_title"), null, accessPath11);
		TextBaselineLower = Add("MAIN_MENU_EDITOR_TEXT_BASELINE_LOWER_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_BASELINE_LOWER_title"), null, accessPath11);
		string[] accessPath12 = new string[2]
		{
			LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_SUBMENU_title"),
			LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_CAPITALIZATION_SUBMENU_title")
		};
		TextCapNone = Add("MAIN_MENU_EDITOR_TEXT_CAPITALIZATION_NONE_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_CAPITALIZATION_NONE_title"), null, accessPath12);
		TextCapAll = Add("MAIN_MENU_EDITOR_TEXT_CAPITALIZATION_ALL_CAPS_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_CAPITALIZATION_ALL_CAPS_title"), null, accessPath12);
		TextCapTitle = Add("MAIN_MENU_EDITOR_TEXT_CAPITALIZATION_TITLE_CASE_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_CAPITALIZATION_TITLE_CASE_title"), null, accessPath12);
		TextCapStart = Add("MAIN_MENU_EDITOR_TEXT_CAPITALIZATION_START_CASE_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_CAPITALIZATION_START_CASE_title"), null, accessPath12);
		string[] accessPath13 = new string[2]
		{
			LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_SUBMENU_title"),
			LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_ALIGNMENT_SUBMENU_title")
		};
		TextAlignmentLeft = Add("MAIN_MENU_EDITOR_TEXT_ALIGNMENT_LEFT_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_ALIGNMENT_LEFT_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.OpenBrackets, (ModifierKeys)6).ToEnumerable(), accessPath13);
		TextAlignmentCenter = Add("MAIN_MENU_EDITOR_TEXT_ALIGNMENT_CENTER_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_ALIGNMENT_CENTER_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.Backslash, (ModifierKeys)6).ToEnumerable(), accessPath13);
		TextAlignmentRight = Add("MAIN_MENU_EDITOR_TEXT_ALIGNMENT_RIGHT_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_ALIGNMENT_RIGHT_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.CloseBrackets, (ModifierKeys)6).ToEnumerable(), accessPath13);
		TextAlignmentJustify = Add("MAIN_MENU_EDITOR_TEXT_ALIGNMENT_JUSTIFIED_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_ALIGNMENT_JUSTIFIED_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.Backslash, (ModifierKeys)7).ToEnumerable(), accessPath13);
		TextAlignmentTop = Add("MAIN_MENU_EDITOR_TEXT_ALIGNMENT_TOP_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_ALIGNMENT_TOP_title"), null, accessPath13);
		TextAlignmentMiddle = Add("MAIN_MENU_EDITOR_TEXT_ALIGNMENT_MIDDLE_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_ALIGNMENT_MIDDLE_title"), null, accessPath13);
		TextAlignmentBottom = Add("MAIN_MENU_EDITOR_TEXT_ALIGNMENT_BOTTOM_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_TEXT_ALIGNMENT_BOTTOM_title"), null, accessPath13);
		IEnumerable<string> accessPath14 = LocalizedStrings.Get("MAIN_MENU_EDITOR_ARRANGEMENT_SUBMENU_title").ToEnumerable();
		ArrangementBringForward = Add("MAIN_MENU_EDITOR_ARRANGEMENT_BRING_FORWARD_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ARRANGEMENT_BRING_FORWARD_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.F, (ModifierKeys)3).ToEnumerable(), accessPath14);
		ArrangementBringToFront = Add("MAIN_MENU_EDITOR_ARRANGEMENT_BRING_TO_FRONT_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ARRANGEMENT_BRING_TO_FRONT_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.F, (ModifierKeys)6).ToEnumerable(), accessPath14);
		ArrangementSendBackward = Add("MAIN_MENU_EDITOR_ARRANGEMENT_SEND_BACKWARD_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ARRANGEMENT_SEND_BACKWARD_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.B, (ModifierKeys)3).ToEnumerable(), accessPath14);
		ArrangementSendToBack = Add("MAIN_MENU_EDITOR_ARRANGEMENT_SEND_TO_BACK_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ARRANGEMENT_SEND_TO_BACK_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.B, (ModifierKeys)6).ToEnumerable(), accessPath14);
		string[] accessPath15 = new string[2]
		{
			LocalizedStrings.Get("MAIN_MENU_EDITOR_ARRANGEMENT_SUBMENU_title"),
			LocalizedStrings.Get("MAIN_MENU_EDITOR_ARRANGEMENT_ALIGN_OBJECTS_SUBMENU_title")
		};
		ArrangementAlignObjLeft = Add("MAIN_MENU_EDITOR_ARRANGEMENT_ALIGN_OBJECTS_LEFT_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ARRANGEMENT_ALIGN_OBJECTS_LEFT_title"), null, accessPath15);
		ArrangementAlignObjCenter = Add("MAIN_MENU_EDITOR_ARRANGEMENT_ALIGN_OBJECTS_CENTER_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ARRANGEMENT_ALIGN_OBJECTS_CENTER_title"), null, accessPath15);
		ArrangementAlignObjRight = Add("MAIN_MENU_EDITOR_ARRANGEMENT_ALIGN_OBJECTS_RIGHT_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ARRANGEMENT_ALIGN_OBJECTS_RIGHT_title"), null, accessPath15);
		ArrangementAlignObjTop = Add("MAIN_MENU_EDITOR_ARRANGEMENT_ALIGN_OBJECTS_TOP_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ARRANGEMENT_ALIGN_OBJECTS_TOP_title"), null, accessPath15);
		ArrangementAlignObjMiddle = Add("MAIN_MENU_EDITOR_ARRANGEMENT_ALIGN_OBJECTS_MIDDLE_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ARRANGEMENT_ALIGN_OBJECTS_MIDDLE_title"), null, accessPath15);
		ArrangementAlignObjBottom = Add("MAIN_MENU_EDITOR_ARRANGEMENT_ALIGN_OBJECTS_BOTTOM_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ARRANGEMENT_ALIGN_OBJECTS_BOTTOM_title"), null, accessPath15);
		FlipVertical = Add("MAIN_MENU_EDITOR_ARRANGEMENT_FLIP_VERTICALLY_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ARRANGEMENT_FLIP_VERTICALLY_title"), null, accessPath14);
		FlipHorizontal = Add("MAIN_MENU_EDITOR_ARRANGEMENT_FLIP_HORIZONTALLY_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ARRANGEMENT_FLIP_HORIZONTALLY_title"), null, accessPath14);
		EventDistributeElements = Add("EDITOR_MENU_DISTRIBUTE_EVENLY_title", LocalizedStrings.Get("EDITOR_MENU_DISTRIBUTE_EVENLY_title"), null, accessPath14);
		HorizontalDistributeElements = Add("EDITOR_MENU_DISTRIBUTE_HORIZONTALLY_title", LocalizedStrings.Get("EDITOR_MENU_DISTRIBUTE_HORIZONTALLY_title"), null, accessPath14);
		VerticalDistributeElements = Add("EDITOR_MENU_DISTRIBUTE_VERTICALLY_title", LocalizedStrings.Get("EDITOR_MENU_DISTRIBUTE_VERTICALLY_title"), null, accessPath14);
		Lock = Add("MAIN_MENU_EDITOR_ARRANGEMENT_LOCK_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ARRANGEMENT_LOCK_title"), null, accessPath14);
		UnlockAll = Add("MAIN_MENU_EDITOR_ARRANGEMENT_UNLOCK_ALL_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ARRANGEMENT_UNLOCK_ALL_title"), null, accessPath14);
		ShowRulers = Add("MAIN_MENU_EDITOR_SHOW_RULERS_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_SHOW_RULERS_title"));
		ShowTemplateGuides = Add("MAIN_MENU_EDITOR_SHOW_TEMPLATE_GUIDES_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_SHOW_TEMPLATE_GUIDES_title"));
		ShowSlideGuides = Add("MAIN_MENU_EDITOR_SHOW_SLIDE_GUIDES_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_SHOW_SLIDE_GUIDES_title"));
		IEnumerable<string> accessPath16 = LocalizedStrings.Get("MAIN_MENU_EDITOR_ZOOM_SUBMENU_title").ToEnumerable();
		ZoomIn = Add("MAIN_MENU_EDITOR_ZOOM_ZOOM_IN_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ZOOM_ZOOM_IN_title"), null, accessPath16);
		ZoomOut = Add("MAIN_MENU_EDITOR_ZOOM_ZOOM_OUT_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ZOOM_ZOOM_OUT_title"), null, accessPath16);
		ZoomActualSize = Add("MAIN_MENU_EDITOR_ZOOM_ACTUAL_SIZE_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ZOOM_ACTUAL_SIZE_title"), null, accessPath16);
		ZoomFitSlide = Add("MAIN_MENU_EDITOR_ZOOM_FIT_SLIDE_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ZOOM_FIT_SLIDE_title"), null, accessPath16);
		ZoomFitCanvas = Add("MAIN_MENU_EDITOR_ZOOM_FIT_CANVAS_title", LocalizedStrings.Get("MAIN_MENU_EDITOR_ZOOM_FIT_CANVAS_title"), null, accessPath16);
		AddScreenPreviewElement = CreateInputAction("AddScreenPreviewElement", string.Empty);
		AddTimerStageItem = CreateInputAction("AddTimerStageItem", string.Empty);
		Unlock = CreateInputAction("EDITOR_MENU_UNLOCK_title", LocalizedStrings.Get("EDITOR_MENU_UNLOCK_title"));
		Hide = CreateInputAction("EDITOR_MENU_HIDE_title", LocalizedStrings.Get("EDITOR_MENU_HIDE_title"));
		FitToText = CreateInputAction("EDITOR_MENU_EXPAND_FIT_TEXT_title", LocalizedStrings.Get("EDITOR_MENU_EXPAND_FIT_TEXT_title"));
		OverlayEdit = CreateInputAction("EDITOR_MENU_EDIT_TEXT_OVERLAY_MODE_title", LocalizedStrings.Get("EDITOR_MENU_EDIT_TEXT_OVERLAY_MODE_title"));
	}

	protected override bool CanConflict(InputActionGroupBase other)
	{
		if (!(other is ReflowMenuGroup) && !(other is PresentationMenuGroup) && !(other is GroupLabelGroup) && !(other is PropGroup))
		{
			return !(other is MacroGroup);
		}
		return false;
	}
}
