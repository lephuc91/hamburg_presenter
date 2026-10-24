using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class DmxProfilesReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static DmxProfilesReflection()
	{
		_003C_003Ey__InlineArray24<string> buffer = default(_003C_003Ey__InlineArray24<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 0) = "ChFkbXhQcm9maWxlcy5wcm90bxIHcnYuZGF0YSK9BwoLRE1YUHJvZmlsZXMS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 1) = "OQoQd29ya3NwYWNlUHJvZmlsZRgBIAEoCzIfLnJ2LmRhdGEuRE1YUHJvZmls";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 2) = "ZXMuRE1YUHJvZmlsZRI2Cg1sYXllclByb2ZpbGVzGAIgAygLMh8ucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 3) = "YS5ETVhQcm9maWxlcy5ETVhQcm9maWxlGroGCgpETVhQcm9maWxlEjgKB3By";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 4) = "b2ZpbGUYASABKAsyJy5ydi5kYXRhLkRNWFByb2ZpbGVzLkRNWFByb2ZpbGUu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 5) = "UHJvZmlsZRI4CgdmaXh0dXJlGAIgASgLMicucnYuZGF0YS5ETVhQcm9maWxl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 6) = "cy5ETVhQcm9maWxlLkZpeHR1cmUSEQoJaXNFbmFibGVkGAMgASgIEkYKDmN1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 7) = "c3RvbU1hcHBpbmdzGAQgAygLMi4ucnYuZGF0YS5ETVhQcm9maWxlcy5ETVhQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 8) = "cm9maWxlLkNoYW5uZWxNYXBwaW5nGn8KB1Byb2ZpbGUSQAoLcHJvZmlsZVR5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 9) = "cGUYASABKA4yKy5ydi5kYXRhLkRNWFByb2ZpbGVzLkRNWFByb2ZpbGUuUHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 10) = "ZmlsZVR5cGUSGQoPc3RhcnRpbmdDaGFubmVsGAIgASgNSABCFwoVc3RhcnRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 11) = "bmdDaGFubmVsX29uZW9mGmQKDkNoYW5uZWxNYXBwaW5nEhQKDGNoYW5uZWxJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 12) = "bmRleBgBIAEoDRI8Cgdjb21tYW5kGAIgASgOMisucnYuZGF0YS5ETVhQcm9m";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 13) = "aWxlcy5ETVhQcm9maWxlLkNvbW1hbmRUeXBlGnUKB0ZpeHR1cmUSQAoLZml4";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 14) = "dHVyZVR5cGUYASABKA4yKy5ydi5kYXRhLkRNWFByb2ZpbGVzLkRNWFByb2Zp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 15) = "bGUuRml4dHVyZVR5cGUSFAoKbGF5ZXJJbmRleBgCIAEoDUgAQhIKEGxheWVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 16) = "SW5kZXhfb25lb2YiMgoLUHJvZmlsZVR5cGUSCQoFQkFTSUMQABIMCghBRFZB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 17) = "TkNFRBABEgoKBkNVU1RPTRACIicKC0ZpeHR1cmVUeXBlEg0KCVdPUktTUEFD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 18) = "RRAAEgkKBUxBWUVSEAEioQEKC0NvbW1hbmRUeXBlEgsKB09QQUNJVFkQABIO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 19) = "CgpCTEVORF9NT0RFEAESDgoKU0VMRUNUX0NVRRACEhAKDENPTlRST0xfVFlQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 20) = "RRADEhEKDUNPTlRST0xfVkFMVUUQBBIXChNUUkFOU0lUSU9OX0RVUkFUSU9O";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 21) = "EAUSEwoPU0VMRUNUX1BMQVlMSVNUEAYSEgoOVEFSR0VURURfTEFZRVIQB0I0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 22) = "+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRhugIH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray24<string>, string>(ref buffer, 23) = "UlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray24<string>, string>(in buffer, 24))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(DMXProfiles), DMXProfiles.Parser, new string[2] { "WorkspaceProfile", "LayerProfiles" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(DMXProfiles.Types.DMXProfile), DMXProfiles.Types.DMXProfile.Parser, new string[4] { "Profile", "Fixture", "IsEnabled", "CustomMappings" }, null, new Type[3]
				{
					typeof(DMXProfiles.Types.DMXProfile.Types.ProfileType),
					typeof(DMXProfiles.Types.DMXProfile.Types.FixtureType),
					typeof(DMXProfiles.Types.DMXProfile.Types.CommandType)
				}, null, new GeneratedClrTypeInfo[3]
				{
					new GeneratedClrTypeInfo(typeof(DMXProfiles.Types.DMXProfile.Types.Profile), DMXProfiles.Types.DMXProfile.Types.Profile.Parser, new string[2] { "ProfileType", "StartingChannel" }, new string[1] { "StartingChannelOneof" }, null, null, null),
					new GeneratedClrTypeInfo(typeof(DMXProfiles.Types.DMXProfile.Types.ChannelMapping), DMXProfiles.Types.DMXProfile.Types.ChannelMapping.Parser, new string[2] { "ChannelIndex", "Command" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(DMXProfiles.Types.DMXProfile.Types.Fixture), DMXProfiles.Types.DMXProfile.Types.Fixture.Parser, new string[2] { "FixtureType", "LayerIndex" }, new string[1] { "LayerIndexOneof" }, null, null, null)
				})
			})
		}));
	}
}
