using System.Windows.Media;

namespace Pro.Text.RTF;

public static class Constants
{
	public const int HalfPointMultiplier = 2;

	public const int QuarterPointMultiplier = 4;

	public const int TwipMultiplier = 20;

	public const int ExpandedColorMultiplier = 100000;

	public const double SingleLineSpacing = 12.0;

	public static readonly ParagraphSettings DefaultParagraphSettings = new ParagraphSettings(ParagraphAlignment.Left, LineSpacingMode.Relative, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);

	public static readonly RunSettings DefaultRunSettings = new RunSettings(RunSettings.DefaultFont, 12, 0.0, new SolidTextFill(Colors.Black), 0.0, Colors.Black);
}
