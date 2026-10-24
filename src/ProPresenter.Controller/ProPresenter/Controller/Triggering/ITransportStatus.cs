using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.Triggering;

public interface ITransportStatus
{
	TransportStatusEntry? GetStatus(ProLayerIndex layer);
}
