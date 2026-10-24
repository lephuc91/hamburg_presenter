using System.Linq;
using Pro.Common.Collections;
using Pro.DO;
using Pro.Localization;
using Pro.UI.DialogService;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Hotkey;

public static class HotkeyHelper
{
	public static void AssignHotkey(SlideCue? cue, SlideHotkey hotkey)
	{
		IPresentation presentation = cue?.ParentPresentation;
		if (presentation != null)
		{
			SlideHotkey slideHotkey = hotkey;
			if ((object)slideHotkey == null || !slideHotkey.IsValid())
			{
				presentation.AssignHotkey(cue, null);
			}
			else if (!(from s in presentation.ArrangementGroups.SelectMany((CueGroup g) => g.Cues)
				where s != cue
				select s.Hotkey).NonNull().Any((Pro.DO.Hotkey s) => s == hotkey) || overwriteHotkey())
			{
				presentation.AssignHotkey(cue, hotkey);
			}
		}
		static bool overwriteHotkey()
		{
			return MessageDialogService.ShowDialog(LocalizedStrings.Get("PRESENTATION_HOTKEY_DIALOG_CONFLICT_ALERT_message"), LocalizedStrings.Get("PRESENTATION_HOTKEY_DIALOG_CONFLICT_ALERT_info"), HotkeyConflictButtons.Cancel | HotkeyConflictButtons.Replace, HotkeyConflictButtons.Replace) == HotkeyConflictButtons.Replace;
		}
	}
}
