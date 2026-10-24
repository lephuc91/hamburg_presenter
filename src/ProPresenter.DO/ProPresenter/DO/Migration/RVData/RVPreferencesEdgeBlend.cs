using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVPreferencesEdgeBlend
{
	[Child]
	[Alias("BlendMode", typeof(int), false)]
	public int BlendMode { get; internal set; }

	[Child]
	[Alias("CenterCircle", typeof(bool), false)]
	public bool CenterCircle { get; internal set; }

	[Child]
	[Alias("CenterLines", typeof(bool), false)]
	public bool CenterLines { get; internal set; }

	[Child]
	[Alias("EnableEdgeBlending", typeof(bool), false)]
	public bool EnableEdgeBlending { get; internal set; }

	[Child]
	[Alias("Gamma", typeof(double), false)]
	public double Gamma { get; internal set; }

	[Child]
	[Alias("GridOverlay", typeof(bool), false)]
	public bool GridOverlay { get; internal set; }

	[Child]
	[Alias("GridSizeText", typeof(int), false)]
	public int GridSizeText { get; internal set; }

	[Child]
	[Alias("Intensity", typeof(int), false)]
	public int Intensity { get; internal set; }

	[Child]
	[Alias("MinBlackLevel", typeof(int), false)]
	public int MinBlackLevel { get; internal set; }

	[Child]
	[Alias("NumberOfProjectors", typeof(int), false)]
	public int NumberOfProjectors { get; internal set; }

	[Child]
	[Alias("Radius", typeof(int), false)]
	public int Radius { get; internal set; }

	[Child]
	[Alias("ScreenRatioHeight", typeof(int), false)]
	public int ScreenRatioHeight { get; internal set; }

	[Child]
	[Alias("ScreenRatioWidth", typeof(int), false)]
	public int ScreenRatioWidth { get; internal set; }
}
