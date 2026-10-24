using System;
using Pro.SerializationInterop.RVProtoData.Registration;

namespace ProPresenter.DO.Registration;

public class RegistrationException : Exception
{
	public RegistrationException(Status status)
		: base($"Registration operation failed because of status:{status}")
	{
	}
}
