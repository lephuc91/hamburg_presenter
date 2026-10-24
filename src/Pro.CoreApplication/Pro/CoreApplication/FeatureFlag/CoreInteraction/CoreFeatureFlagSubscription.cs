using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using CoreApplication.FeatureFlags;
using Pro.Common.Logging;
using Pro.SerializationInterop.RVProtoData.FeatureFlags;

namespace Pro.CoreApplication.FeatureFlag.CoreInteraction;

public class CoreFeatureFlagSubscription : CoreFeatureFlagsServiceSubscriber, ICoreFeatureFlagSubscription, IAsyncDisposable
{
	private readonly TaskCompletionSource _completion = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

	private readonly ReplaySubject<AllFlags> _featureFlagChengeSubject = new ReplaySubject<AllFlags>(1);

	private readonly ILogger _logger;

	public IObservable<AllFlags> WhenServerFlagsChanged => _featureFlagChengeSubject;

	public CoreFeatureFlagSubscription(nint instancePointer, ILogger logger)
		: base(instancePointer)
	{
		_logger = logger;
	}

	public async ValueTask DisposeAsync()
	{
		if (!_completion.Task.IsCompleted)
		{
			CoreUnsubscribe();
		}
		await _completion.Task;
		Cleanup();
		_featureFlagChengeSubject.Dispose();
	}

	public override void NativeCallback(nint instancePointer)
	{
		_logger.Error(new FeatureFlagApplicationException(instancePointer));
	}

	public override void NativeCallback(byte[] protoData)
	{
		try
		{
			Notification notification = Notification.Parser.ParseFrom(protoData);
			switch (notification.NotificationCase)
			{
			case Notification.NotificationOneofCase.AllFlags:
				_featureFlagChengeSubject.OnNext(notification.AllFlags);
				break;
			case Notification.NotificationOneofCase.UnsubscribeComplete:
				_completion.SetResult();
				break;
			}
		}
		catch (Exception ex)
		{
			_logger.Error(ex);
		}
	}

	public override void NativeErrorCallback()
	{
		_logger.Error(new FeatureFlagApplicationException());
	}
}
