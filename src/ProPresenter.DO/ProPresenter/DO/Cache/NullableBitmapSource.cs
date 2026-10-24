using System.Windows.Media.Imaging;

namespace ProPresenter.DO.Cache;

public class NullableBitmapSource
{
	private readonly BitmapSource? _value;

	public static NullableBitmapSource Default { get; } = new NullableBitmapSource(null);

	public NullableBitmapSource(BitmapSource? value)
	{
		_value = value;
	}

	public static implicit operator BitmapSource?(NullableBitmapSource value)
	{
		return value._value;
	}
}
