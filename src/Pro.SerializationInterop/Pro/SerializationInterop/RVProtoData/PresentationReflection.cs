using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class PresentationReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static PresentationReflection()
	{
		_003C_003Ey__InlineArray65<string> buffer = default(_003C_003Ey__InlineArray65<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 0) = "ChJwcmVzZW50YXRpb24ucHJvdG8SB3J2LmRhdGEaDGFjdGlvbi5wcm90bxoV";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 1) = "YXBwbGljYXRpb25JbmZvLnByb3RvGhBiYWNrZ3JvdW5kLnByb3RvGgljdWUu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 2) = "cHJvdG8aE2N1c3RvbU9wdGlvbnMucHJvdG8aDWVmZmVjdHMucHJvdG8aDGdy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 3) = "b3Vwcy5wcm90bxoOaW50UmFuZ2UucHJvdG8aE211c2ljS2V5U2NhbGUucHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 4) = "dG8aEXJ2dGltZXN0YW1wLnByb3RvGgl1cmwucHJvdG8aCnV1aWQucHJvdG8i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 5) = "vRQKDFByZXNlbnRhdGlvbhI4ChBhcHBsaWNhdGlvbl9pbmZvGAEgASgLMhgu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 6) = "cnYuZGF0YS5BcHBsaWNhdGlvbkluZm9CBKiGGQESGwoEdXVpZBgCIAEoCzIN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 7) = "LnJ2LmRhdGEuVVVJRBIMCgRuYW1lGAMgASgJEjAKDmxhc3RfZGF0ZV91c2Vk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 8) = "GAQgASgLMhIucnYuZGF0YS5UaW1lc3RhbXBCBKiGGQESNAoSbGFzdF9tb2Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 9) = "ZmllZF9kYXRlGAUgASgLMhIucnYuZGF0YS5UaW1lc3RhbXBCBKiGGQESFgoI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 10) = "Y2F0ZWdvcnkYBiABKAlCBKiGGQESDQoFbm90ZXMYByABKAkSLQoKYmFja2dy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 11) = "b3VuZBgIIAEoCzITLnJ2LmRhdGEuQmFja2dyb3VuZEIEoIYZARInCgtjaG9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 12) = "ZF9jaGFydBgJIAEoCzIMLnJ2LmRhdGEuVVJMQgSghhkBEjEKFHNlbGVjdGVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 13) = "X2FycmFuZ2VtZW50GAogASgLMg0ucnYuZGF0YS5VVUlEQgSghhkBEjcKDGFy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 14) = "cmFuZ2VtZW50cxgLIAMoCzIhLnJ2LmRhdGEuUHJlc2VudGF0aW9uLkFycmFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 15) = "Z2VtZW50EjIKCmN1ZV9ncm91cHMYDCADKAsyHi5ydi5kYXRhLlByZXNlbnRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 16) = "dGlvbi5DdWVHcm91cBIkCgRjdWVzGA0gAygLMgwucnYuZGF0YS5DdWVCCLKG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 17) = "GQR1dWlkEigKBGNjbGkYDiABKAsyGi5ydi5kYXRhLlByZXNlbnRhdGlvbi5D";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 18) = "Q0xJEkMKD2JpYmxlX3JlZmVyZW5jZRgPIAEoCzIkLnJ2LmRhdGEuUHJlc2Vu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 19) = "dGF0aW9uLkJpYmxlUmVmZXJlbmNlQgSghhkBEjAKCHRpbWVsaW5lGBEgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 20) = "Mh4ucnYuZGF0YS5QcmVzZW50YXRpb24uVGltZWxpbmUSLQoKdHJhbnNpdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 21) = "bhgSIAEoCzITLnJ2LmRhdGEuVHJhbnNpdGlvbkIEoIYZARI/ChNjb250ZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 22) = "X2Rlc3RpbmF0aW9uGBMgASgOMiIucnYuZGF0YS5BY3Rpb24uQ29udGVudERl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 23) = "c3RpbmF0aW9uEh0KE3NsaWRlX3Nob3dfZHVyYXRpb24YFCABKAFIABJQChZt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 24) = "dWx0aV90cmFja3NfbGljZW5zaW5nGBUgASgLMioucnYuZGF0YS5QcmVzZW50";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 25) = "YXRpb24uTXVsdGlUcmFja3NMaWNlbnNpbmdCBKCGGQESFQoJbXVzaWNfa2V5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 26) = "GBYgASgJQgIYARIwCgVtdXNpYxgXIAEoCzIbLnJ2LmRhdGEuUHJlc2VudGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 27) = "aW9uLk11c2ljQgSghhkBGtcBCgRDQ0xJEhQKBmF1dGhvchgBIAEoCUIEoIYZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 28) = "ARIcCg5hcnRpc3RfY3JlZGl0cxgCIAEoCUIEoIYZARIYCgpzb25nX3RpdGxl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 29) = "GAMgASgJQgSghhkBEhcKCXB1Ymxpc2hlchgEIAEoCUIEoIYZARIWCg5jb3B5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 30) = "cmlnaHRfeWVhchgFIAEoDRITCgtzb25nX251bWJlchgGIAEoDRIPCgdkaXNw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 31) = "bGF5GAcgASgIEhMKBWFsYnVtGAggASgJQgSghhkBEhUKB2FydHdvcmsYCSAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 32) = "KAxCBKCGGQEaqAIKDkJpYmxlUmVmZXJlbmNlEhIKCmJvb2tfaW5kZXgYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 33) = "KA0SFwoJYm9va19uYW1lGAIgASgJQgSghhkBEigKDWNoYXB0ZXJfcmFuZ2UY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 34) = "AyABKAsyES5ydi5kYXRhLkludFJhbmdlEiYKC3ZlcnNlX3JhbmdlGAQgASgL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 35) = "MhEucnYuZGF0YS5JbnRSYW5nZRIeChB0cmFuc2xhdGlvbl9uYW1lGAUgASgJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 36) = "QgSghhkBEi4KIHRyYW5zbGF0aW9uX2Rpc3BsYXlfYWJicmV2aWF0aW9uGAYg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 37) = "ASgJQgSohhkBEi8KIXRyYW5zbGF0aW9uX2ludGVybmFsX2FiYnJldmlhdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 38) = "bhgHIAEoCUIEoIYZARIWCghib29rX2tleRgIIAEoCUIEqIYZARqNAwoIVGlt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 39) = "ZWxpbmUSNgoEY3VlcxgBIAMoCzIiLnJ2LmRhdGEuUHJlc2VudGF0aW9uLlRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 40) = "bWVsaW5lLkN1ZUIEqIYZARIQCghkdXJhdGlvbhgFIAEoARIMCgRsb29wGAYg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 41) = "ASgIEisKDGF1ZGlvX2FjdGlvbhgIIAEoCzIPLnJ2LmRhdGEuQWN0aW9uQgSo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 42) = "hhkBEhcKD3RpbWVjb2RlX2VuYWJsZRgJIAEoCBIXCg90aW1lY29kZV9vZmZz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 43) = "ZXQYCiABKAESMwoHY3Vlc192MhgLIAMoCzIiLnJ2LmRhdGEuUHJlc2VudGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 44) = "aW9uLlRpbWVsaW5lLkN1ZRp9CgNDdWUSFAoMdHJpZ2dlcl90aW1lGAEgASgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 45) = "EgwKBG5hbWUYAyABKAkSHwoGY3VlX2lkGAIgASgLMg0ucnYuZGF0YS5VVUlE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 46) = "SAASIQoGYWN0aW9uGAQgASgLMg8ucnYuZGF0YS5BY3Rpb25IAEIOCgx0cmln";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 47) = "Z2VyX2luZm9KBAgCEANKBAgDEARKBAgEEAVKBAgHEAgaaAoLQXJyYW5nZW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 48) = "bnQSGwoEdXVpZBgBIAEoCzINLnJ2LmRhdGEuVVVJRBISCgRuYW1lGAIgASgJ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 49) = "QgSghhkBEigKEWdyb3VwX2lkZW50aWZpZXJzGAMgAygLMg0ucnYuZGF0YS5V";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 50) = "VUlEGlEKCEN1ZUdyb3VwEh0KBWdyb3VwGAEgASgLMg4ucnYuZGF0YS5Hcm91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 51) = "cBImCg9jdWVfaWRlbnRpZmllcnMYAiADKAsyDS5ydi5kYXRhLlVVSUQawAIK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 52) = "FE11bHRpVHJhY2tzTGljZW5zaW5nEhcKD3NvbmdfaWRlbnRpZmllchgBIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 53) = "AxIbChNjdXN0b21lcl9pZGVudGlmaWVyGAIgASgJEisKD2V4cGlyYXRpb25f";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 54) = "ZGF0ZRgDIAEoCzISLnJ2LmRhdGEuVGltZXN0YW1wEi4KEmxpY2Vuc2VfZXhw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 55) = "aXJhdGlvbhgEIAEoCzISLnJ2LmRhdGEuVGltZXN0YW1wEk0KDHN1YnNjcmlw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 56) = "dGlvbhgFIAEoDjI3LnJ2LmRhdGEuUHJlc2VudGF0aW9uLk11bHRpVHJhY2tz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 57) = "TGljZW5zaW5nLlN1YnNjcmlwdGlvbiJGCgxTdWJzY3JpcHRpb24SGgoWU1VC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 58) = "U0NSSVBUSU9OX0NIQVJUX1BSTxAAEhoKFlNVQlNDUklQVElPTl9TTElERV9Q";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 59) = "Uk8QARqTAQoFTXVzaWMSHgoSb3JpZ2luYWxfbXVzaWNfa2V5GAEgASgJQgIY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 60) = "ARIaCg51c2VyX211c2ljX2tleRgCIAEoCUICGAESKAoIb3JpZ2luYWwYAyAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 61) = "KAsyFi5ydi5kYXRhLk11c2ljS2V5U2NhbGUSJAoEdXNlchgEIAEoCzIWLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 62) = "LmRhdGEuTXVzaWNLZXlTY2FsZUIRCglTbGlkZVNob3cSBMCMGQFKBAgQEBFS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 63) = "DHNvY2lhbF9tZWRpYUI0+AEBqgIkUHJvLlNlcmlhbGl6YXRpb25JbnRlcm9w";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray65<string>, string>(ref buffer, 64) = "LlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray65<string>, string>(in buffer, 65))), new FileDescriptor[12]
		{
			ActionReflection.Descriptor,
			ApplicationInfoReflection.Descriptor,
			BackgroundReflection.Descriptor,
			CueReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			EffectsReflection.Descriptor,
			GroupsReflection.Descriptor,
			IntRangeReflection.Descriptor,
			MusicKeyScaleReflection.Descriptor,
			RvtimestampReflection.Descriptor,
			UrlReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Presentation), Presentation.Parser, new string[22]
			{
				"ApplicationInfo", "Uuid", "Name", "LastDateUsed", "LastModifiedDate", "Category", "Notes", "Background", "ChordChart", "SelectedArrangement",
				"Arrangements", "CueGroups", "Cues", "Ccli", "BibleReference", "Timeline", "Transition", "ContentDestination", "SlideShowDuration", "MultiTracksLicensing",
				"MusicKey", "Music"
			}, new string[1] { "SlideShow" }, null, null, new GeneratedClrTypeInfo[7]
			{
				new GeneratedClrTypeInfo(typeof(Presentation.Types.CCLI), Presentation.Types.CCLI.Parser, new string[9] { "Author", "ArtistCredits", "SongTitle", "Publisher", "CopyrightYear", "SongNumber", "Display", "Album", "Artwork" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Presentation.Types.BibleReference), Presentation.Types.BibleReference.Parser, new string[8] { "BookIndex", "BookName", "ChapterRange", "VerseRange", "TranslationName", "TranslationDisplayAbbreviation", "TranslationInternalAbbreviation", "BookKey" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Presentation.Types.Timeline), Presentation.Types.Timeline.Parser, new string[7] { "Cues", "Duration", "Loop", "AudioAction", "TimecodeEnable", "TimecodeOffset", "CuesV2" }, null, null, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(Presentation.Types.Timeline.Types.Cue), Presentation.Types.Timeline.Types.Cue.Parser, new string[4] { "TriggerTime", "Name", "CueId", "Action" }, new string[1] { "TriggerInfo" }, null, null, null)
				}),
				new GeneratedClrTypeInfo(typeof(Presentation.Types.Arrangement), Presentation.Types.Arrangement.Parser, new string[3] { "Uuid", "Name", "GroupIdentifiers" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Presentation.Types.CueGroup), Presentation.Types.CueGroup.Parser, new string[2] { "Group", "CueIdentifiers" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Presentation.Types.MultiTracksLicensing), Presentation.Types.MultiTracksLicensing.Parser, new string[5] { "SongIdentifier", "CustomerIdentifier", "ExpirationDate", "LicenseExpiration", "Subscription" }, null, new Type[1] { typeof(Presentation.Types.MultiTracksLicensing.Types.Subscription) }, null, null),
				new GeneratedClrTypeInfo(typeof(Presentation.Types.Music), Presentation.Types.Music.Parser, new string[4] { "OriginalMusicKey", "UserMusicKey", "Original", "User" }, null, null, null, null)
			})
		}));
	}
}
