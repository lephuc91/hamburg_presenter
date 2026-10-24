using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Create;

public static class AnalyticsCreateReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsCreateReflection()
	{
		_003C_003Ey__InlineArray21<string> buffer = default(_003C_003Ey__InlineArray21<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 0) = "ChVhbmFseXRpY3NDcmVhdGUucHJvdG8SE3J2LmFuYWx5dGljcy5jcmVhdGUi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 1) = "iwEKB0xpYnJhcnkSMwoGc291cmNlGAEgASgOMiMucnYuYW5hbHl0aWNzLmNy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 2) = "ZWF0ZS5MaWJyYXJ5LlNvdXJjZSJLCgZTb3VyY2USCwoHVU5LTk9XThAAEhQK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 3) = "EEFQUExJQ0FUSU9OX01FTlUQARIeChpMSUJSQVJZX09VVExJTkVfQUREX0JV";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 4) = "VFRPThACIqoCCghQbGF5bGlzdBI0CgZzb3VyY2UYASABKA4yJC5ydi5hbmFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 5) = "eXRpY3MuY3JlYXRlLlBsYXlsaXN0LlNvdXJjZRIwCgR0eXBlGAIgASgOMiIu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 6) = "cnYuYW5hbHl0aWNzLmNyZWF0ZS5QbGF5bGlzdC5UeXBlIlIKBlNvdXJjZRIS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 7) = "Cg5TT1VSQ0VfVU5LTk9XThAAEhQKEEFQUExJQ0FUSU9OX01FTlUQARIeChpM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 8) = "SUJSQVJZX09VVExJTkVfQUREX0JVVFRPThACImIKBFR5cGUSEAoMVFlQRV9V";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 9) = "TktOT1dOEAASEAoMUFJFU0VOVEFUSU9OEAESEwoPUExBTk5JTkdfQ0VOVEVS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 10) = "EAISCgoGRk9MREVSEAMSFQoRVEVNUExBVEVfUExBWUxJU1QQBCLBAQoMUHJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 11) = "c2VudGF0aW9uEjgKBnNvdXJjZRgBIAEoDjIoLnJ2LmFuYWx5dGljcy5jcmVh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 12) = "dGUuUHJlc2VudGF0aW9uLlNvdXJjZSJ3CgZTb3VyY2USCwoHVU5LTk9XThAA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 13) = "EhQKEEFQUExJQ0FUSU9OX01FTlUQARIeChpMSUJSQVJZX09VVExJTkVfQURE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 14) = "X0JVVFRPThACEhUKEURFVEFJTF9BRERfQlVUVE9OEAMSEwoPVU5MSU5LRURf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 15) = "SEVBREVSEAQijgEKEFRlbXBsYXRlUGxheWxpc3QSGAoQdG90YWxfaXRlbV9j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 16) = "b3VudBgBIAEoBRIUCgxoZWFkZXJfY291bnQYAiABKAUSGQoRcGxhY2Vob2xk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 17) = "ZXJfY291bnQYAyABKAUSGgoScHJlc2VudGF0aW9uX2NvdW50GAQgASgFEhMK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 18) = "C21lZGlhX2NvdW50GAUgASgFQk/4AQGqAjVQcm8uU2VyaWFsaXphdGlvbklu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 19) = "dGVyb3AuUlZQcm90b0RhdGEuQW5hbHl0aWNzLkNyZWF0ZboCEUFuYWx5dGlj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 20) = "c19DcmVhdGVfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray21<string>, string>(in buffer, 21))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[4]
		{
			new GeneratedClrTypeInfo(typeof(Library), Library.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(Library.Types.Source) }, null, null),
			new GeneratedClrTypeInfo(typeof(Playlist), Playlist.Parser, new string[2] { "Source", "Type" }, null, new Type[2]
			{
				typeof(Playlist.Types.Source),
				typeof(Playlist.Types.Type)
			}, null, null),
			new GeneratedClrTypeInfo(typeof(Presentation), Presentation.Parser, new string[1] { "Source" }, null, new Type[1] { typeof(Presentation.Types.Source) }, null, null),
			new GeneratedClrTypeInfo(typeof(TemplatePlaylist), TemplatePlaylist.Parser, new string[5] { "TotalItemCount", "HeaderCount", "PlaceholderCount", "PresentationCount", "MediaCount" }, null, null, null, null)
		}));
	}
}
