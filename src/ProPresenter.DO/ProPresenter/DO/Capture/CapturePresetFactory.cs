namespace ProPresenter.DO.Capture;

public class CapturePresetFactory : ICapturePresetFactory
{
	private readonly IStreamFactory _streamFactory;

	public CapturePresetFactory(IStreamFactory streamFactory)
	{
		_streamFactory = streamFactory;
	}

	public ICapturePreset Create()
	{
		return new CapturePreset(_streamFactory);
	}
}
