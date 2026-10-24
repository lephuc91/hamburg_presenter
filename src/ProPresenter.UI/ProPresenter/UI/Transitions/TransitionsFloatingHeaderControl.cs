using System.Collections.ObjectModel;
using Pro.UI.Controls;

namespace ProPresenter.UI.Transitions;

public class TransitionsFloatingHeaderControl : FloatingHeaderControl<object, ObservableCollection<object>>
{
	public TransitionsFloatingHeaderControl()
	{
		base.Items = new ObservableCollection<object>();
	}
}
