using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Messages;
using ProPresenter.DO.Themes;

namespace ProPresenter.Controller.Triggering;

public class SerializedMessage
{
	public Pro.SerializationInterop.RVProtoData.Message Message { get; }

	public TemplateSlide? TemplateSlide { get; }

	public SerializedMessage(ProPresenter.DO.Messages.Message message)
	{
		Message = message.Serialize();
		TemplateSlide = message.SelectedTemplate?.Clone();
	}
}
