using System.Windows.Media.Imaging;

namespace ProPresenter.Controller.Remote.Apps;

public interface IImageEncoder
{
	string Encode(BitmapSource? source);
}
