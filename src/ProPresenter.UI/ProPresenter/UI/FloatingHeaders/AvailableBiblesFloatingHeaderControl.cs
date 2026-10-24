using System.Linq;
using Pro.Common.Collections;
using Pro.UI.Controls;
using ProPresenter.DO.Bibles;

namespace ProPresenter.UI.FloatingHeaders;

public class AvailableBiblesFloatingHeaderControl : FloatingHeaderControl<IGrouping<string, AvailableBibleBase>, INotifyEnumerableChanged<IGrouping<string, AvailableBibleBase>>>
{
}
