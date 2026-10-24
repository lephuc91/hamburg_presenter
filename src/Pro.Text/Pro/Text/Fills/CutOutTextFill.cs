using System.Windows.Media;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;

namespace Pro.Text.Fills;

public class CutOutTextFill : TextFillBase
{
	public override bool IsTransparent => false;

	public override System.Windows.Media.Color PrimaryColor => Colors.White;

	public override TextFillType TextFillType => TextFillType.CutOut;

	public override bool IsMask => true;

	public override void SerializeToEntity(IEntityFactory entityFactory, IComplexObservableProperty<IGraphics.Types.IText.Types.IAttributes.Types.IFill> fill)
	{
		IGraphics.Types.IText.Types.IAttributes.Types.IFill.ICutOutFill value = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes.Types.IFill.ICutOutFill>();
		fill.Set(value);
	}

	public override void SerializeToEntity(IEntityFactory entityFactory, IComplexObservableProperty<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute> attributeProperty)
	{
		IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ICutOutFill value = entityFactory.Create<IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute.ICutOutFill>();
		attributeProperty.Set(value);
	}

	public override void DeserializeEntity(IGraphics.Types.IText.Types.IAttributes.Types.IFill attribute)
	{
	}

	public override void DeserializeEntity(IGraphics.Types.IText.Types.IAttributes.Types.ICustomAttribute.Types.IAttribute attribute)
	{
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(TextFillType);
	}

	protected override bool OnEquals(TextFillBase other)
	{
		return true;
	}

	public override TextFillBase Clone()
	{
		return new CutOutTextFill();
	}
}
