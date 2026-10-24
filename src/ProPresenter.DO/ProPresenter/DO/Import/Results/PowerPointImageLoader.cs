using System;
using System.Collections.Generic;
using System.IO;
using Pro.Common.Logging;
using Pro.DO.Storage;
using ProPresenter.DO.Media;
using ProPresenter.DO.PowerPoint;

namespace ProPresenter.DO.Import.Results;

public class PowerPointImageLoader : IPowerPointImageLoader
{
	private readonly IMediaFactory _mediaFactory;

	public PowerPointImageLoader(IMediaFactory mediaFactory)
	{
		_mediaFactory = mediaFactory;
	}

	public void Load(IEnumerable<PowerPointSlideImportData> data, Action<MediaBase, PowerPointSlideImportData> onLoaded, Action onComplete, string containerId)
	{
		Queue<PowerPointSlideImportData> queue = new Queue<PowerPointSlideImportData>(data);
		loadNext();
		void loadNext()
		{
			if (queue.Count == 0)
			{
				onComplete();
			}
			else
			{
				PowerPointSlideImportData datum = queue.Dequeue();
				RelativePath relativePath = CopyToMediaImport(datum.ImagePath);
				if (!relativePath.IsValid)
				{
					loadNext();
				}
				else
				{
					FileMediaBase fileMediaBase = _mediaFactory.CreateEmptyFileMedia(relativePath, containerId, null);
					Action<FileMediaBase> handler = null;
					handler = delegate(FileMediaBase m)
					{
						m.MetadataLoadSuccessful -= handler;
						onLoaded(m, datum);
						loadNext();
					};
					fileMediaBase.MetadataLoadSuccessful += handler;
					fileMediaBase.UpdateSource(userInitiated: true, relativePath);
				}
			}
		}
	}

	private static RelativePath CopyToMediaImport(string path)
	{
		try
		{
			string text = Path.Combine(CommonPaths.MediaImport, Guid.NewGuid().ToString() + Path.GetExtension(path));
			File.Copy(path, text);
			return (RelativePath)text;
		}
		catch (Exception ex)
		{
			Log.Warning("Failed to copy PowerPoint image to imports - " + ex.Message);
			return (RelativePath)path;
		}
	}
}
