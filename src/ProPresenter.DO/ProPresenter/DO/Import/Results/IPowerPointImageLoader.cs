using System;
using System.Collections.Generic;
using ProPresenter.DO.Media;
using ProPresenter.DO.PowerPoint;

namespace ProPresenter.DO.Import.Results;

public interface IPowerPointImageLoader
{
	void Load(IEnumerable<PowerPointSlideImportData> data, Action<MediaBase, PowerPointSlideImportData> onLoaded, Action onComplete, string containerId);
}
