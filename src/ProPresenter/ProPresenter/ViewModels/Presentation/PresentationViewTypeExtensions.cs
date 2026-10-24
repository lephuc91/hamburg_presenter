using System;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.DO;
using ProPresenter.UI.PresentationView;

namespace ProPresenter.ViewModels.Presentation;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(PanelViewType), typeof(PresentationViewType), SourceToDestinationMethodName = "ToPresentationViewType", DestinationToSourceMethodName = "ToPanelViewType")]
public static class PresentationViewTypeExtensions
{
	public static PresentationViewType ToPresentationViewType(this PanelViewType source)
	{
		return source switch
		{
			PanelViewType.Thumbnail => PresentationViewType.Thumbnail, 
			PanelViewType.EasyView => PresentationViewType.EasyView, 
			PanelViewType.List => PresentationViewType.List, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static PanelViewType ToPanelViewType(this PresentationViewType source)
	{
		return source switch
		{
			PresentationViewType.Thumbnail => PanelViewType.Thumbnail, 
			PresentationViewType.EasyView => PanelViewType.EasyView, 
			PresentationViewType.List => PanelViewType.List, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
