namespace ProPresenter.DO.Analytics.Events.PowerPoint;

public interface IPowerPointEvents
{
	void ImportFromFile(string filePath, PowerPointImportType powerPointImportType);
}
