using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class LabelExtesions
{
	public static Action.Types.Label ToProtoLabel(this IAction.Types.ILabel source)
	{
		Action.Types.Label label = new Action.Types.Label();
		if (source.Text.Value != null)
		{
			label.Text = source.Text.Value;
		}
		if ((object)source.Color.Value != null)
		{
			label.Color = source.Color.Value.ToProtoColor();
		}
		return label;
	}

	public static IAction.Types.ILabel ToEntityLabel(this Action.Types.Label source, IEntityFactory entityFactory)
	{
		IAction.Types.ILabel label = entityFactory.Create<IAction.Types.ILabel>();
		label.Text.Set(source.Text);
		label.Color.Set(source.Color?.ToEntityColor());
		return label;
	}
}
