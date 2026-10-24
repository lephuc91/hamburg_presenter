using System;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Token;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Messages;

public abstract class MessageTokenBase : TokenBase
{
	public Guid ID { get; protected set; } = Guid.NewGuid();

	public virtual ObjectBinder<MessageTokenBase, IMessage.Types.ITokenValue> BindValue(IUiScheduler scheduler, IEntityFactory entityFactory, IMessage.Types.ITokenValue right)
	{
		ObjectBinder<MessageTokenBase, IMessage.Types.ITokenValue> objectBinder = new ObjectBinder<MessageTokenBase, IMessage.Types.ITokenValue>(this, right);
		objectBinder.Bind((MessageTokenBase l) => l.WhenPropertyChanges("ID"), (IMessage.Types.ITokenValue r) => r.TokenId.WhenValueChanges, delegate(MessageTokenBase l, IMessage.Types.ITokenValue r)
		{
			r.TokenId.Set(l.ID);
		}, delegate(IMessage.Types.ITokenValue r, MessageTokenBase l)
		{
			l.ID = r.TokenId.Value;
		}).Bind((MessageTokenBase l) => l.WhenPropertyChanges("Content"), (IMessage.Types.ITokenValue r) => r.TokenName.WhenValueChanges, delegate(MessageTokenBase l, IMessage.Types.ITokenValue r)
		{
			r.TokenName.Set(l.Content);
		}, delegate(IMessage.Types.ITokenValue r, MessageTokenBase l)
		{
			l.SetNameFromEntity(r.TokenName.Value);
		});
		return objectBinder;
	}

	protected virtual void SetNameFromEntity(string name)
	{
	}

	public Pro.SerializationInterop.RVProtoData.Message.Types.Token SerializeToken()
	{
		Pro.SerializationInterop.RVProtoData.Message.Types.Token token = new Pro.SerializationInterop.RVProtoData.Message.Types.Token
		{
			Uuid = ID.ToUUID()
		};
		OnSerializeToken(token);
		return token;
	}

	protected abstract void OnSerializeToken(Pro.SerializationInterop.RVProtoData.Message.Types.Token token);

	public void DeserializeToken(Pro.SerializationInterop.RVProtoData.Message.Types.Token token)
	{
		ID = token.Uuid.ToGuid();
		OnDeserializeToken(token);
	}

	protected abstract void OnDeserializeToken(Pro.SerializationInterop.RVProtoData.Message.Types.Token token);

	public Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue SerializeTokenValue()
	{
		Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue tokenValue = new Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue
		{
			TokenId = ID.ToUUID(),
			TokenName = Content
		};
		OnSerializeTokenValue(tokenValue);
		return tokenValue;
	}

	protected abstract void OnSerializeTokenValue(Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue tokenValue);

	public void DeserializeTokenValue(Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue tokenValue)
	{
		OnDeserializeTokenValue(tokenValue);
	}

	protected abstract void OnDeserializeTokenValue(Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue tokenValue);
}
