using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class PropDocumentReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static PropDocumentReflection()
	{
		_003C_003Ey__InlineArray15<string> buffer = default(_003C_003Ey__InlineArray15<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 0) = "ChJwcm9wRG9jdW1lbnQucHJvdG8SB3J2LmRhdGEaFWFwcGxpY2F0aW9uSW5m";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 1) = "by5wcm90bxoJY3VlLnByb3RvGhNjdXN0b21PcHRpb25zLnByb3RvGg1lZmZl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 2) = "Y3RzLnByb3RvGgp1dWlkLnByb3RvIswDCgxQcm9wRG9jdW1lbnQSOAoQYXBw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 3) = "bGljYXRpb25faW5mbxgBIAEoCzIYLnJ2LmRhdGEuQXBwbGljYXRpb25JbmZv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 4) = "QgSohhkBEiAKBGN1ZXMYAiADKAsyDC5ydi5kYXRhLkN1ZUIEqIYZARItCgp0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 5) = "cmFuc2l0aW9uGAMgASgLMhMucnYuZGF0YS5UcmFuc2l0aW9uQgSghhkBEj4K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 6) = "EHByb3BfY29sbGVjdGlvbnMYBCADKAsyJC5ydi5kYXRhLlByb3BEb2N1bWVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 7) = "dC5Qcm9wQ29sbGVjdGlvbhrwAQoOUHJvcENvbGxlY3Rpb24SGwoEdXVpZBgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 8) = "IAEoCzINLnJ2LmRhdGEuVVVJRBIMCgRuYW1lGAIgASgJEj4KBWl0ZW1zGAMg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 9) = "AygLMikucnYuZGF0YS5Qcm9wRG9jdW1lbnQuUHJvcENvbGxlY3Rpb24uSXRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 10) = "bUIEqIYZARIbChNzaW5nbGVfcHJvcF9lbmFibGVkGAQgASgIEhoKBGN1ZXMY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 11) = "BSADKAsyDC5ydi5kYXRhLkN1ZRo6CgRJdGVtEiYKDXByb3BfY3VlX3V1aWQY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 12) = "ASABKAsyDS5ydi5kYXRhLlVVSURIAEIKCghJdGVtVHlwZUI0+AEBqgIkUHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 13) = "LlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRhugIHUlZEYXRhX2IG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 14) = "cHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray15<string>, string>(in buffer, 15))), new FileDescriptor[5]
		{
			ApplicationInfoReflection.Descriptor,
			CueReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			EffectsReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(PropDocument), PropDocument.Parser, new string[4] { "ApplicationInfo", "Cues", "Transition", "PropCollections" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(PropDocument.Types.PropCollection), PropDocument.Types.PropCollection.Parser, new string[5] { "Uuid", "Name", "Items", "SinglePropEnabled", "Cues" }, null, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(PropDocument.Types.PropCollection.Types.Item), PropDocument.Types.PropCollection.Types.Item.Parser, new string[1] { "PropCueUuid" }, new string[1] { "ItemType" }, null, null, null)
				})
			})
		}));
	}
}
