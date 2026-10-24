using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class NetworklinkReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static NetworklinkReflection()
	{
		_003C_003Ey__InlineArray15<string> buffer = default(_003C_003Ey__InlineArray15<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 0) = "ChFuZXR3b3JrbGluay5wcm90bxIHcnYuZGF0YRoVYXBwbGljYXRpb25JbmZv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 1) = "LnByb3RvGhNjdXN0b21PcHRpb25zLnByb3RvGgxwcm9BcGkucHJvdG8ilgEK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 2) = "E05ldHdvcmtMaW5rRG9jdW1lbnQSNAoKZ3JvdXBfaW5mbxgBIAEoCzIgLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 3) = "LmRhdGEuUHJvTGluay5Hcm91cERlZmluaXRpb24SOAoQYXBwbGljYXRpb25f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 4) = "aW5mbxgCIAEoCzIYLnJ2LmRhdGEuQXBwbGljYXRpb25JbmZvQgSohhkBEg8K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 5) = "B2VuYWJsZWQYAyABKAgi4wIKEU5ldHdvcmtMaW5rU3RhdHVzEjsKDHN0YXR1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 6) = "c19wYWlycxgBIAMoCzIlLnJ2LmRhdGEuTmV0d29ya0xpbmtTdGF0dXMuU3Rh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 7) = "dHVzUGFpchqIAQoXTGlua2VkQ2xpZW50SW5mb3JtYXRpb24SMwoIcGxhdGZv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 8) = "cm0YASABKA4yIS5ydi5kYXRhLkFwcGxpY2F0aW9uSW5mby5QbGF0Zm9ybRIS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 9) = "Cgpvc192ZXJzaW9uGAIgASgJEg8KB3ZlcnNpb24YAyABKAkSEwoLZGVzY3Jp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 10) = "cHRpb24YBCABKAkahQEKClN0YXR1c1BhaXISEgoKaXBfYWRkcmVzcxgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 11) = "CRIMCgRwb3J0GAIgASgFElUKGWxpbmtlZF9jbGllbnRfaW5mb3JtYXRpb24Y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 12) = "AyABKAsyMi5ydi5kYXRhLk5ldHdvcmtMaW5rU3RhdHVzLkxpbmtlZENsaWVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 13) = "dEluZm9ybWF0aW9uQjT4AQGqAiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3Au";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray15<string>, string>(ref buffer, 14) = "UlZQcm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray15<string>, string>(in buffer, 15))), new FileDescriptor[3]
		{
			ApplicationInfoReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			ProApiReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(NetworkLinkDocument), NetworkLinkDocument.Parser, new string[3] { "GroupInfo", "ApplicationInfo", "Enabled" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(NetworkLinkStatus), NetworkLinkStatus.Parser, new string[1] { "StatusPairs" }, null, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(NetworkLinkStatus.Types.LinkedClientInformation), NetworkLinkStatus.Types.LinkedClientInformation.Parser, new string[4] { "Platform", "OsVersion", "Version", "Description" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(NetworkLinkStatus.Types.StatusPair), NetworkLinkStatus.Types.StatusPair.Parser, new string[3] { "IpAddress", "Port", "LinkedClientInformation" }, null, null, null, null)
			})
		}));
	}
}
