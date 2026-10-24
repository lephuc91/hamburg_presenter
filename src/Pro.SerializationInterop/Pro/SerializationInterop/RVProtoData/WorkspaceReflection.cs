using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

public static class WorkspaceReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static WorkspaceReflection()
	{
		_003C_003Ey__InlineArray34<string> buffer = default(_003C_003Ey__InlineArray34<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 0) = "Cg93b3Jrc3BhY2UucHJvdG8SB3J2LmRhdGEaFGFsaWdubWVudEd1aWRlLnBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 1) = "b3RvGg5jYWxlbmRhci5wcm90bxoNZWZmZWN0cy5wcm90bxoSZ3JhcGhpY3NE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 2) = "YXRhLnByb3RvGgxob3RLZXkucHJvdG8aDGxheWVycy5wcm90bxoXbGl2ZVZp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 3) = "ZGVvUGxheWxpc3QucHJvdG8aC21hc2tzLnByb3RvGg5wbGF5bGlzdC5wcm90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 4) = "bxoNc2NyZWVucy5wcm90bxoNdGFyZ2V0cy5wcm90bxoJdXJsLnByb3RvGgp1";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 5) = "dWlkLnByb3RvIrwJCglXb3Jrc3BhY2USGwoEdXVpZBgBIAEoCzINLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 6) = "dGEuVVVJRBINCgVtdXRlZBgCIAEoCBIOCgZoaWRkZW4YAyABKAgSPgoRZWRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 7) = "dG9yX2JhY2tncm91bmQYBCABKAsyIy5ydi5kYXRhLldvcmtzcGFjZS5FZGl0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 8) = "b3JCYWNrZ3JvdW5kEikKEmVmZmVjdF9wcmVzZXRfdXVpZBgFIAEoCzINLnJ2";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 9) = "LmRhdGEuVVVJRBIdChVlZmZlY3RfYnVpbGRfZHVyYXRpb24YBiABKAESJwoK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 10) = "dHJhbnNpdGlvbhgHIAEoCzITLnJ2LmRhdGEuVHJhbnNpdGlvbhInChBhY3Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 11) = "dmVfbWFza191dWlkGAggASgLMg0ucnYuZGF0YS5VVUlEEiMKCHBsYXlsaXN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 12) = "GAkgASgLMhEucnYuZGF0YS5QbGF5bGlzdBI0Cgx1bml0X3NjYWxpbmcYCiAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 13) = "KAsyHi5ydi5kYXRhLldvcmtzcGFjZS5Vbml0U2NhbGluZxIgCgdlZmZlY3Rz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 14) = "GBAgAygLMg8ucnYuZGF0YS5FZmZlY3QSHAoFbWFza3MYESADKAsyDS5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 15) = "YXRhLk1hc2sSIAoHc2NyZWVucxgSIAMoCzIPLnJ2LmRhdGEuU2NyZWVuEicK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 16) = "C2VkZ2VfYmxlbmRzGBMgAygLMhIucnYuZGF0YS5FZGdlQmxlbmQSHgoGbGF5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 17) = "ZXJzGBQgAygLMg4ucnYuZGF0YS5MYXllchInCgt0YXJnZXRfc2V0cxgVIAMo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 18) = "CzISLnJ2LmRhdGEuVGFyZ2V0U2V0EiEKCGhvdF9rZXlzGBYgAygLMg8ucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 19) = "ZGF0YS5Ib3RLZXkSIwoIY2FsZW5kYXIYFyABKAsyES5ydi5kYXRhLkNhbGVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 20) = "ZGFyEjEKEGFsaWdubWVudF9ndWlkZXMYGCADKAsyFy5ydi5kYXRhLkFsaWdu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 21) = "bWVudEd1aWRlEjcKE2xpdmVfdmlkZW9fcGxheWxpc3QYGSABKAsyGi5ydi5k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 22) = "YXRhLkxpdmVWaWRlb1BsYXlsaXN0EjYKFm91dHB1dF9wcmV2aWV3X2Rpc3Bs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 23) = "YXkYGiABKAsyFi5ydi5kYXRhLk91dHB1dERpc3BsYXkadgoQRWRpdG9yQmFj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 24) = "a2dyb3VuZBIPCgdlbmFibGVkGAEgASgIEiUKBWZyYW1lGAIgASgLMhYucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 25) = "ZGF0YS5HcmFwaGljcy5SZWN0EhkKA3VybBgDIAEoCzIMLnJ2LmRhdGEuVVJM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 26) = "Eg8KB29wYWNpdHkYBCABKAEa/QEKC1VuaXRTY2FsaW5nEg4KBmxlbmd0aBgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 27) = "IAEoARI1CgR1bml0GAIgASgOMicucnYuZGF0YS5Xb3Jrc3BhY2UuVW5pdFNj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 28) = "YWxpbmcuVW5pdFR5cGUSDgoGcG9pbnRzGAMgASgBIpYBCghVbml0VHlwZRIU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 29) = "ChBVTklUX1RZUEVfUE9JTlRTEAASGQoVVU5JVF9UWVBFX01JTExJTUVURVJT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 30) = "EAESGQoVVU5JVF9UWVBFX0NFTlRJTUVURVJTEAISFAoQVU5JVF9UWVBFX01F";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 31) = "VEVSUxADEhQKEFVOSVRfVFlQRV9JTkNIRVMQBBISCg5VTklUX1RZUEVfRkVF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 32) = "VBAFSgQIGxAcQjT4AQGqAiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3AuUlZQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray34<string>, string>(ref buffer, 33) = "cm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray34<string>, string>(in buffer, 34))), new FileDescriptor[13]
		{
			AlignmentGuideReflection.Descriptor,
			CalendarReflection.Descriptor,
			EffectsReflection.Descriptor,
			GraphicsDataReflection.Descriptor,
			HotKeyReflection.Descriptor,
			LayersReflection.Descriptor,
			LiveVideoPlaylistReflection.Descriptor,
			MasksReflection.Descriptor,
			PlaylistReflection.Descriptor,
			ScreensReflection.Descriptor,
			TargetsReflection.Descriptor,
			UrlReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(Workspace), Workspace.Parser, new string[21]
			{
				"Uuid", "Muted", "Hidden", "EditorBackground", "EffectPresetUuid", "EffectBuildDuration", "Transition", "ActiveMaskUuid", "Playlist", "UnitScaling",
				"Effects", "Masks", "Screens", "EdgeBlends", "Layers", "TargetSets", "HotKeys", "Calendar", "AlignmentGuides", "LiveVideoPlaylist",
				"OutputPreviewDisplay"
			}, null, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(Workspace.Types.EditorBackground), Workspace.Types.EditorBackground.Parser, new string[4] { "Enabled", "Frame", "Url", "Opacity" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Workspace.Types.UnitScaling), Workspace.Types.UnitScaling.Parser, new string[3] { "Length", "Unit", "Points" }, null, new Type[1] { typeof(Workspace.Types.UnitScaling.Types.UnitType) }, null, null)
			})
		}));
	}
}
