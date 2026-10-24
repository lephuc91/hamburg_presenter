using System.Windows;
using System.Windows.Media;
using Pro.Common.Components;

namespace Pro.UI.Theming;

public class PartPalette : NotifyPropertyChangedBase
{
	public Color BackgroundColor { get; }

	public Color BorderColor { get; }

	public Color ContentColor { get; }

	public Color HelperContentColor { get; }

	public Color FillColor { get; }

	public Color SelectionColor { get; }

	public Color DividerColor { get; }

	public Brush Background { get; }

	public Brush Border { get; }

	public Brush Content { get; }

	public Brush HelperContent { get; }

	public Brush Fill { get; }

	public Brush Selection { get; }

	public Brush Divider { get; }

	internal PartPalette(string baseKey, PartPalette? basePalette, GlobalColorProviderDelegate colorProvider)
	{
		BackgroundColor = getPartColor("BACKGROUND", basePalette?.BackgroundColor);
		BorderColor = getPartColor("BORDER", basePalette?.BorderColor);
		ContentColor = getPartColor("CONTENT", basePalette?.ContentColor);
		HelperContentColor = getPartColor("HELPERCONTENT", basePalette?.HelperContentColor);
		FillColor = getPartColor("FILL", basePalette?.FillColor);
		SelectionColor = getPartColor("SELECTION", basePalette?.SelectionColor);
		DividerColor = getPartColor("DIVIDER", basePalette?.DividerColor);
		Background = getBrush(BackgroundColor);
		Border = getBrush(BorderColor);
		Content = getBrush(ContentColor);
		HelperContent = getBrush(HelperContentColor);
		Fill = getBrush(FillColor);
		Selection = getBrush(SelectionColor);
		Divider = getBrush(DividerColor);
		static Brush getBrush(Color color)
		{
			SolidColorBrush obj = new SolidColorBrush
			{
				Color = color
			};
			((Freezable)obj).Freeze();
			return obj;
		}
		Color getPartColor(string partKey, Color? baseColor)
		{
			return colorProvider(baseKey + "_" + partKey, baseColor);
		}
	}
}
