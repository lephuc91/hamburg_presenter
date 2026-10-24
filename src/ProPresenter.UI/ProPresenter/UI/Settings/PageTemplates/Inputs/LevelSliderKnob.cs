using Pro.DO.Audio;
using Pro.UI.Controls;

namespace ProPresenter.UI.Settings.PageTemplates.Inputs;

public class LevelSliderKnob : SliderKnob<double>
{
	public LevelSliderKnob()
	{
		base.Minimum = -60.0;
		base.Maximum = 6.0;
		base.IncrementScalar = 0.3;
	}

	protected override double ScaleValue(double value)
	{
		return ConversionHelper.DecibelsToPowerFeatureRange(value);
	}
}
