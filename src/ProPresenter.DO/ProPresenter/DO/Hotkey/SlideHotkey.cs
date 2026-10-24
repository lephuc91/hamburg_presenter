using System.Windows.Input;
using System.Windows.Media;
using Pro.DO;

namespace ProPresenter.DO.Hotkey;

public class SlideHotkey : Pro.DO.Hotkey, IScrimSource
{
	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public bool IsEditable => false;

	public ListViewType ListViewType => ListViewType.Preview;

	public SlideHotkey(Key key)
		: base(key)
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)


	public SlideHotkey(Key key, Color color)
		: base(key, color)
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)

}
