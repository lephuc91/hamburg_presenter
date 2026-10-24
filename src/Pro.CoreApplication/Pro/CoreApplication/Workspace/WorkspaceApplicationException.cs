using System;
using Pro.SerializationInterop.RVProtoData.Service.Workspace.Call;

namespace Pro.CoreApplication.Workspace;

public class WorkspaceApplicationException : Exception
{
	public Error? Error { get; }

	public WorkspaceApplicationException()
	{
	}

	public WorkspaceApplicationException(Error error)
		: base($"ErrorCode: {error.Code}")
	{
		Error = error;
	}

	public WorkspaceApplicationException(nint reference)
		: base($"Received native reference but expected proto array. Received:{reference}")
	{
	}

	public WorkspaceApplicationException(string errorDescription)
		: base(errorDescription)
	{
	}
}
