namespace ProPresenter.DO;

public interface IScrimSource
{
	ScrimPosition Position { get; }

	DisplayMode DisplayMode { get; }

	bool IsEditable { get; }

	ListViewType ListViewType { get; }
}
