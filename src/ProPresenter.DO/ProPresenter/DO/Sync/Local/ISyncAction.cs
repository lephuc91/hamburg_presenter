namespace ProPresenter.DO.Sync.Local;

public interface ISyncAction
{
	ISyncData Data { get; }

	void Execute();
}
