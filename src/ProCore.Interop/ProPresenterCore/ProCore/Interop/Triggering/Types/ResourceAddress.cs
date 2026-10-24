using System;

namespace ProPresenterCore.ProCore.Interop.Triggering.Types;

public sealed class ResourceAddress
{
	public Guid ResourceID { get; }

	public ProResourceType ResourceType { get; }

	public ProLayerIndex Layer { get; }

	public Guid Slot { get; }

	public TriggerAddress? Trigger { get; }

	internal unsafe ResourceAddress(nint rawAddress)
	{
		ProResourceAddress.__Internal* ptr = (ProResourceAddress.__Internal*)((IntPtr)rawAddress).ToPointer();
		if (ptr != null)
		{
			ResourceID = *(Guid*)ptr->resource.bytes;
			ResourceType = ptr->type;
			Layer = ptr->layer;
			Slot = *(Guid*)ptr->slot.bytes;
			Trigger = new TriggerAddress(new IntPtr(&ptr->trigger));
		}
	}
}
