namespace Pro.Imaging;

public interface IImageDecoder
{
	void DecodeImage(byte[] data, BitmapDecodedDelegate onDecoded);

	void DecodeAnimation(byte[] data, AnimationFrameDecodedDelegate onFrameDecoded);
}
