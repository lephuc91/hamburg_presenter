using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class PlaylistReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static PlaylistReflection()
	{
		_003C_003Ey__InlineArray55<string> buffer = default(_003C_003Ey__InlineArray55<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 0) = "Cg5wbGF5bGlzdC5wcm90bxIHcnYuZGF0YRoMYWN0aW9uLnByb3RvGgtjb2xv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 1) = "ci5wcm90bxoJY3VlLnByb3RvGhNjdXN0b21PcHRpb25zLnByb3RvGgxob3RL";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 2) = "ZXkucHJvdG8aE211c2ljS2V5U2NhbGUucHJvdG8aFHBsYW5uaW5nQ2VudGVy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 3) = "LnByb3RvGgl1cmwucHJvdG8aCnV1aWQucHJvdG8ixwoKCFBsYXlsaXN0EhsK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 4) = "BHV1aWQYASABKAsyDS5ydi5kYXRhLlVVSUQSDAoEbmFtZRgCIAEoCRIqCgR0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 5) = "eXBlGAMgASgOMhYucnYuZGF0YS5QbGF5bGlzdC5UeXBlQgSohhkBEhAKCGV4";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 6) = "cGFuZGVkGAQgASgIEjAKE3RhcmdldGVkX2xheWVyX3V1aWQYBSABKAsyDS5y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 7) = "di5kYXRhLlVVSURCBKiGGQESMAoUc21hcnRfZGlyZWN0b3J5X3BhdGgYBiAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 8) = "KAsyDC5ydi5kYXRhLlVSTEIEqIYZARImCgdob3Rfa2V5GAcgASgLMg8ucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 9) = "ZGF0YS5Ib3RLZXlCBKiGGQESIAoEY3VlcxgIIAMoCzIMLnJ2LmRhdGEuQ3Vl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 10) = "QgSohhkBEikKCGNoaWxkcmVuGAkgAygLMhEucnYuZGF0YS5QbGF5bGlzdEIE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 11) = "qIYZARIeChB0aW1lY29kZV9lbmFibGVkGAogASgIQgSohhkBEjIKBnRpbWlu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 12) = "ZxgLIAEoDjIcLnJ2LmRhdGEuUGxheWxpc3QuVGltaW5nVHlwZUIEqIYZARI0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 13) = "CglwbGF5bGlzdHMYDCABKAsyHy5ydi5kYXRhLlBsYXlsaXN0LlBsYXlsaXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 14) = "QXJyYXlIABIwCgVpdGVtcxgNIAEoCzIfLnJ2LmRhdGEuUGxheWxpc3QuUGxh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 15) = "eWxpc3RJdGVtc0gAEjwKD3NtYXJ0X2RpcmVjdG9yeRgOIAEoCzIhLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 16) = "dGEuUGxheWxpc3QuRm9sZGVyRGlyZWN0b3J5SAESLwoIcGNvX3BsYW4YDyAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 17) = "KAsyGy5ydi5kYXRhLlBsYW5uaW5nQ2VudGVyUGxhbkgBEjkKDHN0YXJ0dXBf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 18) = "aW5mbxgQIAEoCzIdLnJ2LmRhdGEuUGxheWxpc3QuU3RhcnR1cEluZm9CBKiG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 19) = "GQEaNQoNUGxheWxpc3RBcnJheRIkCglwbGF5bGlzdHMYASADKAsyES5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 20) = "YXRhLlBsYXlsaXN0GjUKDVBsYXlsaXN0SXRlbXMSJAoFaXRlbXMYASADKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 21) = "FS5ydi5kYXRhLlBsYXlsaXN0SXRlbRrVAQoPRm9sZGVyRGlyZWN0b3J5EiUK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 22) = "D3NtYXJ0X2RpcmVjdG9yeRgBIAEoCzIMLnJ2LmRhdGEuVVJMEkkKD2ltcG9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 23) = "dF9iZWhhdmlvchgCIAEoDjIwLnJ2LmRhdGEuUGxheWxpc3QuRm9sZGVyRGly";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 24) = "ZWN0b3J5LkltcG9ydEJlaGF2aW9yIlAKDkltcG9ydEJlaGF2aW9yEh4KGklN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 25) = "UE9SVF9CRUhBVklPUl9CQUNLR1JPVU5EEAASHgoaSU1QT1JUX0JFSEFWSU9S";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 26) = "X0ZPUkVHUk9VTkQQARpPCgNUYWcSHQoFY29sb3IYASABKAsyDi5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 27) = "LkNvbG9yEgwKBG5hbWUYAiABKAkSGwoEdXVpZBgDIAEoCzINLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 28) = "VVVJRBopCgtTdGFydHVwSW5mbxIaChJ0cmlnZ2VyX29uX3N0YXJ0dXAYASAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 29) = "KAgiWgoEVHlwZRIQCgxUWVBFX1VOS05PV04QABIRCg1UWVBFX1BMQVlMSVNU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 30) = "EAESDgoKVFlQRV9HUk9VUBACEg4KClRZUEVfU01BUlQQAxINCglUWVBFX1JP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 31) = "T1QQBCJZCgpUaW1pbmdUeXBlEhQKEFRJTUlOR19UWVBFX05PTkUQABIYChRU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 32) = "SU1JTkdfVFlQRV9USU1FQ09ERRABEhsKF1RJTUlOR19UWVBFX1RJTUVfT0Zf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 33) = "REFZEAJCDgoMQ2hpbGRyZW5UeXBlQgoKCExpbmtEYXRhIu4GCgxQbGF5bGlz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 34) = "dEl0ZW0SGwoEdXVpZBgBIAEoCzINLnJ2LmRhdGEuVVVJRBIMCgRuYW1lGAIg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 35) = "ASgJEi4KBmhlYWRlchgDIAEoCzIcLnJ2LmRhdGEuUGxheWxpc3RJdGVtLkhl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 36) = "YWRlckgAEjoKDHByZXNlbnRhdGlvbhgEIAEoCzIiLnJ2LmRhdGEuUGxheWxp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 37) = "c3RJdGVtLlByZXNlbnRhdGlvbkgAEhsKA2N1ZRgFIAEoCzIMLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 38) = "Q3VlSAASPwoPcGxhbm5pbmdfY2VudGVyGAYgASgLMiQucnYuZGF0YS5QbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 39) = "bGlzdEl0ZW0uUGxhbm5pbmdDZW50ZXJIABI4CgtwbGFjZWhvbGRlchgIIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 40) = "CzIhLnJ2LmRhdGEuUGxheWxpc3RJdGVtLlBsYWNlaG9sZGVySAASGwoEdGFn";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 41) = "cxgHIAMoCzINLnJ2LmRhdGEuVVVJRBIRCglpc19oaWRkZW4YCSABKAgaSQoG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 42) = "SGVhZGVyEh0KBWNvbG9yGAEgASgLMg4ucnYuZGF0YS5Db2xvchIgCgdhY3Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 43) = "b25zGAIgAygLMg8ucnYuZGF0YS5BY3Rpb24a7gEKDFByZXNlbnRhdGlvbhIj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 44) = "Cg1kb2N1bWVudF9wYXRoGAEgASgLMgwucnYuZGF0YS5VUkwSKAoLYXJyYW5n";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 45) = "ZW1lbnQYAiABKAsyDS5ydi5kYXRhLlVVSURCBKCGGQESPwoTY29udGVudF9k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 46) = "ZXN0aW5hdGlvbhgDIAEoDjIiLnJ2LmRhdGEuQWN0aW9uLkNvbnRlbnREZXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 47) = "aW5hdGlvbhI0Cg51c2VyX211c2ljX2tleRgEIAEoCzIWLnJ2LmRhdGEuTXVz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 48) = "aWNLZXlTY2FsZUIEoIYZARIYChBhcnJhbmdlbWVudF9uYW1lGAUgASgJGnYK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 49) = "DlBsYW5uaW5nQ2VudGVyEjIKBGl0ZW0YASABKAsyJC5ydi5kYXRhLlBsYW5u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 50) = "aW5nQ2VudGVyUGxhbi5QbGFuSXRlbRIwCgtsaW5rZWRfZGF0YRgCIAEoCzIV";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 51) = "LnJ2LmRhdGEuUGxheWxpc3RJdGVtQgSghhkBGj8KC1BsYWNlaG9sZGVyEjAK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 52) = "C2xpbmtlZF9kYXRhGAEgASgLMhUucnYuZGF0YS5QbGF5bGlzdEl0ZW1CBKCG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 53) = "GQFCCgoISXRlbVR5cGVCNPgBAaoCJFByby5TZXJpYWxpemF0aW9uSW50ZXJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray55<string>, string>(ref buffer, 54) = "cC5SVlByb3RvRGF0YboCB1JWRGF0YV9iBnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray55<string>, string>(in buffer, 55))), new FileDescriptor[9]
		{
			ActionReflection.Descriptor,
			ColorReflection.Descriptor,
			CueReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			HotKeyReflection.Descriptor,
			MusicKeyScaleReflection.Descriptor,
			PlanningCenterReflection.Descriptor,
			UrlReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[2]
		{
			new GeneratedClrTypeInfo(typeof(Playlist), Playlist.Parser, new string[16]
			{
				"Uuid", "Name", "Type", "Expanded", "TargetedLayerUuid", "SmartDirectoryPath", "HotKey", "Cues", "Children", "TimecodeEnabled",
				"Timing", "Playlists", "Items", "SmartDirectory", "PcoPlan", "StartupInfo"
			}, new string[2] { "ChildrenType", "LinkData" }, new Type[2]
			{
				typeof(Playlist.Types.Type),
				typeof(Playlist.Types.TimingType)
			}, null, new GeneratedClrTypeInfo[5]
			{
				new GeneratedClrTypeInfo(typeof(Playlist.Types.PlaylistArray), Playlist.Types.PlaylistArray.Parser, new string[1] { "Playlists" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Playlist.Types.PlaylistItems), Playlist.Types.PlaylistItems.Parser, new string[1] { "Items" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Playlist.Types.FolderDirectory), Playlist.Types.FolderDirectory.Parser, new string[2] { "SmartDirectory", "ImportBehavior" }, null, new Type[1] { typeof(Playlist.Types.FolderDirectory.Types.ImportBehavior) }, null, null),
				new GeneratedClrTypeInfo(typeof(Playlist.Types.Tag), Playlist.Types.Tag.Parser, new string[3] { "Color", "Name", "Uuid" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Playlist.Types.StartupInfo), Playlist.Types.StartupInfo.Parser, new string[1] { "TriggerOnStartup" }, null, null, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(PlaylistItem), PlaylistItem.Parser, new string[9] { "Uuid", "Name", "Header", "Presentation", "Cue", "PlanningCenter", "Placeholder", "Tags", "IsHidden" }, new string[1] { "ItemType" }, null, null, new GeneratedClrTypeInfo[4]
			{
				new GeneratedClrTypeInfo(typeof(PlaylistItem.Types.Header), PlaylistItem.Types.Header.Parser, new string[2] { "Color", "Actions" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(PlaylistItem.Types.Presentation), PlaylistItem.Types.Presentation.Parser, new string[5] { "DocumentPath", "Arrangement", "ContentDestination", "UserMusicKey", "ArrangementName" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(PlaylistItem.Types.PlanningCenter), PlaylistItem.Types.PlanningCenter.Parser, new string[2] { "Item", "LinkedData" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(PlaylistItem.Types.Placeholder), PlaylistItem.Types.Placeholder.Parser, new string[1] { "LinkedData" }, null, null, null, null)
			})
		}));
	}
}
