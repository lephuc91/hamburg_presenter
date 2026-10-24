using System;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Timeline;

public static class AnalyticsTimelineReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static AnalyticsTimelineReflection()
	{
		_003C_003Ey__InlineArray12<string> buffer = default(_003C_003Ey__InlineArray12<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 0) = "ChdhbmFseXRpY3NUaW1lbGluZS5wcm90bxIVcnYuYW5hbHl0aWNzLnRpbWVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 1) = "aW5lInQKBkFjdGlvbhI9CgthY3Rpb25fdHlwZRgBIAEoDjIoLnJ2LmFuYWx5";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 2) = "dGljcy50aW1lbGluZS5BY3Rpb24uQWN0aW9uVHlwZSIrCgpBY3Rpb25UeXBl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 3) = "EggKBFBMQVkQABIICgRTVE9QEAESCQoFUkVTRVQQAiILCglSZWNvcmRDdWUi";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 4) = "/QEKCkN1ZVRyaWdnZXISQwoMdHJpZ2dlcl90eXBlGAEgASgOMi0ucnYuYW5h";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 5) = "bHl0aWNzLnRpbWVsaW5lLkN1ZVRyaWdnZXIuVHJpZ2dlclR5cGUSRQoNdGlt";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 6) = "aW5nX3NvdXJjZRgCIAEoDjIuLnJ2LmFuYWx5dGljcy50aW1lbGluZS5DdWVU";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 7) = "cmlnZ2VyLlRpbWluZ1NvdXJjZSI6CgtUcmlnZ2VyVHlwZRIJCgVTTElERRAA";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 8) = "EgkKBU1FRElBEAESCQoFQVVESU8QAhIKCgZBQ1RJT04QAyInCgxUaW1pbmdT";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 9) = "b3VyY2USDAoISU5URVJOQUwQABIJCgVTTVBURRABQlP4AQGqAjdQcm8uU2Vy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 10) = "aWFsaXphdGlvbkludGVyb3AuUlZQcm90b0RhdGEuQW5hbHl0aWNzLlRpbWVs";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray12<string>, string>(ref buffer, 11) = "aW5lugITQW5hbHl0aWNzX1RpbWVsaW5lX2IGcHJvdG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray12<string>, string>(in buffer, 12))), new FileDescriptor[0], new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[3]
		{
			new GeneratedClrTypeInfo(typeof(Action), Action.Parser, new string[1] { "ActionType" }, null, new Type[1] { typeof(Action.Types.ActionType) }, null, null),
			new GeneratedClrTypeInfo(typeof(RecordCue), RecordCue.Parser, null, null, null, null, null),
			new GeneratedClrTypeInfo(typeof(CueTrigger), CueTrigger.Parser, new string[2] { "TriggerType", "TimingSource" }, null, new Type[2]
			{
				typeof(CueTrigger.Types.TriggerType),
				typeof(CueTrigger.Types.TimingSource)
			}, null, null)
		}));
	}
}
