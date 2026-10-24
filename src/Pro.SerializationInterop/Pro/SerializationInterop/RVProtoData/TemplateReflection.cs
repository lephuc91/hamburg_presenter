using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class TemplateReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static TemplateReflection()
	{
		_003C_003Ey__InlineArray9<string> buffer = default(_003C_003Ey__InlineArray9<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 0) = "Cg50ZW1wbGF0ZS5wcm90bxIHcnYuZGF0YRoMYWN0aW9uLnByb3RvGhVhcHBs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 1) = "aWNhdGlvbkluZm8ucHJvdG8aE2N1c3RvbU9wdGlvbnMucHJvdG8aC3NsaWRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 2) = "LnByb3RvItwBCghUZW1wbGF0ZRpbCgVTbGlkZRIiCgpiYXNlX3NsaWRlGAEg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 3) = "ASgLMg4ucnYuZGF0YS5TbGlkZRIMCgRuYW1lGAIgASgJEiAKB2FjdGlvbnMY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 4) = "AyADKAsyDy5ydi5kYXRhLkFjdGlvbhpzCghEb2N1bWVudBI4ChBhcHBsaWNh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 5) = "dGlvbl9pbmZvGAEgASgLMhgucnYuZGF0YS5BcHBsaWNhdGlvbkluZm9CBKiG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 6) = "GQESJwoGc2xpZGVzGAMgAygLMhcucnYuZGF0YS5UZW1wbGF0ZS5TbGlkZUoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 7) = "CAIQA0I0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJvdG9E";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray9<string>, string>(ref buffer, 8) = "YXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray9<string>, string>(in buffer, 9))), new FileDescriptor[4]
		{
			ActionReflection.Descriptor,
			ApplicationInfoReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			SlideReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Template), Template.Parser, null, null, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(Template.Types.Slide), Template.Types.Slide.Parser, new string[3] { "BaseSlide", "Name", "Actions" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Template.Types.Document), Template.Types.Document.Parser, new string[2] { "ApplicationInfo", "Slides" }, null, null, null, null)
			})
		}));
	}
}
