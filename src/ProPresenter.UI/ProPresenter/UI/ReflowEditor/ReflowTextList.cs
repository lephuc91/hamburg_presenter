using System.Windows.Documents;
using System.Windows.Input;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.DO.Arrangements;

namespace ProPresenter.UI.ReflowEditor;

public class ReflowTextList : ListBoxBase<ArrangedCue, ListBoxItem>
{
	protected override bool ShouldDeselectOnMouseUp(MouseButtonEventArgs e)
	{
		bool num = base.ShouldDeselectOnMouseUp(e);
		bool flag = e.FindHitElement<Adorner>(this) == null;
		return num && flag;
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
	}
}
