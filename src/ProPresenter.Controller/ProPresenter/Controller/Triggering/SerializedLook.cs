using System;
using System.Collections.Generic;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Looks;
using ProPresenter.DO.Themes;

namespace ProPresenter.Controller.Triggering;

public class SerializedLook
{
	public Guid LookID { get; }

	public string LookName { get; }

	public ProAudienceLook LookProto { get; }

	public Dictionary<Guid, TemplateSlide> ScreenTemplateProtos { get; } = new Dictionary<Guid, TemplateSlide>();

	public SerializedLook(AudienceLook sourceLook, IThemeCollection themes)
	{
		LookID = sourceLook.ID;
		LookName = sourceLook.Name;
		LookProto = sourceLook.Serialize();
		foreach (ScreenLook screenLook in sourceLook.ScreenLooks)
		{
			if (screenLook.TemplateId.HasValue && screenLook.ScreenId.HasValue)
			{
				TemplateSlide templateSlide = themes.FindTemplate(screenLook.TemplateId.Value, "", useDefault: false);
				if (templateSlide != null)
				{
					ScreenTemplateProtos.Add(screenLook.ScreenId.Value, templateSlide.CloneWithID());
				}
			}
		}
	}
}
