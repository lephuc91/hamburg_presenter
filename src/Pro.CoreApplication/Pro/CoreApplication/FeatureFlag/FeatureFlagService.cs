using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Pro.Common.Logging;
using Pro.CoreApplication.CoreInteraction;
using Pro.CoreApplication.FeatureFlag.CoreInteraction;
using Pro.SerializationInterop.RVProtoData.FeatureFlags;

namespace Pro.CoreApplication.FeatureFlag;

public class FeatureFlagService : IFeatureFlagService
{
	private sealed record StartUpProperties(IObservable<IReadOnlyList<(string Flag, bool Enabled)>> FlagsObservable);

	public IObservable<IReadOnlyList<(string Flag, bool Enabled)>> WhenServerSideFlagsChange { get; }

	public FeatureFlagService(ICoreApplication coreApplication, ILogger logger)
	{
		Task<StartUpProperties> task = StartupAsync(coreApplication, logger);
		WhenServerSideFlagsChange = (from startupProperties in task.ToObservable()
			select startupProperties?.FlagsObservable ?? Observable.Empty<IReadOnlyList<(string, bool)>>()).Switch();
	}

	private static async Task<StartUpProperties?> StartupAsync(ICoreApplication coreApplication, ILogger logger)
	{
		ServiceResult<ICoreFeatureFlagService> serviceResult = await coreApplication.GetFeatureFlagServiceAsync();
		if (!serviceResult.IsSuccess)
		{
			logger.Error("[{1}] Failed to get Feature Flag Service: {0}", serviceResult.Error, "FeatureFlagService");
			return null;
		}
		return new StartUpProperties(serviceResult.Instance.Subscribe(logger).WhenServerFlagsChanged.Select((AllFlags flags) => flags.Flags.Select((Flag f) => (Flag: f.Name, Enabled: f.Enabled)).ToArray()));
	}
}
