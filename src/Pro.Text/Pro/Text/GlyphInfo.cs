using System.Runtime.InteropServices;
using Pro.Common.Mathematics;

namespace Pro.Text;

internal class GlyphInfo : InternalBase
{
	private static class NativeMethods
	{
		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GlyphInfo_DestroyGlyphInfo")]
		public static extern void DestroyGlyphInfo(nint handle);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GlyphInfo_GetContourCount")]
		public static extern int GetContourCount(nint handle);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GlyphInfo_GetContourPointCount")]
		public static extern int GetContourPointCount(nint handle, int contourIndex);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GlyphInfo_GetPoint")]
		public static extern void GetPoint(nint handle, int contourIndex, int pointIndex, ref double pX, ref double pY, ref double q0X, ref double q0Y, ref double q1X, ref double q1Y);

		[DllImport("PTW.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GlyphInfo_GetBaseline")]
		public static extern double GetBaseline(nint handle);
	}

	private const string ImportPrefix = "GlyphInfo_";

	public double Baseline
	{
		get
		{
			EnsureValid();
			return NativeMethods.GetBaseline(base.Handle);
		}
	}

	internal GlyphInfo(nint handle)
		: base(handle)
	{
	}

	protected override void Destroy()
	{
		NativeMethods.DestroyGlyphInfo(base.Handle);
	}

	public int GetContourCount()
	{
		EnsureValid();
		return NativeMethods.GetContourCount(base.Handle);
	}

	public int GetContourPointCount(int contourIndex)
	{
		EnsureValid();
		return NativeMethods.GetContourPointCount(base.Handle, contourIndex);
	}

	public void GetPoint(int contourIndex, int pointIndex, out Vector2<double> position, out Vector2<double> q0, out Vector2<double> q1)
	{
		EnsureValid();
		double pX = 0.0;
		double pY = 0.0;
		double q0X = 0.0;
		double q0Y = 0.0;
		double q1X = 0.0;
		double q1Y = 0.0;
		NativeMethods.GetPoint(base.Handle, contourIndex, pointIndex, ref pX, ref pY, ref q0X, ref q0Y, ref q1X, ref q1Y);
		position = new Vector2<double>(pX, pY);
		q0 = new Vector2<double>(q0X, q0Y);
		q1 = new Vector2<double>(q1X, q1Y);
	}
}
