using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public class BitmapFill : FillBase
{
	public override FillType Type => FillType.Bitmap;

	public override string DisplayName => string.Empty;

	public BitmapSource? Bitmap { get; }

	public BitmapFill(BitmapSource? bitmap)
	{
		Bitmap = bitmap;
	}

	public override IFill Clone()
	{
		return new BitmapFill(Bitmap);
	}

	public override Color Sample()
	{
		throw new NotSupportedException();
	}
}
