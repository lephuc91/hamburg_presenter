using System;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.FeatureFlags;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;
using Pro.SerializationInterop.RVProtoData.Service.Document;
using Pro.SerializationInterop.RVProtoData.Service.Workspace;

namespace Pro.SerializationInterop.RVProtoData.Application;

public static class ParamsReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ParamsReflection()
	{
		_003C_003Ey__InlineArray23<string> buffer = default(_003C_003Ey__InlineArray23<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 0) = "CgxwYXJhbXMucHJvdG8SC2FwcGxpY2F0aW9uGhZ2MS1oZWxwZXItY29tbW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 1) = "LnByb3RvGhZ2Mi1oZWxwZXItY29tbW9uLnByb3RvGhNmZWF0dXJlLWZsYWdz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 2) = "LnByb3RvGhhkb2N1bWVudC5ib290c3RyYXAucHJvdG8aGXdvcmtzcGFjZS5i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 3) = "b290c3RyYXAucHJvdG8imQEKElByb2R1Y3RJbmZvcm1hdGlvbhIUCgxwcm9k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 4) = "dWN0X25hbWUYASABKAkSFQoNbWFqb3JfdmVyc2lvbhgCIAEoCRIVCg1taW5v";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 5) = "cl92ZXJzaW9uGAMgASgJEhUKDXBhdGNoX3ZlcnNpb24YBCABKAkSFAoMYnVp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 6) = "bGRfbnVtYmVyGAUgASgJEhIKCmJ1aWxkX2RhdGUYBiABKAMihgEKEUFwcGxp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 7) = "Y2F0aW9uUGFyYW1zEjUKDHByb2R1Y3RfaW5mbxgBIAEoCzIfLmFwcGxpY2F0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 8) = "aW9uLlByb2R1Y3RJbmZvcm1hdGlvbhIYChBlbmFibGVkX2ZlYXR1cmVzGAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 9) = "AygJEhQKB3BlZXJfaWQYAyABKARIAIgBAUIKCghfcGVlcl9pZCKHAwoWQXBw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 10) = "bGljYXRpb25TdGFydFBhcmFtcxIzCgthcHBsaWNhdGlvbhgBIAEoCzIeLmFw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 11) = "cGxpY2F0aW9uLkFwcGxpY2F0aW9uUGFyYW1zEjIKCG1lZGlhX3YxGAIgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 12) = "MiAuaGVscGVyLmNvbW1vbi52MS5DcmVhdGlvbk9wdGlvbhIvCgVtZWRpYRgD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 13) = "IAEoCzIgLmhlbHBlci5jb21tb24udjIuQ3JlYXRpb25PcHRpb24SNAoNZmVh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 14) = "dHVyZV9mbGFncxgEIAEoCzIdLmZlYXR1cmVfZmxhZ3MuQ3JlYXRpb25PcHRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 15) = "b24SPQoMcmVnaXN0cmF0aW9uGAYgASgLMicuYXBwbGljYXRpb24uUmVnaXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 16) = "cmF0aW9uQ3JlYXRpb25PcHRpb24SKgoIZG9jdW1lbnQYByABKAsyGC5kb2N1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 17) = "bWVudC5DcmVhdGlvbk9wdGlvbhIsCgl3b3Jrc3BhY2UYCCABKAsyGS53b3Jr";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 18) = "c3BhY2UuQ3JlYXRpb25PcHRpb25KBAgFEAYiHAoaUmVnaXN0cmF0aW9uQ3Jl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 19) = "YXRpb25PcHRpb24iMwoIU2h1dGRvd24SDAoCb2sYASABKAlIABIPCgVlcnJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 20) = "chgCIAEoCUgAQggKBnJlc3VsdEJJqgIwUHJvLlNlcmlhbGl6YXRpb25JbnRl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 21) = "cm9wLlJWUHJvdG9EYXRhLkFwcGxpY2F0aW9uugITUlZEYXRhX0FwcGxpY2F0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray23<string>, string>(ref buffer, 22) = "aW9uX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray23<string>, string>(in buffer, 23))), new FileDescriptor[5]
		{
			V1HelperCommonReflection.Descriptor,
			V2HelperCommonReflection.Descriptor,
			FeatureFlagsReflection.Descriptor,
			DocumentBootstrapReflection.Descriptor,
			WorkspaceBootstrapReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[5]
		{
			new GeneratedClrTypeInfo(typeof(ProductInformation), ProductInformation.Parser, new string[6] { "ProductName", "MajorVersion", "MinorVersion", "PatchVersion", "BuildNumber", "BuildDate" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ApplicationParams), ApplicationParams.Parser, new string[3] { "ProductInfo", "EnabledFeatures", "PeerId" }, new string[1] { "PeerId" }, null, null, null),
			new GeneratedClrTypeInfo(typeof(ApplicationStartParams), ApplicationStartParams.Parser, new string[7] { "Application", "MediaV1", "Media", "FeatureFlags", "Registration", "Document", "Workspace" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(RegistrationCreationOption), RegistrationCreationOption.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(Shutdown), Shutdown.Parser, new string[2] { "Ok", "Error" }, new string[1] { "Result" }, null, null, null)
		}));
	}
}
