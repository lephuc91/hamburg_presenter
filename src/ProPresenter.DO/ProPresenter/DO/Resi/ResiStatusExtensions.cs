using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Resi;

public static class ResiStatusExtensions
{
	public static ResiStreamStatus ToStatus(this ProResiStreamState currentState)
	{
		return currentState switch
		{
			ProResiStreamState.Starting => ResiStreamStatus.Starting, 
			ProResiStreamState.StartCheck => ResiStreamStatus.StartCheck, 
			ProResiStreamState.Started => ResiStreamStatus.Started, 
			ProResiStreamState.StartError => ResiStreamStatus.StartError, 
			ProResiStreamState.Stopping => ResiStreamStatus.Stopping, 
			ProResiStreamState.StopCheck => ResiStreamStatus.StopCheck, 
			ProResiStreamState.Stopped => ResiStreamStatus.Stopped, 
			ProResiStreamState.StopError => ResiStreamStatus.StopError, 
			_ => ResiStreamStatus.Unknown, 
		};
	}
}
