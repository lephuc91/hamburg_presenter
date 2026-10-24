using System.Runtime.InteropServices;

namespace Pro.DxDiagReport;

public class DxDiagReaderGetNextResult([MarshalAs(UnmanagedType.U1)] bool hasMore, uint indexRead, IDxDiagProperty value)
{
	private bool m_has_more = hasMore;

	private uint m_index_read = indexRead;

	private IDxDiagProperty m_value = value;

	public IDxDiagProperty Value => value;

	public uint IndexRead => indexRead;

	public bool HasMore
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return hasMore;
		}
	}
}
