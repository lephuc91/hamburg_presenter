using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Capture;

namespace ProPresenter.DO.Actions.Capture;

public class CaptureFactory : ICaptureFactory
{
	private readonly ICaptureSettingsDocument _captureSettingsDocument;

	private readonly IResiService _resiService;

	public CaptureFactory(ICaptureSettingsDocument captureSettingsDocument, IResiService resiService)
	{
		_captureSettingsDocument = captureSettingsDocument;
		_resiService = resiService;
	}

	public ICapture Create(CaptureType captureType)
	{
		CaptureValidator validator = new CaptureValidator(_captureSettingsDocument, _resiService);
		if (captureType == CaptureType.Start)
		{
			return new CaptureStart(_captureSettingsDocument.Presets, validator);
		}
		return new CaptureStop(validator);
	}

	public ICapture Create(Action.Types.CaptureType protoCapture)
	{
		CaptureValidator validator = new CaptureValidator(_captureSettingsDocument, _resiService);
		ICapture capture = ((protoCapture.CaptureActionCase != Action.Types.CaptureType.CaptureActionOneofCase.Start) ? ((ICapture)new CaptureStop(validator)) : ((ICapture)new CaptureStart(_captureSettingsDocument.Presets, validator)));
		capture.Deserialize(protoCapture);
		return capture;
	}
}
