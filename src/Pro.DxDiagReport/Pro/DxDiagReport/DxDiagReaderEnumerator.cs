using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Pro.DxDiagReport;

public class DxDiagReaderEnumerator(IInternalDxDiagReader reader) : IEnumerator<IDxDiagProperty>
{
	private IInternalDxDiagReader m_reader = reader;

	private uint m_next_index = 0u;

	private IDxDiagProperty m_current;

	public virtual object CurrentNonGeneric => m_current;

	public virtual IDxDiagProperty Current => m_current;

	private void _007EDxDiagReaderEnumerator()
	{
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public virtual bool MoveNext()
	{
		DxDiagReaderGetNextResult dxDiagReaderGetNextResult = reader.TryGetNext(m_next_index);
		m_current = dxDiagReaderGetNextResult.Value;
		m_next_index = dxDiagReaderGetNextResult.IndexRead + 1;
		bool hasMore = dxDiagReaderGetNextResult.HasMore;
		GC.KeepAlive(this);
		return hasMore;
	}

	public virtual void Reset()
	{
		m_next_index = 0u;
	}

	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_007EDxDiagReaderEnumerator();
		}
		else
		{
			base.Finalize();
		}
	}

	public virtual sealed void Dispose()
	{
		Dispose(A_0: true);
		GC.SuppressFinalize(this);
		GC.KeepAlive(this);
	}
}
