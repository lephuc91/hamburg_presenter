using System;
using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Messages;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Actions;

public class MessageAction : ActionBase, IScrimSource, IActionDataIdentifier, ITimelineItem, ITriggerable, INotifyPropertyChanged
{
	private readonly MessageCollection _messages;

	private Identification _messageIdentification = Identification.Empty();

	public override ActionType ActionType => ActionType.Message;

	public Guid MessageID => _messageIdentification.Id;

	private Identification MessageIdentification
	{
		get
		{
			return _messageIdentification;
		}
		set
		{
			SetValue("MessageIdentification", ref _messageIdentification, value, delegate(Identification o, Identification n)
			{
				base.Name = n.Name;
				OnPropertyChanged("MessageID");
				OnPropertyChanged("IsValid");
				UpdateTokens();
			});
		}
	}

	public MessageTokenCollection Tokens { get; }

	public override bool IsValid
	{
		get
		{
			ProPresenter.DO.Messages.Message message;
			return TryFindMessage(out message);
		}
	}

	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public bool IsEditable => true;

	public ListViewType ListViewType => ListViewType.Content;

	protected override string DefaultName => LocalizedStrings.Get("ACTION_TYPE_MESSAGE_title");

	public TimelineItemType TimelineItemType => TimelineItemType.Actions;

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, MessageAction left, Pro.Entity.IAction right)
	{
		ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> objectBinder = ActionBase.CreateBinder(scheduler, entityFactory, left, right, delegate
		{
		});
		Pro.Entity.IAction.Types.IActionTypeData.IMessage message = right.ActionTypeData.Value as Pro.Entity.IAction.Types.IActionTypeData.IMessage;
		if (message == null)
		{
			message = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.IMessage>();
			right.ActionTypeData.Set(message);
		}
		ObjectBinder<MessageTokenCollection, IComplexCollection<IMessage.Types.ITokenValue>> tokensBinder = MessageTokenCollection.CreateTokenValuesBinder(scheduler, entityFactory, left.Tokens, message.Value.Content);
		ObjectBinder<MessageAction, Pro.Entity.IAction.Types.IMessageType> binder = new ObjectBinder<MessageAction, Pro.Entity.IAction.Types.IMessageType>(left, message.Value);
		binder.Bind((MessageAction l) => l.WhenPropertyChanges("MessageIdentification"), (Pro.Entity.IAction.Types.IMessageType r) => r.MessageIdentificaton.WhenAnyValueChanges, delegate(MessageAction l, Pro.Entity.IAction.Types.IMessageType r)
		{
			r.MessageIdentificaton.Value.ParameterUuid.Set(l.MessageID);
			r.MessageIdentificaton.Value.ParameterName.Set(l.Name);
		}, delegate(Pro.Entity.IAction.Types.IMessageType r, MessageAction l)
		{
			l.MessageIdentification = l.MessageIdentification with
			{
				Id = r.MessageIdentificaton.Value.ParameterUuid.ToGuidOrEmpty(),
				Name = (r.MessageIdentificaton.Value.ParameterName.Value ?? string.Empty)
			};
		}, null, scheduler.Scheduler).DoOnInitializeRightFromLeft(tokensBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(tokensBinder.InitializeLeftFromRight)
			.RegisterChildDisposable(() => tokensBinder);
		objectBinder.DoOnInitializeRightFromLeft(binder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(binder.InitializeLeftFromRight).RegisterChildDisposable(() => binder);
		return objectBinder;
	}

	public MessageAction(MessageCollection? messages = null)
	{
		base.Name = DefaultName;
		Tokens = new MessageTokenCollection();
		Tokens.CollectionModified += base.OnDataModified;
		if (messages != null)
		{
			_messages = messages;
			_messages.CollectionChanged += delegate
			{
				OnPropertyChanged("IsValid");
			};
			_messages.TokensChanged += UpdateTokens;
			_messages.NameChanged += Messages_NameChanged;
		}
	}

	public void SetMessage(ProPresenter.DO.Messages.Message message)
	{
		SetMessage(message.ID, message.Name);
	}

	public void SetMessage(Guid id, string name)
	{
		SetIdentifier(id, name);
	}

	public void SetIdentifier(Guid id, string name)
	{
		if (!(id == MessageID))
		{
			Guid oldID = MessageID;
			string oldName = base.Name;
			base.UndoStack?.Commit(UndoActionTypes.ActionSetMessage.ToAction(), delegate
			{
				MessageIdentification = MessageIdentification with
				{
					Id = oldID,
					Name = oldName
				};
			}, delegate
			{
				MessageIdentification = MessageIdentification with
				{
					Id = id,
					Name = name
				};
			}, null, null, autoFinalize: true);
			MessageIdentification = MessageIdentification with
			{
				Id = id,
				Name = name
			};
		}
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		return CopyProperties(new MessageAction(_messages));
	}

	protected override T CopyProperties<T>(T action)
	{
		if (action is MessageAction messageAction)
		{
			messageAction.SetMessage(MessageID, base.Name);
		}
		return base.CopyProperties(action);
	}

	private bool TryFindMessage(out ProPresenter.DO.Messages.Message? message)
	{
		message = _messages?.FirstOrDefaultBy((ProPresenter.DO.Messages.Message m) => m.ID == MessageID, (ProPresenter.DO.Messages.Message m) => m.Name.Equals(base.Name));
		return message != null;
	}

	private void UpdateTokens()
	{
		base.UndoStack.StartIgnoring();
		if (TryFindMessage(out ProPresenter.DO.Messages.Message message))
		{
			Tokens.Clear();
			message?.Tokens.ForEach(delegate(MessageTokenBase t)
			{
				MessageTokenBase messageTokenBase = (MessageTokenBase)t.Clone();
				messageTokenBase.UndoStack = base.UndoStack;
				Tokens.Add(messageTokenBase);
			});
		}
		base.UndoStack.StopIgnoring();
	}

	private void Messages_NameChanged(ProPresenter.DO.Messages.Message message)
	{
		if (message != null && message.ID == MessageID)
		{
			base.Name = message.Name;
			MessageIdentification = MessageIdentification with
			{
				Name = message.Name
			};
		}
	}

	public override Pro.SerializationInterop.RVProtoData.Action Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Action action = base.Serialize();
		action.Message = new Pro.SerializationInterop.RVProtoData.Action.Types.MessageType
		{
			MessageIdentificaton = (id: MessageID, name: base.Name).ToProtoCollectionElement()
		};
		action.Message.Content.AddRange(Tokens.SerializeTokenValues());
		return action;
	}

	public override void Deserialize(Pro.SerializationInterop.RVProtoData.Action data, ApplicationData? applicationData, string containerId)
	{
		base.Deserialize(data, applicationData, containerId);
		Pro.SerializationInterop.RVProtoData.Action.Types.MessageType messageType = data?.Message;
		if (messageType != null)
		{
			MessageIdentification = MessageIdentification with
			{
				Id = messageType.MessageIdentificaton.ParameterUuid.ToGuid(),
				Name = messageType.MessageIdentificaton.ParameterName
			};
			base.Name = MessageIdentification.Name;
			UpdateTokens();
			Tokens.DeserializeTokenValues(messageType.Content);
		}
	}

	protected override void OnUndoStackChanged(UndoStack undoStack)
	{
		Tokens.UndoStack = undoStack;
	}
}
