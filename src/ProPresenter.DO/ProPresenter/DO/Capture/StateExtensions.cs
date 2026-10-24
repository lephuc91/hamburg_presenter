using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Capture;

public static class StateExtensions
{
	public static State ToState(this ProScreenCaptureState state)
	{
		return state switch
		{
			ProScreenCaptureState.Inactive => State.Inactive, 
			ProScreenCaptureState.Active => State.Active, 
			ProScreenCaptureState.Caution => State.Caution, 
			_ => State.Error, 
		};
	}
}
