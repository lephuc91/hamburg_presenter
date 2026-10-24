using System;
using Pro.Common.Logging;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements;

public static class LineMaskStyleExtensions
{
	public static Graphics.Types.Text.Types.LineFillMask.Types.LineMaskStyle ToProtoLineMaskStyle(this LineMaskStyle lineMaskStyle)
	{
		return lineMaskStyle switch
		{
			LineMaskStyle.FullWidth => Graphics.Types.Text.Types.LineFillMask.Types.LineMaskStyle.FullWidth, 
			LineMaskStyle.LineWidth => Graphics.Types.Text.Types.LineFillMask.Types.LineMaskStyle.LineWidth, 
			LineMaskStyle.MaxLineWidth => Graphics.Types.Text.Types.LineFillMask.Types.LineMaskStyle.MaxLineWidth, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static LineMaskStyle ToLineMaskStyle(this Graphics.Types.Text.Types.LineFillMask.Types.LineMaskStyle protoLineMaskStyle)
	{
		switch (protoLineMaskStyle)
		{
		case Graphics.Types.Text.Types.LineFillMask.Types.LineMaskStyle.FullWidth:
			return LineMaskStyle.FullWidth;
		case Graphics.Types.Text.Types.LineFillMask.Types.LineMaskStyle.LineWidth:
			return LineMaskStyle.LineWidth;
		case Graphics.Types.Text.Types.LineFillMask.Types.LineMaskStyle.MaxLineWidth:
			return LineMaskStyle.MaxLineWidth;
		default:
			Log.Warning("Found unsupported line mask style, defaulting to full width");
			return LineMaskStyle.FullWidth;
		}
	}
}
