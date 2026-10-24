using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Edit;

public static class AnalyticsEditReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsEditReflection()
	{
		_003C_003Ey__InlineArray6<string> buffer = default(_003C_003Ey__InlineArray6<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 0) = "ChNhbmFseXRpY3NFZGl0LnByb3RvEhFydi5hbmFseXRpY3MuZWRpdCKIAQoM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 1) = "UHJlc2VudGF0aW9uEj4KCmNoYW5nZVR5cGUYASABKA4yKi5ydi5hbmFseXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 2) = "Y3MuZWRpdC5QcmVzZW50YXRpb24uQ2hhbmdlVHlwZRIMCgR1dWlkGAMgASgJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 3) = "IioKCkNoYW5nZVR5cGUSCAoERURJVBAAEggKBFVORE8QARIICgRSRURPEAJC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 4) = "S/gBAaoCM1Byby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray6<string>, string>(ref buffer, 5) = "bmFseXRpY3MuRWRpdLoCD0FuYWx5dGljc19FZGl0X2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray6<string>, string>(in buffer, 6))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Presentation), Presentation.Parser, new string[2] { "ChangeType", "Uuid" }, null, new Type[1] { typeof(Presentation.Types.ChangeType) }, null, null)
		}));
	}
}
