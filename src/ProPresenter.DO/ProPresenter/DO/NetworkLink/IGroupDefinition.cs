using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Collections;

namespace ProPresenter.DO.NetworkLink;

public interface IGroupDefinition : INotifyEnumerableChanged<GroupMember>, IEnumerable<GroupMember>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged
{
	string Name { get; }

	event Action Updated;
}
