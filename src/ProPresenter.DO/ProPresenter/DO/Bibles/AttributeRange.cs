using Pro.Text;

namespace ProPresenter.DO.Bibles;

public class AttributeRange
{
	public AttributeType Type { get; }

	public Range Range { get; }

	public AttributeRange(AttributeType type, Range range)
	{
		Type = type;
		Range = range;
	}
}
