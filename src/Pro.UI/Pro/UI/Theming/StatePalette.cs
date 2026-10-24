using System;
using Pro.Common.Components;

namespace Pro.UI.Theming;

public class StatePalette : NotifyPropertyChangedBase
{
	public string Key { get; }

	public PartPalette Standard { get; }

	public PartPalette Disabled { get; }

	public PartPalette Hover { get; }

	public PartPalette Pressed { get; }

	public PartPalette Selected { get; }

	public PartPalette InactiveSelected { get; }

	public PartPalette Checked { get; }

	public PartPalette Focused { get; }

	internal StatePalette(string baseKey, StatePalette? basePalette, GlobalColorProviderDelegate colorProvider)
	{
		Key = baseKey;
		Standard = getPartPalette(string.Empty, () => basePalette?.Standard);
		Disabled = getPartPalette("DISABLED", () => basePalette?.Disabled);
		Hover = getPartPalette("HOVER", () => basePalette?.Hover);
		Pressed = getPartPalette("PRESSED", () => basePalette?.Pressed);
		Selected = getPartPalette("SELECTED", () => basePalette?.Selected);
		InactiveSelected = getPartPalette("INACTIVESELECTED", () => basePalette?.InactiveSelected);
		Checked = getPartPalette("CHECKED", () => basePalette?.Checked);
		Focused = getPartPalette("FOCUSED", () => basePalette?.Focused);
		PartPalette getPartPalette(string stateKey, Func<PartPalette?> baseSelector)
		{
			return new PartPalette(string.IsNullOrEmpty(stateKey) ? baseKey : (baseKey + "_" + stateKey), baseSelector(), colorProvider);
		}
	}
}
