using Pro.UI.InputActions;

namespace ProPresenter.DO.InputActionMap;

public interface IProPresenterGroup
{
	InputAction AddMediaMarker { get; }

	InputAction AddSelectedCuesToPlaylist { get; }

	InputAction AddSelectionToNewTheme { get; }

	InputAction AddSelectionToTheme { get; }

	InputAction BreakTextToNewSlide { get; }

	InputAction BreakTextToNextSlide { get; }

	InputAction ConfigureGroupHotkey { get; }

	InputAction ConvertPCOPlaylist { get; }

	InputAction DeleteTheme { get; }

	InputAction EditTheme { get; }

	InputAction NewPCOPlaylist { get; }

	InputAction NewTheme { get; }

	InputAction NextSlideWithSuppression { get; }

	InputAction OpenMediaInspector { get; }

	InputAction OpenPCOAttachmentManager { get; }

	InputAction PlaybackJumpBack { get; }

	InputAction PlaybackJumpEnd { get; }

	InputAction PlaybackJumpForward { get; }

	InputAction PlaybackJumpStart { get; }

	InputAction RefreshPCOPlaylist { get; }

	InputAction SetMediaInPoint { get; }

	InputAction SetMediaOutPoint { get; }

	InputAction TogglePlaybackState { get; }
}
