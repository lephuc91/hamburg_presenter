using System;
using System.Collections.Generic;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Themes;

namespace ProPresenter.Controller.Triggering;

public class TriggerEnvironment
{
	public StageData? StageDocument { get; }

	public Dictionary<Guid, SerializedMessage> Messages { get; } = new Dictionary<Guid, SerializedMessage>();

	public TemplateSlide? CCLITemplateSlide { get; }

	public SerializedLook? LiveLook { get; }

	public Dictionary<Guid, SerializedLook> AudienceLooks { get; } = new Dictionary<Guid, SerializedLook>();

	public Dictionary<Guid, Timer> Timers { get; } = new Dictionary<Guid, Timer>();

	internal TriggerEnvironment(StageData? stageDocument, Dictionary<Guid, SerializedMessage> messages, TemplateSlide? ccliTemplateSlide, SerializedLook? liveLook, Dictionary<Guid, SerializedLook> looks, Dictionary<Guid, Timer> timers)
	{
		StageDocument = stageDocument;
		Messages = messages;
		CCLITemplateSlide = ccliTemplateSlide;
		LiveLook = liveLook;
		AudienceLooks = looks;
		Timers = timers;
	}

	public TriggerEnvironment()
	{
	}
}
