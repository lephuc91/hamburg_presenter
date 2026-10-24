using System.Collections.Generic;
using System.Windows.Input;
using Pro.Common.FeatureFlag;
using Pro.Localization;
using Pro.UI.InputActions;

namespace ProPresenter.DO.InputActionMap;

public class ProMenuGroup : InputActionGroupBase
{
	public InputAction About { get; }

	public InputAction CheckForUpdates { get; }

	public InputAction Quit { get; }

	public InputAction OpenSettings { get; }

	public InputAction General { get; }

	public InputAction Screens { get; }

	public InputAction Import { get; }

	public InputAction Groups { get; }

	public InputAction Input { get; }

	public InputAction Network { get; }

	public InputAction? Sync { get; }

	public InputAction Audio { get; }

	public InputAction Devices { get; }

	public InputAction Updates { get; }

	public InputAction Account { get; }

	public InputAction Media { get; }

	public InputAction Integrations { get; }

	public InputAction SlideLabels { get; }

	public ProMenuGroup(string label, InputActionGroupCollectionBase parent, IFlagService flagService)
		: base(label, parent)
	{
		About = Add("MAIN_MENU_APPLICATION_ABOUT_PROPRESENTER_title", LocalizedStrings.Get("MAIN_MENU_APPLICATION_ABOUT_PROPRESENTER_title"));
		CheckForUpdates = Add("MAIN_MENU_APPLICATION_CHECK_FOR_UPDATES_title", LocalizedStrings.Get("MAIN_MENU_APPLICATION_CHECK_FOR_UPDATES_title"));
		Quit = Add("MAIN_MENU_APPLICATION_QUIT_mac_title", LocalizedStrings.Get("GLOBAL_QUIT"), new global::_003C_003Ez__ReadOnlySingleElementList<VirtualKeyGesture>(VirtualKeyGesture.CreateKeyGesture(VirtualKey.Q, (ModifierKeys)2)));
		string text = "MAIN_MENU_APPLICATION_SETTINGS_title";
		IEnumerable<string> accessPath = new global::_003C_003Ez__ReadOnlySingleElementList<string>(LocalizedStrings.Get(text));
		OpenSettings = Add(text, LocalizedStrings.Get(text), new global::_003C_003Ez__ReadOnlySingleElementList<VirtualKeyGesture>(VirtualKeyGesture.CreateKeyGesture(VirtualKey.Comma, (ModifierKeys)2)));
		Account = Add("MAIN_MENU_APPLICATION_SETTINGS_ACCOUNT_title", LocalizedStrings.Get("MAIN_MENU_APPLICATION_SETTINGS_ACCOUNT_title"), null, accessPath);
		General = Add("MAIN_MENU_APPLICATION_PREFERENCES_GENERAL_title", LocalizedStrings.Get("MAIN_MENU_APPLICATION_PREFERENCES_GENERAL_title"), null, accessPath);
		Updates = Add("MAIN_MENU_APPLICATION_PREFERENCES_UPDATES_title", LocalizedStrings.Get("MAIN_MENU_APPLICATION_PREFERENCES_UPDATES_title"), null, accessPath);
		Screens = Add("MAIN_MENU_APPLICATION_PREFERENCES_SCREENS_title", LocalizedStrings.Get("MAIN_MENU_APPLICATION_PREFERENCES_SCREENS_title"), null, accessPath);
		Network = Add("MAIN_MENU_APPLICATION_PREFERENCES_NETWORK_title", LocalizedStrings.Get("MAIN_MENU_APPLICATION_PREFERENCES_NETWORK_title"), null, accessPath);
		Input = Add("MAIN_MENU_APPLICATION_PREFERENCES_INPUTS_title", LocalizedStrings.Get("MAIN_MENU_APPLICATION_PREFERENCES_INPUTS_title"), null, accessPath);
		Devices = Add("MAIN_MENU_APPLICATION_PREFERENCES_DEVICES_title", LocalizedStrings.Get("MAIN_MENU_APPLICATION_PREFERENCES_DEVICES_title"), null, accessPath);
		Media = Add("MAIN_MENU_APPLICATION_SETTINGS_MEDIA_title", LocalizedStrings.Get("MAIN_MENU_APPLICATION_SETTINGS_MEDIA_title"), null, accessPath);
		Audio = Add("MAIN_MENU_APPLICATION_PREFERENCES_AUDIO_title", LocalizedStrings.Get("MAIN_MENU_APPLICATION_PREFERENCES_AUDIO_title"), null, accessPath);
		Import = Add("MAIN_MENU_APPLICATION_PREFERENCES_IMPORT_title", LocalizedStrings.Get("MAIN_MENU_APPLICATION_PREFERENCES_IMPORT_title"), null, accessPath);
		Integrations = Add("MAIN_MENU_APPLICATION_SETTINGS_INTEGRATIONS_title", LocalizedStrings.Get("MAIN_MENU_APPLICATION_SETTINGS_INTEGRATIONS_title"), null, accessPath);
		Groups = Add("MAIN_MENU_APPLICATION_PREFERENCES_GROUPS_AND_LABELS_title", LocalizedStrings.Get("MAIN_MENU_APPLICATION_PREFERENCES_GROUPS_AND_LABELS_title"), null, accessPath);
		SlideLabels = Add("MAIN_MENU_APPLICATION_SETTINGS_SLIDELABELS_title", LocalizedStrings.Get("MAIN_MENU_APPLICATION_SETTINGS_SLIDELABELS_title"), null, accessPath);
		if (!flagService.IsFlagEnabled(Flag.Cloud))
		{
			Sync = Add("MAIN_MENU_APPLICATION_PREFERENCES_SYNC_title", LocalizedStrings.Get("MAIN_MENU_APPLICATION_PREFERENCES_SYNC_title"), null, accessPath);
		}
	}
}
