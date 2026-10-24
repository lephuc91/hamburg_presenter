using ProPresenter.DO.Media.Properties;

namespace ProPresenter.DO.Media;

public interface IDrawMedia
{
	DrawingProperties Drawing { get; }

	bool SupportsScaleAndBlur { get; }

	bool SupportsCustomScale { get; }
}
