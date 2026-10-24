using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.MediaManagement;

public static class AnalyticsMediaManagementReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsMediaManagementReflection()
	{
		_003C_003Ey__InlineArray21<string> buffer = default(_003C_003Ey__InlineArray21<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 0) = "Ch5hbmFseXRpY3NNZWRpYU1hbmFnZW1lbnQucHJvdG8SHHJ2LmFuYWx5dGlj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 1) = "cy5tZWRpYW1hbmFnZW1lbnQi4gEKFEluc3RhbGxhdGlvbkNvbXBsZXRlEk0K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 2) = "B3N1Y2Nlc3MYASABKAsyOi5ydi5hbmFseXRpY3MubWVkaWFtYW5hZ2VtZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 3) = "Lkluc3RhbGxhdGlvbkNvbXBsZXRlLlN1Y2Nlc3NIABJNCgdmYWlsdXJlGAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 4) = "ASgLMjoucnYuYW5hbHl0aWNzLm1lZGlhbWFuYWdlbWVudC5JbnN0YWxsYXRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 5) = "b25Db21wbGV0ZS5GYWlsdXJlSAAaCQoHU3VjY2VzcxoYCgdGYWlsdXJlEg0K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 6) = "BWVycm9yGAEgASgJQgcKBXN0YXRlIuUBChVCb290c3RyYXBwaW5nQ29tcGxl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 7) = "dGUSTgoHc3VjY2VzcxgBIAEoCzI7LnJ2LmFuYWx5dGljcy5tZWRpYW1hbmFn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 8) = "ZW1lbnQuQm9vdHN0cmFwcGluZ0NvbXBsZXRlLlN1Y2Nlc3NIABJOCgdmYWls";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 9) = "dXJlGAIgASgLMjsucnYuYW5hbHl0aWNzLm1lZGlhbWFuYWdlbWVudC5Cb290";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 10) = "c3RyYXBwaW5nQ29tcGxldGUuRmFpbHVyZUgAGgkKB1N1Y2Nlc3MaGAoHRmFp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 11) = "bHVyZRINCgVlcnJvchgBIAEoCUIHCgVzdGF0ZSIfCg5NZXNzYWdlRmFpbHVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 12) = "ZRINCgVlcnJvchgBIAEoCSIYChZVbmV4cGVjdGVkbHlOb3RSdW5uaW5nIo8B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 13) = "ChFDb25uZWN0aW9uQ2hhbmdlZBJECgVzdGF0ZRgBIAEoDjI1LnJ2LmFuYWx5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 14) = "dGljcy5tZWRpYW1hbmFnZW1lbnQuQ29ubmVjdGlvbkNoYW5nZWQuU3RhdGUi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 15) = "NAoFU3RhdGUSEwoPU1RBVEVfQ09OTkVDVEVEEAASFgoSU1RBVEVfRElTQ09O";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 16) = "TkVDVEVEEAEiNAoTQWRkZWRNZWRpYVJlZmVyZW5jZRINCgV3aWR0aBgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 17) = "BRIOCgZoZWlnaHQYAiABKAUiDwoNTm90UmVzcG9uZGluZ0Jh+AEBqgI+UHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 18) = "LlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRhLkFuYWx5dGljcy5N";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 19) = "ZWRpYU1hbmFnZW1lbnS6AhpBbmFseXRpY3NfTWVkaWFNYW5hZ2VtZW50X2IG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray21<string>, string>(ref buffer, 20) = "cHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray21<string>, string>(in buffer, 21))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[7]
		{
			new GeneratedClrTypeInfo(typeof(InstallationComplete), InstallationComplete.Parser, new string[2] { "Success", "Failure" }, new string[1] { "State" }, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(InstallationComplete.Types.Success), InstallationComplete.Types.Success.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(InstallationComplete.Types.Failure), InstallationComplete.Types.Failure.Parser, new string[1] { "Error" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(BootstrappingComplete), BootstrappingComplete.Parser, new string[2] { "Success", "Failure" }, new string[1] { "State" }, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(BootstrappingComplete.Types.Success), BootstrappingComplete.Types.Success.Parser, null, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(BootstrappingComplete.Types.Failure), BootstrappingComplete.Types.Failure.Parser, new string[1] { "Error" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(MessageFailure), MessageFailure.Parser, new string[1] { "Error" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(UnexpectedlyNotRunning), UnexpectedlyNotRunning.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(ConnectionChanged), ConnectionChanged.Parser, new string[1] { "State" }, null, new Type[1] { typeof(ConnectionChanged.Types.State) }, null, null),
			new GeneratedClrTypeInfo(typeof(AddedMediaReference), AddedMediaReference.Parser, new string[2] { "Width", "Height" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(NotResponding), NotResponding.Parser, null, null, null, null, null)
		}));
	}
}
