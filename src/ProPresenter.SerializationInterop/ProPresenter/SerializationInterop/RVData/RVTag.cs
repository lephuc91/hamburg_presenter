using System.Windows.Media;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVTag
{
	[Trait]
	public string name { get; set; }

	[Trait]
	public Color color { get; set; }
}
