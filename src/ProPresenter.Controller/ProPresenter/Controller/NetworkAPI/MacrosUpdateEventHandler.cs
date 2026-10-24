using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.DO.Triggering;
using ProPresenter.DO.Events;
using ProPresenter.DO.MacroGroups;

namespace ProPresenter.Controller.NetworkAPI;

internal class MacrosUpdateEventHandler : DebouncedEventSender
{
	private record MacroData(Guid ID, string Name, Color Color);

	private IEnumerable<MacroData> _previous = Array.Empty<MacroData>();

	private IEnumerable<MacroData> _current = Array.Empty<MacroData>();

	private readonly IMacroSource _macroSource;

	public MacrosUpdateEventHandler(IMacroSource macroSource)
	{
		_macroSource = macroSource;
		ApplicationEventPublisher.AddHandler(this);
	}

	protected override EventResult OnEventReceived(IApplicationEvent @event)
	{
		EventResult result = EventResult.Continue;
		if (@event is MacrosUpdated macrosUpdated)
		{
			MacroData[] array = macrosUpdated.Macros.Select((Macro m) => ToMacroData(m)).ToArray();
			if (!_current.ContentsMatchExactly(array))
			{
				_current = array;
				result = EventResult.Debounce;
			}
		}
		return result;
	}

	protected override void Publish()
	{
		if (!_previous.ContentsMatchExactly(_current))
		{
			OnSend(MacroHandler.UpdateMacros(_macroSource, null));
		}
		_previous = _current.ToArray();
	}

	private static MacroData ToMacroData(Macro macro)
	{
		return new MacroData(macro.ID, macro.Name, macro.Color);
	}
}
