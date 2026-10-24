using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.FeatureFlag;
using Pro.Common.Versioning;
using Pro.Localization;
using Pro.UI.InputActions;

namespace ProPresenter.DO.InputActionMap;

public class HelpMenuGroup : InputActionGroupBase
{
	public InputAction ContactSupport { get; }

	public InputAction KnowledgeBase { get; }

	public InputAction VideoTutorials { get; }

	public InputAction SubmitFeedback { get; }

	public InputAction ReleaseNotes { get; }

	public InputAction ReportIssue { get; }

	public InputAction CrashReport { get; }

	public InputAction WhatsNew { get; }

	public InputAction FindMyMouse { get; }

	public InputAction AdvancedOnScreenStats { get; }

	public InputAction DownloadSampleContent { get; }

	public InputAction DumpWorkspaceInfo { get; }

	public bool ShowWhatsNew { get; }

	public HelpMenuGroup(string label, InputActionGroupCollectionBase parent, IFlagService flagService, IVersionInfoProvider versionInfoProvider)
		: base(label, parent)
	{
		ShowWhatsNew = versionInfoProvider.AppVersion.Major != 22 || !flagService.IsFlagEnabled(Flag.Cloud);
		ContactSupport = Add("MAIN_MENU_HELP_CONTACT_SUPPORT_title", LocalizedStrings.Get("MAIN_MENU_HELP_CONTACT_SUPPORT_title"));
		KnowledgeBase = Add("MAIN_MENU_HELP_KNOWLEDGE_BASE_title", LocalizedStrings.Get("MAIN_MENU_HELP_KNOWLEDGE_BASE_title"));
		VideoTutorials = Add("MAIN_MENU_HELP_VIDEO_TUTORIALS_title", LocalizedStrings.Get("MAIN_MENU_HELP_VIDEO_TUTORIALS_title"));
		DownloadSampleContent = Add("WELCOME_WINDOW_APPENDIX_SAMPLE_CONTENT_title", LocalizedStrings.Get("WELCOME_WINDOW_APPENDIX_SAMPLE_CONTENT_title"));
		ReportIssue = Add("MAIN_MENU_HELP_REPORT_AN_ISSUE_title", LocalizedStrings.Get("MAIN_MENU_HELP_REPORT_AN_ISSUE_title"));
		SubmitFeedback = Add("MAIN_MENU_HELP_SUBMIT_FEEDBACK_title", LocalizedStrings.Get("MAIN_MENU_HELP_SUBMIT_FEEDBACK_title"));
		CrashReport = Add("MAIN_MENU_HELP_SUBMIT_CRASH_REPORT_title", LocalizedStrings.Get("MAIN_MENU_HELP_SUBMIT_CRASH_REPORT_title"));
		WhatsNew = Add("MAIN_MENU_HELP_WHATS_NEW_title", LocalizedStrings.Get("MAIN_MENU_HELP_WHATS_NEW_title"));
		ReleaseNotes = Add("MAIN_MENU_HELP_RELEASE_NOTES_title", LocalizedStrings.Get("MAIN_MENU_HELP_RELEASE_NOTES_title"));
		FindMyMouse = Add("MAIN_MENU_HELP_FIND_MY_MOUSE_title", LocalizedStrings.Get("MAIN_MENU_HELP_FIND_MY_MOUSE_title"), VirtualKeyGesture.CreateKeyGesture(VirtualKey.M, (ModifierKeys)1).ToEnumerable());
		AdvancedOnScreenStats = CreateInputAction("MAIN_MENU_HELP_ADVANCED_ON_SCREEN_STATS_title", LocalizedStrings.Get("MAIN_MENU_HELP_ADVANCED_ON_SCREEN_STATS_title"));
		DumpWorkspaceInfo = CreateInputAction("MAIN_MENU_HELP_DUMP_WORKSPACE_INFO_title", LocalizedStrings.Get("MAIN_MENU_HELP_LOG_CLOUD_STATE_title"));
	}
}
