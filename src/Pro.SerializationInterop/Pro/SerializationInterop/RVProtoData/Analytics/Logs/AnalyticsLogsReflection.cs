using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Logs;

public static class AnalyticsLogsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsLogsReflection()
	{
		_003C_003Ey__InlineArray74<string> buffer = default(_003C_003Ey__InlineArray74<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 0) = "ChNhbmFseXRpY3NMb2dzLnByb3RvEhFydi5hbmFseXRpY3MubG9ncyJwCghM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 1) = "b2dFcnJvchIwCghtZXRhZGF0YRgBIAEoCzIeLnJ2LmFuYWx5dGljcy5sb2dz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 2) = "LkxvZ01ldGFkYXRhEhsKE2RvY3VtZW50X2lkZW50aWZpZXIYAiABKAkSFQoN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 3) = "ZG9jdW1lbnRfbmFtZRgDIAEoCSJpChZMb2dXb3Jrc3BhY2VzUHVibGlzaGVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 4) = "EjAKCG1ldGFkYXRhGAEgASgLMh4ucnYuYW5hbHl0aWNzLmxvZ3MuTG9nTWV0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 5) = "YWRhdGESHQoVd29ya3NwYWNlX2lkZW50aWZpZXJzGAIgAygJImkKGUxvZ0Nv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 6) = "bGxhYm9yYXRvcnNQdWJsaXNoZWQSMAoIbWV0YWRhdGEYASABKAsyHi5ydi5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 7) = "bmFseXRpY3MubG9ncy5Mb2dNZXRhZGF0YRIaChJjb2xsYWJvcmF0b3JfbmFt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 8) = "ZXMYAiADKAkiewoTTG9nRG9jdW1lbnRVcGxvYWRlZBIwCghtZXRhZGF0YRgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 9) = "IAEoCzIeLnJ2LmFuYWx5dGljcy5sb2dzLkxvZ01ldGFkYXRhEhsKE2RvY3Vt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 10) = "ZW50X2lkZW50aWZpZXIYAiABKAkSFQoNZG9jdW1lbnRfbmFtZRgDIAEoCSJ9";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 11) = "ChVMb2dEb2N1bWVudERvd25sb2FkZWQSMAoIbWV0YWRhdGEYASABKAsyHi5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 12) = "di5hbmFseXRpY3MubG9ncy5Mb2dNZXRhZGF0YRIbChNkb2N1bWVudF9pZGVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 13) = "dGlmaWVyGAIgASgJEhUKDWRvY3VtZW50X25hbWUYAyABKAkiygEKDUxvZ0Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 14) = "ZmZQdXNoZWQSMAoIbWV0YWRhdGEYASABKAsyHi5ydi5hbmFseXRpY3MubG9n";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 15) = "cy5Mb2dNZXRhZGF0YRIbChNkb2N1bWVudF9pZGVudGlmaWVyGAIgASgJEhUK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 16) = "DWRvY3VtZW50X25hbWUYAyABKAkSNgoNZGlmZl9tZXRhZGF0YRgEIAEoCzIf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 17) = "LnJ2LmFuYWx5dGljcy5sb2dzLkRpZmZNZXRhZGF0YRIbChNmcm9tX3ZlcnNp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 18) = "b25fdmVjdG9yGAUgASgJIogCCg9Mb2dEaWZmUmVjZWl2ZWQSMAoIbWV0YWRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 19) = "dGEYASABKAsyHi5ydi5hbmFseXRpY3MubG9ncy5Mb2dNZXRhZGF0YRIbChNk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 20) = "b2N1bWVudF9pZGVudGlmaWVyGAIgASgJEhUKDWRvY3VtZW50X25hbWUYBCAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 21) = "KAkSFgoOdmVyc2lvbl92ZWN0b3IYBSABKAkSPwoNaW1wb3J0X3Jlc3VsdBgG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 22) = "IAEoDjIoLnJ2LmFuYWx5dGljcy5sb2dzLkRpZmZBcHBsaWNhdGlvblJlc3Vs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 23) = "dBI2Cg1kaWZmX21ldGFkYXRhGAcgASgLMh8ucnYuYW5hbHl0aWNzLmxvZ3Mu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 24) = "RGlmZk1ldGFkYXRhInsKEUxvZ0NvbnZlcnRUb0Nsb3VkEjAKCG1ldGFkYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 25) = "GAEgASgLMh4ucnYuYW5hbHl0aWNzLmxvZ3MuTG9nTWV0YWRhdGESHAoUd29y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 26) = "a3NwYWNlX2lkZW50aWZpZXIYAiABKAkSFgoOd29ya3NwYWNlX25hbWUYAyAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 27) = "KAkijgEKEkxvZ09wZW5lZFdvcmtzcGFjZRIwCghtZXRhZGF0YRgBIAEoCzIe";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 28) = "LnJ2LmFuYWx5dGljcy5sb2dzLkxvZ01ldGFkYXRhEhwKFHdvcmtzcGFjZV9p";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 29) = "ZGVudGlmaWVyGAIgASgJEhYKDndvcmtzcGFjZV9uYW1lGAMgASgJEhAKCGlz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 30) = "X2xvY2FsGAQgASgIInsKEUxvZ0NvbnZlcnRUb0xvY2FsEjAKCG1ldGFkYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 31) = "GAEgASgLMh4ucnYuYW5hbHl0aWNzLmxvZ3MuTG9nTWV0YWRhdGESHAoUd29y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 32) = "a3NwYWNlX2lkZW50aWZpZXIYAiABKAkSFgoOd29ya3NwYWNlX25hbWUYAyAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 33) = "KAkiUQoQTG9nU3luY2luZ0NoYW5nZRItCgZwYXVzZWQYASABKAsyHS5ydi5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 34) = "bmFseXRpY3MubG9ncy5QYXVzZVN0YXRlEg4KBm9ubGluZRgCIAEoCCI7CgpQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 35) = "YXVzZVN0YXRlEhYKDnVudGlsX3RpbWVfdXRjGAEgASgEEhUKDXBhdXNlZF9h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 36) = "dF91dGMYAiABKAQikQEKEUxvZ0RvY3VtZW50U3RvcmVkEjAKCG1ldGFkYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 37) = "GAEgASgLMh4ucnYuYW5hbHl0aWNzLmxvZ3MuTG9nTWV0YWRhdGESGwoTZG9j";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 38) = "dW1lbnRfaWRlbnRpZmllchgCIAEoCRIVCg1kb2N1bWVudF9uYW1lGAMgASgJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 39) = "EhYKDnZlcnNpb25fdmVjdG9yGAQgASgJIn4KEkxvZ0RvY3VtZW50Q3JlYXRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 40) = "ZBIwCghtZXRhZGF0YRgBIAEoCzIeLnJ2LmFuYWx5dGljcy5sb2dzLkxvZ01l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 41) = "dGFkYXRhEhsKE2RvY3VtZW50X2lkZW50aWZpZXIYAiABKAkSFQoNZG9jdW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 42) = "bnRfbmFtZRgDIAEoCToCGAEiZQoUTG9nRG9jdW1lbnRSZXF1ZXN0ZWQSMAoI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 43) = "bWV0YWRhdGEYASABKAsyHi5ydi5hbmFseXRpY3MubG9ncy5Mb2dNZXRhZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 44) = "YRIbChNkb2N1bWVudF9pZGVudGlmaWVyGAIgASgJIqIBChJMb2dEb2N1bWVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 45) = "dFVwZGF0ZWQSMAoIbWV0YWRhdGEYASABKAsyHi5ydi5hbmFseXRpY3MubG9n";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 46) = "cy5Mb2dNZXRhZGF0YRIbChNkb2N1bWVudF9pZGVudGlmaWVyGAIgASgJEh4K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 47) = "FnByZXZpb3VzX2RvY3VtZW50X25hbWUYAyABKAkSHQoVdXBkYXRlZF9kb2N1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 48) = "bWVudF9uYW1lGAQgASgJInoKEkxvZ0RvY3VtZW50RGVsZXRlZBIwCghtZXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 49) = "ZGF0YRgBIAEoCzIeLnJ2LmFuYWx5dGljcy5sb2dzLkxvZ01ldGFkYXRhEhsK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 50) = "E2RvY3VtZW50X2lkZW50aWZpZXIYAiABKAkSFQoNZG9jdW1lbnRfbmFtZRgD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 51) = "IAEoCSLcAQoTTG9nRG9jdW1lbnRDb25mbGljdBIwCghtZXRhZGF0YRgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 52) = "CzIeLnJ2LmFuYWx5dGljcy5sb2dzLkxvZ01ldGFkYXRhEhsKE2RvY3VtZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 53) = "X2lkZW50aWZpZXIYAiABKAkSFQoNZG9jdW1lbnRfbmFtZRgDIAEoCRInCgVm";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 54) = "aWVsZBgEIAEoDjIYLnJ2LmFuYWx5dGljcy5sb2dzLkZpZWxkEjYKDWNvbmZs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 55) = "aWN0X3R5cGUYBSABKA4yHy5ydi5hbmFseXRpY3MubG9ncy5Db25mbGljdFR5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 56) = "cGUifQoaTG9nV29ya3NwYWNlUmVzeW5jaHJvbml6ZWQSMAoIbWV0YWRhdGEY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 57) = "ASABKAsyHi5ydi5hbmFseXRpY3MubG9ncy5Mb2dNZXRhZGF0YRItCgVjYXVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 58) = "ZRgCIAEoDjIeLnJ2LmFuYWx5dGljcy5sb2dzLlJlc3luY0NhdXNlIlQKDERp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 59) = "ZmZNZXRhZGF0YRISCgpjaGFuZ2VfbnVtGAEgASgNEhgKEHBhcnRpYWxfc3Rh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 60) = "cnRfdnYYAiABKAkSFgoOcGFydGlhbF9lbmRfdnYYAyABKAkigwEKC0xvZ01l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 61) = "dGFkYXRhEg8KB3BlZXJfaWQYASABKAkSEwoLbG9nX21lc3NhZ2UYAiABKAkS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 62) = "HAoUd29ya3NwYWNlX2lkZW50aWZpZXIYAyABKAkSMAoKbG9nX3NvdXJjZRgE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 63) = "IAEoDjIcLnJ2LmFuYWx5dGljcy5sb2dzLkxvZ1NvdXJjZSojCgVGaWVsZBIG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 64) = "CgJJRBAAEggKBE5BTUUQARIICgRQQVRIEAIqmwEKDENvbmZsaWN0VHlwZRIQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 65) = "CgxEVVBMSUNBVEVfSUQQABISCg5EVVBMSUNBVEVfTkFNRRABEhIKDkRVUExJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 66) = "Q0FURV9QQVRIEAISFgoSRE9DVU1FTlRfTk9UX0ZPVU5EEAMSHAoYRE9DVU1F";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 67) = "TlRfQUxSRUFEWV9ERUxFVEVEEAQSGwoXQ09OQ1VSUkVOVF9NT0RJRklDQVRJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 68) = "T04QBSomCgtSZXN5bmNDYXVzZRINCglXT1JLU1BBQ0UQABIICgRTWU5DEAEq";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 69) = "TQoVRGlmZkFwcGxpY2F0aW9uUmVzdWx0EgsKB1NVQ0NFU1MQABILCgdGQUlM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 70) = "VVJFEAESGgoWQVdBSVRJTkdfT1RIRVJfQ0hBTkdFUxACKiEKCUxvZ1NvdXJj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 71) = "ZRIKCgZDTElFTlQQABIICgRDT1JFEAFCS/gBAaoCM1Byby5TZXJpYWxpemF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 72) = "aW9uSW50ZXJvcC5SVlByb3RvRGF0YS5BbmFseXRpY3MuTG9nc7oCD0FuYWx5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray74<string>, string>(ref buffer, 73) = "dGljc19Mb2dzX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray74<string>, string>(in buffer, 74))), new FileDescriptor[0], new GeneratedClrTypeInfo(new Type[5]
		{
			typeof(Field),
			typeof(ConflictType),
			typeof(ResyncCause),
			typeof(DiffApplicationResult),
			typeof(LogSource)
		}, null, new GeneratedClrTypeInfo[21]
		{
			new GeneratedClrTypeInfo(typeof(LogError), LogError.Parser, new string[3] { "Metadata", "DocumentIdentifier", "DocumentName" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogWorkspacesPublished), LogWorkspacesPublished.Parser, new string[2] { "Metadata", "WorkspaceIdentifiers" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogCollaboratorsPublished), LogCollaboratorsPublished.Parser, new string[2] { "Metadata", "CollaboratorNames" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogDocumentUploaded), LogDocumentUploaded.Parser, new string[3] { "Metadata", "DocumentIdentifier", "DocumentName" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogDocumentDownloaded), LogDocumentDownloaded.Parser, new string[3] { "Metadata", "DocumentIdentifier", "DocumentName" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogDiffPushed), LogDiffPushed.Parser, new string[5] { "Metadata", "DocumentIdentifier", "DocumentName", "DiffMetadata", "FromVersionVector" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogDiffReceived), LogDiffReceived.Parser, new string[6] { "Metadata", "DocumentIdentifier", "DocumentName", "VersionVector", "ImportResult", "DiffMetadata" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogConvertToCloud), LogConvertToCloud.Parser, new string[3] { "Metadata", "WorkspaceIdentifier", "WorkspaceName" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogOpenedWorkspace), LogOpenedWorkspace.Parser, new string[4] { "Metadata", "WorkspaceIdentifier", "WorkspaceName", "IsLocal" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogConvertToLocal), LogConvertToLocal.Parser, new string[3] { "Metadata", "WorkspaceIdentifier", "WorkspaceName" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogSyncingChange), LogSyncingChange.Parser, new string[2] { "Paused", "Online" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(PauseState), PauseState.Parser, new string[2] { "UntilTimeUtc", "PausedAtUtc" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogDocumentStored), LogDocumentStored.Parser, new string[4] { "Metadata", "DocumentIdentifier", "DocumentName", "VersionVector" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogDocumentCreated), LogDocumentCreated.Parser, new string[3] { "Metadata", "DocumentIdentifier", "DocumentName" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogDocumentRequested), LogDocumentRequested.Parser, new string[2] { "Metadata", "DocumentIdentifier" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogDocumentUpdated), LogDocumentUpdated.Parser, new string[4] { "Metadata", "DocumentIdentifier", "PreviousDocumentName", "UpdatedDocumentName" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogDocumentDeleted), LogDocumentDeleted.Parser, new string[3] { "Metadata", "DocumentIdentifier", "DocumentName" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogDocumentConflict), LogDocumentConflict.Parser, new string[5] { "Metadata", "DocumentIdentifier", "DocumentName", "Field", "ConflictType" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogWorkspaceResynchronized), LogWorkspaceResynchronized.Parser, new string[2] { "Metadata", "Cause" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(DiffMetadata), DiffMetadata.Parser, new string[3] { "ChangeNum", "PartialStartVv", "PartialEndVv" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LogMetadata), LogMetadata.Parser, new string[4] { "PeerId", "LogMessage", "WorkspaceIdentifier", "LogSource" }, null, null, null, null)
		}));
	}
}
