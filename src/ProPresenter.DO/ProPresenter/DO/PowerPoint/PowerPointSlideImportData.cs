namespace ProPresenter.DO.PowerPoint;

public class PowerPointSlideImportData
{
	public string ImagePath { get; }

	public string Notes { get; }

	public PowerPointSlideImportData(string imagePath, string notes = "")
	{
		ImagePath = imagePath;
		Notes = notes;
	}
}
