using System;
using Pro.Common.Mathematics;

namespace Pro.Editor.Canvas;

public static class ICanvasElementExtensions
{
	public const double MinimumThickness = 1.0;

	public static Angle<double> GetGlobalRotation(this ICanvasElement? element)
	{
		if (element == null)
		{
			return Angle<double>.Zero;
		}
		return element.Rotation + element.CanvasParent.GetGlobalRotation();
	}

	public static Matrix<double> GetGlobalTransformMatrix(this ICanvasElement? element, double scale = 1.0)
	{
		return element?.CanvasParent.GetGlobalTransformMatrix().Combine(Matrix<double>.Identity.Translate(element.Position * scale).Rotate(element.Rotation.InvertedCartesianValue, element.Size / 2.0)) ?? Matrix<double>.Identity;
	}

	public static Vector2<double> Center(this ICanvasElement element)
	{
		return element.Position + element.Size / 2.0;
	}

	public static void Scale(this ICanvasElement element, Vector2<double> scalar)
	{
		element.Position = element.Position.ComponentwiseProduct(scalar);
		element.Size = element.Size.ComponentwiseProduct(scalar);
	}

	public static Vector2<double> EnsurePositiveSize(this ICanvasElement element, Vector2<double> newSize)
	{
		if (element.IsAspectRatioLocked || element.IsAspectRatioLockForced)
		{
			if (newSize.X < 1.0 && element.Size.X < element.Size.Y)
			{
				newSize = new Vector2<double>(1.0, 1.0 * element.Size.Y / element.Size.X);
			}
			else if (newSize.Y < 1.0)
			{
				newSize = new Vector2<double>(1.0 * element.Size.X / element.Size.Y, 1.0);
			}
		}
		else
		{
			newSize = new Vector2<double>(Math.Max(newSize.X, 1.0), Math.Max(newSize.Y, 1.0));
		}
		return newSize;
	}
}
