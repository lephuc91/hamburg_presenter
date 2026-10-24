using CoreApplication.PowerPointImport;
using Google.Protobuf;
using Pro.SerializationInterop.RVProtoData.PPTImport;

namespace Pro.CoreApplication.PowerPoint.CoreInteraction;

public class CorePowerPointImportService : global::CoreApplication.PowerPointImport.PowerPointImportService, ICorePowerPointImportService
{
	public ImportResult ImportPPT(PPTImportParams importParams)
	{
		return Import(importParams.ToByteArray());
	}
}
