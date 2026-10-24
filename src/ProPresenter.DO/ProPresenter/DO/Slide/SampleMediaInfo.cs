using System;
using System.Windows.Media;
using Pro.Common.Utility;
using Pro.ssAPI;

namespace ProPresenter.DO.Slide;

public class SampleMediaInfo : IEquatable<SampleMediaInfo?>
{
	public ImageSource? Source { get; }

	public ScaleBehavior ScaleBehavior { get; }

	public ScaleAlignment ScaleAlignment { get; }

	public bool FlipHorizontally { get; }

	public bool FlipVertically { get; }

	public SampleMediaInfo(ImageSource? source, ScaleBehavior scaleBehavior, ScaleAlignment scaleAlignment, bool flipHorizontally, bool flipVertically)
	{
		Source = source;
		ScaleBehavior = scaleBehavior;
		ScaleAlignment = scaleAlignment;
		FlipHorizontally = flipHorizontally;
		FlipVertically = flipVertically;
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(Source, ScaleBehavior, ScaleAlignment, FlipHorizontally, FlipVertically);
	}

	public override bool Equals(object? obj)
	{
		if (obj is SampleMediaInfo other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(SampleMediaInfo? other)
	{
		if ((object)other != null && Source == other.Source && ScaleBehavior == other.ScaleBehavior && ScaleAlignment == other.ScaleAlignment && FlipHorizontally == other.FlipHorizontally)
		{
			return FlipVertically == other.FlipVertically;
		}
		return false;
	}

	public static bool operator ==(SampleMediaInfo? lhs, SampleMediaInfo? rhs)
	{
		return lhs.NullableEquals(rhs);
	}

	public static bool operator !=(SampleMediaInfo? lhs, SampleMediaInfo? rhs)
	{
		return !lhs.NullableEquals(rhs);
	}
}
