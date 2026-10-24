using System;
using System.Windows.Media.Imaging;

namespace Pro.Common.Animation;

public interface IAnimationFrame
{
	BitmapSource Image { get; }

	TimeSpan Duration { get; }
}
