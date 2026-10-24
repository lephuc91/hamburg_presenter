using System;
using System.Threading.Tasks;
using Pro.Common.Concurrency;
using Pro.Common.Logging;
using Pro.CoreApplication.Workspace;
using ProPresenter.DO.Analytics.Events.TrackedEvents.Workspace;

namespace ProPresenter.DO.CloudOnboarding;

public sealed class CloudConversionService : ICloudConversionService
{
	private readonly ICloudWorkspaceService _cloudWorkspaceService;

	private readonly ILogger _logger;

	private readonly IWorkspaceAnalyticsEventPublisher _workspaceAnalytics;

	private readonly IStopwatchFactory _stopwatchFactory;

	public CloudConversionService(ICloudWorkspaceService cloudWorkspaceService, ILogger logger, IWorkspaceAnalyticsEventPublisher workspaceAnalytics, IStopwatchFactory stopwatchFactory)
	{
		_cloudWorkspaceService = cloudWorkspaceService;
		_logger = logger;
		_workspaceAnalytics = workspaceAnalytics;
		_stopwatchFactory = stopwatchFactory;
	}

	public async Task<Guid?> ConvertToCloudAsync(WorkspaceIssueFlags workspaceIssues)
	{
		IStopwatch stopwatch = _stopwatchFactory.Create();
		stopwatch.Restart();
		try
		{
			Guid guid = await _cloudWorkspaceService.PublishAsync();
			if (guid == Guid.Empty)
			{
				return null;
			}
			_workspaceAnalytics.WorkspaceCreation(WorkspaceCreationSource.CloudOnboarding, stopwatch.Elapsed);
			return guid;
		}
		catch (Exception value)
		{
			_logger?.Error($"Failed to convert workspace to cloud: {value}");
			return null;
		}
	}
}
