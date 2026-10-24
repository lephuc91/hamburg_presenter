using System.Windows.Media;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public class OutputScreenFill : FillBase
{
	public override FillType Type => FillType.OutputScreen;

	public override string DisplayName => string.Empty;

	public override IFill Clone()
	{
		return new OutputScreenFill();
	}

	public override Color Sample()
	{
		return Colors.Transparent;
	}
}
