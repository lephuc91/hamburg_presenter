using Rv.Analytics.Powerpoint;

namespace ProPresenter.DO.Analytics.Events.PowerPoint;

public static class ProtoPowerPointImportEventExtensions
{
	public static ImportType ToProtoLocation(this PowerPointImportType importType)
	{
		if (importType == PowerPointImportType.CoreOpenXml)
		{
			return ImportType.CoreOpenXml;
		}
		return ImportType.SlidesAsImages;
	}
}
