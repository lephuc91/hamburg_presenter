using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;
using Pro.DO.Label;
using Pro.Localization;

namespace ProPresenter.DO.Label;

public static class DefaultLabels
{
	public static IEnumerable<GroupLabel> Group => new GroupLabel[25]
	{
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_VERSE_title"), DefaultColors.Verse1, (Key)44),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_VERSE_1_title"), DefaultColors.Verse1, (Key)44),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_VERSE_2_title"), DefaultColors.Verse2, (Key)62),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_VERSE_3_title"), DefaultColors.Verse3, (Key)47),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_VERSE_4_title"), DefaultColors.Verse4, (Key)49),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_VERSE_5_title"), DefaultColors.Verse5, (Key)50),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_VERSE_6_title"), DefaultColors.Verse6, (Key)51),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_CHORUS_title"), DefaultColors.Chorus1, (Key)46),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_CHORUS_1_title"), DefaultColors.Chorus1, (Key)46),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_CHORUS_2_title"), DefaultColors.Chorus2, (Key)67),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_CHORUS_3_title"), DefaultColors.Chorus3, (Key)69),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_CHORUS_4_title"), DefaultColors.Chorus4, (Key)0),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_BRIDGE_title"), DefaultColors.Bridge1, (Key)45),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_BRIDGE_1_title"), DefaultColors.Bridge1, (Key)45),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_BRIDGE_2_title"), DefaultColors.Bridge2, (Key)57),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_BRIDGE_3_title"), DefaultColors.Bridge3, (Key)56),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_PRECHORUS_title"), DefaultColors.PreChorus, (Key)59),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_TAG_title"), DefaultColors.Tag, (Key)63),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_INTRO_title"), DefaultColors.Intro, (Key)52),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_ENDING_title"), DefaultColors.Ending, (Key)48),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_OUTRO_title"), DefaultColors.Outro, (Key)58),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_INTERLUDE_title"), DefaultColors.Interlude, (Key)0),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_VAMP_title"), DefaultColors.Interlude, (Key)0),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_TURNAROUND_title"), DefaultColors.Interlude, (Key)0),
		new GroupLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_GROUP_BLANK_title"), DefaultColors.Blank, (Key)0)
	};

	public static IEnumerable<ActionLabel> Slide => new ActionLabel[4]
	{
		new ActionLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_LABEL_BLANK_SLIDE_title"), Colors.Transparent),
		new ActionLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_LABEL_INSTRUMENTAL_title"), Colors.Transparent),
		new ActionLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_LABEL_REPEAT_title"), Colors.Transparent),
		new ActionLabel(LocalizedStrings.Get("LABEL_PREFERENCES_DEFAULT_LABEL_SPOKEN_WORD_title"), Colors.Transparent)
	};
}
