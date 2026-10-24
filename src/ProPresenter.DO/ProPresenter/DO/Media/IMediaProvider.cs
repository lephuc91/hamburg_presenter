using System;
using System.Collections.Generic;

namespace ProPresenter.DO.Media;

public interface IMediaProvider
{
	void GetMedia(MediaBase currentMedia, Action<MediaBase?> mediaCallback);

	void GetMedia(string containerId, Action<MediaBase?> mediaCallback);

	void GetMedia(MediaBase currentMedia, IEnumerable<string>? files, Action<MediaBase> mediaCallback);

	void GetMedia(string containerId, IEnumerable<string>? files, Action<MediaBase> mediaCallback);
}
