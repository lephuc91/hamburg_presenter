using System.Collections.ObjectModel;
using Pro.UI.Controls;

namespace ProPresenter.UI.FloatingHeaders;

public class FlatFloatingHeaderControl : FloatingHeaderControl<object, ObservableCollection<object>>
{
	public FlatFloatingHeaderControl()
	{
		base.Items = new ObservableCollection<object>();
	}
}
