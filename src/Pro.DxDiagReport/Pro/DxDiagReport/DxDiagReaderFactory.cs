using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using std;

namespace Pro.DxDiagReport;

public class DxDiagReaderFactory : IDxDiagReaderFactory
{
	public unsafe virtual IDxDiagReader CreateRoot()
	{
		//IL_0008: Expected I8, but got I
		//IL_0070: Expected I, but got I8
		//IL_003b: Expected I, but got I8
		//IL_003b: Expected I, but got I8
		//IL_004b: Expected I, but got I8
		long num = (nint)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		try
		{
			Unsafe.SkipInit(out unique_ptr_003CProDxDiag_003A_003ADxDataReader_002Cstd_003A_003Adefault_delete_003CProDxDiag_003A_003ADxDataReader_003E_0020_003E obj);
			unique_ptr_003CProDxDiag_003A_003ADxDataReader_002Cstd_003A_003Adefault_delete_003CProDxDiag_003A_003ADxDataReader_003E_0020_003E* ptr = &obj;
			unique_ptr_003CProDxDiag_003A_003ADxDataReader_002Cstd_003A_003Adefault_delete_003CProDxDiag_003A_003ADxDataReader_003E_0020_003E* pointer = global::_003CModule_003E.ProDxDiag_002EDxDataReader_002ECreate(&obj);
			return new DxDiagReader(new ManagedUniquePtr_003CProDxDiag_003A_003ADxDataReader_003E(pointer));
		}
		catch when (((Func<bool>)delegate
		{
			// Could not convert BlockContainer to single expression
			uint exceptionCode = (uint)Marshal.GetExceptionCode();
			return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
		}).Invoke())
		{
			uint num2 = 0u;
			global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					return null;
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num2 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num2 != 0;
				}).Invoke())
				{
				}
				if (num2 != 0)
				{
					throw;
				}
			}
			finally
			{
				global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num2);
			}
		}
		return null;
	}
}
