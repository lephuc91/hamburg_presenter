using Pro.DO.Triggering;
using Pro.Localization;
using ProPresenter.DO.Actions.Capture;

namespace ProPresenter.DO.Actions;

public class WarningMessageStrategy : IWarningMessageStrategy
{
	public string AudioInput()
	{
		return LocalizedStrings.Get("AUDIO_INPUT_ACTION_ERROR_tooltip");
	}

	public string Playlist()
	{
		return LocalizedStrings.Get("PLAYLIST_ACTION_ERROR_tooltip");
	}

	public string Media(string name)
	{
		return LocalizedStrings.Get("PRESENTATION_MEDIA_ACTION_VALIDATION_ERROR_tooltip", new object[1] { name });
	}

	public string MediaFill(string? name)
	{
		return LocalizedStrings.Get("PRESENTATION_SLIDE_ACTION_VALIDATION_ELEMENT_MISSING_MEDIA_ERROR_tooltip", new object[1] { name });
	}

	public string Stage()
	{
		return LocalizedStrings.Get("PRESENTATION_STAGE_ACTION_VALIDATION_ERROR_tooltip");
	}

	public string Timer()
	{
		return LocalizedStrings.Get("PRESENTATION_TIMER_ACTION_VALIDATION_ERROR_tooltip");
	}

	public string Look(string name)
	{
		return LocalizedStrings.Get("PRESENTATION_LOOK_ACTION_VALIDATION_ERROR_tooltip", new object[1] { name });
	}

	public string Communication()
	{
		return LocalizedStrings.Get("PRESENTATION_COMMUNICATION_ACTION_VALIDATION_ERROR_tooltip");
	}

	public string Prop()
	{
		return LocalizedStrings.Get("PRESENTATION_PROP_ACTION_VALIDATION_ERROR_tooltip");
	}

	public string Message()
	{
		return LocalizedStrings.Get("PRESENTATION_MESSAGE_ACTION_VALIDATION_ERROR_tooltip");
	}

	public string Macro()
	{
		return LocalizedStrings.Get("PRESENTATION_MACRO_ACTION_VALIDATION_ERROR_tooltip");
	}

	public string ClearGroup()
	{
		return LocalizedStrings.Get("PRESENTATION_CLEAR_GROUP_ACTION_VALIDATION_ERROR_tooltip");
	}

	public string Capture(ICapture capture)
	{
		if (capture is CaptureStart captureStart)
		{
			return LocalizedStrings.Get("CAPTURE_ACTION_INVALID_tooltip", new object[1] { captureStart.PresetIdentifier.Name });
		}
		return string.Empty;
	}

	public string Default(ActionType actionType)
	{
		return typeof(ActionType).Name;
	}
}
