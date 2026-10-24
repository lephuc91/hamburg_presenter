using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Pro.Common.HTTP.Results;

public record ErrorResult : IRequestResult
{
	private Exception? Exception;

	public ErrorResult()
	{
	}

	public ErrorResult(Exception e)
	{
		Exception = e;
	}

	[CompilerGenerated]
	protected virtual bool PrintMembers(StringBuilder builder)
	{
		return false;
	}
}
public record ErrorResult<T>(T Data) : ErrorResult();
