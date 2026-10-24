using System;
using Google.Protobuf.Reflection;
using Rv.Data;

namespace Pro.SerializationInterop.RVProtoData;

public static class PlanningCenterReflection
{
	private static FileDescriptor descriptor;

	public static FileDescriptor Descriptor => descriptor;

	static PlanningCenterReflection()
	{
		_003C_003Ey__InlineArray36<string> buffer = default(_003C_003Ey__InlineArray36<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 0) = "ChRwbGFubmluZ0NlbnRlci5wcm90bxIHcnYuZGF0YRoTY3VzdG9tT3B0aW9u";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 1) = "cy5wcm90bxoScHJlc2VudGF0aW9uLnByb3RvGhFydnRpbWVzdGFtcC5wcm90";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 2) = "bxoJdXJsLnByb3RvIoMLChJQbGFubmluZ0NlbnRlclBsYW4SEwoLcGxhbl9p";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 3) = "ZF9udW0YASABKA0SFQoNcGFyZW50X2lkX251bRgCIAEoDRIUCgxzZXJpZXNf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 4) = "dGl0bGUYAyABKAkSEgoKcGxhbl90aXRsZRgEIAEoCRIRCglkYXRlX2xpc3QY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 5) = "BSABKAkSKAoMY3JlYXRlZF9kYXRlGAYgASgLMhIucnYuZGF0YS5UaW1lc3Rh";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 6) = "bXASJwoLdXBkYXRlX2RhdGUYByABKAsyEi5ydi5kYXRhLlRpbWVzdGFtcBIy";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 7) = "ChZsYXN0X3VwZGF0ZV9jaGVja19kYXRlGAggASgLMhIucnYuZGF0YS5UaW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 8) = "c3RhbXASEwoLcGxhbl9pZF9zdHIYCSABKAkSFQoNcGFyZW50X2lkX3N0chgK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 9) = "IAEoCRrQCAoIUGxhbkl0ZW0SRAoJaXRlbV90eXBlGAEgASgOMjEucnYuZGF0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 10) = "YS5QbGFubmluZ0NlbnRlclBsYW4uUGxhbkl0ZW0uUGxhbkl0ZW1UeXBlEhIK";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 11) = "CnBjb19pZF9udW0YAiABKA0SFgoOc2VydmljZV9pZF9udW0YAyABKA0SFQoN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 12) = "cGFyZW50X2lkX251bRgEIAEoDRIMCgRuYW1lGAUgASgJEkQKC2F0dGFjaG1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 13) = "bnRzGAYgAygLMi8ucnYuZGF0YS5QbGFubmluZ0NlbnRlclBsYW4uUGxhbkl0";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 14) = "ZW0uQXR0YWNobWVudBInCgt1cGRhdGVfZGF0ZRgHIAEoCzISLnJ2LmRhdGEu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 15) = "VGltZXN0YW1wEkgKC2xpbmtlZF9zb25nGAggASgLMi0ucnYuZGF0YS5QbGFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 16) = "bmluZ0NlbnRlclBsYW4uUGxhbkl0ZW0uU29uZ0l0ZW1CBKCGGQESEgoKcGNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 17) = "X2lkX3N0chgJIAEoCRIWCg5zZXJ2aWNlX2lkX3N0chgKIAEoCRIVCg1wYXJl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 18) = "bnRfaWRfc3RyGAsgASgJGvUBCgpBdHRhY2htZW50EgwKBG5hbWUYASABKAkS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 19) = "HwoDdXJsGAIgASgLMgwucnYuZGF0YS5VUkxCBKCGGQESKAoMY3JlYXRlZF9k";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 20) = "YXRlGAMgASgLMhIucnYuZGF0YS5UaW1lc3RhbXASJwoLbGlua2VkX3BhdGgY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 21) = "BCABKAsyDC5ydi5kYXRhLlVSTEIEoIYZARISCgpwY29faWRfbnVtGAUgASgN";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 22) = "EhQKDG5lZWRzX3VwZGF0ZRgGIAEoCBInCgt1cGRhdGVfZGF0ZRgHIAEoCzIS";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 23) = "LnJ2LmRhdGEuVGltZXN0YW1wEhIKCnBjb19pZF9zdHIYCCABKAkawQIKCFNv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 24) = "bmdJdGVtEhIKCnBjb19pZF9udW0YASABKA0SGgoSYXJyYW5nZW1lbnRfaWRf";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 25) = "bnVtGAIgASgNEi4KBGNjbGkYAyABKAsyGi5ydi5kYXRhLlByZXNlbnRhdGlv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 26) = "bi5DQ0xJQgSghhkBEk4KCHNlcXVlbmNlGAQgASgLMjYucnYuZGF0YS5QbGFu";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 27) = "bmluZ0NlbnRlclBsYW4uUGxhbkl0ZW0uU29uZ0l0ZW0uU2VxdWVuY2VCBKCG";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 28) = "GQESEgoKcGNvX2lkX3N0chgFIAEoCRIaChJhcnJhbmdlbWVudF9pZF9zdHIY";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 29) = "BiABKAkaVQoIU2VxdWVuY2USEgoKcGNvX2lkX251bRgBIAEoDRIMCgRuYW1l";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 30) = "GAIgASgJEhMKC2dyb3VwX25hbWVzGAMgAygJEhIKCnBjb19pZF9zdHIYBCAB";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 31) = "KAkidQoMUGxhbkl0ZW1UeXBlEhcKE1BMQU5fSVRFTV9UWVBFX0lURU0QABIX";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 32) = "ChNQTEFOX0lURU1fVFlQRV9TT05HEAESGAoUUExBTl9JVEVNX1RZUEVfTUVE";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 33) = "SUEQAhIZChVQTEFOX0lURU1fVFlQRV9IRUFERVIQA0I0+AEBqgIkUHJvLlNl";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 34) = "cmlhbGl6YXRpb25JbnRlcm9wLlJWUHJvdG9EYXRhugIHUlZEYXRhX2IGcHJv";
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray36<string>, string>(ref buffer, 35) = "dG8z";
		descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String(string.Concat(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray36<string>, string>(in buffer, 36))), new FileDescriptor[4]
		{
			CustomOptionsReflection.Descriptor,
			PresentationReflection.Descriptor,
			RvtimestampReflection.Descriptor,
			UrlReflection.Descriptor
		}, new GeneratedClrTypeInfo(null, null, new GeneratedClrTypeInfo[1]
		{
			new GeneratedClrTypeInfo(typeof(PlanningCenterPlan), PlanningCenterPlan.Parser, new string[10] { "PlanIdNum", "ParentIdNum", "SeriesTitle", "PlanTitle", "DateList", "CreatedDate", "UpdateDate", "LastUpdateCheckDate", "PlanIdStr", "ParentIdStr" }, null, null, null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(PlanningCenterPlan.Types.PlanItem), PlanningCenterPlan.Types.PlanItem.Parser, new string[11]
				{
					"ItemType", "PcoIdNum", "ServiceIdNum", "ParentIdNum", "Name", "Attachments", "UpdateDate", "LinkedSong", "PcoIdStr", "ServiceIdStr",
					"ParentIdStr"
				}, null, new Type[1] { typeof(PlanningCenterPlan.Types.PlanItem.Types.PlanItemType) }, null, new GeneratedClrTypeInfo[2]
				{
					new GeneratedClrTypeInfo(typeof(PlanningCenterPlan.Types.PlanItem.Types.Attachment), PlanningCenterPlan.Types.PlanItem.Types.Attachment.Parser, new string[8] { "Name", "Url", "CreatedDate", "LinkedPath", "PcoIdNum", "NeedsUpdate", "UpdateDate", "PcoIdStr" }, null, null, null, null),
					new GeneratedClrTypeInfo(typeof(PlanningCenterPlan.Types.PlanItem.Types.SongItem), PlanningCenterPlan.Types.PlanItem.Types.SongItem.Parser, new string[6] { "PcoIdNum", "ArrangementIdNum", "Ccli", "Sequence", "PcoIdStr", "ArrangementIdStr" }, null, null, null, new GeneratedClrTypeInfo[1]
					{
						new GeneratedClrTypeInfo(typeof(PlanningCenterPlan.Types.PlanItem.Types.SongItem.Types.Sequence), PlanningCenterPlan.Types.PlanItem.Types.SongItem.Types.Sequence.Parser, new string[4] { "PcoIdNum", "Name", "GroupNames", "PcoIdStr" }, null, null, null, null)
					})
				})
			})
		}));
	}
}
