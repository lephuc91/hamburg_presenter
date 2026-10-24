using System;
using Pro.Common.Utility;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.Rendering;

internal class BezierPathBitmapKey : IEquatable<BezierPathBitmapKey>
{
	private readonly int _hashCode;

	public BezierPath Path { get; }

	public RenderingMode Mode { get; }

	public BezierPathBitmapKey(BezierPath path, RenderingMode mode)
	{
		Path = path;
		Mode = mode;
		_hashCode = HashCodeHelper.GenerateHashCode(path, mode);
	}

	public override int GetHashCode()
	{
		return _hashCode;
	}

	public override bool Equals(object? obj)
	{
		if (obj is BezierPathBitmapKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(BezierPathBitmapKey? other)
	{
		if ((object)other != null && Path == other.Path)
		{
			return Mode == other.Mode;
		}
		return false;
	}

	public static bool operator ==(BezierPathBitmapKey lhs, BezierPathBitmapKey rhs)
	{
		return lhs.NullableEquals<BezierPathBitmapKey>(rhs);
	}

	public static bool operator !=(BezierPathBitmapKey lhs, BezierPathBitmapKey rhs)
	{
		return !lhs.NullableEquals<BezierPathBitmapKey>(rhs);
	}
}
