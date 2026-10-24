using ProPresenter.DO.MacroGroups;

namespace ProPresenter.DO.Macros;

public class MacrosRepo : IMacrosRepo
{
	public MacroCollection Macros => DataVault.Macros;

	public MacroGroupCollection MacroGroups => DataVault.MacroGroups;

	public IMacroSource MacroSource => DataVault.MacroSource;
}
