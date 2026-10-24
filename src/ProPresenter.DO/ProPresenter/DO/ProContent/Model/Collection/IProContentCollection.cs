using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using ProPresenter.DO.ProContent.Model.Asset;

namespace ProPresenter.DO.ProContent.Model.Collection;

public interface IProContentCollection : INotifyEnumerableChanged<IProContentAsset>, IEnumerable<IProContentAsset>, IEnumerable, INotifyCollectionChanged
{
	string Id { get; }

	string DisplayName { get; }

	string Description { get; }

	Uri? ExternalUrl { get; }

	ProContentCollectionLayoutType LayoutType { get; }

	void Add(IProContentAsset asset);
}
