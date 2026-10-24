using System;
using System.Collections.Generic;

namespace Pro.Common.FeatureFlag;

public interface IFlagService
{
	IEnumerable<Flag> AllFlags { get; }

	IReadOnlyList<string> LaunchEnabledKeys { get; }

	bool IsFlagEnabled(Flag flag);

	void SetServerSideFeatureFlagObservable(IObservable<IReadOnlyList<(string Flag, bool Enabled)>> whenServerSideFlagsChange);
}
