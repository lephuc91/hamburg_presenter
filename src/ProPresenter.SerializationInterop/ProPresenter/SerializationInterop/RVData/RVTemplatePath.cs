using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVTemplatePath
{
	[Trait]
	public string templateFilePath { get; set; }

	[Trait]
	public int templateSlideIndex { get; set; }
}
