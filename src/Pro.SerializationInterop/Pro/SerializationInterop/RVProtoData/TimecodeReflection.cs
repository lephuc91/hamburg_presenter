using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class TimecodeReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static TimecodeReflection()
	{
		_003C_003Ey__InlineArray9<string> buffer = default(_003C_003Ey__InlineArray9<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 0) = "Cg50aW1lY29kZS5wcm90bxIHcnYuZGF0YRoKdXVpZC5wcm90byKYAgoQVGlt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 1) = "ZWNvZGVTZXR0aW5ncxIZChFkZXZpY2VfaWRlbnRpZmllchgBIAEoCRIPCgdj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 2) = "aGFubmVsGAIgASgFEjAKBmZvcm1hdBgDIAEoDjIgLnJ2LmRhdGEuVGltZWNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 3) = "ZGVTZXR0aW5ncy5Gb3JtYXQSDgoGb2Zmc2V0GAQgASgBEioKE3BsYXlsaXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 4) = "X2lkZW50aWZpZXIYBSABKAsyDS5ydi5kYXRhLlVVSUQSEQoJaXNfYWN0aXZl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 5) = "GAYgASgIIlcKBkZvcm1hdBIRCg1GT1JNQVRfMjRfRlBTEAASEQoNRk9STUFU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 6) = "XzI1X0ZQUxABEhQKEEZPUk1BVF8yOV85N19GUFMQAhIRCg1GT1JNQVRfMzBf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 7) = "RlBTEANCNPgBAaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3Rv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 8) = "RGF0YboCB1JWRGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<string>, string>(in buffer, 9))), new FileDescriptor[1] { UuidReflection.Descriptor }, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(TimecodeSettings), TimecodeSettings.Parser, new string[6] { "DeviceIdentifier", "Channel", "Format", "Offset", "PlaylistIdentifier", "IsActive" }, null, new Type[1] { typeof(TimecodeSettings.Types.Format) }, null, null)
		}));
	}
}
