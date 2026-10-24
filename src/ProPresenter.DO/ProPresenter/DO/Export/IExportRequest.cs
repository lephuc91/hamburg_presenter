namespace ProPresenter.DO.Export;

public interface IExportRequest
{
	int ItemCount { get; }

	string CurrentItemName { get; set; }

	bool Archiving { get; set; }
}
