using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(AudioCountdownVisibilityCriteria), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion), SourceToDestinationMethodName = "ToProtoAudioCountdownVisibilityCriterion", DestinationDefaultValue = "HasTimeRemaining", DestinationToSourceMethodName = "ToAudioCountdownVisibilityCriteria", SourceDefaultValue = "HasTimeRemaining", UnmatchedSourceNames = new string[] { "IsNotLooping", "IsLooping" }, UnmatchedDestinationNames = new string[] { "NotLooping", "Looping" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(AudioCountdownVisibilityCriteria), typeof(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion), SourceToDestinationMethodName = "ToEntityAudioCountdownVisibilityCriterion", DestinationDefaultValue = "HasTimeRemaining", DestinationToSourceMethodName = "ToAudioCountdownVisibilityCriteria", SourceDefaultValue = "HasTimeRemaining", UnmatchedSourceNames = new string[] { "IsNotLooping", "IsLooping" }, UnmatchedDestinationNames = new string[] { "NotLooping", "Looping" })]
public static class AudioCountdownVisibilityCriteriaExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion ToProtoAudioCountdownVisibilityCriterion(this AudioCountdownVisibilityCriteria source)
	{
		return source switch
		{
			AudioCountdownVisibilityCriteria.HasTimeRemaining => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.HasTimeRemaining, 
			AudioCountdownVisibilityCriteria.HasExpired => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.HasExpired, 
			AudioCountdownVisibilityCriteria.IsRunning => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.IsRunning, 
			AudioCountdownVisibilityCriteria.NotRunning => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.NotRunning, 
			AudioCountdownVisibilityCriteria.IsLooping => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.Looping, 
			AudioCountdownVisibilityCriteria.IsNotLooping => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.NotLooping, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.HasTimeRemaining, 
		};
	}

	public static AudioCountdownVisibilityCriteria ToAudioCountdownVisibilityCriteria(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.HasTimeRemaining => AudioCountdownVisibilityCriteria.HasTimeRemaining, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.HasExpired => AudioCountdownVisibilityCriteria.HasExpired, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.IsRunning => AudioCountdownVisibilityCriteria.IsRunning, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.NotRunning => AudioCountdownVisibilityCriteria.NotRunning, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.Looping => AudioCountdownVisibilityCriteria.IsLooping, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.NotLooping => AudioCountdownVisibilityCriteria.IsNotLooping, 
			_ => AudioCountdownVisibilityCriteria.HasTimeRemaining, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion ToEntityAudioCountdownVisibilityCriterion(this AudioCountdownVisibilityCriteria source)
	{
		return source switch
		{
			AudioCountdownVisibilityCriteria.HasTimeRemaining => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.HasTimeRemaining, 
			AudioCountdownVisibilityCriteria.HasExpired => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.HasExpired, 
			AudioCountdownVisibilityCriteria.IsRunning => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.IsRunning, 
			AudioCountdownVisibilityCriteria.NotRunning => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.NotRunning, 
			AudioCountdownVisibilityCriteria.IsLooping => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.Looping, 
			AudioCountdownVisibilityCriteria.IsNotLooping => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.NotLooping, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.HasTimeRemaining, 
		};
	}

	public static AudioCountdownVisibilityCriteria ToAudioCountdownVisibilityCriteria(this ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.HasTimeRemaining => AudioCountdownVisibilityCriteria.HasTimeRemaining, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.HasExpired => AudioCountdownVisibilityCriteria.HasExpired, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.IsRunning => AudioCountdownVisibilityCriteria.IsRunning, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.NotRunning => AudioCountdownVisibilityCriteria.NotRunning, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.Looping => AudioCountdownVisibilityCriteria.IsLooping, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility.Types.AudioCountdownVisibilityCriterion.NotLooping => AudioCountdownVisibilityCriteria.IsNotLooping, 
			_ => AudioCountdownVisibilityCriteria.HasTimeRemaining, 
		};
	}
}
