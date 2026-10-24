using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using Pro.Common.SourceGenerator.Attributes;

namespace Pro.Common.Collections;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_input" })]
public class GeneralizingGenericEnumerator<TConcrete, TGeneral> : IEnumerator<TGeneral>, IEnumerator, IDisposable where TConcrete : TGeneral
{
	private readonly IEnumerator<TConcrete> _input;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public TGeneral Current => (TGeneral)(object)_input.Current;

	object IEnumerator.Current => ((IEnumerator)_input).Current;

	public GeneralizingGenericEnumerator(IEnumerator<TConcrete> input)
	{
		_input = input;
	}

	public bool MoveNext()
	{
		return _input.MoveNext();
	}

	public void Reset()
	{
		_input.Reset();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_input.Dispose();
		}
	}
}
