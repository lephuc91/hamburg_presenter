using ProPresenterCore.ProCore.Interop;

namespace Pro.ssAPI.Devices;

public static class ColorFormatExtensions
{
	public static ColorFormat ToColorFormat(this ProMediaColorFormat format)
	{
		return format switch
		{
			ProMediaColorFormat.SDR => ColorFormat.Sdr, 
			ProMediaColorFormat.HDRRec2100Hlg => ColorFormat.HdrRec2100HLG, 
			ProMediaColorFormat.HDRRec2100Pq => ColorFormat.HdrRec2100PQ, 
			_ => ColorFormat.Sdr, 
		};
	}
}
