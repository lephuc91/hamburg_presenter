namespace ProPresenter.DO.Analytics.Events.PowerPoint;

public class PowerPointEvents : IPowerPointEvents
{
	public void ImportFromFile(string filePath, PowerPointImportType powerPointImportType)
	{
		PowerPointImportEvent.Publish(filePath, powerPointImportType);
	}
}
