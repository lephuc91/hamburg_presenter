using System.ComponentModel;

namespace Pro.Text;

public enum BulletType
{
	[Description("-")]
	Dash,
	[Description("⁃")]
	HyphenDash,
	[Description("•")]
	SmallCircle,
	[Description("●")]
	Circle,
	[Description("◦")]
	SmallOpenCircle,
	[Description("○")]
	OpenCircle,
	[Description("▪")]
	SmallSquare,
	[Description("■")]
	Square,
	[Description("▫")]
	SmallOpenSquare,
	[Description("□")]
	OpenSquare,
	[Description("✓")]
	Checkmark,
	[Description("✔")]
	HeavyCheckmark,
	[Description("◆")]
	Diamond,
	[Description("◇")]
	OpenDiamond
}
