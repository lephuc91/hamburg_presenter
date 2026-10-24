using System;
using Pro.Common.Utility;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

public struct PlaybackMarkerIdentifier : IEquatable<PlaybackMarkerIdentifier>
{
	public PlaybackMarkerIdentifierType Type { get; }

	public PlaybackMarkerIdentifierDestination Destination { get; }

	public string Name { get; }

	public string DisplayText
	{
		get
		{
			if (Type != PlaybackMarkerIdentifierType.Name)
			{
				return LocalizedStrings.Get(Type);
			}
			return "\"" + Name + "\"";
		}
	}

	public PlaybackMarkerIdentifier(PlaybackMarkerIdentifierDestination destination, PlaybackMarkerIdentifierType type, string name = "")
	{
		Destination = destination;
		Type = type;
		Name = name;
	}

	public Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier
		{
			Destination = Destination.ToProtoPlaybackMarkerIdentifierDestination(),
			Name = (Name ?? ""),
			Type = Type.ToProtoPlaybackMarkerIdentifierType()
		};
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(Destination, Type, Name);
	}

	public static bool operator ==(PlaybackMarkerIdentifier lhs, PlaybackMarkerIdentifier rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(PlaybackMarkerIdentifier lhs, PlaybackMarkerIdentifier rhs)
	{
		return !lhs.Equals(rhs);
	}

	public override bool Equals(object? obj)
	{
		if (obj is PlaybackMarkerIdentifier obj2)
		{
			return Equals(obj2);
		}
		return false;
	}

	public bool Equals(PlaybackMarkerIdentifier obj)
	{
		if (obj.Destination == Destination && obj.Type == Type)
		{
			if (Type == PlaybackMarkerIdentifierType.Name)
			{
				return Name == obj.Name;
			}
			return true;
		}
		return false;
	}

	public PlaybackMarkerIdentifier Clone()
	{
		return new PlaybackMarkerIdentifier(Destination, Type, Name);
	}

	public IPlaybackMarkerInformation? SelectLinkData(ILinkData? linkData)
	{
		return Destination switch
		{
			PlaybackMarkerIdentifierDestination.Presentation => linkData?.CurrentPresentationPlaybackMarkers, 
			PlaybackMarkerIdentifierDestination.Announcement => linkData?.CurrentAnnouncementPlaybackMarkers, 
			PlaybackMarkerIdentifierDestination.Audio => linkData?.CurrentAudioPlaybackMarkers, 
			_ => throw new NotSupportedException(), 
		};
	}
}
