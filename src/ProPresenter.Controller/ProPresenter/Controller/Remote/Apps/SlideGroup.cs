using Newtonsoft.Json;

namespace ProPresenter.Controller.Remote.Apps;

public class SlideGroup
{
	[JsonProperty(PropertyName = "groupName")]
	public string? Name { get; set; }

	[JsonProperty(PropertyName = "groupColor")]
	public string? Color { get; set; }

	[JsonProperty(PropertyName = "groupSlides")]
	public Slide[]? Slides { get; set; }
}
