using Newtonsoft.Json;

namespace ProPresenter.Controller.Remote.Apps;

public class Presentation
{
	[JsonProperty(PropertyName = "presentationName")]
	public string? Name { get; set; }

	[JsonProperty(PropertyName = "presentationPath")]
	public string? Path { get; set; }

	[JsonProperty(PropertyName = "presentationCurrentLocation")]
	public string? CurrentLocation { get; set; }

	[JsonProperty(PropertyName = "presentationHasTimeline")]
	public bool HasTimeline { get; set; }

	[JsonProperty(PropertyName = "presentationSlideGroups")]
	public SlideGroup[]? SlideGroups { get; set; }

	[JsonProperty(PropertyName = "presentationDestination")]
	public Destination Destination { get; set; }
}
