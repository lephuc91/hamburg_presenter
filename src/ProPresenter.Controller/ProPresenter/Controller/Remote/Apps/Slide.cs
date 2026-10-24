using Newtonsoft.Json;

namespace ProPresenter.Controller.Remote.Apps;

public class Slide
{
	[JsonProperty(PropertyName = "slideEnabled")]
	public bool Enabled { get; set; }

	[JsonProperty(PropertyName = "slideNotes")]
	public string? Notes { get; set; }

	[JsonProperty(PropertyName = "slideAttachmentMask")]
	public int AttachmentMask { get; set; }

	[JsonProperty(PropertyName = "slideText")]
	public string? Text { get; set; }

	[JsonProperty(PropertyName = "slideImage")]
	public string? Image { get; set; }

	[JsonProperty(PropertyName = "slideIndex")]
	public int Index { get; set; }

	[JsonProperty(PropertyName = "slideTransitionType")]
	public int TransitionType { get; set; } = -1;

	[JsonProperty(PropertyName = "slideLabel")]
	public string? Label { get; set; }

	[JsonProperty(PropertyName = "slideColor")]
	public string? Color { get; set; }
}
