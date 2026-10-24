using System;
using System.Reactive.Linq;
using Pro.Common.ErrorReporting;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Entity.Merged.Collections;
using Pro.Entity.Merged.Entities;

namespace Pro.Entity.Merged.Factory;

public class MergedEntityFactory(IEntityFactory entityFactory, IErrorReporter errorReporter) : IMergedEntityFactory
{
	public IMergedCollection<IMergedAudioInput> CreateAudioInputCollection(IComplexCollection<ICloudAudioInput> remoteAudioInputs, IComplexCollection<IAudioInput> localAudioInputs)
	{
		return new MergedCollection<ICloudAudioInput, IAudioInput, IMergedAudioInput>(remoteAudioInputs, localAudioInputs, (ICloudAudioInput remote, IAudioInput local) => new MergedAudioInput(remote, local), (ICloudAudioInput remote, IAudioInput local) => remote.Uuid.Value == local.Uuid.Value, delegate(ICloudAudioInput remote)
		{
			IAudioInput audioInput = entityFactory.Create<IAudioInput>();
			audioInput.Uuid.Set(remote.Uuid.Value);
			return audioInput;
		}, delegate(IAudioInput local)
		{
			ICloudAudioInput cloudAudioInput = entityFactory.Create<ICloudAudioInput>();
			cloudAudioInput.Uuid.Set(local.Uuid.Value);
			return cloudAudioInput;
		}, InitializeSync, (IMergedAudioInput m) => m.Remote, (IMergedAudioInput m) => m.Local);
	}

	public IMergedAudioInput CreateMergedAudioInput(Guid id)
	{
		ICloudAudioInput cloudAudioInput = entityFactory.Create<ICloudAudioInput>();
		cloudAudioInput.Uuid.Set(id);
		IAudioInput audioInput = entityFactory.Create<IAudioInput>();
		audioInput.Uuid.Set(id);
		InitializeSync(cloudAudioInput, audioInput, SyncDirection.RemoteToLocal);
		return new MergedAudioInput(cloudAudioInput, audioInput);
	}

	private void InitializeSync(ICloudAudioInput remote, IAudioInput local, SyncDirection syncDirection)
	{
		switch (syncDirection)
		{
		case SyncDirection.LocalToRemote:
			initializeLocalToRemote();
			initializeRemoteToLocal();
			break;
		case SyncDirection.RemoteToLocal:
			initializeRemoteToLocal();
			initializeLocalToRemote();
			break;
		default:
			throw new ArgumentOutOfRangeException("syncDirection", syncDirection, null);
		}
		void initializeLocalToRemote()
		{
			local.RegisterLinkedDisposable(local.Uuid.WhenValueChanges.Skip(1).Subscribe(delegate
			{
				errorReporter.Error("Local audio input changed UUID value. This indicates a problem");
			}));
			local.RegisterLinkedDisposable(local.UserDescription.WhenValueChanges.DistinctUntilChanged().Subscribe(delegate(string v)
			{
				remote.UserDescription.Set(v);
			}));
		}
		void initializeRemoteToLocal()
		{
			remote.RegisterLinkedDisposable(remote.Uuid.WhenValueChanges.Skip(1).Subscribe(delegate
			{
				errorReporter.Error("Remote audio input changed UUID value. This indicates a problem");
			}));
			remote.RegisterLinkedDisposable(remote.UserDescription.WhenValueChanges.DistinctUntilChanged().Subscribe(delegate(string v)
			{
				local.UserDescription.Set(v);
			}));
		}
	}

	public IMergedCollection<IMergedMessage> CreateMessageCollection(IComplexCollection<IMessage> remoteMessages, IComplexCollection<ILocalMessage> localMessages)
	{
		return new MergedCollection<IMessage, ILocalMessage, IMergedMessage>(remoteMessages, localMessages, (IMessage remote, ILocalMessage local) => new MergedMessage(remote, local), (IMessage remote, ILocalMessage local) => remote.Uuid.Value == local.Uuid.Value, delegate(IMessage remote)
		{
			ILocalMessage localMessage = entityFactory.Create<ILocalMessage>();
			localMessage.Uuid.Set(remote.Uuid.Value);
			return localMessage;
		}, delegate(ILocalMessage local)
		{
			IMessage message = entityFactory.Create<IMessage>();
			message.Uuid.Set(local.Uuid.Value);
			return message;
		}, InitializeSync, (IMergedMessage m) => m.Remote, (IMergedMessage m) => m.Local);
	}

	public IMergedMessage CreateMergedMessage(Guid id)
	{
		IMessage message = entityFactory.Create<IMessage>();
		message.Uuid.Set(id);
		ILocalMessage localMessage = entityFactory.Create<ILocalMessage>();
		localMessage.Uuid.Set(id);
		InitializeSync(message, localMessage, SyncDirection.RemoteToLocal);
		return new MergedMessage(message, localMessage);
	}

