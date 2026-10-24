using System;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Label;

public class ActionLabel : LabelBase<ActionLabel>, IIdentifiable
{
	public Guid ID { get; private set; } = Guid.NewGuid();

	public string Name
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
		}
	}

	public static ObjectBinder<ActionLabel, IAction.Types.ILabel> CreateBinder(ActionLabel left, IAction.Types.ILabel right)
	{
		return new ObjectBinder<ActionLabel, IAction.Types.ILabel>(left, right).Bind((ActionLabel l) => l.WhenPropertyChanges("Text"), (IAction.Types.ILabel r) => r.Text.WhenValueChanges, delegate(ActionLabel l, IAction.Types.ILabel r)
		{
			r.Text.Set(l.Text);
		}, delegate(IAction.Types.ILabel r, ActionLabel l)
		{
			l.Text = r.Text.Value ?? string.Empty;
		}).Bind((ActionLabel l) => l.WhenPropertyChanges("Color"), (IAction.Types.ILabel r) => r.Color.WhenValueChanges, delegate(ActionLabel l, IAction.Types.ILabel r)
		{
			r.Color.Set(l.Color?.ToEntityColor());
		}, delegate(IAction.Types.ILabel r, ActionLabel l)
		{
			l.Color = r.Color.Value?.ToColor();
		});
	}

	private ActionLabel()
		: this(string.Empty)
	{
	}

	public ActionLabel(string text)
		: this(text, null)
	{
	}

	public ActionLabel(string text, System.Windows.Media.Color? color)
		: base(text, color)
	{
	}

	public override ActionLabel Clone()
	{
		return CopyProperties(new ActionLabel());
	}

	public string Encode()
	{
		return base.Text + "|" + (base.Color.HasValue ? base.Color.Value.EncodeColor() : string.Empty);
	}

	public static ActionLabel Decode(string label)
	{
		string[] array = label.Split('|');
		string text = array[0];
		System.Windows.Media.Color? color = (string.IsNullOrEmpty(array[1]) ? ((System.Windows.Media.Color?)null) : new System.Windows.Media.Color?(array[1].DecodeColor()));
		return new ActionLabel(text, color);
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Action.Types.Label data)
	{
		OnDeserialize(data.Text, data.Color?.ToColor());
	}

	public Pro.SerializationInterop.RVProtoData.Action.Types.Label Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Action.Types.Label
		{
			Text = base.Text,
			Color = base.OriginalColor?.ToProtoColor()
		};
	}
}
