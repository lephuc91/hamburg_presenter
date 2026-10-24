using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class CalendarReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static CalendarReflection()
	{
		_003C_003Ey__InlineArray27<string> buffer = default(_003C_003Ey__InlineArray27<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 0) = "Cg5jYWxlbmRhci5wcm90bxIHcnYuZGF0YRoMYWN0aW9uLnByb3RvGhtjb2xs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 1) = "ZWN0aW9uRWxlbWVudFR5cGUucHJvdG8aE2N1c3RvbU9wdGlvbnMucHJvdG8a";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 2) = "EXJ2dGltZXN0YW1wLnByb3RvGgp1dWlkLnByb3RvIoIICghDYWxlbmRhchIn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 3) = "CgZldmVudHMYASADKAsyFy5ydi5kYXRhLkNhbGVuZGFyLkV2ZW50Eg4KBmFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 4) = "dGl2ZRgCIAEoCBq8BwoFRXZlbnQSGwoEdXVpZBgBIAEoCzINLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 5) = "VVVJRBIMCgRuYW1lGAIgASgJEhkKC2Rlc2NyaXB0aW9uGAMgASgJQgSghhkB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 6) = "EiAKBGRhdGUYBCABKAsyEi5ydi5kYXRhLlRpbWVzdGFtcBI6Cg9yZWN1cnJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 7) = "bmNlX2RheXMYBSADKA4yIS5ydi5kYXRhLkNhbGVuZGFyLkV2ZW50LkRheU9m";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 8) = "V2VlaxI3ChVyZWN1cnJlbmNlX2xpbWl0X2RhdGUYBiABKAsyEi5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 9) = "LlRpbWVzdGFtcEIEoIYZARI1ChlyZWN1cnJlbmNlX2V4Y2x1ZGVkX2RhdGVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 10) = "GAcgAygLMhIucnYuZGF0YS5UaW1lc3RhbXASOAoGYWN0aW9uGAggASgLMh4u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 11) = "cnYuZGF0YS5DYWxlbmRhci5FdmVudC5BY3Rpb25CCKCGGQGohhkBEiAKB2Fj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 12) = "dGlvbnMYCSADKAsyDy5ydi5kYXRhLkFjdGlvbhrrAgoGQWN0aW9uEhIKBHR5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 13) = "cGUYASABKA1CBKiGGQESIQoEdXVpZBgCIAEoCzINLnJ2LmRhdGEuVVVJREIE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 14) = "qIYZARI7CghwbGF5bGlzdBgDIAEoCzInLnJ2LmRhdGEuQ2FsZW5kYXIuRXZl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 15) = "bnQuQWN0aW9uLlBsYXlsaXN0SAASNQoFbWFjcm8YBCABKAsyJC5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 16) = "LkNhbGVuZGFyLkV2ZW50LkFjdGlvbi5NYWNyb0gAGmcKCFBsYXlsaXN0EioK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 17) = "DXBsYXlsaXN0X3V1aWQYASABKAsyDS5ydi5kYXRhLlVVSURCBKCGGQESLwoS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 18) = "cGxheWxpc3RfaXRlbV91dWlkGAIgASgLMg0ucnYuZGF0YS5VVUlEQgSghhkB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 19) = "Gj8KBU1hY3JvEjYKDmlkZW50aWZpY2F0aW9uGAEgASgLMh4ucnYuZGF0YS5D";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 20) = "b2xsZWN0aW9uRWxlbWVudFR5cGVCDAoKQWN0aW9uVHlwZSLUAQoJRGF5T2ZX";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 21) = "ZWVrEhcKE0RBWV9PRl9XRUVLX1VOS05PV04QABIWChJEQVlfT0ZfV0VFS19T";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 22) = "VU5EQVkQARIWChJEQVlfT0ZfV0VFS19NT05EQVkQAhIXChNEQVlfT0ZfV0VF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 23) = "S19UVUVTREFZEAMSGQoVREFZX09GX1dFRUtfV0VETkVTREFZEAQSGAoUREFZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 24) = "X09GX1dFRUtfVEhVUlNEQVkQBRIWChJEQVlfT0ZfV0VFS19GUklEQVkQBhIY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 25) = "ChREQVlfT0ZfV0VFS19TQVRVUkRBWRAHQjT4AQGqAiRQcm8uU2VyaWFsaXph";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray27<string>, string>(ref buffer, 26) = "dGlvbkludGVyb3AuUlZQcm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray27<string>, string>(in buffer, 27))), new FileDescriptor[5]
		{
			ActionReflection.Descriptor,
			CollectionElementTypeReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			RvtimestampReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Calendar), Calendar.Parser, new string[2] { "Events", "Active" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(Calendar.Types.Event), Calendar.Types.Event.Parser, new string[9] { "Uuid", "Name", "Description", "Date", "RecurrenceDays", "RecurrenceLimitDate", "RecurrenceExcludedDates", "Action", "Actions" }, null, new Type[1] { typeof(Calendar.Types.Event.Types.DayOfWeek) }, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(Calendar.Types.Event.Types.Action), Calendar.Types.Event.Types.Action.Parser, new string[4] { "Type", "Uuid", "Playlist", "Macro" }, new string[1] { "ActionType" }, null, null, new GeneratedClrTypeInfo[2]
					{
						new GeneratedClrTypeInfo(typeof(Calendar.Types.Event.Types.Action.Types.Playlist), Calendar.Types.Event.Types.Action.Types.Playlist.Parser, new string[2] { "PlaylistUuid", "PlaylistItemUuid" }, null, null, null, null),
						new GeneratedClrTypeInfo(typeof(Calendar.Types.Event.Types.Action.Types.Macro), Calendar.Types.Event.Types.Action.Types.Macro.Parser, new string[1] { "Identification" }, null, null, null, null)
					})
				})
			})
		}));
	}
}
