using ProPresenter.DO.Macros;

namespace ProPresenter.Controller.Triggering;

public class MacroInfo
{
	public ProPresenterMacro OriginalMacro { get; }

	public MacroInfo(ProPresenterMacro originalMacro)
	{
		OriginalMacro = originalMacro;
	}
}
