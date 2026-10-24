using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class ClearGroupsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ClearGroupsReflection()
	{
		_003C_003Ey__InlineArray32<string> buffer = default(_003C_003Ey__InlineArray32<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 0) = "ChFjbGVhckdyb3Vwcy5wcm90bxIHcnYuZGF0YRoMYWN0aW9uLnByb3RvGhVh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 1) = "cHBsaWNhdGlvbkluZm8ucHJvdG8aC2NvbG9yLnByb3RvGhNjdXN0b21PcHRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 2) = "b25zLnByb3RvGgp1dWlkLnByb3RvIssJChNDbGVhckdyb3Vwc0RvY3VtZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 3) = "EjgKEGFwcGxpY2F0aW9uX2luZm8YASABKAsyGC5ydi5kYXRhLkFwcGxpY2F0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 4) = "aW9uSW5mb0IEqIYZARI3CgZncm91cHMYAiADKAsyJy5ydi5kYXRhLkNsZWFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 5) = "R3JvdXBzRG9jdW1lbnQuQ2xlYXJHcm91cBrACAoKQ2xlYXJHcm91cBIbCgR1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 6) = "dWlkGAEgASgLMg0ucnYuZGF0YS5VVUlEEgwKBG5hbWUYAiABKAkSMAoNbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 7) = "ZXJfdGFyZ2V0cxgDIAMoCzIZLnJ2LmRhdGEuQWN0aW9uLkNsZWFyVHlwZRIc";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 8) = "ChRpc19oaWRkZW5faW5fcHJldmlldxgEIAEoCBIYCgppbWFnZV9kYXRhGAUg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 9) = "ASgMQgSghhkBEkUKCmltYWdlX3R5cGUYBiABKA4yMS5ydi5kYXRhLkNsZWFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 10) = "R3JvdXBzRG9jdW1lbnQuQ2xlYXJHcm91cC5JbWFnZVR5cGUSFgoOaXNfaWNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 11) = "bl90aW50ZWQYByABKAgSLQoPaWNvbl90aW50X2NvbG9yGAggASgLMg4ucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 12) = "ZGF0YS5Db2xvckIEoIYZARI8ChB0aW1lbGluZV90YXJnZXRzGAkgAygOMiIu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 13) = "cnYuZGF0YS5BY3Rpb24uQ29udGVudERlc3RpbmF0aW9uEiUKHWNsZWFyX3By";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 14) = "ZXNlbnRhdGlvbl9uZXh0X3NsaWRlGAogASgIIqkFCglJbWFnZVR5cGUSEwoP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 15) = "SW1hZ2VUeXBlQ3VzdG9tEAASEAoMSW1hZ2VUeXBlT25lEAESEAoMSW1hZ2VU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 16) = "eXBlVHdvEAISEgoOSW1hZ2VUeXBlVGhyZWUQAxIRCg1JbWFnZVR5cGVGb3Vy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 17) = "EAQSEQoNSW1hZ2VUeXBlRml2ZRAFEhAKDEltYWdlVHlwZVNpeBAGEhIKDklt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 18) = "YWdlVHlwZVNldmVuEAcSEgoOSW1hZ2VUeXBlRWlnaHQQCBIRCg1JbWFnZVR5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 19) = "cGVOaW5lEAkSEQoNSW1hZ2VUeXBlWmVybxAKEhAKDEltYWdlVHlwZUFsbBAL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 20) = "EhUKEUltYWdlVHlwZU1lZ2Fob3JuEAwSEQoNSW1hZ2VUeXBlUGxheRANEhEK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 21) = "DUltYWdlVHlwZUJ1bGIQDhIXChNJbWFnZVR5cGVTdW5nbGFzc2VzEA8SEgoO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 22) = "SW1hZ2VUeXBlQXJyb3cQEBITCg9JbWFnZVR5cGVUYXJnZXQQERIRCg1JbWFn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 23) = "ZVR5cGVTdGFyEBISEAoMSW1hZ2VUeXBlU3VuEBMSEQoNSW1hZ2VUeXBlQmVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 24) = "bBAUEhYKEkltYWdlVHlwZVBhcGVyY2xpcBAVEhIKDkltYWdlVHlwZUZsYXNr";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 25) = "EBYSFwoTSW1hZ2VUeXBlRXllZ2xhc3NlcxAXEhQKEEltYWdlVHlwZUN1cGNh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 26) = "a2UQGBISCg5JbWFnZVR5cGVTbGlkZRAZEhAKDEltYWdlVHlwZUhhdBAaEhMK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 27) = "D0ltYWdlVHlwZUZsb3dlchAbEhIKDkltYWdlVHlwZUhlYXJ0EBwSFAoQSW1h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 28) = "Z2VUeXBlTWVzc2FnZRAdEhIKDkltYWdlVHlwZUF1ZGlvEB4SEgoOSW1hZ2VU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 29) = "eXBlQ2xvdWQQHxIYChRJbWFnZVR5cGVFeGNsYW1hdGlvbhAgQjT4AQGqAiRQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 30) = "cm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90b0RhdGG6AgdSVkRhdGFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray32<string>, string>(ref buffer, 31) = "YgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray32<string>, string>(in buffer, 32))), new FileDescriptor[5]
		{
			ActionReflection.Descriptor,
			ApplicationInfoReflection.Descriptor,
			ColorReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(ClearGroupsDocument), ClearGroupsDocument.Parser, new string[2] { "ApplicationInfo", "Groups" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(ClearGroupsDocument.Types.ClearGroup), ClearGroupsDocument.Types.ClearGroup.Parser, new string[10] { "Uuid", "Name", "LayerTargets", "IsHiddenInPreview", "ImageData", "ImageType", "IsIconTinted", "IconTintColor", "TimelineTargets", "ClearPresentationNextSlide" }, null, new Type[1] { typeof(ClearGroupsDocument.Types.ClearGroup.Types.ImageType) }, null, null)
			})
		}));
	}
}
