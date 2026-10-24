using System;
using System.Runtime.InteropServices;
using System.Text;
using Pro.Common.Win32;

namespace Pro.Reporting;

public class UnmanagedException : Exception
{
	private static class NativeMethods
	{
		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void proStackWalkWin(nint context, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder buffer, int bufferSize);
	}

	private readonly string _stackTrace;

	public override string Message { get; }

	public override string StackTrace => _stackTrace;

	internal unsafe UnmanagedException(nint exceptionInfo, Exception? innerException = null)
		: base(null, innerException)
	{
		if (exceptionInfo != IntPtr.Zero)
		{
			if (((EXCEPTION_POINTERS*)exceptionInfo)->ExceptionRecord != IntPtr.Zero)
			{
				EXCEPTION_RECORD* exceptionRecord = (EXCEPTION_RECORD*)((EXCEPTION_POINTERS*)exceptionInfo)->ExceptionRecord;
				Message = exceptionRecord->Code.ToString();
				if (exceptionRecord->Code == EXCEPTION.STACK_OVERFLOW)
				{
					_stackTrace = Message;
					return;
				}
				StringBuilder stringBuilder = new StringBuilder(131072);
				NativeMethods.proStackWalkWin(((EXCEPTION_POINTERS*)exceptionInfo)->ContextRecord, stringBuilder, stringBuilder.Capacity);
				_stackTrace = stringBuilder.ToString();
				Message = Message + Environment.NewLine + Environment.NewLine + _stackTrace;
				return;
			}
		}
		_stackTrace = (Message = "Unknown native exception");
	}
}
