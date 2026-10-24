using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class StageReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static StageReflection()
	{
		_003C_003Ey__InlineArray12<string> buffer = default(_003C_003Ey__InlineArray12<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 0) = "CgtzdGFnZS5wcm90bxIHcnYuZGF0YRoVYXBwbGljYXRpb25JbmZvLnByb3Rv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 1) = "Ghtjb2xsZWN0aW9uRWxlbWVudFR5cGUucHJvdG8aE2N1c3RvbU9wdGlvbnMu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 2) = "cHJvdG8aCnV1aWQucHJvdG8aC3NsaWRlLnByb3RvIr0CCgVTdGFnZRpSCgZM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 3) = "YXlvdXQSGwoEdXVpZBgBIAEoCzINLnJ2LmRhdGEuVVVJRBIMCgRuYW1lGAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 4) = "ASgJEh0KBXNsaWRlGAMgASgLMg4ucnYuZGF0YS5TbGlkZRpsCghEb2N1bWVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 5) = "dBI4ChBhcHBsaWNhdGlvbl9pbmZvGAEgASgLMhgucnYuZGF0YS5BcHBsaWNh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 6) = "dGlvbkluZm9CBKiGGQESJgoHbGF5b3V0cxgCIAMoCzIVLnJ2LmRhdGEuU3Rh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 7) = "Z2UuTGF5b3V0GnIKEFNjcmVlbkFzc2lnbm1lbnQSLgoGc2NyZWVuGAEgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 8) = "Mh4ucnYuZGF0YS5Db2xsZWN0aW9uRWxlbWVudFR5cGUSLgoGbGF5b3V0GAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 9) = "ASgLMh4ucnYuZGF0YS5Db2xsZWN0aW9uRWxlbWVudFR5cGVCNPgBAaoCJFBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 10) = "by5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboCB1JWRGF0YV9i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 11) = "BnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray12<string>, string>(in buffer, 12))), new FileDescriptor[5]
		{
			ApplicationInfoReflection.Descriptor,
			CollectionElementTypeReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			UuidReflection.Descriptor,
			SlideReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Stage), Stage.Parser, null, null, null, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(Stage.Types.Layout), Stage.Types.Layout.Parser, new string[3] { "Uuid", "Name", "Slide" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Stage.Types.Document), Stage.Types.Document.Parser, new string[2] { "ApplicationInfo", "Layouts" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Stage.Types.ScreenAssignment), Stage.Types.ScreenAssignment.Parser, new string[2] { "Screen", "Layout" }, null, null, null, null)
			})
		}));
	}
}
