using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Pro.Common.Animation;

namespace ProPresenter.DO.Cache;

public interface IBitmapImageDecoder
{
	BitmapSource DecodeImage(byte[] data);

	IReadOnlyList<IAnimationFrame> DecodeAnimation(byte[] data);
}
