using System;
using System.Collections.Generic;
using Pro.Common.Background;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.DO.Audio;
using Pro.DO.Effects.Descriptions;
using Pro.DO.Storage;
using Pro.Entity;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media.Properties.File;
using ProPresenter.DO.Media.Services;

namespace ProPresenter.DO.Media;

public class MediaFactory : IMediaFactory
{
	private readonly IMetadataLoader _metadataLoader;

	private readonly IAsyncExecutor _executor;

	private readonly ITrackedMediaHelpers _mediaHelpers;

	private readonly IRemoteFileLoader _remoteFileLoader;

	private readonly ILiveVideoInputCollection _liveVideoInputs;

	private readonly IAudioSetup _audioSetup;

	private readonly IReadOnlyList<EffectDescription> _availableEffects;

	private readonly IFlagService _flagService;

	public MediaFactory(IMetadataLoader metadataLoader, IAsyncExecutor executor, ITrackedMediaHelpers mediaHelpers, IRemoteFileLoader remoteFileLoader, ILiveVideoInputCollection liveVideoInputs, IAudioSetup audioSetup, IReadOnlyList<EffectDescription> availableEffects, IFlagService flagService)
	{
		_metadataLoader = metadataLoader;
		_executor = executor;
		_mediaHelpers = mediaHelpers;
		_remoteFileLoader = remoteFileLoader;
		_liveVideoInputs = liveVideoInputs;
		_audioSetup = audioSetup;
		_availableEffects = availableEffects;
		_flagService = flagService;
	}

	public FileMediaBase CreateMedia(string file, string containerId, Guid? overrideId = null)
	{
		if (file.IsImageFile())
		{
			return new VisualMedia(_metadataLoader, _remoteFileLoader, _executor, _mediaHelpers, _flagService, _availableEffects, containerId, (RelativePath)file, overrideId);
		}
		if (file.IsVideoFile())
		{
			return new VideoMedia(_metadataLoader, _remoteFileLoader, _executor, _mediaHelpers, _flagService, _audioSetup, _availableEffects, containerId, (RelativePath)file, overrideId);
		}
		if (file.IsAudioFile())
		{
			return new AudioMedia(_metadataLoader, _executor, _mediaHelpers, _flagService, _audioSetup, containerId, (RelativePath)file, overrideId);
		}
		throw new NotSupportedException("Media file not supported");
	}

	public MediaBase? CreateMedia(IMedia mediaEntity, string containerId, Guid? overrideId = null)
	{
		MediaBase result = null;
		IMedia.Types.ITypeProperties value = mediaEntity.TypeProperties.Value;
		if (!(value is IMedia.Types.ITypeProperties.IAudio))
		{
			if (!(value is IMedia.Types.ITypeProperties.IImage))
			{
				if (!(value is IMedia.Types.ITypeProperties.IVideo))
				{
					if (value is IMedia.Types.ITypeProperties.ILiveVideo)
					{
						result = CreateLiveVideoMedia();
					}
				}
				else
				{
					result = CreateVideoMedia(containerId, overrideId);
				}
			}
			else
			{
				result = CreateVisualMedia(containerId, overrideId);
			}
		}
		else
		{
			result = CreateAudioMedia(containerId, overrideId);
		}
		return result;
	}

	public FileMediaBase CreateEmptyFileMedia(string file, string containerId, Guid? overrideId = null)
	{
		if (file.IsImageFile())
		{
			return new VisualMedia(_metadataLoader, _remoteFileLoader, _executor, _mediaHelpers, _flagService, _availableEffects, containerId, null, overrideId);
		}
		if (file.IsVideoFile())
		{
			return new VideoMedia(_metadataLoader, _remoteFileLoader, _executor, _mediaHelpers, _flagService, _audioSetup, _availableEffects, containerId, null, overrideId);
		}
		if (file.IsAudioFile())
		{
			return new AudioMedia(_metadataLoader, _executor, _mediaHelpers, _flagService, _audioSetup, containerId, null, overrideId);
		}
		throw new NotSupportedException("Media file not supported");
	}

	public AudioMedia CreateAudioMedia(string containerId, Guid? overrideId = null)
	{
		return new AudioMedia(_metadataLoader, _executor, _mediaHelpers, _flagService, _audioSetup, containerId, null, overrideId);
	}

	public VisualMedia CreateVisualMedia(string containerId, Guid? overrideId = null)
	{
		return new VisualMedia(_metadataLoader, _remoteFileLoader, _executor, _mediaHelpers, _flagService, _availableEffects, containerId, null, overrideId);
	}

	public VideoMedia CreateVideoMedia(string containerId, Guid? overrideId = null)
	{
		return new VideoMedia(_metadataLoader, _remoteFileLoader, _executor, _mediaHelpers, _flagService, _audioSetup, _availableEffects, containerId, null, overrideId);
	}

	public WebMedia CreateWebMedia()
	{
		return new WebMedia();
	}

	public LiveVideoMedia CreateLiveVideoMedia()
	{
		return new LiveVideoMedia(_liveVideoInputs, _audioSetup, _availableEffects);
	}
}
