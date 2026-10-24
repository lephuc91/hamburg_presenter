namespace ProPresenter.DO.ProContent.Model.Format;

public interface IProContentFormat
{
	string Id { get; }

	string Name { get; }

	int Width { get; }

	int Height { get; }

	double? Framerate { get; }

	bool? Interlaced { get; }
}
