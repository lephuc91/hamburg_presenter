using System;

namespace CoreApplication.PowerPointImport;

public abstract class PowerPointImportService
{
	protected unsafe ImportResult Import(byte[] importRequest)
	{
		PinnedArray_003Cunsigned_0020char_003E obj = null;
		PinnedArray_003Cunsigned_0020char_003E obj2 = new PinnedArray_003Cunsigned_0020char_003E(importRequest);
		ImportResult result;
		try
		{
			obj = obj2;
			ulong num = (ulong)obj.Length();
			int num2 = global::_003CModule_003E.CorePPTImport(obj.Get(), num);
			byte success = ((num2 == 0) ? ((byte)1) : ((byte)0));
			result = new ImportResult(success != 0, num2);
		}
		catch
		{
			//try-fault
			((IDisposable)obj).Dispose();
			throw;
		}
		((IDisposable)obj).Dispose();
		return result;
	}

	public PowerPointImportService()
	{
	}
}
