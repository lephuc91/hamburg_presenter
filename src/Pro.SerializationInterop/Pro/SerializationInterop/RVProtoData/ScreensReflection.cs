using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class ScreensReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static ScreensReflection()
	{
		_003C_003Ey__InlineArray73<string> buffer = default(_003C_003Ey__InlineArray73<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 0) = "Cg1zY3JlZW5zLnByb3RvEgdydi5kYXRhGgtjb2xvci5wcm90bxoTY3VzdG9t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 1) = "T3B0aW9ucy5wcm90bxoSZ3JhcGhpY3NEYXRhLnByb3RvGgp1dWlkLnByb3Rv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 2) = "Ir4JCgZTY3JlZW4SGwoEdXVpZBgBIAEoCzINLnJ2LmRhdGEuVVVJRBIMCgRu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 3) = "YW1lGAIgASgJEh0KBWNvbG9yGAMgASgLMg4ucnYuZGF0YS5Db2xvchImCgZi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 4) = "b3VuZHMYBCABKAsyFi5ydi5kYXRhLkdyYXBoaWNzLlJlY3QSGwoTYXNwZWN0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 5) = "X3JhdGlvX2xvY2tlZBgFIAEoCBIpCiFvdXRwdXRfYm91bmRzX2FzcGVjdF9y";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 6) = "YXRpb19sb2NrZWQYBiABKAgSHgoWY29ybmVyX3Bpbm5pbmdfZW5hYmxlZBgH";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 7) = "IAEoCBIzChNzdWJzY3JlZW5fdW5pdF9yZWN0GAggASgLMhYucnYuZGF0YS5H";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 8) = "cmFwaGljcy5SZWN0EhAKCHJvdGF0aW9uGAkgASgBEhEKBWdhbW1hGAogASgB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 9) = "QgIYARIXCgtibGFja19sZXZlbBgLIAEoAUICGAESFQoNYmxlbmRlZF9lZGdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 10) = "cxgMIAEoDRIsCg1jb3JuZXJfdmFsdWVzGA0gASgLMhUucnYuZGF0YS5Db3Ju";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 11) = "ZXJWYWx1ZXMSNAoOb3V0cHV0X2Rpc3BsYXkYDiABKAsyFi5ydi5kYXRhLk91";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 12) = "dHB1dERpc3BsYXlCBKCGGQESGwoNY29sb3JfZW5hYmxlZBgPIAEoCEIEqIYZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 13) = "ARI5ChBjb2xvcl9hZGp1c3RtZW50GBAgASgLMh8ucnYuZGF0YS5TY3JlZW4u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 14) = "Q29sb3JBZGp1c3RtZW50Ej0KEmJsZW5kX2NvbXBlbnNhdGlvbhgRIAEoCzIh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 15) = "LnJ2LmRhdGEuU2NyZWVuLkJsZW5kQ29tcGVuc2F0aW9uEjUKDmFscGhhX3Nl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 16) = "dHRpbmdzGBIgASgLMh0ucnYuZGF0YS5TY3JlZW4uQWxwaGFTZXR0aW5ncxqj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 17) = "AQoPQ29sb3JBZGp1c3RtZW50Eg0KBWdhbW1hGAEgASgBEhMKC2JsYWNrX2xl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 18) = "dmVsGAIgASgBEhEKCXJlZF9sZXZlbBgDIAEoARITCgtncmVlbl9sZXZlbBgE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 19) = "IAEoARISCgpibHVlX2xldmVsGAUgASgBEhgKCmJyaWdodG5lc3MYBiABKAFC";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 20) = "BKiGGQESFgoIY29udHJhc3QYByABKAFCBKiGGQEaKAoRQmxlbmRDb21wZW5z";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 21) = "YXRpb24SEwoLYmxhY2tfbGV2ZWwYASABKAEazQIKDUFscGhhU2V0dGluZ3MS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 22) = "MAoEbW9kZRgBIAEoDjIiLnJ2LmRhdGEuU2NyZWVuLkFscGhhU2V0dGluZ3Mu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 23) = "TW9kZRJFCgxhbHBoYV9kZXZpY2UYAiABKAsyKS5ydi5kYXRhLlNjcmVlbi5B";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 24) = "bHBoYVNldHRpbmdzLkFscGhhRGV2aWNlQgSghhkBGmsKC0FscGhhRGV2aWNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 25) = "EicKB2Rpc3BsYXkYASABKAsyFi5ydi5kYXRhLk91dHB1dERpc3BsYXkSMwoT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 26) = "c3Vic2NyZWVuX3VuaXRfcmVjdBgCIAEoCzIWLnJ2LmRhdGEuR3JhcGhpY3Mu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 27) = "UmVjdCJWCgRNb2RlEhAKDE1PREVfVU5LTk9XThAAEhEKDU1PREVfRElTQUJM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 28) = "RUQQARIWChJNT0RFX1BSRU1VTFRJUExJRUQQAhIRCg1NT0RFX1NUUkFJR0hU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 29) = "EAMiwgEKDENvcm5lclZhbHVlcxIpCgh0b3BfbGVmdBgBIAEoCzIXLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 30) = "dGEuR3JhcGhpY3MuUG9pbnQSKgoJdG9wX3JpZ2h0GAIgASgLMhcucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 31) = "YS5HcmFwaGljcy5Qb2ludBIsCgtib3R0b21fbGVmdBgDIAEoCzIXLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 32) = "dGEuR3JhcGhpY3MuUG9pbnQSLQoMYm90dG9tX3JpZ2h0GAQgASgLMhcucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 33) = "ZGF0YS5HcmFwaGljcy5Qb2ludCJkCgtEaXNwbGF5TW9kZRIMCgRuYW1lGAEg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 34) = "ASgJEg0KBXdpZHRoGAIgASgNEg4KBmhlaWdodBgDIAEoDRIUCgxyZWZyZXNo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 35) = "X3JhdGUYBCABKAESEgoKaW50ZXJsYWNlZBgFIAEoCCKvBgoNT3V0cHV0RGlz";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 36) = "cGxheRIMCgRuYW1lGAEgASgJEg0KBW1vZGVsGAIgASgJEg4KBnNlcmlhbBgD";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 37) = "IAEoCRISCgpkZXZpY2VOYW1lGAQgASgJEg4KBnZlbmRvchgFIAEoCRIRCglt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 38) = "b2RlSW5kZXgYBiABKA0SJgoGYm91bmRzGAcgASgLMhYucnYuZGF0YS5HcmFw";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 39) = "aGljcy5SZWN0EikKBHR5cGUYCCABKA4yGy5ydi5kYXRhLk91dHB1dERpc3Bs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 40) = "YXkuVHlwZRIiCgRtb2RlGAkgASgLMhQucnYuZGF0YS5EaXNwbGF5TW9kZRIR";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 41) = "CglyZW5kZXJfaWQYCiABKAkSNwoKYmxhY2ttYWdpYxgLIAEoCzIhLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 42) = "dGEuT3V0cHV0RGlzcGxheS5CbGFja21hZ2ljSAASEwoLdmlkZW9fZGVsYXkY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 43) = "DCABKAUSOgoNcmVuZGVyX2Zvcm1hdBgNIAEoDjIjLnJ2LmRhdGEuT3V0cHV0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 44) = "RGlzcGxheS5SZW5kZXJGb3JtYXQSGwoTaGRyX21heF9uaXRzX29mZnNldBgO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 45) = "IAEoBRqoAQoKQmxhY2ttYWdpYxIPCgdlbmFibGVkGAEgASgIEjsKCGtleV9t";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 46) = "b2RlGAIgASgOMikucnYuZGF0YS5PdXRwdXREaXNwbGF5LkJsYWNrbWFnaWMu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 47) = "S2V5TW9kZRITCgtibGVuZF92YWx1ZRgDIAEoASI3CgdLZXlNb2RlEhUKEUtF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 48) = "WV9NT0RFX0lOVEVSTkFMEAASFQoRS0VZX01PREVfRVhURVJOQUwQASJoCgRU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 49) = "eXBlEhAKDFRZUEVfVU5LTk9XThAAEg8KC1RZUEVfU0NSRUVOEAESDQoJVFlQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 50) = "RV9DQVJEEAISDAoIVFlQRV9OREkQAxIPCgtUWVBFX1NZUEhPThAEEg8KC1RZ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 51) = "UEVfQ1VTVE9NEAUiYQoMUmVuZGVyRm9ybWF0EhQKEFJFTkRFUkZPUk1BVF9T";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 52) = "RFIQABIcChhSRU5ERVJGT1JNQVRfUkVDXzIxMDBfUFEQARIdChlSRU5ERVJG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 53) = "T1JNQVRfUkVDXzIxMDBfSExHEAJCEQoPSGFyZHdhcmVPcHRpb25zIowGCglF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 54) = "ZGdlQmxlbmQSGwoEdXVpZBgBIAEoCzINLnJ2LmRhdGEuVVVJRBISCgZyYWRp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 55) = "dXMYAiABKAFCAhgBEhUKCWludGVuc2l0eRgDIAEoAUICGAESKQoEbW9kZRgE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 56) = "IAEoDjIXLnJ2LmRhdGEuRWRnZUJsZW5kLk1vZGVCAhgBEjMKDGZpcnN0X3Nj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 57) = "cmVlbhgFIAEoCzIZLnJ2LmRhdGEuRWRnZUJsZW5kLlNjcmVlbkICGAESNAoN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 58) = "c2Vjb25kX3NjcmVlbhgGIAEoCzIZLnJ2LmRhdGEuRWRnZUJsZW5kLlNjcmVl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 59) = "bkICGAESLgoLbGVmdF9zY3JlZW4YByABKAsyGS5ydi5kYXRhLkVkZ2VCbGVu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 60) = "ZC5TY3JlZW4SLwoMcmlnaHRfc2NyZWVuGAggASgLMhkucnYuZGF0YS5FZGdl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 61) = "QmxlbmQuU2NyZWVuEi0KCnRvcF9zY3JlZW4YCSABKAsyGS5ydi5kYXRhLkVk";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 62) = "Z2VCbGVuZC5TY3JlZW4SMAoNYm90dG9tX3NjcmVlbhgKIAEoCzIZLnJ2LmRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 63) = "dGEuRWRnZUJsZW5kLlNjcmVlbhqhAgoGU2NyZWVuEhsKBHV1aWQYASABKAsy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 64) = "DS5ydi5kYXRhLlVVSUQSMAoEZWRnZRgCIAEoDjIeLnJ2LmRhdGEuRWRnZUJs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 65) = "ZW5kLlNjcmVlbi5FZGdlQgIYARINCgVnYW1tYRgDIAEoARIXCgtibGFja19s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 66) = "ZXZlbBgEIAEoAUICGAESJQoEbW9kZRgFIAEoDjIXLnJ2LmRhdGEuRWRnZUJs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 67) = "ZW5kLk1vZGUSDgoGcmFkaXVzGAYgASgBEhEKCWludGVuc2l0eRgHIAEoASJW";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 68) = "CgRFZGdlEhAKDEVER0VfVU5LTk9XThAAEg0KCUVER0VfTEVGVBABEg4KCkVE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 69) = "R0VfUklHSFQQAhIMCghFREdFX1RPUBADEg8KC0VER0VfQk9UVE9NEAQiOwoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 70) = "TW9kZRIPCgtNT0RFX0xJTkVBUhAAEg4KCk1PREVfQ1VCSUMQARISCg5NT0RF";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 71) = "X1FVQURSQVRJQxACQjT4AQGqAiRQcm8uU2VyaWFsaXphdGlvbkludGVyb3Au";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray73<string>, string>(ref buffer, 72) = "UlZQcm90b0RhdGG6AgdSVkRhdGFfYgZwcm90bzM=";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray73<string>, string>(in buffer, 73))), new FileDescriptor[4]
		{
			ColorReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			GraphicsDataReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[5]
		{
			new GeneratedClrTypeInfo(typeof(Screen), Screen.Parser, new string[18]
			{
				"Uuid", "Name", "Color", "Bounds", "AspectRatioLocked", "OutputBoundsAspectRatioLocked", "CornerPinningEnabled", "SubscreenUnitRect", "Rotation", "Gamma",
				"BlackLevel", "BlendedEdges", "CornerValues", "OutputDisplay", "ColorEnabled", "ColorAdjustment", "BlendCompensation", "AlphaSettings"
			}, null, null, null, new GeneratedClrTypeInfo[3]
			{
				new GeneratedClrTypeInfo(typeof(Screen.Types.ColorAdjustment), Screen.Types.ColorAdjustment.Parser, new string[7] { "Gamma", "BlackLevel", "RedLevel", "GreenLevel", "BlueLevel", "Brightness", "Contrast" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Screen.Types.BlendCompensation), Screen.Types.BlendCompensation.Parser, new string[1] { "BlackLevel" }, null, null, null, null),
				new GeneratedClrTypeInfo(typeof(Screen.Types.AlphaSettings), Screen.Types.AlphaSettings.Parser, new string[2] { "Mode", "AlphaDevice" }, null, new Type[1] { typeof(Screen.Types.AlphaSettings.Types.Mode) }, null, new GeneratedClrTypeInfo[1]
				{
					new GeneratedClrTypeInfo(typeof(Screen.Types.AlphaSettings.Types.AlphaDevice), Screen.Types.AlphaSettings.Types.AlphaDevice.Parser, new string[2] { "Display", "SubscreenUnitRect" }, null, null, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(CornerValues), CornerValues.Parser, new string[4] { "TopLeft", "TopRight", "BottomLeft", "BottomRight" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(DisplayMode), DisplayMode.Parser, new string[5] { "Name", "Width", "Height", "RefreshRate", "Interlaced" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(OutputDisplay), OutputDisplay.Parser, new string[14]
			{
				"Name", "Model", "Serial", "DeviceName", "Vendor", "ModeIndex", "Bounds", "Type", "Mode", "RenderId",
				"Blackmagic", "VideoDelay", "RenderFormat", "HdrMaxNitsOffset"
			}, new string[1] { "HardwareOptions" }, new Type[2]
			{
				typeof(OutputDisplay.Types.Type),
				typeof(OutputDisplay.Types.RenderFormat)
			}, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(OutputDisplay.Types.Blackmagic), OutputDisplay.Types.Blackmagic.Parser, new string[3] { "Enabled", "KeyMode", "BlendValue" }, null, new Type[1] { typeof(OutputDisplay.Types.Blackmagic.Types.KeyMode) }, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(EdgeBlend), EdgeBlend.Parser, new string[10] { "Uuid", "Radius", "Intensity", "Mode", "FirstScreen", "SecondScreen", "LeftScreen", "RightScreen", "TopScreen", "BottomScreen" }, null, new Type[1] { typeof(EdgeBlend.Types.Mode) }, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(EdgeBlend.Types.Screen), EdgeBlend.Types.Screen.Parser, new string[7] { "Uuid", "Edge", "Gamma", "BlackLevel", "Mode", "Radius", "Intensity" }, null, new Type[1] { typeof(EdgeBlend.Types.Screen.Types.Edge) }, null, null)
			})
		}));
	}
}
