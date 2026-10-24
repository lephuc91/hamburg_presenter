using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class VersionReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static VersionReflection()
	{
		_003C_003Ey__InlineArray5<string> buffer = default(_003C_003Ey__InlineArray5<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 0) = "Cg12ZXJzaW9uLnByb3RvEgdydi5kYXRhIl0KB1ZlcnNpb24SFQoNbWFqb3Jf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 1) = "dmVyc2lvbhgBIAEoDRIVCg1taW5vcl92ZXJzaW9uGAIgASgNEhUKDXBhdGNo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 2) = "X3ZlcnNpb24YAyABKA0SDQoFYnVpbGQYBCABKAlCNPgBAaoCJFByby5TZXJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 3) = "YWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboCB1JWRGF0YV9iBnByb3Rv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray5<string>, string>(ref buffer, 4) = "Mw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray5<string>, string>(in buffer, 5))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Version), Version.Parser, new string[4] { "MajorVersion", "MinorVersion", "PatchVersion", "Build" }, null, null, null, null)
		}));
	}
}
