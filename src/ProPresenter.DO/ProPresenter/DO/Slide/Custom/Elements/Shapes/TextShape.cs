using System.Windows.Media;
using Pro.DO.Utility;
using Pro.Localization;
using Pro.Text;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Slide.Custom.Elements.Shapes;

public class TextShape : RectangleShape
{
	protected override double CenteringScalar => 0.75;

	public override string DefaultShapeName => LocalizedStrings.Get("GLOBAL_SHAPE_TEXT");

	public TextShape(IProPresenterDOFactoryProvider factoryProvider, string containerId, bool useDefaultSettings = true)
		: this(factoryProvider.MediaFactory, factoryProvider.TextDocumentFactory, containerId, useDefaultSettings)
	{
	}

	private TextShape(IMediaFactory mediaFactory, ITextDocumentFactory textDocumentFactory, string containerId, bool useDefaultSettings)
		: base(mediaFactory, textDocumentFactory, containerId)
	{
		base.AdditionalInfo |= AdditionalInfo.Text;
		if (!useDefaultSettings)
		{
			return;
		}
		if (base.Fill != null)
		{
			base.Fill.IsEnabled = false;
		}
		if (base.Text != null)
		{
			base.Text.Settings.ScaleMode = ScaleMode.None;
			base.Text.IterateRuns(Range.All, splitRuns: false, delegate(RunBase r)
			{
				r.Settings.Fill = new SolidTextFill(Colors.White);
			});
		}
	}

	public override SlideElementBase Clone()
	{
		TextShape textShape = new TextShape(base.MediaFactory, base.TextDocumentFactory, base.ContainerId, useDefaultSettings: false);
		CopyProperties(textShape);
		return textShape;
	}
}
