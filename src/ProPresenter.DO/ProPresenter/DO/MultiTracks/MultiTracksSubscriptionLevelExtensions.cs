using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.MultiTracks;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(MultiTracksSubscriptionLevel), typeof(Pro.SerializationInterop.RVProtoData.Presentation.Types.MultiTracksLicensing.Types.Subscription), DestinationToSourceMethodName = "ToMultiTracksSubscriptionLevel", SourceToDestinationMethodName = "ToProtoSubcription", DestinationDefaultValue = "ChartPro", SourceDefaultValue = "ChartPro", ExcludeSourceNames = new string[] { "Unknown", "Disabled" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(MultiTracksSubscriptionLevel), typeof(IPresentation.Types.IMultiTracksLicensing.Types.Subscription), DestinationToSourceMethodName = "ToMultiTracksSubscriptionLevel", SourceToDestinationMethodName = "ToEntitySubscription", DestinationDefaultValue = "ChartPro", SourceDefaultValue = "ChartPro", ExcludeSourceNames = new string[] { "Unknown", "Disabled" })]
public static class MultiTracksSubscriptionLevelExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Presentation.Types.MultiTracksLicensing.Types.Subscription ToProtoSubcription(this MultiTracksSubscriptionLevel source)
	{
		return source switch
		{
			MultiTracksSubscriptionLevel.ChartPro => Pro.SerializationInterop.RVProtoData.Presentation.Types.MultiTracksLicensing.Types.Subscription.ChartPro, 
			MultiTracksSubscriptionLevel.SlidePro => Pro.SerializationInterop.RVProtoData.Presentation.Types.MultiTracksLicensing.Types.Subscription.SlidePro, 
			_ => Pro.SerializationInterop.RVProtoData.Presentation.Types.MultiTracksLicensing.Types.Subscription.ChartPro, 
		};
	}

	public static MultiTracksSubscriptionLevel ToMultiTracksSubscriptionLevel(this Pro.SerializationInterop.RVProtoData.Presentation.Types.MultiTracksLicensing.Types.Subscription source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Presentation.Types.MultiTracksLicensing.Types.Subscription.ChartPro => MultiTracksSubscriptionLevel.ChartPro, 
			Pro.SerializationInterop.RVProtoData.Presentation.Types.MultiTracksLicensing.Types.Subscription.SlidePro => MultiTracksSubscriptionLevel.SlidePro, 
			_ => MultiTracksSubscriptionLevel.ChartPro, 
		};
	}

	public static IPresentation.Types.IMultiTracksLicensing.Types.Subscription ToEntitySubscription(this MultiTracksSubscriptionLevel source)
	{
		return source switch
		{
			MultiTracksSubscriptionLevel.ChartPro => IPresentation.Types.IMultiTracksLicensing.Types.Subscription.ChartPro, 
			MultiTracksSubscriptionLevel.SlidePro => IPresentation.Types.IMultiTracksLicensing.Types.Subscription.SlidePro, 
			_ => IPresentation.Types.IMultiTracksLicensing.Types.Subscription.ChartPro, 
		};
	}

	public static MultiTracksSubscriptionLevel ToMultiTracksSubscriptionLevel(this IPresentation.Types.IMultiTracksLicensing.Types.Subscription source)
	{
		return source switch
		{
			IPresentation.Types.IMultiTracksLicensing.Types.Subscription.ChartPro => MultiTracksSubscriptionLevel.ChartPro, 
			IPresentation.Types.IMultiTracksLicensing.Types.Subscription.SlidePro => MultiTracksSubscriptionLevel.SlidePro, 
			_ => MultiTracksSubscriptionLevel.ChartPro, 
		};
	}
}
