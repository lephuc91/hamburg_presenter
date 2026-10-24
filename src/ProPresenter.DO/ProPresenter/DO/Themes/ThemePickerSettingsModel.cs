using Pro.Common.Components;

namespace ProPresenter.DO.Themes;

public class ThemePickerSettingsModel : NotifyPropertyChangedBase
{
	private bool _mediaActionEnabled = true;

	public ThemePickerGroup ContextualGroup { get; }

	public bool MediaActionEnabled
	{
		get
		{
			return _mediaActionEnabled;
		}
		set
		{
			SetValue("MediaActionEnabled", ref _mediaActionEnabled, value);
		}
	}

	public ThemePickerSettingsModel(ThemePickerGroup contextualGroup)
	{
		ContextualGroup = contextualGroup;
	}
}
