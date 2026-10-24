using System;

namespace Pro.CoreApplication.Media;

public interface IEnableAnalyticsProvider
{
	bool EnableAnalytics { get; set; }

	IObservable<bool> WhenEnableAnalyticsChanged { get; }
}