	private void InitializeSync(IMessage remote, ILocalMessage local, SyncDirection _)
	{
		remote.RegisterLinkedDisposable(remote.Uuid.WhenValueChanges.Skip(1).Subscribe(delegate
		{
			errorReporter.Error("Remote message changed UUID value. This indicates a problem");
		}));
		local.RegisterLinkedDisposable(local.Uuid.WhenValueChanges.Skip(1).Subscribe(delegate
		{
			errorReporter.Error("Local message changed UUID value. This indicates a problem");
		}));
	}

	public IMergedCollection<IMergedScreen> CreateScreenCollection(IComplexCollection<ICloudProPresenterScreen> remoteScreens, IComplexCollection<IProPresenterScreen> localScreens)
	{
		return new MergedCollection<ICloudProPresenterScreen, IProPresenterScreen, IMergedScreen>(remoteScreens, localScreens, (ICloudProPresenterScreen remote, IProPresenterScreen local) => new MergedScreen(remote, local), (ICloudProPresenterScreen remote, IProPresenterScreen local) => remote.Uuid.Value == local.Uuid.Value, delegate(ICloudProPresenterScreen remote)
		{
			IProPresenterScreen proPresenterScreen = entityFactory.Create<IProPresenterScreen>();
			proPresenterScreen.Uuid.Set(remote.Uuid.Value);
			proPresenterScreen.Name.Set(remote.Name.Value);
			proPresenterScreen.ScreenType.Set(remote.ScreenType.Value);
			return proPresenterScreen;
		}, delegate(IProPresenterScreen local)
		{
			ICloudProPresenterScreen cloudProPresenterScreen = entityFactory.Create<ICloudProPresenterScreen>();
			cloudProPresenterScreen.Uuid.Set(local.Uuid.Value);
			cloudProPresenterScreen.Name.Set(local.Name.Value);
			cloudProPresenterScreen.ScreenType.Set(local.ScreenType.Value);
			return cloudProPresenterScreen;
		}, InitializeSync, (IMergedScreen m) => m.Remote, (IMergedScreen m) => m.Local);
	}

	public IMergedScreen CreateMergedScreen(Guid id, IProPresenterScreen.Types.ScreenType screenType)
	{
		ICloudProPresenterScreen cloudProPresenterScreen = entityFactory.Create<ICloudProPresenterScreen>();
		cloudProPresenterScreen.Uuid.Set(id);
		cloudProPresenterScreen.ScreenType.Set(screenType);
		IProPresenterScreen proPresenterScreen = entityFactory.Create<IProPresenterScreen>();
		proPresenterScreen.Uuid.Set(id);
		proPresenterScreen.ScreenType.Set(screenType);
		InitializeSync(cloudProPresenterScreen, proPresenterScreen, SyncDirection.RemoteToLocal);
		return new MergedScreen(cloudProPresenterScreen, proPresenterScreen);
	}

	private void InitializeSync(ICloudProPresenterScreen remote, IProPresenterScreen local, SyncDirection syncDirection)
	{
		switch (syncDirection)
		{
		case SyncDirection.LocalToRemote:
			initializeLocalToRemote();
			initializeRemoteToLocal();
			break;
		case SyncDirection.RemoteToLocal:
			initializeRemoteToLocal();
			initializeLocalToRemote();
			break;
		default:
			throw new ArgumentOutOfRangeException("syncDirection", syncDirection, null);
		}
		void initializeLocalToRemote()
		{
			local.RegisterLinkedDisposable(local.Name.WhenValueChanges.DistinctUntilChanged().Subscribe(delegate(string v)
			{
				remote.Name.Set(v);
			}));
			local.RegisterLinkedDisposable(local.Uuid.WhenValueChanges.Skip(1).Subscribe(delegate
			{
				errorReporter.Error("Local screen changed UUID value. This indicates a problem");
			}));
			local.RegisterLinkedDisposable(local.ScreenType.WhenValueChanges.Skip(1).Subscribe(delegate
			{
				errorReporter.Error("Local screen changed ScreenType value. This indicates a problem");
			}));
		}
		void initializeRemoteToLocal()
		{
			remote.RegisterLinkedDisposable(remote.Name.WhenValueChanges.DistinctUntilChanged().Subscribe(delegate(string v)
			{
				local.Name.Set(v);
			}));
			remote.RegisterLinkedDisposable(remote.Uuid.WhenValueChanges.Skip(1).Subscribe(delegate
			{
				errorReporter.Error("Remote screen changed UUID value. This indicates a problem");
			}));
			remote.RegisterLinkedDisposable(remote.ScreenType.WhenValueChanges.Skip(1).Subscribe(delegate
			{
				errorReporter.Error("Remote screen changed ScreenType value. This indicates a problem");
			}));
		}
	}

