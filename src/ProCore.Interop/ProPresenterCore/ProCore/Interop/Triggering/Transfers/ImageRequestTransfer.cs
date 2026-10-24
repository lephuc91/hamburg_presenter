using Pro.Common.Components;

namespace ProPresenterCore.ProCore.Interop.Triggering.Transfers;

public class ImageRequestTransfer : DisposableBase
{
	private unsafe readonly ProImageRequestTransfer.__Internal* _native;

	public ProImageRequestTransferType ImageType { get; }

	public IBitmapHandle? Image { get; set; }

	public unsafe ImageRequestTransfer(ProImageRequestTransfer.__Internal* native)
	{
		_native = native;
		ImageType = _native->type;
	}

	internal unsafe void Apply()
	{
		Image?.BitmapSource?.Encode(ref _native->image, ref _native->imageSize);
	}

	protected override void OnDispose(bool disposeObjects)
	{
		if (disposeObjects)
		{
			Image?.Dispose();
		}
	}
}
