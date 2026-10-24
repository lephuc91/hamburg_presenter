using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.FeatureFlag;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.DO.Settings;

namespace ProPresenter.FeatureFlag;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_serverSideFlagChangeSubscription" })]
public class FeatureFlagService : IFlagService, IDisposable
{
	private const Flag MASTER_FLAG = Flag.ServerDrivenFeatureFlags;

	private const string COMMAND_LINE_DISABLED_PREFIX = "--disabled-flag=";

	private const string COMMAND_LINE_ENABLED_PREFIX = "--enabled-flag=";

	private readonly bool _isMasterFlagEnabled;

	private readonly IApp _appSettings;

	private IDisposable? _serverSideFlagChangeSubscription;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IEnumerable<Flag> AllFlags => Enum.GetValues<Flag>();

	public IReadOnlyList<string> LaunchEnabledKeys { get; }

	public FeatureFlagService(IApp appSettings, string[] args)
	{
		_appSettings = appSettings;
		_isMasterFlagEnabled = IsMasterFlagEnabled(appSettings, args);
		IEnumerable<string> first = from f in Enum.GetValues<Flag>()
			where f.GetDefaultValue()
			select f.GetSerializationKey();
		if (_isMasterFlagEnabled)
		{
			first = first.Concat(_appSettings.ServerEnabledFlags ?? Array.Empty<string>()).Except(_appSettings.ServerDisabledFlags ?? Array.Empty<string>());
		}
		first = first.Concat(_appSettings.EnabledFeatureFlags).Except(_appSettings.DisabledFeatureFlags);
		LaunchEnabledKeys = first.Concat(from a in args
			where a.StartsWith("--enabled-flag=")
			select a.Substring("--enabled-flag=".Length)).Except(from a in args
			where a.StartsWith("--disabled-flag=")
			select a.Substring("--disabled-flag=".Length)).GetEnabledKeys();
	}

	public bool IsFlagEnabled(Flag flag)
	{
		return LaunchEnabledKeys.Contains(flag.GetSerializationKey());
	}

	public void SetServerSideFeatureFlagObservable(IObservable<IReadOnlyList<(string Flag, bool Enabled)>> whenServerSideFlagsChange)
	{
		if (_serverSideFlagChangeSubscription != null)
		{
			throw new InvalidOperationException("ServerSideFeatureFlagObservable should never be set more than once");
		}
		_serverSideFlagChangeSubscription = whenServerSideFlagsChange.Subscribe(delegate(IReadOnlyList<(string Flag, bool Enabled)> flags)
		{
			string[] array = (from f in flags
				where f.Enabled
				select f.Flag).ToArray();
			string[] array2 = (from f in flags
				where !f.Enabled
				select f.Flag).ToArray();
			_appSettings.ServerEnabledFlags = ((_appSettings.ServerEnabledFlags == null) ? array : _appSettings.ServerEnabledFlags.Concat(array).Except(array2).Distinct()
				.ToArray());
			_appSettings.ServerDisabledFlags = ((_appSettings.ServerDisabledFlags == null) ? array2 : _appSettings.ServerDisabledFlags.Concat(array2).Except(array).Distinct()
				.ToArray());
			NotifyFlagChange(from flag in Enum.GetValues<Flag>()
				where flags.Any(((string Flag, bool Enabled) f) => f.Flag == flag.GetSerializationKey())
				select flag);
		});
	}

	private static void NotifyFlagChange([ParamCollection] IEnumerable<Flag> flags)
	{
	}

	private static bool IsMasterFlagEnabled(IApp appSettings, string[] args)
	{
		if (args.Contains("--disabled-flag=" + Flag.ServerDrivenFeatureFlags.GetSerializationKey()))
		{
			return false;
		}
		if (args.Contains("--enabled-flag=" + Flag.ServerDrivenFeatureFlags.GetSerializationKey()))
		{
			return true;
		}
		if (appSettings.EnabledFeatureFlags.Contains(Flag.ServerDrivenFeatureFlags.GetSerializationKey()))
		{
			return true;
		}
		if (appSettings.DisabledFeatureFlags.Contains(Flag.ServerDrivenFeatureFlags.GetSerializationKey()))
		{
			return false;
		}
		return Flag.ServerDrivenFeatureFlags.GetDefaultValue();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_serverSideFlagChangeSubscription?.Dispose();
		}
	}
}