	public IMergedCollection<IMergedTimer> CreateTimerCollection(IComplexCollection<ITimer> remoteTimers, IComplexCollection<ILocalTimer> localTimers)
	{
		return new MergedCollection<ITimer, ILocalTimer, IMergedTimer>(remoteTimers, localTimers, (ITimer remoteTimer, ILocalTimer localTimer) => new MergedTimer(remoteTimer, localTimer), (ITimer remoteTimer, ILocalTimer localTimer) => remoteTimer.Uuid.Value == localTimer.Uuid.Value, delegate(ITimer remote)
		{
			ILocalTimer localTimer2 = entityFactory.Create<ILocalTimer>();
			localTimer2.Uuid.Set(remote.Uuid.Value);
			return localTimer2;
		}, delegate(ILocalTimer local)
		{
			ITimer timer = entityFactory.Create<ITimer>();
			timer.Uuid.Set(local.Uuid.Value);
			return timer;
		}, InitializeSync, (IMergedTimer m) => m.Remote, (IMergedTimer m) => m.Local);
	}

	public IMergedTimer CreateMergedTimer(Guid id)
	{
		ITimer timer = entityFactory.Create<ITimer>();
		timer.Uuid.Set(id);
		ILocalTimer localTimer = entityFactory.Create<ILocalTimer>();
		localTimer.Uuid.Set(id);
		InitializeSync(timer, localTimer, SyncDirection.RemoteToLocal);
		return new MergedTimer(timer, localTimer);
	}

	private void InitializeSync(ITimer remote, ILocalTimer local, SyncDirection _)
	{
		remote.RegisterLinkedDisposable(remote.Uuid.WhenValueChanges.Skip(1).Subscribe(delegate
		{
			errorReporter.Error("Remote timer changed UUID value. This indicates a problem");
		}));
		local.RegisterLinkedDisposable(local.Uuid.WhenValueChanges.Skip(1).Subscribe(delegate
		{
			errorReporter.Error("Local timer changed UUID value. This indicates a problem");
		}));
	}

	public IMergedCollection<IMergedVideoInput> CreateVideoInputCollection(IComplexCollection<ICloudVideoInput> remoteVideoInputs, IComplexCollection<IVideoInput> localVideoInputs)
	{
		return new MergedCollection<ICloudVideoInput, IVideoInput, IMergedVideoInput>(remoteVideoInputs, localVideoInputs, (ICloudVideoInput remote, IVideoInput local) => new MergedVideoInput(remote, local), (ICloudVideoInput remote, IVideoInput local) => remote.Uuid.Value == local.Uuid.Value, delegate(ICloudVideoInput remote)
		{
			IVideoInput videoInput = entityFactory.Create<IVideoInput>();
			videoInput.Uuid.Set(remote.Uuid.Value);
			return videoInput;
		}, delegate(IVideoInput local)
		{
			ICloudVideoInput cloudVideoInput = entityFactory.Create<ICloudVideoInput>();
			cloudVideoInput.Uuid.Set(local.Uuid.Value);
			return cloudVideoInput;
		}, InitializeSync, (IMergedVideoInput m) => m.Remote, (IMergedVideoInput m) => m.Local);
	}

	public IMergedVideoInput CreateMergedVideoInput(Guid id)
	{
		ICloudVideoInput cloudVideoInput = entityFactory.Create<ICloudVideoInput>();
		cloudVideoInput.Uuid.Set(id);
		IVideoInput videoInput = entityFactory.Create<IVideoInput>();
		videoInput.Uuid.Set(id);
		InitializeSync(cloudVideoInput, videoInput, SyncDirection.RemoteToLocal);
		return new MergedVideoInput(cloudVideoInput, videoInput);
	}

	private void InitializeSync(ICloudVideoInput remote, IVideoInput local, SyncDirection syncDirection)
	{
		switch (syncDirection)
		{
		case SyncDirection.LocalToRemote:
			initializeLocalToRemote();
			initializeRemoteToLocal();
			break;
		case SyncDirection.RemoteToLocal:
			initializeRemoteToLocal();
			initializeLocalToRemote();
			break;
		default:
			throw new ArgumentOutOfRangeException("syncDirection", syncDirection, null);
		}
		void initializeLocalToRemote()
		{
			local.RegisterLinkedDisposable(local.Uuid.WhenValueChanges.Skip(1).Subscribe(delegate
			{
				errorReporter.Error("Local video input changed UUID value. This indicates a problem");
			}));
			local.RegisterLinkedDisposable(local.UserDescription.WhenValueChanges.DistinctUntilChanged().Subscribe(delegate(string v)
			{
				remote.UserDescription.Set(v);
			}));
		}
		void initializeRemoteToLocal()
		{
			remote.RegisterLinkedDisposable(remote.Uuid.WhenValueChanges.Skip(1).Subscribe(delegate
			{
				errorReporter.Error("Remote video input changed UUID value. This indicates a problem");
			}));
			remote.RegisterLinkedDisposable(remote.UserDescription.WhenValueChanges.DistinctUntilChanged().Subscribe(delegate(string v)
			{
				local.UserDescription.Set(v);
			}));
		}
	}

	public IMergedProPresenterWorkspace CreateMergedProPresenterWorkspace(IProPresenterWorkspace remote, IProPresenterLocalWorkspace local)
	{
		return new MergedProPresenterWorkspace(remote, local, this);
	}
}
