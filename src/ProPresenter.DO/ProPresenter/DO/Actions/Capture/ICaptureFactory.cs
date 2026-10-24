using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Actions.Capture;

public interface ICaptureFactory
{
	ICapture Create(CaptureType captureType);

	ICapture Create(Action.Types.CaptureType protoCapture);
}
