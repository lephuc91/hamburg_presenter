using System;
using Pro.Common.Mathematics;

namespace Pro.Editor.Canvas.Transforming;

public static class HandleLocationExtensions
{
	private const int LocationCount = 8;

	public static HandleLocation GetNextHandle(this HandleLocation location, int offset)
	{
		if (offset % 8 == 0)
		{
			return location;
		}
		uint num = (uint)location << offset.Mod(8);
		return (HandleLocation)((num | (num >> 8)) & 0xFF);
	}

	public static HandleLocation GetOppositeHandle(this HandleLocation location)
	{
		return location.GetNextHandle(4);
	}

	public static HandleLocation GetHorizontallyOppositeHandle(this HandleLocation location)
	{
		return location switch
		{
			HandleLocation.None => HandleLocation.None, 
			HandleLocation.TopLeft => HandleLocation.TopRight, 
			HandleLocation.TopCenter => HandleLocation.TopCenter, 
			HandleLocation.TopRight => HandleLocation.TopLeft, 
			HandleLocation.RightCenter => HandleLocation.LeftCenter, 
			HandleLocation.BottomRight => HandleLocation.BottomLeft, 
			HandleLocation.BottomCenter => HandleLocation.BottomCenter, 
			HandleLocation.BottomLeft => HandleLocation.BottomRight, 
			HandleLocation.LeftCenter => HandleLocation.RightCenter, 
			HandleLocation.All => HandleLocation.All, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static HandleLocation GetVerticallyOppositeHandle(this HandleLocation location)
	{
		return location switch
		{
			HandleLocation.None => HandleLocation.None, 
			HandleLocation.TopLeft => HandleLocation.BottomLeft, 
			HandleLocation.TopCenter => HandleLocation.BottomCenter, 
			HandleLocation.TopRight => HandleLocation.BottomRight, 
			HandleLocation.RightCenter => HandleLocation.RightCenter, 
			HandleLocation.BottomRight => HandleLocation.TopRight, 
			HandleLocation.BottomCenter => HandleLocation.TopCenter, 
			HandleLocation.BottomLeft => HandleLocation.TopLeft, 
			HandleLocation.LeftCenter => HandleLocation.LeftCenter, 
			HandleLocation.All => HandleLocation.All, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static bool AdjustsWidth(this HandleLocation location)
	{
		if (!location.HasFlag(HandleLocation.TopCenter))
		{
			return !location.HasFlag(HandleLocation.BottomCenter);
		}
		return false;
	}

	public static bool AdjustsHeight(this HandleLocation location)
	{
		if (!location.HasFlag(HandleLocation.LeftCenter))
		{
			return !location.HasFlag(HandleLocation.RightCenter);
		}
		return false;
	}

	public static bool IsLeft(this HandleLocation location)
	{
		if (!location.HasFlag(HandleLocation.BottomLeft) && !location.HasFlag(HandleLocation.LeftCenter))
		{
			return location.HasFlag(HandleLocation.TopLeft);
		}
		return true;
	}

	public static bool IsTop(this HandleLocation location)
	{
		if (!location.HasFlag(HandleLocation.TopLeft) && !location.HasFlag(HandleLocation.TopCenter))
		{
			return location.HasFlag(HandleLocation.TopRight);
		}
		return true;
	}

	public static bool IsRight(this HandleLocation location)
	{
		if (!location.HasFlag(HandleLocation.BottomRight) && !location.HasFlag(HandleLocation.RightCenter))
		{
			return location.HasFlag(HandleLocation.TopRight);
		}
		return true;
	}

	public static bool IsBottom(this HandleLocation location)
	{
		if (!location.HasFlag(HandleLocation.BottomLeft) && !location.HasFlag(HandleLocation.BottomCenter))
		{
			return location.HasFlag(HandleLocation.BottomRight);
		}
		return true;
	}

	public static bool IsCorner(this HandleLocation location)
	{
		if (location != HandleLocation.TopLeft && location != HandleLocation.TopRight && location != HandleLocation.BottomRight)
		{
			return location == HandleLocation.BottomLeft;
		}
		return true;
	}

	public static double GetAngle(this HandleLocation location)
	{
		int num = 0;
		uint num2 = (uint)location;
		while (num2 > 1)
		{
			num2 >>= 1;
			num++;
		}
		return 225.0 + (double)num * 45.0;
	}

	public static Vector2<double> GetHandlePosition(this HandleLocation location, Rect<double> bounds, Angle<double> rotation)
	{
		Vector2<double> vector = location switch
		{
			HandleLocation.TopLeft => bounds.TopLeft, 
			HandleLocation.TopCenter => bounds.TopCenter, 
			HandleLocation.TopRight => bounds.TopRight, 
			HandleLocation.RightCenter => bounds.RightCenter, 
			HandleLocation.BottomRight => bounds.BottomRight, 
			HandleLocation.BottomCenter => bounds.BottomCenter, 
			HandleLocation.BottomLeft => bounds.BottomLeft, 
			HandleLocation.LeftCenter => bounds.LeftCenter, 
			_ => throw new ArgumentException("location"), 
		};
		if (rotation.Value == 0.0)
		{
			return vector;
		}
		return vector.Rotate(bounds.Center, rotation.InvertedCartesianValue);
	}

	public static Vector2<double> GetPositionScalar(this HandleLocation location, bool isMirroring, bool isRatioLocked)
	{
		return new Vector2<double>(location.IsLeft() ? 1.0 : (((location.IsRight() || isRatioLocked) && isMirroring) ? (-1.0) : 0.0), location.IsTop() ? 1.0 : (((location.IsBottom() || isRatioLocked) && isMirroring) ? (-1.0) : 0.0));
	}

	public static Vector2<double> GetSizeScalar(this HandleLocation location, bool isMirroring, bool isRatioLocked)
	{
		double num = ((!isMirroring) ? 1.0 : 2.0);
		return new Vector2<double>(location.IsLeft() ? (0.0 - num) : ((location.IsRight() || isRatioLocked) ? num : 0.0), location.IsTop() ? (0.0 - num) : ((location.IsBottom() || isRatioLocked) ? num : 0.0));
	}
}
