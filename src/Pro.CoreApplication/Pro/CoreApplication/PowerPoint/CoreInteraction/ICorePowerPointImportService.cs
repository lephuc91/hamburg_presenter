using CoreApplication.PowerPointImport;
using Pro.SerializationInterop.RVProtoData.PPTImport;

namespace Pro.CoreApplication.PowerPoint.CoreInteraction;

public interface ICorePowerPointImportService
{
	ImportResult ImportPPT(PPTImportParams importParams);
}
