using System.Collections.Generic;
using Pro.UI.InputActions;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO.InputActionMap.OutputScreen;

public class OutputScreenInputAction : InputAction
{
	public override InputActionType Type => InputActionType.MenuItem;

	public ScreenArrangementBase? Screen { get; set; }

	public OutputScreenInputAction(ScreenArrangementBase screen, IEnumerable<VirtualKeyGesture?>? defaultGestures, InputActionGroupBase parentGroup, params string[] accessPath)
		: base(screen.ID.ToString(), screen.Name, defaultGestures, parentGroup, accessPath)
	{
		LinkAction("Name", delegate
		{
			base.Label = Screen?.Name;
		});
		Screen = screen;
		Screen.PropertyChanged += base.RaiseLinkedValues;
	}
}
