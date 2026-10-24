using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProCoreTestPatternsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProCoreTestPatternsReflection()
	{
		_003C_003Ey__InlineArray21<string> buffer = default(_003C_003Ey__InlineArray21<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 0) = "Chlwcm9Db3JlVGVzdFBhdHRlcm5zLnByb3RvEgdydi5kYXRhGhF0ZXN0UGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 1) = "dGVybi5wcm90bxoKdXVpZC5wcm90byKwAwoSVGVzdFBhdHRlcm5SZXF1ZXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 2) = "EkUKD2dldF9kZWZpbml0aW9ucxgBIAEoCzIqLnJ2LmRhdGEuVGVzdFBhdHRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 3) = "cm5SZXF1ZXN0LkdldERlZmluaXRpb25zSAASNgoRc2V0X2N1cnJlbnRfc3Rh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 4) = "dGUYAiABKAsyGS5ydi5kYXRhLlRlc3RQYXR0ZXJuU3RhdGVIABJIChFnZXRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 5) = "Y3VycmVudF9zdGF0ZRgDIAEoCzIrLnJ2LmRhdGEuVGVzdFBhdHRlcm5SZXF1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 6) = "ZXN0LkdldEN1cnJlbnRTdGF0ZUgAEkEKDWdldF90aHVtYm5haWwYBCABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 7) = "KC5ydi5kYXRhLlRlc3RQYXR0ZXJuUmVxdWVzdC5HZXRUaHVtYm5haWxIABoQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 8) = "Cg5HZXREZWZpbml0aW9ucxoRCg9HZXRDdXJyZW50U3RhdGUaXgoMR2V0VGh1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 9) = "bWJuYWlsEi8KB3BhdHRlcm4YASABKAsyHi5ydi5kYXRhLlRlc3RQYXR0ZXJu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 10) = "RGVmaW5pdGlvbhINCgV3aWR0aBgCIAEoBRIOCgZoZWlnaHQYAyABKAVCCQoH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 11) = "UmVxdWVzdCLoAgoTVGVzdFBhdHRlcm5SZXNwb25zZRJGCg9nZXRfZGVmaW5p";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 12) = "dGlvbnMYASABKAsyKy5ydi5kYXRhLlRlc3RQYXR0ZXJuUmVzcG9uc2UuR2V0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 13) = "RGVmaW5pdGlvbnNIABI2ChFnZXRfY3VycmVudF9zdGF0ZRgCIAEoCzIZLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 14) = "LmRhdGEuVGVzdFBhdHRlcm5TdGF0ZUgAEkIKDWdldF90aHVtYm5haWwYAyAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 15) = "KAsyKS5ydi5kYXRhLlRlc3RQYXR0ZXJuUmVzcG9uc2UuR2V0VGh1bWJuYWls";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 16) = "SAAaQgoOR2V0RGVmaW5pdGlvbnMSMAoIcGF0dGVybnMYASADKAsyHi5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 17) = "YXRhLlRlc3RQYXR0ZXJuRGVmaW5pdGlvbho9CgxHZXRUaHVtYm5haWwSHgoH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 18) = "cGF0dGVybhgBIAEoCzINLnJ2LmRhdGEuVVVJRBINCgVpbWFnZRgCIAEoDEIK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 19) = "CghSZXNwb25zZUI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 20) = "UHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray21<string>, string>(in buffer, 21))), new FileDescriptor[2]
		{
			TestPatternReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(TestPatternRequest), TestPatternRequest.Parser, new string[4] { "GetDefinitions", "SetCurrentState", "GetCurrentState", "GetThumbnail" }, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(TestPatternRequest.Types.GetDefinitions), TestPatternRequest.Types.GetDefinitions.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(TestPatternRequest.Types.GetCurrentState), TestPatternRequest.Types.GetCurrentState.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(TestPatternRequest.Types.GetThumbnail), TestPatternRequest.Types.GetThumbnail.Parser, new string[3] { "Pattern", "Width", "Height" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(TestPatternResponse), TestPatternResponse.Parser, new string[3] { "GetDefinitions", "GetCurrentState", "GetThumbnail" }, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(TestPatternResponse.Types.GetDefinitions), TestPatternResponse.Types.GetDefinitions.Parser, new string[1] { "Patterns" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(TestPatternResponse.Types.GetThumbnail), TestPatternResponse.Types.GetThumbnail.Parser, new string[2] { "Pattern", "Image" }, null, null, null, null)
			})
		}));
	}
}
