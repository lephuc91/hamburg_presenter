using Newtonsoft.Json;

namespace ProPresenter.Controller.Remote.Apps;

public class PresentationResponse
{
	[JsonProperty(PropertyName = "action")]
	public string? Action { get; set; }

	[JsonProperty(PropertyName = "presentationPath")]
	public string? Path { get; set; }

	[JsonProperty(PropertyName = "presentation")]
	public Presentation? Presentation { get; set; }
}
