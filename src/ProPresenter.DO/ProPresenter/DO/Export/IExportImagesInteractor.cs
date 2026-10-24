namespace ProPresenter.DO.Export;

public interface IExportImagesInteractor
{
	string GetInitialExportName();

	bool CanExecute();

	void Execute(IExportImageSettings settings);
}
