using ProPresenter.DO.MacroGroups;

namespace ProPresenter.DO.Macros;

public interface IMacrosRepo
{
	MacroCollection Macros { get; }

	MacroGroupCollection MacroGroups { get; }

	IMacroSource MacroSource { get; }
}
