using System.ComponentModel;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Token;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Messages;

public class TextToken : MessageTokenBase
{
	public MessageTextData TextData { get; }

	public override string Content => TextData.Name;

	public string Text
	{
		get
		{
			return TextData.Text;
		}
		set
		{
			string text = TextData.Text;
			TextData.Text = value;
			base.UndoStack?.Commit(UndoActionTypes.MessageText.ToAction(), this, "Text", text, value);
		}
	}

	public override ObjectBinder<MessageTokenBase, IMessage.Types.ITokenValue> BindValue(IUiScheduler scheduler, IEntityFactory entityFactory, IMessage.Types.ITokenValue right)
	{
		IMessage.Types.ITokenValue.Types.ITokenValueType.IText text = right.TokenValueType.Value as IMessage.Types.ITokenValue.Types.ITokenValueType.IText;
		if (text == null)
		{
			text = entityFactory.Create<IMessage.Types.ITokenValue.Types.ITokenValueType.IText>();
			right.TokenValueType.Set(text);
		}
		ObjectBinder<TextToken, IMessage.Types.ITokenValue.Types.ITokenValueText> textBinder = new ObjectBinder<TextToken, IMessage.Types.ITokenValue.Types.ITokenValueText>(this, text.Value);
		textBinder.Bind((TextToken l) => l.WhenPropertyChanges("Text"), (IMessage.Types.ITokenValue.Types.ITokenValueText r) => r.Value.WhenValueChanges, delegate(TextToken l, IMessage.Types.ITokenValue.Types.ITokenValueText r)
		{
			r.Value.Set(l.Text);
		}, delegate(IMessage.Types.ITokenValue.Types.ITokenValueText r, TextToken l)
		{
			l.Text = r.Value.Value;
		});
		ObjectBinder<MessageTokenBase, IMessage.Types.ITokenValue> objectBinder = base.BindValue(scheduler, entityFactory, right);
		objectBinder.DoOnInitializeRightFromLeft(textBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(textBinder.InitializeLeftFromRight).RegisterChildDisposable(() => textBinder);
		return objectBinder;
	}

	protected override void SetNameFromEntity(string name)
	{
		TextData.Name = name;
	}

	public TextToken(string name, string text)
		: this(new MessageTextData(name, text))
	{
	}

	public TextToken(MessageTextData textData)
	{
		TextData = textData;
		LinkProperties("Text", "Text");
		LinkProperties("Name", "Content");
		TextData.PropertyChanged += delegate(object? s, PropertyChangedEventArgs e)
		{
			RaiseLinkedValues(s, e);
			OnDataModified();
		};
	}

	public override TokenBase Clone()
	{
		return CopyProperties(new TextToken(TextData.Clone())
		{
			ID = base.ID
		});
	}

	protected override void OnSerializeToken(Pro.SerializationInterop.RVProtoData.Message.Types.Token token)
	{
		token.Text = new Pro.SerializationInterop.RVProtoData.Message.Types.Token.Types.TokenTypeText
		{
			Name = Content
		};
	}

	protected override void OnDeserializeToken(Pro.SerializationInterop.RVProtoData.Message.Types.Token token)
	{
	}

	protected override void OnSerializeTokenValue(Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue tokenValue)
	{
		tokenValue.Text = new Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue.Types.TokenValueText
		{
			Value = TextData.Text
		};
	}

	protected override void OnDeserializeTokenValue(Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue tokenValue)
	{
		TextData.Text = tokenValue.Text.Value;
	}
}
