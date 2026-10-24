using System;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics;

internal static class ProtoEditorEventExtensions
{
	public static EditorOverlayShown.Types.Source ToShownSource(this OverlayShowSource source)
	{
		return source switch
		{
			OverlayShowSource.DoubleClick => EditorOverlayShown.Types.Source.DoubleClick, 
			OverlayShowSource.ContextMenu => EditorOverlayShown.Types.Source.ContextualMenu, 
			OverlayShowSource.PlusButtonMenu => EditorOverlayShown.Types.Source.PlusButtonMenu, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static EditorOverlayClosed.Types.Source ToClosedSource(this OverlayCloseSource source)
	{
		return source switch
		{
			OverlayCloseSource.ClickOffElement => EditorOverlayClosed.Types.Source.ClickOffElement, 
			OverlayCloseSource.CloseButton => EditorOverlayClosed.Types.Source.CloseButton, 
			OverlayCloseSource.EscapeKey => EditorOverlayClosed.Types.Source.EscapeKey, 
			_ => throw new NotImplementedException(), 
		};
	}
}
