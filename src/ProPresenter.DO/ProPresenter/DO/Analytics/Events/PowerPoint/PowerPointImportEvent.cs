using System.IO;
using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Rv.Analytics.Powerpoint;

namespace ProPresenter.DO.Analytics.Events.PowerPoint;

public record PowerPointImportEvent(string FilePath, PowerPointImportType PowerPointImportType) : IAnalyticEvent
{
	public static void Publish(string filePath, PowerPointImportType powerPointImportType)
	{
		EventPublisher.Publish(new PowerPointImportEvent(filePath, powerPointImportType));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			ImportPowerPoint importPowerPoint = new ImportPowerPoint
			{
				Type = PowerPointImportType.ToProtoLocation()
			};
			ImportPowerPoint importPowerPoint2 = importPowerPoint;
			string text = Path.GetExtension(FilePath).ToLower();
			ImportFormat format = ((text == ".ppt") ? ImportFormat.Ppt : ((text == ".pptx") ? ImportFormat.Pptx : ImportFormat.Unkown));
			importPowerPoint2.Format = format;
			e.ImportPowerpoint = importPowerPoint;
		});
	}
}
