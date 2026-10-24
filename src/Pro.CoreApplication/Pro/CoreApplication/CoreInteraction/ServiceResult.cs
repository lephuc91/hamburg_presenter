using System;
using System.Diagnostics.CodeAnalysis;

namespace Pro.CoreApplication.CoreInteraction;

public record ServiceResult<T>
{
	public T Instance { get; }

	public Exception? Error { get; }

	[MemberNotNullWhen(true, "Instance")]
	[MemberNotNullWhen(false, "Error")]
	public bool IsSuccess
	{
		[MemberNotNullWhen(true, "Instance")]
		[MemberNotNullWhen(false, "Error")]
		get;
	}

	public bool IsFatalError { get; }

	public ServiceResult(T instance)
	{
		Instance = instance;
		IsSuccess = true;
	}

	public ServiceResult(T instance, Exception error, bool isFatalError)
	{
		Instance = instance;
		Error = error;
		IsSuccess = false;
		IsFatalError = isFatalError;
	}
}
