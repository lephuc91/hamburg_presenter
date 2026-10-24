using ProPresenterCore.ProCore.Interop.Utility;

namespace ProPresenterCore.ProCore.Interop.Resi.Types;

public class DestinationGroup
{
	public string Id { get; }

	public string Name { get; }

	public unsafe DestinationGroup(ProResiDestinationGroup.__Internal* destinationGroupPtr)
	{
		Id = StringMarshalling.StringFromCString(destinationGroupPtr->id);
		Name = StringMarshalling.StringFromCString(destinationGroupPtr->name);
	}
}
