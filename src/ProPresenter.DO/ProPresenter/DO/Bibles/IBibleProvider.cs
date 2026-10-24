namespace ProPresenter.DO.Bibles;

public interface IBibleProvider
{
	AvailableBibleCollection AvailableBibles { get; }

	InstalledBibleCollection InstalledBibles { get; }

	LoadedBibleCollection LoadedBibles { get; }
}
