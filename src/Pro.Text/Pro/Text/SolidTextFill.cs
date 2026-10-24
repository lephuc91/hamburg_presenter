using System.Windows.Media;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;

namespace Pro.Text;

public class SolidTextFill : TextFillBase
{
	private static readonly System.Windows.Media.Color DefaultColor = Colors.White;

	public override TextFillType TextFillType => TextFillType.SolidColor;

	public override System.Windows.Media.Color PrimaryColor => Color;

	public override bool IsTransparent => Color.A == 0;

	public override bool IsMask => false;

	public System.Windows.Media.Color Color { get; }

	public override void SerializeToEntity(IEntityFactory entityFactory, IComplexObservableProperty<IGraphics.Types.IText.Types.IAttributes.Types.IFill> fill)
	{
		IGraphics.Types.IText.Types.IAttributes.Types.IFill.ITextSolidFill textSolidFill = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes.Types.IFill.ITextSolidFill>();
		textSolidFill.Set(Color.ToEntityColor());
		fill.Set(textSolidFill);
	}

	public override void SerializeToEntity(IEntityFactory entityFactory, IComplexObservableProperty<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute> attributeProperty)
	{
	}

	public override void DeserializeEntity(IGraphics.Types.IText.Types.IAttributes.Types.IFill attribute)
	{
	}

	public override void DeserializeEntity(IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute attribute)
	{
	}

	public SolidTextFill()
		: this(DefaultColor)
	{
	}

	public SolidTextFill(System.Windows.Media.Color color)
	{
		Color = color;
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(TextFillType, Color);
	}

	protected override bool OnEquals(TextFillBase other)
	{
		return Color == ((SolidTextFill)other).Color;
	}

	public override TextFillBase Clone()
	{
		return new SolidTextFill(Color);
	}
}
