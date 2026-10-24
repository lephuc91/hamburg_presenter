using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Token;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Messages;

public class MessageTokenCollection : TokenCollection<MessageTokenBase>
{
	public static ObjectBinder<MessageTokenCollection, IComplexCollection<IMessage.Types.ITokenValue>> CreateTokenValuesBinder(IUiScheduler scheduler, IEntityFactory entityFactory, MessageTokenCollection left, IComplexCollection<IMessage.Types.ITokenValue>? right)
	{
		ObjectBinder<MessageTokenCollection, IComplexCollection<IMessage.Types.ITokenValue>> objectBinder = new ObjectBinder<MessageTokenCollection, IComplexCollection<IMessage.Types.ITokenValue>>(left, right);
		objectBinder.Bind((MessageTokenCollection l) => l.Collection.WhenCollectionChanges(), (IComplexCollection<IMessage.Types.ITokenValue> r) => r.WhenCollectionChanges, delegate(MessageTokenCollection l, IComplexCollection<IMessage.Types.ITokenValue> r)
		{
			r.SynchronizeFrom(l, (MessageTokenBase m, IMessage.Types.ITokenValue e) => m.ID == e.TokenId.Value, delegate(MessageTokenBase m)
			{
				IMessage.Types.ITokenValue tokenValue = entityFactory.Create<IMessage.Types.ITokenValue>();
				ObjectBinder<MessageTokenBase, IMessage.Types.ITokenValue> objectBinder2 = m.BindValue(scheduler, entityFactory, tokenValue);
				objectBinder2.InitializeRightFromLeft();
				tokenValue.RegisterLinkedDisposable(objectBinder2);
				return tokenValue;
			});
		}, delegate(IComplexCollection<IMessage.Types.ITokenValue> r, MessageTokenCollection l)
		{
			r.Items.SynchronizeTo(l, (IMessage.Types.ITokenValue e, MessageTokenBase m) => m.ID == e.TokenId.Value, delegate(IMessage.Types.ITokenValue e, int i)
			{
				MessageTokenBase messageTokenBase = CreateTokenFromValue(e);
				ObjectBinder<MessageTokenBase, IMessage.Types.ITokenValue> objectBinder3 = messageTokenBase.BindValue(scheduler, entityFactory, e);
				objectBinder3.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(objectBinder3);
				l.Insert(i, messageTokenBase);
			}, l.Collection.Move, delegate(int i)
			{
				MessageTokenBase messageTokenBase2 = l.ElementAtOrDefault(i);
				if (messageTokenBase2 != null)
				{
					l.Remove(messageTokenBase2);
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	private static MessageTokenBase CreateTokenFromValue(IMessage.Types.ITokenValue e)
	{
		IMessage.Types.ITokenValue.Types.ITokenValueType value = e.TokenValueType.Value;
		if (!(value is IMessage.Types.ITokenValue.Types.ITokenValueType.IText text))
		{
			if (!(value is IMessage.Types.ITokenValue.Types.ITokenValueType.ITimer))
			{
				if (value is IMessage.Types.ITokenValue.Types.ITokenValueType.IClock)
				{
					return new ClockToken();
				}
				throw new NotSupportedException($"Type {e} is not supported");
			}
			return new TimerToken(Guid.NewGuid(), string.Empty);
		}
		return new TextToken(e.TokenName.Value, text.Value.Value.Value);
	}

	public IEnumerable<Pro.SerializationInterop.RVProtoData.Message.Types.Token> SerializeTokens()
	{
		return base.Collection.Select((MessageTokenBase t) => t.SerializeToken());
	}

	public IEnumerable<Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue> SerializeTokenValues()
	{
		return base.Collection.Select((MessageTokenBase t) => t.SerializeTokenValue());
	}

	public void DeserializeTokens(IEnumerable<Pro.SerializationInterop.RVProtoData.Message.Types.Token> tokens)
	{
		base.UndoStack?.StartIgnoring();
		base.Collection.DeserializeCollection(tokens, (MessageTokenBase t, Pro.SerializationInterop.RVProtoData.Message.Types.Token p) => t.ID == p.Uuid.ToGuid(), DeserializeToken, delegate(MessageTokenBase t)
		{
			Add(t);
		}, delegate(MessageTokenBase t)
		{
			Remove(t);
		}, delegate(MessageTokenBase t, Pro.SerializationInterop.RVProtoData.Message.Types.Token p)
		{
			t.DataModified -= base.OnCollectionModified;
			t.DeserializeToken(p);
			t.DataModified += base.OnCollectionModified;
		});
		base.UndoStack?.StopIgnoring();
	}

	public void DeserializeTokenValues(IEnumerable<Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue> tokenValues)
	{
		if (tokenValues == null)
		{
			return;
		}
		base.UndoStack?.StartIgnoring();
		foreach (Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue tokenValue in tokenValues)
		{
			DeserializeTokenValue(tokenValue);
		}
		base.UndoStack?.StopIgnoring();
	}

	private MessageTokenBase DeserializeToken(Pro.SerializationInterop.RVProtoData.Message.Types.Token token)
	{
		return token.TokenTypeCase switch
		{
			Pro.SerializationInterop.RVProtoData.Message.Types.Token.TokenTypeOneofCase.Text => new TextToken(new MessageTextData(token.Text.Name, string.Empty)), 
			Pro.SerializationInterop.RVProtoData.Message.Types.Token.TokenTypeOneofCase.Timer => new TimerToken(token.Timer.TimerUuid.ToGuid(), token.Timer.Name), 
			Pro.SerializationInterop.RVProtoData.Message.Types.Token.TokenTypeOneofCase.Clock => new ClockToken(), 
			_ => throw new NotSupportedException(), 
		};
	}

	private void DeserializeTokenValue(Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue tokenValue)
	{
		if (tokenValue != null)
		{
			base.Collection.FirstOrDefaultBy((MessageTokenBase t) => t.ID == tokenValue.TokenId.ToGuid(), (MessageTokenBase t) => t.Content == tokenValue.TokenName)?.DeserializeTokenValue(tokenValue);
		}
	}
}
