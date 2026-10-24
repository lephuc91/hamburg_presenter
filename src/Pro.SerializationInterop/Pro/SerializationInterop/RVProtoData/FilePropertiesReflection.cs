using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class FilePropertiesReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static FilePropertiesReflection()
	{
		_003C_003Ey__InlineArray9<string> buffer = default(_003C_003Ey__InlineArray9<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 0) = "ChRmaWxlUHJvcGVydGllcy5wcm90bxIHcnYuZGF0YRoTY3VzdG9tT3B0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 1) = "cy5wcm90bxoJdXJsLnByb3RvIoUCCg5GaWxlUHJvcGVydGllcxIfCglsb2Nh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 2) = "bF91cmwYASABKAsyDC5ydi5kYXRhLlVSTBJDChFyZW1vdGVfcHJvcGVydGll";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 3) = "cxgCIAEoCzIoLnJ2LmRhdGEuRmlsZVByb3BlcnRpZXMuUmVtb3RlUHJvcGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 4) = "dGllcxqMAQoQUmVtb3RlUHJvcGVydGllcxJHCgpwcm9jb250ZW50GAEgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 5) = "MjMucnYuZGF0YS5GaWxlUHJvcGVydGllcy5SZW1vdGVQcm9wZXJ0aWVzLlBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 6) = "b0NvbnRlbnQaLwoKUHJvQ29udGVudBIhChNkb3dubG9hZF9pZGVudGlmaWVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 7) = "GAEgASgJQgSghhkBQjT4AQGqAiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3Au";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 8) = "UlZQcm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<string>, string>(in buffer, 9))), new FileDescriptor[2]
		{
			CustomOptionsReflection.Descriptor,
			UrlReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(FileProperties), FileProperties.Parser, new string[2] { "LocalUrl", "RemoteProperties" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(FileProperties.Types.RemoteProperties), FileProperties.Types.RemoteProperties.Parser, new string[1] { "Procontent" }, null, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(FileProperties.Types.RemoteProperties.Types.ProContent), FileProperties.Types.RemoteProperties.Types.ProContent.Parser, new string[1] { "DownloadIdentifier" }, null, null, null, null)
				})
			})
		}));
	}
}
