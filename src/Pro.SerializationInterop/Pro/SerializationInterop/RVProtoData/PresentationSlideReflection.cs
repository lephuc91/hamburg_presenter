using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class PresentationSlideReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static PresentationSlideReflection()
	{
		_003C_003Ey__InlineArray13<string> buffer = default(_003C_003Ey__InlineArray13<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 0) = "ChdwcmVzZW50YXRpb25TbGlkZS5wcm90bxIHcnYuZGF0YRoUYWxpZ25tZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 1) = "R3VpZGUucHJvdG8aE2N1c3RvbU9wdGlvbnMucHJvdG8aDWVmZmVjdHMucHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 2) = "dG8aEmdyYXBoaWNzRGF0YS5wcm90bxoLc2xpZGUucHJvdG8aCXVybC5wcm90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 3) = "byLaAgoRUHJlc2VudGF0aW9uU2xpZGUSIgoKYmFzZV9zbGlkZRgBIAEoCzIO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 4) = "LnJ2LmRhdGEuU2xpZGUSNQoFbm90ZXMYAiABKAsyIC5ydi5kYXRhLlByZXNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 5) = "bnRhdGlvblNsaWRlLk5vdGVzQgSghhkBEjQKE3RlbXBsYXRlX2d1aWRlbGlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 6) = "ZXMYAyADKAsyFy5ydi5kYXRhLkFsaWdubWVudEd1aWRlEicKC2Nob3JkX2No";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 7) = "YXJ0GAQgASgLMgwucnYuZGF0YS5VUkxCBKCGGQESLQoKdHJhbnNpdGlvbhgF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 8) = "IAEoCzITLnJ2LmRhdGEuVHJhbnNpdGlvbkIEoIYZARpcCgVOb3RlcxIWCghy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 9) = "dGZfZGF0YRgBIAEoDEIEoIYZARI7CgphdHRyaWJ1dGVzGAIgASgLMiEucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 10) = "ZGF0YS5HcmFwaGljcy5UZXh0LkF0dHJpYnV0ZXNCBKCGGQFCNPgBAaoCJFBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 11) = "by5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboCB1JWRGF0YV9i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray13<string>, string>(ref buffer, 12) = "BnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray13<string>, string>(in buffer, 13))), new FileDescriptor[6]
		{
			AlignmentGuideReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			EffectsReflection.Descriptor,
			GraphicsDataReflection.Descriptor,
			SlideReflection.Descriptor,
			UrlReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(PresentationSlide), PresentationSlide.Parser, new string[5] { "BaseSlide", "Notes", "TemplateGuidelines", "ChordChart", "Transition" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(PresentationSlide.Types.Notes), PresentationSlide.Types.Notes.Parser, new string[2] { "RtfData", "Attributes" }, null, null, null, null)
			})
		}));
	}
}
