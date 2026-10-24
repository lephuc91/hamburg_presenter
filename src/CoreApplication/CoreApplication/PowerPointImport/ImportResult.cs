using System.Runtime.InteropServices;

namespace CoreApplication.PowerPointImport;

public class ImportResult([MarshalAs(UnmanagedType.U1)] bool success, int errorCode)
{
	private bool _success = success;

	private int _errorCode = errorCode;

	public int ErrorCode => errorCode;

	public bool Success
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return success;
		}
	}
}
