using Newtonsoft.Json;

namespace ProPresenter.Controller.Remote.Apps;

public class TriggerPresentationSlideRequest
{
	[JsonProperty(PropertyName = "presentationPath")]
	public string Path { get; set; } = string.Empty;

	[JsonProperty(PropertyName = "slideIndex")]
	public int SlideIndex { get; set; }
}
