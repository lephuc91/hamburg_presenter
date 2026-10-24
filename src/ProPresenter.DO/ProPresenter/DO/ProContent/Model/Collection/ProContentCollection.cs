using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using ProPresenter.DO.ProContent.Model.Asset;

namespace ProPresenter.DO.ProContent.Model.Collection;

public class ProContentCollection : ImmutableObservableCollection<IProContentAsset>, IProContentCollection, INotifyEnumerableChanged<IProContentAsset>, IEnumerable<IProContentAsset>, IEnumerable, INotifyCollectionChanged
{
	public string Id { get; }

	public string DisplayName { get; }

	public string Description { get; }

	public Uri? ExternalUrl { get; }

	public ProContentCollectionLayoutType LayoutType { get; }

	public ProContentCollection(string id, string displayName, string description, Uri? externalUrl = null, ProContentCollectionLayoutType layoutType = ProContentCollectionLayoutType.CarouselSmall)
	{
		Id = id;
		DisplayName = displayName;
		Description = description;
		ExternalUrl = externalUrl;
		LayoutType = layoutType;
	}

	public void Add(IProContentAsset asset)
	{
		base.Collection.Add(asset);
	}
}
