using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class GroupsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static GroupsReflection()
	{
		_003C_003Ey__InlineArray10<string> buffer = default(_003C_003Ey__InlineArray10<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 0) = "Cgxncm91cHMucHJvdG8SB3J2LmRhdGEaC2NvbG9yLnByb3RvGhNjdXN0b21P";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 1) = "cHRpb25zLnByb3RvGgxob3RLZXkucHJvdG8aCnV1aWQucHJvdG8i2QEKBUdy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 2) = "b3VwEhsKBHV1aWQYASABKAsyDS5ydi5kYXRhLlVVSUQSDAoEbmFtZRgCIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 3) = "CRIjCgVjb2xvchgDIAEoCzIOLnJ2LmRhdGEuQ29sb3JCBKCGGQESHwoGaG90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 4) = "S2V5GAQgASgLMg8ucnYuZGF0YS5Ib3RLZXkSOQocYXBwbGljYXRpb25fZ3Jv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 5) = "dXBfaWRlbnRpZmllchgFIAEoCzINLnJ2LmRhdGEuVVVJREIEoIYZARIkChZh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 6) = "cHBsaWNhdGlvbl9ncm91cF9uYW1lGAYgASgJQgSohhkBIjMKEVByb0dyb3Vw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 7) = "c0RvY3VtZW50Eh4KBmdyb3VwcxgBIAMoCzIOLnJ2LmRhdGEuR3JvdXBCNPgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 8) = "AaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboCB1JW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray10<string>, string>(ref buffer, 9) = "RGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray10<string>, string>(in buffer, 10))), new FileDescriptor[4]
		{
			ColorReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			HotKeyReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(Group), Group.Parser, new string[6] { "Uuid", "Name", "Color", "HotKey", "ApplicationGroupIdentifier", "ApplicationGroupName" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ProGroupsDocument), ProGroupsDocument.Parser, new string[1] { "Groups" }, null, null, null, null)
		}));
	}
}
