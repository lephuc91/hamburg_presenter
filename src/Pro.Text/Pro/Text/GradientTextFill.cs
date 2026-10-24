using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;

namespace Pro.Text;

public class GradientTextFill : TextFillBase
{
	private static readonly System.Windows.Media.Color DefaultStartColor = System.Windows.Media.Color.FromArgb(byte.MaxValue, 2, 91, 233);

	private static readonly System.Windows.Media.Color DefaultEndColor = System.Windows.Media.Color.FromArgb(byte.MaxValue, 2, 196, 250);

	private static readonly Angle<double> DefaultAngle = new Angle<double>(315.0, isCartesian: true);

	public override TextFillType TextFillType => TextFillType.Gradient;

	public override System.Windows.Media.Color PrimaryColor => StartColor;

	public override bool IsTransparent
	{
		get
		{
			if (StartColor.A == 0)
			{
				return EndColor.A == 0;
			}
			return false;
		}
	}

	public override bool IsMask => false;

	public System.Windows.Media.Color StartColor { get; }

	public System.Windows.Media.Color EndColor { get; }

	public Angle<double> Angle { get; }

	public bool StretchToDocumentBounds { get; }

	public override void SerializeToEntity(IEntityFactory entityFactory, IComplexObservableProperty<IGraphics.Types.IText.Types.IAttributes.Types.IFill> fill)
	{
		IGraphics.Types.IText.Types.IAttributes.Types.IFill.ITextGradientFill textGradientFill = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes.Types.IFill.ITextGradientFill>();
		SerializeToEntity(entityFactory, textGradientFill.Value);
		fill.Set(textGradientFill);
	}

	public override void SerializeToEntity(IEntityFactory entityFactory, IComplexObservableProperty<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute> attributeProperty)
	{
		IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ITextGradientFill textGradientFill = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ITextGradientFill>();
		SerializeToEntity(entityFactory, textGradientFill.Value);
		attributeProperty.Set(textGradientFill);
	}

	private void SerializeToEntity(IEntityFactory entityFactory, IGraphics.Types.IText.Types.IGradientFill gradient)
	{
		gradient.Gradient.Value.Angle.Set(Angle.Value);
		gradient.StretchToDocumentBounds.Set(StretchToDocumentBounds);
		IGraphics.Types.IGradient.Types.IColorStop colorStop = entityFactory.Create<IGraphics.Types.IGradient.Types.IColorStop>();
		colorStop.Color.Set(StartColor.ToEntityColor());
		gradient.Gradient.Value.Stops.Add(colorStop);
		IGraphics.Types.IGradient.Types.IColorStop colorStop2 = entityFactory.Create<IGraphics.Types.IGradient.Types.IColorStop>();
		colorStop2.Color.Set(EndColor.ToEntityColor());
		gradient.Gradient.Value.Stops.Add(colorStop2);
	}

	public override void DeserializeEntity(IGraphics.Types.IText.Types.IAttributes.Types.IFill attribute)
	{
	}

	public override void DeserializeEntity(IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute attribute)
	{
	}

	public GradientTextFill()
		: this(DefaultStartColor, DefaultEndColor, DefaultAngle, stretchToDocumentBounds: false)
	{
	}

	public GradientTextFill(System.Windows.Media.Color startColor, System.Windows.Media.Color endColor, Angle<double> angle, bool stretchToDocumentBounds)
	{
		StartColor = startColor;
		EndColor = endColor;
		Angle = angle;
		StretchToDocumentBounds = stretchToDocumentBounds;
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(TextFillType, StartColor, EndColor, Angle, StretchToDocumentBounds);
	}

	protected override bool OnEquals(TextFillBase other)
	{
		GradientTextFill gradientTextFill = (GradientTextFill)other;
		if (StartColor == gradientTextFill.StartColor && EndColor == gradientTextFill.EndColor && Angle == gradientTextFill.Angle)
		{
			return StretchToDocumentBounds == gradientTextFill.StretchToDocumentBounds;
		}
		return false;
	}

	public override TextFillBase Clone()
	{
		return new GradientTextFill(StartColor, EndColor, Angle, StretchToDocumentBounds);
	}
}
