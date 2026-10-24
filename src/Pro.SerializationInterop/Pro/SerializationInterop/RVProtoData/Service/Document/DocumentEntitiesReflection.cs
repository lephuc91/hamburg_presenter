using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Service.Document;

public static class DocumentEntitiesReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static DocumentEntitiesReflection()
	{
		_003C_003Ey__InlineArray20<string> buffer = default(_003C_003Ey__InlineArray20<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 0) = "Chdkb2N1bWVudC5lbnRpdGllcy5wcm90bxIIZG9jdW1lbnQiFQoFUmVhZHkS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 1) = "DAoEZGF0YRgBIAEoDCIICgZSZW1vdGUiGgoFTG9jYWwSEQoJdGltZXN0YW1w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 2) = "GAEgASgEItgCCglJbnRyaW5zaWMSDAoEdXVpZBgBIAEoCRImCgRraW5kGAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 3) = "ASgOMhguZG9jdW1lbnQuSW50cmluc2ljLktpbmQSDAoEYm9keRgDIAEoDCKG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 4) = "AgoES2luZBIMCghDYWxlbmRhchAAEggKBENDTEkQARIPCgtDbGVhckdyb3Vw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 5) = "cxACEgoKBkdyb3VwcxADEg8KC0tleU1hcHBpbmdzEAQSCgoGTGFiZWxzEAUS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 6) = "CgoGTWFjcm9zEAYSDAoITWVzc2FnZXMQBxIJCgVQcm9wcxAIEgkKBVN0YWdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 7) = "EAkSCgoGVGltZXJzEAoSDQoJV29ya3NwYWNlEAsSDwoLTGlicmFyeURhdGEQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 8) = "DBIRCg1QbGF5bGlzdEF1ZGlvEA0SEwoPUGxheWxpc3RMaWJyYXJ5EA4SEQoN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 9) = "UGxheWxpc3RNZWRpYRAPEhUKEVBsYXlsaXN0VGVtcGxhdGVzEBAiuwEKCERv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 10) = "Y3VtZW50EgwKBHV1aWQYASABKAkSDAoEcGF0aBgCIAEoCRIgCgVyZWFkeRgK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 11) = "IAEoCzIPLmRvY3VtZW50LlJlYWR5SAASIAoFbG9jYWwYCyABKAsyDy5kb2N1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 12) = "bWVudC5Mb2NhbEgAEiIKBnJlbW90ZRgMIAEoCzIQLmRvY3VtZW50LlJlbW90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 13) = "ZUgAIiMKBEtpbmQSEAoMUFJFU0VOVEFUSU9OEAASCQoFVEhFTUUQAUIGCgRi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 14) = "b2R5IoUBCgtEb2N1bWVudFNldBInCgppbnRyaW5zaWNzGAEgAygLMhMuZG9j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 15) = "dW1lbnQuSW50cmluc2ljEikKDXByZXNlbnRhdGlvbnMYAiADKAsyEi5kb2N1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 16) = "bWVudC5Eb2N1bWVudBIiCgZ0aGVtZXMYAyADKAsyEi5kb2N1bWVudC5Eb2N1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 17) = "bWVudEJTqgI1UHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 18) = "LlNlcnZpY2UuRG9jdW1lbnS6AhhSVkRhdGFfU2VydmljZV9Eb2N1bWVudF9i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray20<string>, string>(ref buffer, 19) = "BnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray20<string>, string>(in buffer, 20))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[6]
		{
			new GeneratedClrTypeInfo(typeof(Ready), Ready.Parser, new string[1] { "Data" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Remote), Remote.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Local), Local.Parser, new string[1] { "Timestamp" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Intrinsic), Intrinsic.Parser, new string[3] { "Uuid", "Kind", "Body" }, null, new Type[1] { typeof(Intrinsic.Types.Kind) }, null, null),
			new GeneratedClrTypeInfo(typeof(Document), Document.Parser, new string[5] { "Uuid", "Path", "Ready", "Local", "Remote" }, new string[1] { "Body" }, new Type[1] { typeof(Document.Types.Kind) }, null, null),
			new GeneratedClrTypeInfo(typeof(DocumentSet), DocumentSet.Parser, new string[3] { "Intrinsics", "Presentations", "Themes" }, null, null, null, null)
		}));
	}
}
