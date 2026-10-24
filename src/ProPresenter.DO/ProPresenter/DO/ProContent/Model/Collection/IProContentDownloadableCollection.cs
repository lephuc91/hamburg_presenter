using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.ProContent.Model.Format;

namespace ProPresenter.DO.ProContent.Model.Collection;

public interface IProContentDownloadableCollection : IProContentCollection, INotifyEnumerableChanged<IProContentAsset>, IEnumerable<IProContentAsset>, IEnumerable, INotifyCollectionChanged
{
	IProContentFormat[] Formats { get; }
}
