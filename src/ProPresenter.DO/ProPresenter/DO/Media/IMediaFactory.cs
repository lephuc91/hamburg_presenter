using System;
using Pro.Entity;

namespace ProPresenter.DO.Media;

public interface IMediaFactory
{
	FileMediaBase CreateMedia(string file, string containerId, Guid? overrideId = null);

	MediaBase? CreateMedia(IMedia mediaEntity, string containerId, Guid? overrideId = null);

	FileMediaBase CreateEmptyFileMedia(string file, string containerId, Guid? overrideId = null);

	AudioMedia CreateAudioMedia(string containerId, Guid? overrideId = null);

	VisualMedia CreateVisualMedia(string containerId, Guid? overrideId = null);

	VideoMedia CreateVideoMedia(string containerId, Guid? overrideId = null);

	WebMedia CreateWebMedia();

	LiveVideoMedia CreateLiveVideoMedia();
}
