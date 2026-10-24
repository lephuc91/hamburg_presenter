using System;

namespace ProPresenterCore.ProCore.Interop;

public class ProResultException : Exception
{
	public ProResult ProResult { get; }

	internal ProResultException(ProResult result)
	{
		ProResult = result;
	}
}
