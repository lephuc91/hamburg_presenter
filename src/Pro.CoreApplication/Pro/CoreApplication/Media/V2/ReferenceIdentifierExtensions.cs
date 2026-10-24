using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

namespace Pro.CoreApplication.Media.V2;

public static class ReferenceIdentifierExtensions
{
	public static string ToSimpleDisplayString(this ReferenceIdentifier id)
	{
		return id.ContainerId + " - " + id.Uuid;
	}
}
