using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class SlideLabelExtensions
{
	public static Action.Types.Label ToProto(this IAction.Types.ILabel label)
	{
		Action.Types.Label label2 = new Action.Types.Label();
		if (label.Text.Value != null)
		{
			label2.Text = label.Text.Value;
		}
		if ((object)label.Color.Value != null)
		{
			label2.Color = label.Color.Value.ToProtoColor();
		}
		return label2;
	}

	public static IAction.Types.ILabel ToEntity(this Action.Types.Label protoLabel, IEntityFactory entityFactory)
	{
		IAction.Types.ILabel label = entityFactory.Create<IAction.Types.ILabel>();
		label.Text.Set(protoLabel.Text);
		label.Color.Set(protoLabel.Color?.ToEntityColor());
		return label;
	}
}
