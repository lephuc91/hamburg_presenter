using System;
using ProPresenter.UI.TransportStatus;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.ViewModels.TransportStatus;

public static class TransportStatusViewExtensions
{
	public static void ViewAction(this TransportStatusView view, Action presentationAction, Action announcementAction, Action audioAction)
	{
		switch (view)
		{
		case TransportStatusView.Presentation:
			presentationAction?.Invoke();
			break;
		case TransportStatusView.Announcement:
			announcementAction?.Invoke();
			break;
		case TransportStatusView.Audio:
			audioAction?.Invoke();
			break;
		case TransportStatusView.Presentation | TransportStatusView.Announcement:
			break;
		}
	}

	public static TransportStatusView ToTransportStatusView(this ProLayerIndex layer)
	{
		switch (layer)
		{
		case ProLayerIndex.PresentationBackground:
		case ProLayerIndex.PresentationForeground:
			return TransportStatusView.Presentation;
		case ProLayerIndex.AnnouncementsBackground:
		case ProLayerIndex.AnnouncementsForeground:
			return TransportStatusView.Announcement;
		case ProLayerIndex.Music:
			return TransportStatusView.Audio;
		default:
			return TransportStatusView.Unknown;
		}
	}

	public static ProLayerIndex ToProLayerIndex(this TransportStatusView view)
	{
		return view switch
		{
			TransportStatusView.Presentation => ProLayerIndex.PresentationBackground, 
			TransportStatusView.Announcement => ProLayerIndex.AnnouncementsBackground, 
			TransportStatusView.Audio => ProLayerIndex.Music, 
			_ => ProLayerIndex.Invalid, 
		};
	}
}
