using System.Windows.Media.Imaging;

namespace ProPresenter.UI.Utility;

public interface ICustomIconProvider
{
	bool TryGetIcon(out BitmapSource? icon, string selectedFile);
}
