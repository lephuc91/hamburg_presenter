using System;
using Pro.Common.Mathematics;
using Pro.Text;

namespace Pro.UI.Controls;

public interface IFormattedTextBox
{
	TextDocument? Document { get; }

	Pro.Text.Range[] SelectionRanges { get; }

	event Action<Vector2<double>, FormattedTextBox.CaretLocation, double> CaretPositionChanged;
}
