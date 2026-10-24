using System;
using System.Collections.Generic;
using Pro.Common.Collections;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Slide.Links;

internal static class VisibilityConditionFactory
{
	public static ILinkedVisibilityObject? GenerateLinkedVisibilityObject(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition protoCondition, IEnumerable<SlideElementBase> otherElements)
	{
		switch (protoCondition.ConditionTypeCase)
		{
		case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.ConditionTypeOneofCase.ElementVisibility:
		{
			SlideElementBase slideElementBase = otherElements.FirstOrDefaultBy((SlideElementBase e) => e.ID == protoCondition.ElementVisibility.OtherElementUuid.ToGuid(), (SlideElementBase e) => e.Name.Equals(protoCondition.ElementVisibility.OtherElementName));
			if (slideElementBase != null)
			{
				return ElementLinkedVisibilityObject.Deserialize(protoCondition.ElementVisibility, slideElementBase);
			}
			return null;
		}
		case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.ConditionTypeOneofCase.TimerVisibility:
			return TimerLinkedVisibilityObject.Deserialize(protoCondition.TimerVisibility, () => DataVault.TimerDocument?.Timers);
		case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.ConditionTypeOneofCase.VideoCountdownVisibility:
			return VideoCountdownLinkedVisibilityObject.Deserialize(protoCondition.VideoCountdownVisibility);
		case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.ConditionTypeOneofCase.AudioCountdownVisibility:
			return AudioCountdownLinkedVisibilityObject.Deserialize(protoCondition.AudioCountdownVisibility);
		case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.ConditionTypeOneofCase.CaptureSessionVisibility:
			return CaptureSessionLinkedVisibilityObject.Deserialize(protoCondition.CaptureSessionVisibility);
		case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.ConditionTypeOneofCase.VideoInputVisibility:
			return VideoInputLinkedVisibilityObject.Deserialize(protoCondition.VideoInputVisibility);
		case Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.ConditionTypeOneofCase.None:
			return null;
		default:
			throw new NotSupportedException();
		}
	}
}
