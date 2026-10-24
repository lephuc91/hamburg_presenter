using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1TriggerReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1TriggerReflection()
	{
		_003C_003Ey__InlineArray46<string> buffer = default(_003C_003Ey__InlineArray46<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 0) = "ChVwcm9BcGlWMVRyaWdnZXIucHJvdG8SB3J2LmRhdGEi5QcKFkFQSV92MV9U";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 1) = "cmlnZ2VyX1JlcXVlc3QSMgoDY3VlGAEgASgLMiMucnYuZGF0YS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 2) = "VHJpZ2dlcl9SZXF1ZXN0LkN1ZUgAEjwKCHBsYXlsaXN0GAIgASgLMigucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 3) = "ZGF0YS5BUElfdjFfVHJpZ2dlcl9SZXF1ZXN0LlBsYXlsaXN0SAASNgoFbWVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 4) = "aWEYAyABKAsyJS5ydi5kYXRhLkFQSV92MV9UcmlnZ2VyX1JlcXVlc3QuTWVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 5) = "aWFIABI2CgVhdWRpbxgEIAEoCzIlLnJ2LmRhdGEuQVBJX3YxX1RyaWdnZXJf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 6) = "UmVxdWVzdC5BdWRpb0gAEkEKC3ZpZGVvX2lucHV0GAUgASgLMioucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 7) = "YS5BUElfdjFfVHJpZ2dlcl9SZXF1ZXN0LlZpZGVvSW5wdXRIABI6CgdsaWJy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 8) = "YXJ5GAYgASgLMicucnYuZGF0YS5BUElfdjFfVHJpZ2dlcl9SZXF1ZXN0Lkxp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 9) = "YnJhcnlIABI0CgRuZXh0GAcgASgLMiQucnYuZGF0YS5BUElfdjFfVHJpZ2dl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 10) = "cl9SZXF1ZXN0Lk5leHRIABI8CghwcmV2aW91cxgIIAEoCzIoLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 11) = "QVBJX3YxX1RyaWdnZXJfUmVxdWVzdC5QcmV2aW91c0gAEj8KCm1lZGlhX25l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 12) = "eHQYCSABKAsyKS5ydi5kYXRhLkFQSV92MV9UcmlnZ2VyX1JlcXVlc3QuTWVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 13) = "aWFOZXh0SAASRwoObWVkaWFfcHJldmlvdXMYCiABKAsyLS5ydi5kYXRhLkFQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 14) = "SV92MV9UcmlnZ2VyX1JlcXVlc3QuTWVkaWFQcmV2aW91c0gAEj8KCmF1ZGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 15) = "X25leHQYCyABKAsyKS5ydi5kYXRhLkFQSV92MV9UcmlnZ2VyX1JlcXVlc3Qu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 16) = "QXVkaW9OZXh0SAASRwoOYXVkaW9fcHJldmlvdXMYDCABKAsyLS5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 17) = "LkFQSV92MV9UcmlnZ2VyX1JlcXVlc3QuQXVkaW9QcmV2aW91c0gAGhQKA0N1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 18) = "ZRINCgVpbmRleBgBIAEoDRoWCghQbGF5bGlzdBIKCgJpZBgBIAEoCRoTCgVN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 19) = "ZWRpYRIKCgJpZBgBIAEoCRoLCglNZWRpYU5leHQaDwoNTWVkaWFQcmV2aW91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 20) = "cxoTCgVBdWRpbxIKCgJpZBgBIAEoCRoLCglBdWRpb05leHQaDwoNQXVkaW9Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 21) = "cmV2aW91cxoYCgpWaWRlb0lucHV0EgoKAmlkGAEgASgJGhUKB0xpYnJhcnkS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 22) = "CgoCaWQYASABKAkaBgoETmV4dBoKCghQcmV2aW91c0IJCgdSZXF1ZXN0IqgH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 23) = "ChdBUElfdjFfVHJpZ2dlcl9SZXNwb25zZRIzCgNjdWUYASABKAsyJC5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 24) = "YXRhLkFQSV92MV9UcmlnZ2VyX1Jlc3BvbnNlLkN1ZUgAEj0KCHBsYXlsaXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 25) = "GAIgASgLMikucnYuZGF0YS5BUElfdjFfVHJpZ2dlcl9SZXNwb25zZS5QbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 26) = "bGlzdEgAEjcKBW1lZGlhGAMgASgLMiYucnYuZGF0YS5BUElfdjFfVHJpZ2dl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 27) = "cl9SZXNwb25zZS5NZWRpYUgAEjcKBWF1ZGlvGAQgASgLMiYucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 28) = "UElfdjFfVHJpZ2dlcl9SZXNwb25zZS5BdWRpb0gAEkIKC3ZpZGVvX2lucHV0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 29) = "GAUgASgLMisucnYuZGF0YS5BUElfdjFfVHJpZ2dlcl9SZXNwb25zZS5WaWRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 30) = "b0lucHV0SAASOwoHbGlicmFyeRgGIAEoCzIoLnJ2LmRhdGEuQVBJX3YxX1Ry";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 31) = "aWdnZXJfUmVzcG9uc2UuTGlicmFyeUgAEjUKBG5leHQYByABKAsyJS5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 32) = "YXRhLkFQSV92MV9UcmlnZ2VyX1Jlc3BvbnNlLk5leHRIABI9CghwcmV2aW91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 33) = "cxgIIAEoCzIpLnJ2LmRhdGEuQVBJX3YxX1RyaWdnZXJfUmVzcG9uc2UuUHJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 34) = "dmlvdXNIABJACgptZWRpYV9uZXh0GAkgASgLMioucnYuZGF0YS5BUElfdjFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 35) = "VHJpZ2dlcl9SZXNwb25zZS5NZWRpYU5leHRIABJICg5tZWRpYV9wcmV2aW91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 36) = "cxgKIAEoCzIuLnJ2LmRhdGEuQVBJX3YxX1RyaWdnZXJfUmVzcG9uc2UuTWVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 37) = "aWFQcmV2aW91c0gAEkAKCmF1ZGlvX25leHQYCyABKAsyKi5ydi5kYXRhLkFQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 38) = "SV92MV9UcmlnZ2VyX1Jlc3BvbnNlLkF1ZGlvTmV4dEgAEkgKDmF1ZGlvX3By";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 39) = "ZXZpb3VzGAwgASgLMi4ucnYuZGF0YS5BUElfdjFfVHJpZ2dlcl9SZXNwb25z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 40) = "ZS5BdWRpb1ByZXZpb3VzSAAaBQoDQ3VlGgoKCFBsYXlsaXN0GgcKBU1lZGlh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 41) = "GgsKCU1lZGlhTmV4dBoPCg1NZWRpYVByZXZpb3VzGgcKBUF1ZGlvGgsKCUF1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 42) = "ZGlvTmV4dBoPCg1BdWRpb1ByZXZpb3VzGgwKClZpZGVvSW5wdXQaCQoHTGli";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 43) = "cmFyeRoGCgROZXh0GgoKCFByZXZpb3VzQgoKCFJlc3BvbnNlQjT4AQGqAiRQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 44) = "cm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQcm90b0RhdGG6AgdSVkRhdGFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray46<string>, string>(ref buffer, 45) = "YgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray46<string>, string>(in buffer, 46))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Request), API_v1_Trigger_Request.Parser, new string[12]
			{
				"Cue", "Playlist", "Media", "Audio", "VideoInput", "Library", "Next", "Previous", "MediaNext", "MediaPrevious",
				"AudioNext", "AudioPrevious"
			}, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[12]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Request.Types.Cue), API_v1_Trigger_Request.Types.Cue.Parser, new string[1] { "Index" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Request.Types.Playlist), API_v1_Trigger_Request.Types.Playlist.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Request.Types.Media), API_v1_Trigger_Request.Types.Media.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Request.Types.MediaNext), API_v1_Trigger_Request.Types.MediaNext.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Request.Types.MediaPrevious), API_v1_Trigger_Request.Types.MediaPrevious.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Request.Types.Audio), API_v1_Trigger_Request.Types.Audio.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Request.Types.AudioNext), API_v1_Trigger_Request.Types.AudioNext.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Request.Types.AudioPrevious), API_v1_Trigger_Request.Types.AudioPrevious.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Request.Types.VideoInput), API_v1_Trigger_Request.Types.VideoInput.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Request.Types.Library), API_v1_Trigger_Request.Types.Library.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Request.Types.Next), API_v1_Trigger_Request.Types.Next.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Request.Types.Previous), API_v1_Trigger_Request.Types.Previous.Parser, null, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Response), API_v1_Trigger_Response.Parser, new string[12]
			{
				"Cue", "Playlist", "Media", "Audio", "VideoInput", "Library", "Next", "Previous", "MediaNext", "MediaPrevious",
				"AudioNext", "AudioPrevious"
			}, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[12]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Response.Types.Cue), API_v1_Trigger_Response.Types.Cue.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Response.Types.Playlist), API_v1_Trigger_Response.Types.Playlist.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Response.Types.Media), API_v1_Trigger_Response.Types.Media.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Response.Types.MediaNext), API_v1_Trigger_Response.Types.MediaNext.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Response.Types.MediaPrevious), API_v1_Trigger_Response.Types.MediaPrevious.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Response.Types.Audio), API_v1_Trigger_Response.Types.Audio.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Response.Types.AudioNext), API_v1_Trigger_Response.Types.AudioNext.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Response.Types.AudioPrevious), API_v1_Trigger_Response.Types.AudioPrevious.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Response.Types.VideoInput), API_v1_Trigger_Response.Types.VideoInput.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Response.Types.Library), API_v1_Trigger_Response.Types.Library.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Response.Types.Next), API_v1_Trigger_Response.Types.Next.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Trigger_Response.Types.Previous), API_v1_Trigger_Response.Types.Previous.Parser, null, null, null, null, null)
			})
		}));
	}
}
