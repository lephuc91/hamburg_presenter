using System.Collections;
using System.Collections.Generic;

namespace Pro.DxDiagReport;

public class DxDiagReaderEnumerable(IInternalDxDiagReader reader) : IEnumerable<IDxDiagProperty>
{
	private IInternalDxDiagReader m_reader = reader;

	public virtual IEnumerator<IDxDiagProperty> GetEnumeratorGeneric()
	{
		return new DxDiagReaderEnumerator(reader);
	}

	IEnumerator<IDxDiagProperty> IEnumerable<IDxDiagProperty>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEnumeratorGeneric
		return this.GetEnumeratorGeneric();
	}

	public virtual IEnumerator GetEnumerator()
	{
		return new DxDiagReaderEnumerator(reader);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
		return this.GetEnumerator();
	}
}
