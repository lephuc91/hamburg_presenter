using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ProDxDiag;
using std;

namespace Pro.DxDiagReport;

internal class DxDiagReader(ManagedUniquePtr_003CProDxDiag_003A_003ADxDataReader_003E reader) : IInternalDxDiagReader
{
	private ManagedUniquePtr_003CProDxDiag_003A_003ADxDataReader_003E m_reader = reader;

	public virtual IEnumerable<IDxDiagProperty> Read()
	{
		return new DxDiagReaderEnumerable(this);
	}

	public unsafe virtual DxDiagReaderGetNextResult TryGetNext(uint nextIndex)
	{
		//IL_0008: Expected I8, but got I
		//IL_001e: Expected I, but got I8
		//IL_0354: Expected I, but got I8
		//IL_0321: Expected I, but got I8
		//IL_0321: Expected I, but got I8
		//IL_0331: Expected I, but got I8
		//IL_04ed: Expected I, but got I8
		//IL_04ba: Expected I, but got I8
		//IL_04ba: Expected I, but got I8
		//IL_04ca: Expected I, but got I8
		//IL_0378: Expected I, but got I8
		//IL_0049: Expected I, but got I8
		//IL_006e: Expected I, but got I8
		//IL_03ad: Expected I, but got I8
		//IL_0424: Expected I, but got I8
		//IL_0426: Expected I8, but got I
		//IL_042d: Expected I, but got I8
		long num = (nint)stackalloc byte[global::_003CModule_003E.__CxxQueryExceptionSize()];
		DxDataReader* intPtr = reader.op_MemberSelection();
		uint num2 = ((delegate* unmanaged[Cdecl, Cdecl]<nint, uint>)(*(ulong*)(*(long*)intPtr + 8)))((nint)intPtr);
		Unsafe.SkipInit(out basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E obj);
		Unsafe.SkipInit(out DxDataReader.Value value);
		Unsafe.SkipInit(out uint exceptionCode);
		Unsafe.SkipInit(out uint num5);
		while (nextIndex < num2)
		{
			try
			{
				DxDataReader* ptr = reader.op_MemberSelection();
				long num3 = *(long*)(*(long*)ptr + 16);
				((delegate* unmanaged[Cdecl, Cdecl]<nint, basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*, uint, basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*>)num3)((nint)ptr, &obj, nextIndex);
				try
				{
					DxDataReader* ptr2 = reader.op_MemberSelection();
					long num4 = *(long*)(*(long*)ptr2 + 24);
					((delegate* unmanaged[Cdecl, Cdecl]<nint, DxDataReader.Value*, basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*, DxDataReader.Value*>)num4)((nint)ptr2, &value, &obj);
					try
					{
						if (*(int*)(&value) != 1)
						{
							if (*(int*)(&value) == 2)
							{
								goto IL_01ff;
							}
							if (*(int*)(&value) == 3)
							{
								goto IL_017a;
							}
							if (*(int*)(&value) == 4)
							{
								goto IL_00f5;
							}
							goto IL_00a8;
						}
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<DxDataReader.Value*, void>)(&global::_003CModule_003E.ProDxDiag_002EDxDataReader_002EValue_002E_007Bdtor_007D), &value);
						throw;
					}
					goto end_IL_004a;
					IL_00a8:
					basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E* pThis = (basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*)Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref value, 8));
					try
					{
						global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_Tidy_deallocate((basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*)Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref value, 8)));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), pThis);
						throw;
					}
					goto IL_00d8;
					end_IL_004a:;
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_007Bdtor_007D), &obj);
					throw;
				}
				DxDiagReaderGetNextResult dxDiagReaderGetNextResult;
				try
				{
					try
					{
						dxDiagReaderGetNextResult = new DxDiagReaderGetNextResult(hasMore: true, nextIndex, new DxDiagPropertyGeneric<string>(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020std_003A_003Abasic_string_003Cwchar_t_002Cstruct_0020std_003A_003Achar_traits_003Cwchar_t_003E_002Cclass_0020std_003A_003Aallocator_003Cwchar_t_003E_0020_003E_0020_003E(&obj), global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020std_003A_003Abasic_string_003Cwchar_t_002Cstruct_0020std_003A_003Achar_traits_003Cwchar_t_003E_002Cclass_0020std_003A_003Aallocator_003Cwchar_t_003E_0020_003E_0020_003E((basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*)Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref value, 8)))));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<DxDataReader.Value*, void>)(&global::_003CModule_003E.ProDxDiag_002EDxDataReader_002EValue_002E_007Bdtor_007D), &value);
						throw;
					}
					basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E* pThis2 = (basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*)Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref value, 8));
					try
					{
						global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_Tidy_deallocate((basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*)Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref value, 8)));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), pThis2);
						throw;
					}
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_007Bdtor_007D), &obj);
					throw;
				}
				try
				{
					global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_Tidy_deallocate(&obj);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), &obj);
					throw;
				}
				DxDiagReaderGetNextResult dxDiagReaderGetNextResult2 = dxDiagReaderGetNextResult;
				GC.KeepAlive(this);
				return dxDiagReaderGetNextResult;
				IL_00f5:
				DxDiagReaderGetNextResult dxDiagReaderGetNextResult3;
				try
				{
					try
					{
						dxDiagReaderGetNextResult3 = new DxDiagReaderGetNextResult(hasMore: true, nextIndex, new DxDiagPropertyGeneric<uint>(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020std_003A_003Abasic_string_003Cwchar_t_002Cstruct_0020std_003A_003Achar_traits_003Cwchar_t_003E_002Cclass_0020std_003A_003Aallocator_003Cwchar_t_003E_0020_003E_0020_003E(&obj), Unsafe.As<DxDataReader.Value, uint>(ref Unsafe.AddByteOffset(ref value, 44))));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<DxDataReader.Value*, void>)(&global::_003CModule_003E.ProDxDiag_002EDxDataReader_002EValue_002E_007Bdtor_007D), &value);
						throw;
					}
					basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E* pThis3 = (basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*)Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref value, 8));
					try
					{
						global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_Tidy_deallocate((basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*)Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref value, 8)));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), pThis3);
						throw;
					}
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_007Bdtor_007D), &obj);
					throw;
				}
				try
				{
					global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_Tidy_deallocate(&obj);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), &obj);
					throw;
				}
				DxDiagReaderGetNextResult dxDiagReaderGetNextResult4 = dxDiagReaderGetNextResult3;
				GC.KeepAlive(this);
				return dxDiagReaderGetNextResult3;
				IL_01ff:
				DxDiagReaderGetNextResult dxDiagReaderGetNextResult5;
				try
				{
					try
					{
						dxDiagReaderGetNextResult5 = new DxDiagReaderGetNextResult(hasMore: true, nextIndex, new DxDiagPropertyGeneric<bool>(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020std_003A_003Abasic_string_003Cwchar_t_002Cstruct_0020std_003A_003Achar_traits_003Cwchar_t_003E_002Cclass_0020std_003A_003Aallocator_003Cwchar_t_003E_0020_003E_0020_003E(&obj), Unsafe.As<DxDataReader.Value, bool>(ref Unsafe.AddByteOffset(ref value, 4))));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<DxDataReader.Value*, void>)(&global::_003CModule_003E.ProDxDiag_002EDxDataReader_002EValue_002E_007Bdtor_007D), &value);
						throw;
					}
					basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E* pThis4 = (basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*)Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref value, 8));
					try
					{
						global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_Tidy_deallocate((basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*)Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref value, 8)));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), pThis4);
						throw;
					}
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_007Bdtor_007D), &obj);
					throw;
				}
				try
				{
					global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_Tidy_deallocate(&obj);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), &obj);
					throw;
				}
				DxDiagReaderGetNextResult dxDiagReaderGetNextResult6 = dxDiagReaderGetNextResult5;
				GC.KeepAlive(this);
				return dxDiagReaderGetNextResult5;
				IL_00d8:
				try
				{
					global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_Tidy_deallocate(&obj);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), &obj);
					throw;
				}
				goto end_IL_0026;
				IL_017a:
				DxDiagReaderGetNextResult dxDiagReaderGetNextResult7;
				try
				{
					try
					{
						dxDiagReaderGetNextResult7 = new DxDiagReaderGetNextResult(hasMore: true, nextIndex, new DxDiagPropertyGeneric<int>(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020std_003A_003Abasic_string_003Cwchar_t_002Cstruct_0020std_003A_003Achar_traits_003Cwchar_t_003E_002Cclass_0020std_003A_003Aallocator_003Cwchar_t_003E_0020_003E_0020_003E(&obj), Unsafe.As<DxDataReader.Value, int>(ref Unsafe.AddByteOffset(ref value, 40))));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<DxDataReader.Value*, void>)(&global::_003CModule_003E.ProDxDiag_002EDxDataReader_002EValue_002E_007Bdtor_007D), &value);
						throw;
					}
					basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E* pThis5 = (basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*)Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref value, 8));
					try
					{
						global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_Tidy_deallocate((basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*)Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref value, 8)));
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), pThis5);
						throw;
					}
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_007Bdtor_007D), &obj);
					throw;
				}
				try
				{
					global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_Tidy_deallocate(&obj);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), &obj);
					throw;
				}
				DxDiagReaderGetNextResult dxDiagReaderGetNextResult8 = dxDiagReaderGetNextResult7;
				GC.KeepAlive(this);
				return dxDiagReaderGetNextResult7;
				end_IL_0026:;
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				exceptionCode = (uint)Marshal.GetExceptionCode();
				return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						goto end_IL_0332;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num5 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num5 != 0;
					}).Invoke())
					{
					}
					if (num5 != 0)
					{
						throw;
					}
					end_IL_0332:;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
				}
			}
			nextIndex++;
		}
		DxDataReader* intPtr2 = reader.op_MemberSelection();
		uint num6 = ((delegate* unmanaged[Cdecl, Cdecl]<nint, uint>)(*(ulong*)(*(long*)intPtr2 + 32)))((nint)intPtr2) + num2;
		Unsafe.SkipInit(out basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E obj4);
		Unsafe.SkipInit(out unique_ptr_003CProDxDiag_003A_003ADxDataReader_002Cstd_003A_003Adefault_delete_003CProDxDiag_003A_003ADxDataReader_003E_0020_003E obj5);
		Unsafe.SkipInit(out basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E obj6);
		while (nextIndex < num6)
		{
			try
			{
				uint num7 = nextIndex - num2;
				DxDataReader* ptr3 = reader.op_MemberSelection();
				long num8 = *(long*)(*(long*)ptr3 + 40);
				((delegate* unmanaged[Cdecl, Cdecl]<nint, basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*, uint, basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*>)num8)((nint)ptr3, &obj4, num7);
				DxDiagReaderGetNextResult dxDiagReaderGetNextResult9;
				try
				{
					ulong needle_size = global::_003CModule_003E.std_002E_WChar_traits_003Cwchar_t_003E_002Elength((char*)Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BG_0040KFBKFMEH_0040_003F_0024AAD_003F_0024AAi_003F_0024AAr_003F_0024AAe_003F_0024AAc_003F_0024AAt_003F_0024AAP_003F_0024AAl_003F_0024AAa_003F_0024AAy_0040));
					ulong hay_size = Unsafe.As<basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E, ulong>(ref Unsafe.AddByteOffset(ref obj4, 16));
					ulong num9 = global::_003CModule_003E.std_002E_Traits_find_003Cstruct_0020std_003A_003Achar_traits_003Cwchar_t_003E_0020_003E(global::_003CModule_003E.std_002E_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002E_Myptr((_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E*)(&obj4)), hay_size, 0uL, (char*)Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BG_0040KFBKFMEH_0040_003F_0024AAD_003F_0024AAi_003F_0024AAr_003F_0024AAe_003F_0024AAc_003F_0024AAt_003F_0024AAP_003F_0024AAl_003F_0024AAa_003F_0024AAy_0040), needle_size);
					if (num9 == ulong.MaxValue)
					{
						unique_ptr_003CProDxDiag_003A_003ADxDataReader_002Cstd_003A_003Adefault_delete_003CProDxDiag_003A_003ADxDataReader_003E_0020_003E* ptr4 = &obj5;
						DxDataReader* ptr5 = reader.op_MemberSelection();
						long num10 = *(long*)(*(long*)ptr5 + 48);
						basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E* ptr6 = &obj6;
						basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E* ptr7 = global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_007Bctor_007D(&obj6, &obj4);
						long num11 = (nint)((delegate* unmanaged[Cdecl, Cdecl]<nint, unique_ptr_003CProDxDiag_003A_003ADxDataReader_002Cstd_003A_003Adefault_delete_003CProDxDiag_003A_003ADxDataReader_003E_0020_003E*, basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*, unique_ptr_003CProDxDiag_003A_003ADxDataReader_002Cstd_003A_003Adefault_delete_003CProDxDiag_003A_003ADxDataReader_003E_0020_003E*>)num10)((nint)ptr5, &obj5, ptr7);
						DxDiagReader dxDiagReader = new DxDiagReader(new ManagedUniquePtr_003CProDxDiag_003A_003ADxDataReader_003E((unique_ptr_003CProDxDiag_003A_003ADxDataReader_002Cstd_003A_003Adefault_delete_003CProDxDiag_003A_003ADxDataReader_003E_0020_003E*)num11));
						dxDiagReaderGetNextResult9 = new DxDiagReaderGetNextResult(hasMore: true, nextIndex, new DxDiagPropertyGeneric<IEnumerable<IDxDiagProperty>>(global::_003CModule_003E.msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020std_003A_003Abasic_string_003Cwchar_t_002Cstruct_0020std_003A_003Achar_traits_003Cwchar_t_003E_002Cclass_0020std_003A_003Aallocator_003Cwchar_t_003E_0020_003E_0020_003E(&obj4), dxDiagReader.Read()));
						goto IL_0461;
					}
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_007Bdtor_007D), &obj4);
					throw;
				}
				try
				{
					global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_Tidy_deallocate(&obj4);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), &obj4);
					throw;
				}
				goto end_IL_0384;
				IL_0461:
				try
				{
					global::_003CModule_003E.std_002Ebasic_string_003Cwchar_t_002Cstd_003A_003Achar_traits_003Cwchar_t_003E_002Cstd_003A_003Aallocator_003Cwchar_t_003E_0020_003E_002E_Tidy_deallocate(&obj4);
				}
				catch
				{
					//try-fault
					global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cwchar_t_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cwchar_t_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), &obj4);
					throw;
				}
				DxDiagReaderGetNextResult dxDiagReaderGetNextResult10 = dxDiagReaderGetNextResult9;
				GC.KeepAlive(this);
				return dxDiagReaderGetNextResult9;
				end_IL_0384:;
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				exceptionCode = (uint)Marshal.GetExceptionCode();
				return (byte)global::_003CModule_003E.__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				num5 = 0u;
				global::_003CModule_003E.__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						goto end_IL_04cb;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num5 = (uint)global::_003CModule_003E.__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num5 != 0;
					}).Invoke())
					{
					}
					if (num5 != 0)
					{
						throw;
					}
					end_IL_04cb:;
				}
				finally
				{
					global::_003CModule_003E.__CxxUnregisterExceptionObject((void*)num, (int)num5);
				}
			}
			nextIndex++;
		}
		GC.KeepAlive(this);
		return new DxDiagReaderGetNextResult(hasMore: false, nextIndex, null);
	}
}
