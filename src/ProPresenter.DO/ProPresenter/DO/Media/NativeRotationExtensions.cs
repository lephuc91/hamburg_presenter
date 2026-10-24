using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Media;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(NativeRotation), typeof(Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties.Types.NativeRotationType), SourceToDestinationMethodName = "ToProtoNativeRotationType", DestinationToSourceMethodName = "ToNativeRotation")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(NativeRotation), typeof(IMedia.Types.IDrawingProperties.Types.NativeRotationType), SourceToDestinationMethodName = "ToEntityNativeRotationType", DestinationToSourceMethodName = "ToNativeRotation")]
public static class NativeRotationExtensions
{
	private const double ZERO_DEGREES = 0.0;

	private const double NINETY_DEGREES = 90.0;

	private const double ONE_HUNDRED_EIGHTY_DEGREES = 180.0;

	private const double TWO_HUNDRED_SEVENTY_DEGREES = 270.0;

	public static double GetValue(this NativeRotation nativeRotation)
	{
		return nativeRotation switch
		{
			NativeRotation.RotateStandard => 0.0, 
			NativeRotation.Rotate90 => 90.0, 
			NativeRotation.Rotate180 => 180.0, 
			NativeRotation.Rotate270 => 270.0, 
			_ => 0.0, 
		};
	}

	public static NativeRotation GetNativeRotation(this float rotation)
	{
		return ((double)rotation).GetNativeRotation();
	}

	public static NativeRotation GetNativeRotation(this double rotation)
	{
		if (rotation != 0.0)
		{
			if (rotation != 90.0)
			{
				if (rotation != 180.0)
				{
					if (rotation == 270.0)
					{
						return NativeRotation.Rotate270;
					}
					return NativeRotation.RotateStandard;
				}
				return NativeRotation.Rotate180;
			}
			return NativeRotation.Rotate90;
		}
		return NativeRotation.RotateStandard;
	}

	public static Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties.Types.NativeRotationType ToProtoNativeRotationType(this NativeRotation source)
	{
		return source switch
		{
			NativeRotation.RotateStandard => Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties.Types.NativeRotationType.RotateStandard, 
			NativeRotation.Rotate90 => Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties.Types.NativeRotationType.Rotate90, 
			NativeRotation.Rotate180 => Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties.Types.NativeRotationType.Rotate180, 
			NativeRotation.Rotate270 => Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties.Types.NativeRotationType.Rotate270, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static NativeRotation ToNativeRotation(this Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties.Types.NativeRotationType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties.Types.NativeRotationType.RotateStandard => NativeRotation.RotateStandard, 
			Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties.Types.NativeRotationType.Rotate90 => NativeRotation.Rotate90, 
			Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties.Types.NativeRotationType.Rotate180 => NativeRotation.Rotate180, 
			Pro.SerializationInterop.RVProtoData.Media.Types.DrawingProperties.Types.NativeRotationType.Rotate270 => NativeRotation.Rotate270, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static IMedia.Types.IDrawingProperties.Types.NativeRotationType ToEntityNativeRotationType(this NativeRotation source)
	{
		return source switch
		{
			NativeRotation.RotateStandard => IMedia.Types.IDrawingProperties.Types.NativeRotationType.RotateStandard, 
			NativeRotation.Rotate90 => IMedia.Types.IDrawingProperties.Types.NativeRotationType.Rotate90, 
			NativeRotation.Rotate180 => IMedia.Types.IDrawingProperties.Types.NativeRotationType.Rotate180, 
			NativeRotation.Rotate270 => IMedia.Types.IDrawingProperties.Types.NativeRotationType.Rotate270, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static NativeRotation ToNativeRotation(this IMedia.Types.IDrawingProperties.Types.NativeRotationType source)
	{
		return source switch
		{
			IMedia.Types.IDrawingProperties.Types.NativeRotationType.RotateStandard => NativeRotation.RotateStandard, 
			IMedia.Types.IDrawingProperties.Types.NativeRotationType.Rotate90 => NativeRotation.Rotate90, 
			IMedia.Types.IDrawingProperties.Types.NativeRotationType.Rotate180 => NativeRotation.Rotate180, 
			IMedia.Types.IDrawingProperties.Types.NativeRotationType.Rotate270 => NativeRotation.Rotate270, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
