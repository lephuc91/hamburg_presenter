using System;
using Pro.SerializationInterop.RVProtoData.FeatureFlags;

namespace Pro.CoreApplication.FeatureFlag.CoreInteraction;

public interface ICoreFeatureFlagSubscription
{
	IObservable<AllFlags> WhenServerFlagsChanged { get; }
}
