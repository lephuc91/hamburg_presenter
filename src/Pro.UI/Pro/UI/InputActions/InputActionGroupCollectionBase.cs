using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;

namespace Pro.UI.InputActions;

public abstract class InputActionGroupCollectionBase : ImmutableObservableCollection<InputActionGroupBase>, INotifyEnumerableChanged<InputActionGroupBase>, IEnumerable<InputActionGroupBase>, IEnumerable, INotifyCollectionChanged
{
	protected void AddInputActionGroup(InputActionGroupBase group)
	{
		base.Collection.Add(group);
	}

	protected void RemoveInputActionGroup(InputActionGroupBase group)
	{
		base.Collection.Remove(group);
	}
}
