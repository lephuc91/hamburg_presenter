namespace ProPresenter.DO.Import;

public enum ImportStatus
{
	Pending,
	Converting,
	Migrating,
	Importing,
	Succeeded,
	Failed,
	Skipped,
	Extracting
}
