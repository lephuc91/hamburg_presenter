using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Common.Strings;
using Pro.Common.Time;
using ProPresenter.DO.Actions;

namespace ProPresenter.DO.Slide.Links;

public record PlaybackMarkerInformation(IPlaybackMarker[]? Markers, TimeSlice Elapsed, TimeSlice LoopDuration, TimeSlice TotalDuration) : IPlaybackMarkerInformation
{
	public IPlaybackMarker? FindMarker(PlaybackMarkerIdentifier identifier, Color implicitColor)
	{
		if (Markers == null)
		{
			return null;
		}
		if (Elapsed <= TimeSlice.Zero || LoopDuration <= TimeSlice.Zero || TotalDuration <= TimeSlice.Zero)
		{
			return Markers.FirstOrDefault();
		}
		TimeSlice loopTimeElapsed = Elapsed % LoopDuration;
		int num = (int)Math.Floor(Elapsed / LoopDuration);
		TimeSlice loopOffset = LoopDuration * num;
		return identifier.Type switch
		{
			PlaybackMarkerIdentifierType.First => Markers.FirstOrDefault() ?? ImplicitMarker(TimeSlice.Zero, implicitColor), 
			PlaybackMarkerIdentifierType.Previous => OffsetMarker(Markers.LastOrDefault((IPlaybackMarker m) => m.Timestamp < loopTimeElapsed && m.Timestamp + loopOffset <= TotalDuration), loopOffset, null) ?? ImplicitMarker(loopOffset, implicitColor), 
			PlaybackMarkerIdentifierType.Next => OffsetMarker(Markers.FirstOrDefault((IPlaybackMarker m) => m.Timestamp >= loopTimeElapsed && m.Timestamp + loopOffset <= TotalDuration), loopOffset, null) ?? ImplicitMarker(MathHelper.Min(LoopDuration + loopOffset, TotalDuration), implicitColor), 
			PlaybackMarkerIdentifierType.Last => OffsetMarker(Markers.LastOrDefault((IPlaybackMarker m) => m.Timestamp < TotalDuration % LoopDuration), loopOffset, LoopDuration * Math.Floor(TotalDuration / LoopDuration)) ?? OffsetMarker(Markers.LastOrDefault(), loopOffset, LoopDuration * (Math.Floor(TotalDuration / LoopDuration) - 1.0)) ?? ImplicitMarker(TotalDuration, implicitColor), 
			PlaybackMarkerIdentifierType.Name => OffsetMarker(findByName(Markers, identifier) ?? findByRegex(Markers, identifier.Name.ToWildCardRegex(), caseSensitive: true) ?? findByRegex(Markers, identifier.Name.ToWildCardRegex(), caseSensitive: false) ?? findByRegex(Markers, identifier.Name, caseSensitive: true) ?? findByRegex(Markers, identifier.Name, caseSensitive: false), loopOffset, null), 
			_ => null, 
		};
	}

	private static IPlaybackMarker ImplicitMarker(TimeSlice timestamp, Color implicitColor)
	{
		return new PlaybackMarker
		{
			Name = string.Empty,
			Color = implicitColor,
			Timestamp = timestamp
		};
	}

	private static bool MatchName(string name, string pattern, bool caseSensitive)
	{
		return name?.Equals(pattern, caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase) ?? false;
	}

	private static IPlaybackMarker? OffsetMarker(IPlaybackMarker? marker, TimeSlice loopOffset, TimeSlice? offset = null)
	{
		if (marker == null)
		{
			return null;
		}
		PlaybackMarker playbackMarker = new PlaybackMarker();
		playbackMarker.Name = marker.Name;
		playbackMarker.Color = marker.Color;
		playbackMarker.Timestamp = marker.Timestamp + (offset ?? loopOffset);
		playbackMarker.UpdateContainerId(marker.ContainerId);
		return playbackMarker;
	}

	private static IPlaybackMarker? findByName(IPlaybackMarker[] markers, PlaybackMarkerIdentifier identifier)
	{
		return markers?.FirstOrDefaultBy((IPlaybackMarker m) => MatchName(m.Name, identifier.Name, caseSensitive: true), (IPlaybackMarker m) => MatchName(m.Name, identifier.Name, caseSensitive: false));
	}

	private static IPlaybackMarker? findByRegex(IPlaybackMarker[] markers, string pattern, bool caseSensitive)
	{
		RegexOptions options = ((!caseSensitive) ? RegexOptions.IgnoreCase : RegexOptions.None);
		if (!pattern.IsValidRegex(out Regex regex, options))
		{
			return null;
		}
		return markers.FirstOrDefault(delegate(IPlaybackMarker m)
		{
			Match match = regex?.Match(m.Name);
			return match != null && match.Success && MatchName(m.Name, match.Value, caseSensitive);
		});
	}
}
