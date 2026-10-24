using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.ProContent.Model.Format;

namespace ProPresenter.DO.ProContent.Model.Collection;

public class ProContentDownloadableCollection : ProContentCollection, IProContentDownloadableCollection, IProContentCollection, INotifyEnumerableChanged<IProContentAsset>, IEnumerable<IProContentAsset>, IEnumerable, INotifyCollectionChanged
{
	public IProContentFormat[] Formats { get; }

	public ProContentDownloadableCollection(string id, string displayName, string description, IProContentFormat[] formats, Uri? externalUrl = null, ProContentCollectionLayoutType layoutType = ProContentCollectionLayoutType.CarouselSmall)
		: base(id, displayName, description, externalUrl, layoutType)
	{
		Formats = formats;
	}
}
