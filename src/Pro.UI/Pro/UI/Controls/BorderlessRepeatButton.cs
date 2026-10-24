using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Pro.UI.Controls;

public class BorderlessRepeatButton : RepeatButton
{
	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.Key != 18)
		{
			base.OnKeyDown(e);
		}
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.Key != 18)
		{
			base.OnKeyUp(e);
		}
	}
}
