using System.Runtime.CompilerServices;

namespace Pro.CoreApplication.Registration.Interaction;

public record RegistrationOperationHandleResponse(bool MessageHandled, bool OperationCompleted)
{
	public static RegistrationOperationHandleResponse Unhandled { get; } = new RegistrationOperationHandleResponse(MessageHandled: false, OperationCompleted: false);

	[CompilerGenerated]
	protected RegistrationOperationHandleResponse(RegistrationOperationHandleResponse original)
	{
		MessageHandled = original.MessageHandled;
		OperationCompleted = original.OperationCompleted;
	}
}
