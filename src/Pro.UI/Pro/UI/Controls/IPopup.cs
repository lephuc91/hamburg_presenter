using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Pro.UI.Controls;

public interface IPopup
{
	UIElement? Child { get; set; }

	bool AllowsTransparency { get; set; }

	HorizontalAlignment HorizontalAlignment { get; set; }

	double HorizontalOffset { get; set; }

	bool IsOpen { get; set; }

	PlacementMode Placement { get; set; }

	UIElement? PlacementTarget { get; set; }

	bool StaysOpen { get; set; }

	VerticalAlignment VerticalAlignment { get; set; }

	double VerticalOffset { get; set; }

	double Width { get; set; }

	double Height { get; set; }

	double MinWidth { get; set; }

	double MaxWidth { get; set; }

	double MinHeight { get; set; }

	double MaxHeight { get; set; }

	bool SendKeyEventsToMainWindow { get; set; }

	event EventHandler Closed;

	event EventHandler Opened;
}
