using Pro.Common.Mathematics;

namespace ProPresenter.DO.Import.Results;

public interface IPowerpointDestinationSelection : ILibraryAndPlaylistDestinationSelection
{
	Vector2<double> Size { get; }
}
