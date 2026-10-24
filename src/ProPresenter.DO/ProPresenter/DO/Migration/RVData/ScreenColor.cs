using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class ScreenColor
{
	[Child]
	[Alias("A", typeof(byte), false)]
	public byte A { get; set; }

	[Child]
	[Alias("R", typeof(byte), false)]
	public byte R { get; set; }

	[Child]
	[Alias("G", typeof(byte), false)]
	public byte G { get; set; }

	[Child]
	[Alias("B", typeof(byte), false)]
	public byte B { get; set; }
}
