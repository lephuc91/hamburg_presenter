using System;
using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;

namespace Pro.SerializationInterop.RVProtoData;

public static class ProApiV1MediaReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ProApiV1MediaReflection()
	{
		_003C_003Ey__InlineArray62<string> buffer = default(_003C_003Ey__InlineArray62<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 0) = "ChNwcm9BcGlWMU1lZGlhLnByb3RvEgdydi5kYXRhGh5nb29nbGUvcHJvdG9i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 1) = "dWYvd3JhcHBlcnMucHJvdG8aGHByb0FwaVYxSWRlbnRpZmllci5wcm90bxof";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 2) = "cHJvQXBpVjFNZWRpYVBsYXlsaXN0SXRlbS5wcm90bxoWcHJvQXBpVjFQbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 3) = "bGlzdC5wcm90bxoKdXVpZC5wcm90byK0CwoUQVBJX3YxX01lZGlhX1JlcXVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 4) = "c3QSPAoJcGxheWxpc3RzGAEgASgLMicucnYuZGF0YS5BUElfdjFfTWVkaWFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 5) = "UmVxdWVzdC5QbGF5bGlzdHNIABJBCgxnZXRfcGxheWxpc3QYAiABKAsyKS5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 6) = "di5kYXRhLkFQSV92MV9NZWRpYV9SZXF1ZXN0LkdldFBsYXlsaXN0SAASUAoU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 7) = "Z2V0X3BsYXlsaXN0X3VwZGF0ZXMYAyABKAsyMC5ydi5kYXRhLkFQSV92MV9N";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 8) = "ZWRpYV9SZXF1ZXN0LkdldFBsYXlsaXN0VXBkYXRlc0gAEkMKDWdldF90aHVt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 9) = "Ym5haWwYBCABKAsyKi5ydi5kYXRhLkFQSV92MV9NZWRpYV9SZXF1ZXN0Lkdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 10) = "dFRodW1ibmFpbEgAEkYKEHBsYXlsaXN0X2ZvY3VzZWQYBSABKAsyKi5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 11) = "YXRhLkFQSV92MV9NZWRpYV9SZXF1ZXN0LkVtcHR5TWVzc2FnZUgAEkUKD3Bs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 12) = "YXlsaXN0X2FjdGl2ZRgGIAEoCzIqLnJ2LmRhdGEuQVBJX3YxX01lZGlhX1Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 13) = "cXVlc3QuRW1wdHlNZXNzYWdlSAASOwoFZm9jdXMYByABKAsyKi5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 14) = "LkFQSV92MV9NZWRpYV9SZXF1ZXN0LkZvY3VzTWVzc2FnZUgAEj8KB3RyaWdn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 15) = "ZXIYCCABKAsyLC5ydi5kYXRhLkFQSV92MV9NZWRpYV9SZXF1ZXN0LlRyaWdn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 16) = "ZXJNZXNzYWdlSAAaCwoJUGxheWxpc3RzGigKC0dldFBsYXlsaXN0EgoKAmlk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 17) = "GAEgASgJEg0KBXN0YXJ0GAQgASgNGiAKEkdldFBsYXlsaXN0VXBkYXRlcxIK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 18) = "CgJpZBgBIAEoCRo8CgxHZXRUaHVtYm5haWwSGwoEdXVpZBgBIAEoCzINLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 19) = "LmRhdGEuVVVJRBIPCgdxdWFsaXR5GAIgASgFGg4KDEVtcHR5TWVzc2FnZRqA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 20) = "AgoMRm9jdXNNZXNzYWdlEjoKBG5leHQYASABKAsyKi5ydi5kYXRhLkFQSV92";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 21) = "MV9NZWRpYV9SZXF1ZXN0LkVtcHR5TWVzc2FnZUgAEj4KCHByZXZpb3VzGAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 22) = "ASgLMioucnYuZGF0YS5BUElfdjFfTWVkaWFfUmVxdWVzdC5FbXB0eU1lc3Nh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 23) = "Z2VIABI8CgZhY3RpdmUYAyABKAsyKi5ydi5kYXRhLkFQSV92MV9NZWRpYV9S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 24) = "ZXF1ZXN0LkVtcHR5TWVzc2FnZUgAEioKAmlkGAQgASgLMhwuZ29vZ2xlLnBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 25) = "b3RvYnVmLlN0cmluZ1ZhbHVlSABCCgoIUGxheWxpc3QawQMKDlRyaWdnZXJN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 26) = "ZXNzYWdlEj0KB2ZvY3VzZWQYASABKAsyKi5ydi5kYXRhLkFQSV92MV9NZWRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 27) = "YV9SZXF1ZXN0LkVtcHR5TWVzc2FnZUgAEjwKBmFjdGl2ZRgCIAEoCzIqLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 28) = "LmRhdGEuQVBJX3YxX01lZGlhX1JlcXVlc3QuRW1wdHlNZXNzYWdlSAASMwoL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 29) = "cGxheWxpc3RfaWQYAyABKAsyHC5nb29nbGUucHJvdG9idWYuU3RyaW5nVmFs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 30) = "dWVIABI7CgVzdGFydBgEIAEoCzIqLnJ2LmRhdGEuQVBJX3YxX01lZGlhX1Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 31) = "cXVlc3QuRW1wdHlNZXNzYWdlSAESOgoEbmV4dBgFIAEoCzIqLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 32) = "QVBJX3YxX01lZGlhX1JlcXVlc3QuRW1wdHlNZXNzYWdlSAESPgoIcHJldmlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 33) = "dXMYBiABKAsyKi5ydi5kYXRhLkFQSV92MV9NZWRpYV9SZXF1ZXN0LkVtcHR5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 34) = "TWVzc2FnZUgBEjAKCG1lZGlhX2lkGAcgASgLMhwuZ29vZ2xlLnByb3RvYnVm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 35) = "LlN0cmluZ1ZhbHVlSAFCCgoIUGxheWxpc3RCBgoESXRlbUIJCgdSZXF1ZXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 36) = "IroIChVBUElfdjFfTWVkaWFfUmVzcG9uc2USPQoJcGxheWxpc3RzGAEgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 37) = "MigucnYuZGF0YS5BUElfdjFfTWVkaWFfUmVzcG9uc2UuUGxheWxpc3RzSAAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 38) = "QgoMZ2V0X3BsYXlsaXN0GAIgASgLMioucnYuZGF0YS5BUElfdjFfTWVkaWFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 39) = "UmVzcG9uc2UuR2V0UGxheWxpc3RIABJRChRnZXRfcGxheWxpc3RfdXBkYXRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 40) = "cxgDIAEoCzIxLnJ2LmRhdGEuQVBJX3YxX01lZGlhX1Jlc3BvbnNlLkdldFBs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 41) = "YXlsaXN0VXBkYXRlc0gAEkQKDWdldF90aHVtYm5haWwYBCABKAsyKy5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 42) = "YXRhLkFQSV92MV9NZWRpYV9SZXNwb25zZS5HZXRUaHVtYm5haWxIABJNChBw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 43) = "bGF5bGlzdF9mb2N1c2VkGAUgASgLMjEucnYuZGF0YS5BUElfdjFfTWVkaWFf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 44) = "UmVzcG9uc2UuR2V0Rm9jdXNlZFBsYXlsaXN0SAASSwoPcGxheWxpc3RfYWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 45) = "aXZlGAYgASgLMjAucnYuZGF0YS5BUElfdjFfTWVkaWFfUmVzcG9uc2UuR2V0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 46) = "QWN0aXZlUGxheWxpc3RIABI8CgVmb2N1cxgHIAEoCzIrLnJ2LmRhdGEuQVBJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 47) = "X3YxX01lZGlhX1Jlc3BvbnNlLkVtcHR5TWVzc2FnZUgAEj4KB3RyaWdnZXIY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 48) = "CCABKAsyKy5ydi5kYXRhLkFQSV92MV9NZWRpYV9SZXNwb25zZS5FbXB0eU1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 49) = "c3NhZ2VIABo4CglQbGF5bGlzdHMSKwoJcGxheWxpc3RzGAEgAygLMhgucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 50) = "ZGF0YS5BUElfdjFfUGxheWxpc3QaZwoLR2V0UGxheWxpc3QSJgoCaWQYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 51) = "KAsyGi5ydi5kYXRhLkFQSV92MV9JZGVudGlmaWVyEjAKBWl0ZW1zGAIgAygL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 52) = "MiEucnYuZGF0YS5BUElfdjFfTWVkaWFQbGF5bGlzdEl0ZW0aPAoSR2V0UGxh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 53) = "eWxpc3RVcGRhdGVzEiYKAmlkGAEgASgLMhoucnYuZGF0YS5BUElfdjFfSWRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 54) = "bnRpZmllchpDCgxHZXRUaHVtYm5haWwSGwoEdXVpZBgBIAEoCzINLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 55) = "dGEuVVVJRBIWCg50aHVtYm5haWxfZGF0YRgCIAEoDBo8ChJHZXRGb2N1c2Vk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 56) = "UGxheWxpc3QSJgoCaWQYASABKAsyGi5ydi5kYXRhLkFQSV92MV9JZGVudGlm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 57) = "aWVyGmsKEUdldEFjdGl2ZVBsYXlsaXN0EiwKCHBsYXlsaXN0GAEgASgLMhou";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 58) = "cnYuZGF0YS5BUElfdjFfSWRlbnRpZmllchIoCgRpdGVtGAIgASgLMhoucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 59) = "ZGF0YS5BUElfdjFfSWRlbnRpZmllchoOCgxFbXB0eU1lc3NhZ2VCCgoIUmVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 60) = "cG9uc2VCNPgBAaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3Rv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray62<string>, string>(ref buffer, 61) = "RGF0YboCB1JWRGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray62<string>, string>(in buffer, 62))), new FileDescriptor[5]
		{
			WrappersReflection.Descriptor,
			ProApiV1IdentifierReflection.Descriptor,
			ProApiV1MediaPlaylistItemReflection.Descriptor,
			ProApiV1PlaylistReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(API_v1_Media_Request), API_v1_Media_Request.Parser, new string[8] { "Playlists", "GetPlaylist", "GetPlaylistUpdates", "GetThumbnail", "PlaylistFocused", "PlaylistActive", "Focus", "Trigger" }, new string[1] { "Request" }, null, null, new GeneratedClrTypeInfo[7]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Media_Request.Types.Playlists), API_v1_Media_Request.Types.Playlists.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Media_Request.Types.GetPlaylist), API_v1_Media_Request.Types.GetPlaylist.Parser, new string[2] { "Id", "Start" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Media_Request.Types.GetPlaylistUpdates), API_v1_Media_Request.Types.GetPlaylistUpdates.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Media_Request.Types.GetThumbnail), API_v1_Media_Request.Types.GetThumbnail.Parser, new string[2] { "Uuid", "Quality" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Media_Request.Types.EmptyMessage), API_v1_Media_Request.Types.EmptyMessage.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Media_Request.Types.FocusMessage), API_v1_Media_Request.Types.FocusMessage.Parser, new string[4] { "Next", "Previous", "Active", "Id" }, new string[1] { "Playlist" }, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Media_Request.Types.TriggerMessage), API_v1_Media_Request.Types.TriggerMessage.Parser, new string[7] { "Focused", "Active", "PlaylistId", "Start", "Next", "Previous", "MediaId" }, new string[2] { "Playlist", "Item" }, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(API_v1_Media_Response), API_v1_Media_Response.Parser, new string[8] { "Playlists", "GetPlaylist", "GetPlaylistUpdates", "GetThumbnail", "PlaylistFocused", "PlaylistActive", "Focus", "Trigger" }, new string[1] { "Response" }, null, null, new GeneratedClrTypeInfo[7]
			{
				new GeneratedClrTypeInfo(typeof(API_v1_Media_Response.Types.Playlists), API_v1_Media_Response.Types.Playlists.Parser, new string[1] { "Playlists_" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Media_Response.Types.GetPlaylist), API_v1_Media_Response.Types.GetPlaylist.Parser, new string[2] { "Id", "Items" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Media_Response.Types.GetPlaylistUpdates), API_v1_Media_Response.Types.GetPlaylistUpdates.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Media_Response.Types.GetThumbnail), API_v1_Media_Response.Types.GetThumbnail.Parser, new string[2] { "Uuid", "ThumbnailData" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Media_Response.Types.GetFocusedPlaylist), API_v1_Media_Response.Types.GetFocusedPlaylist.Parser, new string[1] { "Id" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Media_Response.Types.GetActivePlaylist), API_v1_Media_Response.Types.GetActivePlaylist.Parser, new string[2] { "Playlist", "Item" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(API_v1_Media_Response.Types.EmptyMessage), API_v1_Media_Response.Types.EmptyMessage.Parser, null, null, null, null, null)
			})
		}));
	}
}
