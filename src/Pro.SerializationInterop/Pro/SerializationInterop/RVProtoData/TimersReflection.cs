using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class TimersReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static TimersReflection()
	{
		_003C_003Ey__InlineArray45<string> buffer = default(_003C_003Ey__InlineArray45<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 0) = "Cgx0aW1lcnMucHJvdG8SB3J2LmRhdGEaFWFwcGxpY2F0aW9uSW5mby5wcm90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 1) = "bxoTY3VzdG9tT3B0aW9ucy5wcm90bxoKdXVpZC5wcm90byL4AgoFQ2xvY2sS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 2) = "DgoGZm9ybWF0GAEgASgJGt4CCgZGb3JtYXQSOwoJZGF0ZV90eXBlGAIgASgO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 3) = "MigucnYuZGF0YS5DbG9jay5Gb3JtYXQuRGF0ZUZvcm1hdHRlclN0eWxlEj0K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 4) = "C3RpbWVfZm9ybWF0GAMgASgOMigucnYuZGF0YS5DbG9jay5Gb3JtYXQuRGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 5) = "ZUZvcm1hdHRlclN0eWxlEh0KFW1pbGl0YXJ5X3RpbWVfZW5hYmxlZBgEIAEo";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 6) = "CCKyAQoSRGF0ZUZvcm1hdHRlclN0eWxlEh0KGURBVEVfRk9STUFUVEVSX1NU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 7) = "WUxFX05PTkUQABIeChpEQVRFX0ZPUk1BVFRFUl9TVFlMRV9TSE9SVBABEh8K";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 8) = "G0RBVEVfRk9STUFUVEVSX1NUWUxFX01FRElVTRACEh0KGURBVEVfRk9STUFU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 9) = "VEVSX1NUWUxFX0xPTkcQAxIdChlEQVRFX0ZPUk1BVFRFUl9TVFlMRV9GVUxM";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 10) = "EARKBAgBEAIiigkKBVRpbWVyEhsKBHV1aWQYASABKAsyDS5ydi5kYXRhLlVV";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 11) = "SUQSDAoEbmFtZRgCIAEoCRI5Cg1jb25maWd1cmF0aW9uGAogASgLMhwucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 12) = "ZGF0YS5UaW1lci5Db25maWd1cmF0aW9uQgSohhkBGooDCgZGb3JtYXQSKQoE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 13) = "aG91chgBIAEoDjIbLnJ2LmRhdGEuVGltZXIuRm9ybWF0LlN0eWxlEisKBm1p";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 14) = "bnV0ZRgCIAEoDjIbLnJ2LmRhdGEuVGltZXIuRm9ybWF0LlN0eWxlEisKBnNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 15) = "Y29uZBgDIAEoDjIbLnJ2LmRhdGEuVGltZXIuRm9ybWF0LlN0eWxlEjAKC21p";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 16) = "bGxpc2Vjb25kGAQgASgOMhsucnYuZGF0YS5UaW1lci5Gb3JtYXQuU3R5bGUS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 17) = "GgoSaXNfd2FsbF9jbG9ja190aW1lGAUgASgIEhcKD2lzXzI0X2hvdXJfdGlt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 18) = "ZRgGIAEoCBIrCiNzaG93X21pbGxpc2Vjb25kc191bmRlcl9taW51dGVfb25s";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 19) = "eRgHIAEoCCJnCgVTdHlsZRIOCgpTVFlMRV9OT05FEAASDwoLU1RZTEVfU0hP";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 20) = "UlQQARIOCgpTVFlMRV9MT05HEAISFgoSU1RZTEVfUkVNT1ZFX1NIT1JUEAMS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 21) = "FQoRU1RZTEVfUkVNT1ZFX0xPTkcQBBrjBAoNQ29uZmlndXJhdGlvbhJECglj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 22) = "b3VudGRvd24YASABKAsyLy5ydi5kYXRhLlRpbWVyLkNvbmZpZ3VyYXRpb24u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 23) = "VGltZXJUeXBlQ291bnRkb3duSAASUgoRY291bnRkb3duX3RvX3RpbWUYAiAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 24) = "KAsyNS5ydi5kYXRhLlRpbWVyLkNvbmZpZ3VyYXRpb24uVGltZXJUeXBlQ291";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 25) = "bnRkb3duVG9UaW1lSAASSQoMZWxhcHNlZF90aW1lGAMgASgLMjEucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 26) = "YS5UaW1lci5Db25maWd1cmF0aW9uLlRpbWVyVHlwZUVsYXBzZWRUaW1lSAAS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 27) = "FgoOYWxsb3dzX292ZXJydW4YBCABKAgaJgoSVGltZXJUeXBlQ291bnRkb3du";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 28) = "EhAKCGR1cmF0aW9uGAEgASgBGssBChhUaW1lclR5cGVDb3VudGRvd25Ub1Rp";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 29) = "bWUSEwoLdGltZV9vZl9kYXkYASABKAESUAoGcGVyaW9kGAIgASgOMkAucnYu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 30) = "ZGF0YS5UaW1lci5Db25maWd1cmF0aW9uLlRpbWVyVHlwZUNvdW50ZG93blRv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 31) = "VGltZS5UaW1lUGVyaW9kIkgKClRpbWVQZXJpb2QSEgoOVElNRV9QRVJJT0Rf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 32) = "QU0QABISCg5USU1FX1BFUklPRF9QTRABEhIKDlRJTUVfUEVSSU9EXzI0EAIa";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 33) = "UgoUVGltZXJUeXBlRWxhcHNlZFRpbWUSEgoKc3RhcnRfdGltZRgBIAEoARIQ";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 34) = "CghlbmRfdGltZRgCIAEoARIUCgxoYXNfZW5kX3RpbWUYAyABKAhCCwoJVGlt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 35) = "ZXJUeXBlSgQIAxAESgQIBBAFSgQIBRAGSgQIBhAHSgQIBxAISgQICBAJSgQI";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 36) = "CRAKIo8BCg5UaW1lcnNEb2N1bWVudBI4ChBhcHBsaWNhdGlvbl9pbmZvGAEg";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 37) = "ASgLMhgucnYuZGF0YS5BcHBsaWNhdGlvbkluZm9CBKiGGQESIwoFY2xvY2sY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 38) = "AiABKAsyDi5ydi5kYXRhLkNsb2NrQgSohhkBEh4KBnRpbWVycxgDIAMoCzIO";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 39) = "LnJ2LmRhdGEuVGltZXIiXgoKTG9jYWxUaW1lchIbCgR1dWlkGAEgASgLMg0u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 40) = "cnYuZGF0YS5VVUlEEjMKDWNvbmZpZ3VyYXRpb24YAiABKAsyHC5ydi5kYXRh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 41) = "LlRpbWVyLkNvbmZpZ3VyYXRpb24iOgoTVGltZXJzTG9jYWxEb2N1bWVudBIj";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 42) = "CgZ0aW1lcnMYASADKAsyEy5ydi5kYXRhLkxvY2FsVGltZXJCNPgBAaoCJFBy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 43) = "by5TZXJpYWxpemF0aW9uSW50ZXJvcC5SVlByb3RvRGF0YboCB1JWRGF0YV9i";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray45<string>, string>(ref buffer, 44) = "BnByb3RvMw==";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray45<string>, string>(in buffer, 45))), new FileDescriptor[3]
		{
			ApplicationInfoReflection.Descriptor,
			CustomOptionsReflection.Descriptor,
			UuidReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[5]
		{
			new GeneratedClrTypeInfo(typeof(Clock), Clock.Parser, new string[1] { "Format" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(Clock.Types.Format), Clock.Types.Format.Parser, new string[3] { "DateType", "TimeFormat", "MilitaryTimeEnabled" }, null, new Type[1] { typeof(Clock.Types.Format.Types.DateFormatterStyle) }, null, null)
			}),
			new GeneratedClrTypeInfo(typeof(Timer), Timer.Parser, new string[3] { "Uuid", "Name", "Configuration" }, null, null, null, new GeneratedClrTypeInfo[2]
			{
				new GeneratedClrTypeInfo(typeof(Timer.Types.Format), Timer.Types.Format.Parser, new string[7] { "Hour", "Minute", "Second", "Millisecond", "IsWallClockTime", "Is24HourTime", "ShowMillisecondsUnderMinuteOnly" }, null, new Type[1] { typeof(Timer.Types.Format.Types.Style) }, null, null),
				new GeneratedClrTypeInfo(typeof(Timer.Types.Configuration), Timer.Types.Configuration.Parser, new string[4] { "Countdown", "CountdownToTime", "ElapsedTime", "AllowsOverrun" }, new string[1] { "TimerType" }, null, null, new GeneratedClrTypeInfo[3]
				{
					new GeneratedClrTypeInfo(typeof(Timer.Types.Configuration.Types.TimerTypeCountdown), Timer.Types.Configuration.Types.TimerTypeCountdown.Parser, new string[1] { "Duration" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(Timer.Types.Configuration.Types.TimerTypeCountdownToTime), Timer.Types.Configuration.Types.TimerTypeCountdownToTime.Parser, new string[2] { "TimeOfDay", "Period" }, null, new Type[1] { typeof(Timer.Types.Configuration.Types.TimerTypeCountdownToTime.Types.TimePeriod) }, null, null),
					new GeneratedClrTypeInfo(typeof(Timer.Types.Configuration.Types.TimerTypeElapsedTime), Timer.Types.Configuration.Types.TimerTypeElapsedTime.Parser, new string[3] { "StartTime", "EndTime", "HasEndTime" }, null, null, null, null)
				})
			}),
			new GeneratedClrTypeInfo(typeof(TimersDocument), TimersDocument.Parser, new string[3] { "ApplicationInfo", "Clock", "Timers" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(LocalTimer), LocalTimer.Parser, new string[2] { "Uuid", "Configuration" }, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(TimersLocalDocument), TimersLocalDocument.Parser, new string[1] { "Timers" }, null, null, null, null)
		}));
	}
}
