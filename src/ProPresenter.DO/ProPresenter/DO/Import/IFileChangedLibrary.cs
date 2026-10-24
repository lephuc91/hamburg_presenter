namespace ProPresenter.DO.Import;

public interface IFileChangedLibrary
{
	void UpdateName(IImportRequest request, string newName);

	string GetNewName(string filePath);
}
