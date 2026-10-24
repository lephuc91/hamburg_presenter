namespace ProPresenter.DO.Import.Results;

public interface IFileCreator
{
	void Copy(string source, string dest);

	void CreateDirectory(string dir);

	bool DirectoryExists(string dir);
}
