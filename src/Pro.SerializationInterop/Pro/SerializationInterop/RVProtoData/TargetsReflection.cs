using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class TargetsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static TargetsReflection()
	{
		_003C_003Ey__InlineArray15<string> buffer = default(_003C_003Ey__InlineArray15<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 0) = "Cg10YXJnZXRzLnByb3RvEgdydi5kYXRhGgtjb2xvci5wcm90bxoSZ3JhcGhp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 1) = "Y3NEYXRhLnByb3RvGhF0ZXN0UGF0dGVybi5wcm90bxoJdXJsLnByb3RvGgp1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 2) = "dWlkLnByb3RvIvcBCglUYXJnZXRTZXQSGwoEdXVpZBgBIAEoCzINLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 3) = "dGEuVVVJRBIMCgRuYW1lGAIgASgJEh0KBWNvbG9yGAMgASgLMg4ucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 4) = "YS5Db2xvchIlCg90ZXN0X2ltYWdlX3BhdGgYBCABKAsyDC5ydi5kYXRhLlVS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 5) = "TBIrCgtzb3VyY2Vfc2l6ZRgFIAEoCzIWLnJ2LmRhdGEuR3JhcGhpY3MuU2l6";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 6) = "ZRIgCgd0YXJnZXRzGAYgAygLMg8ucnYuZGF0YS5UYXJnZXQSKgoMdGVzdF9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 7) = "YXR0ZXJuGAcgASgLMhQucnYuZGF0YS5UZXN0UGF0dGVybiLuAQoGVGFyZ2V0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 8) = "EhsKBHV1aWQYASABKAsyDS5ydi5kYXRhLlVVSUQSDAoEbmFtZRgCIAEoCRIw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 9) = "ChBzb3VyY2VfdW5pdF9yZWN0GAMgASgLMhYucnYuZGF0YS5HcmFwaGljcy5S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 10) = "ZWN0EicKD3Rlc3RfaW1hZ2VfZmlsbBgEIAEoCzIOLnJ2LmRhdGEuTWVkaWES";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 11) = "KAoFc2hhcGUYBSABKAsyGS5ydi5kYXRhLkdyYXBoaWNzLkVsZW1lbnQSNAoI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 12) = "ZmxpcE1vZGUYBiABKA4yIi5ydi5kYXRhLkdyYXBoaWNzLkVsZW1lbnQuRmxp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 13) = "cE1vZGVCNPgBAaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3Rv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 14) = "RGF0YboCB1JWRGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray15<string>, string>(in buffer, 15))), new FileDescriptor[5]
		{
			ColorReflection.Descriptor,
			GraphicsDataReflection.Descriptor,
			TestPatternReflection.Descriptor,
			UrlReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(TargetSet), TargetSet.Parser, new string[7] { "Uuid", "Name", "Color", "TestImagePath", "SourceSize", "Targets", "TestPattern" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Target), Target.Parser, new string[6] { "Uuid", "Name", "SourceUnitRect", "TestImageFill", "Shape", "FlipMode" }, null, null, null, null)
		}));
	}
}
