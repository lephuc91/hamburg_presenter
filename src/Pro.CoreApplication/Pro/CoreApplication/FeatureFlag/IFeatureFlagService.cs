using System;
using System.Collections.Generic;

namespace Pro.CoreApplication.FeatureFlag;

public interface IFeatureFlagService
{
	IObservable<IReadOnlyList<(string Flag, bool Enabled)>> WhenServerSideFlagsChange { get; }
}
