using System.Runtime.InteropServices;

namespace Pro.Common.Win32;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct MINIDUMP_EXCEPTION_INFORMATION
{
	private int _threadID;

	private nint _exceptionInfo;

	private bool _clientPointers;

	public int ThreadID
	{
		get
		{
			return _threadID;
		}
		set
		{
			_threadID = value;
		}
	}

	public nint ExceptionInfo
	{
		get
		{
			return _exceptionInfo;
		}
		set
		{
			_exceptionInfo = value;
		}
	}

	public bool ClientPointers
	{
		get
		{
			return _clientPointers;
		}
		set
		{
			_clientPointers = value;
		}
	}
}
