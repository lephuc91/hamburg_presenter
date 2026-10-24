using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using Pro.Common.Components;

namespace ProPresenter.DO.Looks;

public interface IAudienceLookCollection : INotifyEnumerableChanged<AudienceLook>, IEnumerable<AudienceLook>, IEnumerable, INotifyCollectionChanged, IReadOnlyList<AudienceLook>, IReadOnlyCollection<AudienceLook>, ICutPasteCollection<AudienceLook>, ICutCollection<AudienceLook>, IDragDropCollection<AudienceLook>
{
	event Action? CollectionModified;

	AudienceLook Add(string name = "");

	void Add(AudienceLook audienceLook);

	void Insert(int index, AudienceLook audienceLook);

	void Remove(AudienceLook audienceLook);
}
