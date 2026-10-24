using System.Diagnostics.CodeAnalysis;
using Pro.Common.Logging;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller.Triggering;

internal static class TriggerExtensions
{
	public static bool TryGetOperation(this TriggerAddress? address, [NotNullWhen(true)] out TriggerOperation? operation)
	{
		if (address != null)
		{
			if (address.ClientObject is TriggerOperation triggerOperation)
			{
				operation = triggerOperation;
				return true;
			}
		}
		else
		{
			Log.Error("TriggerAddress is null");
		}
		operation = null;
		return false;
	}
}
