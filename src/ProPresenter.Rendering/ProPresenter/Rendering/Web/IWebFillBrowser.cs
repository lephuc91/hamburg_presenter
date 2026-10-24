using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Pro.Common.Mathematics;

namespace ProPresenter.Rendering.Web;

public interface IWebFillBrowser : IDisposable
{
	bool IsDisposed { get; }

	void SetSize(Vector2<double> size);

	Task GotoUrlAsync(string url, IEnumerable<Cookie>? cookies = null, string? script = null);

	BitmapSource? GetCurrentBitmap();

	string GetUrl();
}
