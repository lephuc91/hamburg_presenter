using System;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop.Triggering.Types;

public sealed class TriggerAddress
{
	public Guid Cue { get; }

	public Guid Action { get; }

	public TriggerHandle Handle { get; }

	public object? ClientObject { get; }

	internal unsafe TriggerAddress(nint rawAddress)
	{
		ProTriggerAddress.__Internal* ptr = (ProTriggerAddress.__Internal*)((IntPtr)rawAddress).ToPointer();
		Cue = *(Guid*)ptr->cue.bytes;
		Action = *(Guid*)ptr->action.bytes;
		Handle = new TriggerHandle(ptr->handle);
		ClientObject = ((ptr->clientData != IntPtr.Zero) ? GCHandle.FromIntPtr(ptr->clientData).Target : null);
	}
}
