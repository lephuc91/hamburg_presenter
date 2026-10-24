using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1AnnouncementReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1AnnouncementReflection()
	{
		_003C_003Ey__InlineArray52<string> buffer = default(_003C_003Ey__InlineArray52<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 0) = "Chpwcm9BcGlWMUFubm91bmNlbWVudC5wcm90bxIHcnYuZGF0YRoacHJvQXBp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 1) = "VjFQcmVzZW50YXRpb24ucHJvdG8aH3Byb0FwaVYxVGltZWxpbmVPcGVyYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 2) = "b24ucHJvdG8imAgKG0FQSV92MV9Bbm5vdW5jZW1lbnRfUmVxdWVzdBJhChlh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 3) = "Y3RpdmVfdGltZWxpbmVfb3BlcmF0aW9uGAEgASgLMjwucnYuZGF0YS5BUElf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 4) = "djFfQW5ub3VuY2VtZW50X1JlcXVlc3QuQWN0aXZlVGltZWxpbmVPcGVyYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 5) = "b25IABJbChZhY3RpdmVfdGltZWxpbmVfc3RhdHVzGAIgASgLMjkucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 6) = "YS5BUElfdjFfQW5ub3VuY2VtZW50X1JlcXVlc3QuQWN0aXZlVGltZWxpbmVT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 7) = "dGF0dXNIABI9CgZhY3RpdmUYAyABKAsyKy5ydi5kYXRhLkFQSV92MV9Bbm5v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 8) = "dW5jZW1lbnRfUmVxdWVzdC5BY3RpdmVIABJNCgtzbGlkZV9pbmRleBgEIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 9) = "CzI2LnJ2LmRhdGEuQVBJX3YxX0Fubm91bmNlbWVudF9SZXF1ZXN0LkFubm91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 10) = "bmNlbWVudEluZGV4SAASSAoMYWN0aXZlX2ZvY3VzGAUgASgLMjAucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 11) = "YS5BUElfdjFfQW5ub3VuY2VtZW50X1JlcXVlc3QuQWN0aXZlRm9jdXNIABJM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 12) = "Cg5hY3RpdmVfdHJpZ2dlchgGIAEoCzIyLnJ2LmRhdGEuQVBJX3YxX0Fubm91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 13) = "bmNlbWVudF9SZXF1ZXN0LkFjdGl2ZVRyaWdnZXJIABJVChNhY3RpdmVfbmV4";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 14) = "dF90cmlnZ2VyGAcgASgLMjYucnYuZGF0YS5BUElfdjFfQW5ub3VuY2VtZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 15) = "X1JlcXVlc3QuQWN0aXZlTmV4dFRyaWdnZXJIABJdChdhY3RpdmVfcHJldmlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 16) = "dXNfdHJpZ2dlchgIIAEoCzI6LnJ2LmRhdGEuQVBJX3YxX0Fubm91bmNlbWVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 17) = "dF9SZXF1ZXN0LkFjdGl2ZVByZXZpb3VzVHJpZ2dlckgAElcKFGFjdGl2ZV9p";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 18) = "bmRleF90cmlnZ2VyGAkgASgLMjcucnYuZGF0YS5BUElfdjFfQW5ub3VuY2Vt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 19) = "ZW50X1JlcXVlc3QuQWN0aXZlSW5kZXhUcmlnZ2VySAAaTwoXQWN0aXZlVGlt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 20) = "ZWxpbmVPcGVyYXRpb24SNAoJb3BlcmF0aW9uGAEgASgOMiEucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 21) = "UElfdjFfVGltZWxpbmVPcGVyYXRpb24aFgoUQWN0aXZlVGltZWxpbmVTdGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 22) = "dXMaCAoGQWN0aXZlGhMKEUFubm91bmNlbWVudEluZGV4Gg0KC0FjdGl2ZUZv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 23) = "Y3VzGg8KDUFjdGl2ZVRyaWdnZXIaEwoRQWN0aXZlTmV4dFRyaWdnZXIaFwoV";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 24) = "QWN0aXZlUHJldmlvdXNUcmlnZ2VyGiMKEkFjdGl2ZUluZGV4VHJpZ2dlchIN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 25) = "CgVpbmRleBgBIAEoDUIJCgdSZXF1ZXN0IuUIChxBUElfdjFfQW5ub3VuY2Vt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 26) = "ZW50X1Jlc3BvbnNlEmIKGWFjdGl2ZV90aW1lbGluZV9vcGVyYXRpb24YASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 27) = "KAsyPS5ydi5kYXRhLkFQSV92MV9Bbm5vdW5jZW1lbnRfUmVzcG9uc2UuQWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 28) = "aXZlVGltZWxpbmVPcGVyYXRpb25IABJcChZhY3RpdmVfdGltZWxpbmVfc3Rh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 29) = "dHVzGAIgASgLMjoucnYuZGF0YS5BUElfdjFfQW5ub3VuY2VtZW50X1Jlc3Bv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 30) = "bnNlLkFjdGl2ZVRpbWVsaW5lU3RhdHVzSAASPgoGYWN0aXZlGAMgASgLMiwu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 31) = "cnYuZGF0YS5BUElfdjFfQW5ub3VuY2VtZW50X1Jlc3BvbnNlLkFjdGl2ZUgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 32) = "EkcKC3NsaWRlX2luZGV4GAQgASgLMjAucnYuZGF0YS5BUElfdjFfQW5ub3Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 33) = "Y2VtZW50X1Jlc3BvbnNlLlNsaWRlSW5kZXhIABJJCgxhY3RpdmVfZm9jdXMY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 34) = "BSABKAsyMS5ydi5kYXRhLkFQSV92MV9Bbm5vdW5jZW1lbnRfUmVzcG9uc2Uu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 35) = "QWN0aXZlRm9jdXNIABJNCg5hY3RpdmVfdHJpZ2dlchgGIAEoCzIzLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 36) = "dGEuQVBJX3YxX0Fubm91bmNlbWVudF9SZXNwb25zZS5BY3RpdmVUcmlnZ2Vy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 37) = "SAASVgoTYWN0aXZlX25leHRfdHJpZ2dlchgHIAEoCzI3LnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 38) = "X3YxX0Fubm91bmNlbWVudF9SZXNwb25zZS5BY3RpdmVOZXh0VHJpZ2dlckgA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 39) = "El4KF2FjdGl2ZV9wcmV2aW91c190cmlnZ2VyGAggASgLMjsucnYuZGF0YS5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 40) = "UElfdjFfQW5ub3VuY2VtZW50X1Jlc3BvbnNlLkFjdGl2ZVByZXZpb3VzVHJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 41) = "Z2dlckgAElgKFGFjdGl2ZV9pbmRleF90cmlnZ2VyGAkgASgLMjgucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 42) = "YS5BUElfdjFfQW5ub3VuY2VtZW50X1Jlc3BvbnNlLkFjdGl2ZUluZGV4VHJp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 43) = "Z2dlckgAGhkKF0FjdGl2ZVRpbWVsaW5lT3BlcmF0aW9uGkAKFEFjdGl2ZVRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 44) = "bWVsaW5lU3RhdHVzEhIKCmlzX3J1bm5pbmcYASABKAgSFAoMY3VycmVudF90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 45) = "aW1lGAIgASgBGjwKBkFjdGl2ZRIyCgxhbm5vdW5jZW1lbnQYASABKAsyHC5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 46) = "di5kYXRhLkFQSV92MV9QcmVzZW50YXRpb24aRAoKU2xpZGVJbmRleBI2ChJh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 47) = "bm5vdW5jZW1lbnRfaW5kZXgYASABKAsyGi5ydi5kYXRhLkFQSV92MV9TbGlk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 48) = "ZUluZGV4Gg0KC0FjdGl2ZUZvY3VzGg8KDUFjdGl2ZVRyaWdnZXIaEwoRQWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 49) = "aXZlTmV4dFRyaWdnZXIaFwoVQWN0aXZlUHJldmlvdXNUcmlnZ2VyGhQKEkFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 50) = "dGl2ZUluZGV4VHJpZ2dlckIJCgdSZXF1ZXN0QjT4AQGqAiRQcm8uU2VyaWFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray52<string>, string>(ref buffer, 51) = "aXphdGlvbkludGVyb3AuUlZQcm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray52<string>, string>(in buffer, 52))), new FileDescriptor[2]
		{
			ProApiV1PresentationReflection.Descriptor,
			ProApiV1TimelineOperationReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Request), API_v1_Announcement_Request.Parser, new string[9] { "ActiveTimelineOperation", "ActiveTimelineStatus", "Active", "SlideIndex", "ActiveFocus", "ActiveTrigger", "ActiveNextTrigger", "ActivePreviousTrigger", "ActiveIndexTrigger" }, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[9]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Request.Types.ActiveTimelineOperation), API_v1_Announcement_Request.Types.ActiveTimelineOperation.Parser, new string[1] { "Operation" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Request.Types.ActiveTimelineStatus), API_v1_Announcement_Request.Types.ActiveTimelineStatus.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Request.Types.Active), API_v1_Announcement_Request.Types.Active.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Request.Types.AnnouncementIndex), API_v1_Announcement_Request.Types.AnnouncementIndex.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Request.Types.ActiveFocus), API_v1_Announcement_Request.Types.ActiveFocus.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Request.Types.ActiveTrigger), API_v1_Announcement_Request.Types.ActiveTrigger.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Request.Types.ActiveNextTrigger), API_v1_Announcement_Request.Types.ActiveNextTrigger.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Request.Types.ActivePreviousTrigger), API_v1_Announcement_Request.Types.ActivePreviousTrigger.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Request.Types.ActiveIndexTrigger), API_v1_Announcement_Request.Types.ActiveIndexTrigger.Parser, new string[1] { "Index" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Response), API_v1_Announcement_Response.Parser, new string[9] { "ActiveTimelineOperation", "ActiveTimelineStatus", "Active", "SlideIndex", "ActiveFocus", "ActiveTrigger", "ActiveNextTrigger", "ActivePreviousTrigger", "ActiveIndexTrigger" }, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[9]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Response.Types.ActiveTimelineOperation), API_v1_Announcement_Response.Types.ActiveTimelineOperation.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Response.Types.ActiveTimelineStatus), API_v1_Announcement_Response.Types.ActiveTimelineStatus.Parser, new string[2] { "IsRunning", "CurrentTime" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Response.Types.Active), API_v1_Announcement_Response.Types.Active.Parser, new string[1] { "Announcement" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Response.Types.SlideIndex), API_v1_Announcement_Response.Types.SlideIndex.Parser, new string[1] { "AnnouncementIndex" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Response.Types.ActiveFocus), API_v1_Announcement_Response.Types.ActiveFocus.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Response.Types.ActiveTrigger), API_v1_Announcement_Response.Types.ActiveTrigger.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Response.Types.ActiveNextTrigger), API_v1_Announcement_Response.Types.ActiveNextTrigger.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Response.Types.ActivePreviousTrigger), API_v1_Announcement_Response.Types.ActivePreviousTrigger.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Announcement_Response.Types.ActiveIndexTrigger), API_v1_Announcement_Response.Types.ActiveIndexTrigger.Parser, null, null, null, null, null)
			})
		}));
	}
}
