using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProClockSourceReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProClockSourceReflection()
	{
		_003C_003Ey__InlineArray7<string> buffer = default(_003C_003Ey__InlineArray7<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 0) = "ChRwcm9DbG9ja1NvdXJjZS5wcm90bxIHcnYuZGF0YSK1AQoOUHJvQ2xvY2tT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 1) = "b3VyY2USDAoEdXVpZBgBIAEoCRIMCgRuYW1lGAIgASgJEhEKCWNvbm5lY3Rl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 2) = "ZBgDIAEoCBIOCgZhY3RpdmUYBCABKAgSKgoEdHlwZRgFIAEoDjIcLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 3) = "dGEuUHJvQ2xvY2tTb3VyY2UuVHlwZSI4CgRUeXBlEg8KC1RZUEVfVU5LT1dO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 4) = "EAASDgoKVFlQRV9JTlBVVBABEg8KC1RZUEVfT1VUUFVUEAJCNPgBAaoCJFBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 5) = "by5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboCB1JWRGF0YV9i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray7<string>, string>(ref buffer, 6) = "BnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray7<string>, string>(in buffer, 7))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(ProClockSource), ProClockSource.Parser, new string[5] { "Uuid", "Name", "Connected", "Active", "Type" }, null, new Type[1] { typeof(ProClockSource.Types.Type) }, null, null)
		}));
	}
}
