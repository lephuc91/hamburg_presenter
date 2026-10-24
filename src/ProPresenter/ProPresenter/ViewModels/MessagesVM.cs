using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Strings;
using Pro.Common.Time;
using Pro.Common.ToastNotifications;
using Pro.Common.Utility;
using Pro.DO.Token;
using Pro.DO.Transitions;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.DialogService;
using ProPresenter.Controller;
using ProPresenter.Controller.NetworkAPI.Receive;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Messages;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Timer;
using ProPresenter.DO.Transitions;
using ProPresenter.UI;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class MessagesVM : LinkedNotifyPropertyChangedBase, IMessagesVM, INotifyPropertyChanged
{
	private const string NetworkMessagesURLFormat = "http://{0}.local:{1}/html/pages/messages";

	private readonly ICoreManager _manager;

	private readonly IApp _app;

	private readonly ITriggering _service;

	private bool _isEditing = MessagesPreferences.Settings.IsEditing;

	private Message? _selectedMessage;

	private TemplateSlide? _fallbackTemplate;

	private Message? _activeMessage;

	private bool _renameNextItem;

	private string _addTokenText = string.Empty;

	private readonly IServerStateHandler _serverStateHandler;

	private readonly INetwork _network;

	private readonly IToastNotificationService _toastNotificationService;

	private readonly RelayCommand _showMessageCommand;

	private readonly RelayCommand _clearMessageCommand;

	public IReadOnlyList<TimeSlice> RemoveTimes { get; } = new global::_003C_003Ez__ReadOnlyArray<TimeSlice>(new TimeSlice[7]
	{
		TimeSlice.FromSeconds(5.0),
		TimeSlice.FromSeconds(10.0),
		TimeSlice.FromSeconds(15.0),
		TimeSlice.FromSeconds(20.0),
		TimeSlice.FromSeconds(30.0),
		TimeSlice.FromSeconds(45.0),
		TimeSlice.FromSeconds(60.0)
	});

	public IEnumerable<Message> ActiveMessages => _manager.ActiveMessages.ToArray();

	public MessageCollection Messages { get; }

	public bool HasMessages => Messages.Any();

	public TokenCollection<MessageTokenBase> AvailableTokens { get; } = new TokenCollection<MessageTokenBase>();

	public IEnumerable<TimerToken> Timers => DataVault.TimerDocument.Timers.Select((TimerData t) => new TimerToken(t));

	public ssAPIOutput OutputController { get; }

	public TemplateSlide? SelectedTemplate => ActiveMessage?.SelectedTemplate ?? _fallbackTemplate;

	public bool IsEditing
	{
		get
		{
			return _isEditing;
		}
		set
		{
			SetValue("IsEditing", ref _isEditing, value, delegate(bool _, bool n)
			{
				MessagesPreferences.Settings.IsEditing = n;
			});
		}
	}

	public string Text
	{
		get
		{
			return ActiveMessage?.Text ?? string.Empty;
		}
		set
		{
			if (ActiveMessage != null && ActiveMessage.Text != value)
			{
				ActiveMessage.Text = value;
				MessagesEditEvent.Publish(MessageEditAction.SetText);
			}
		}
	}

	public bool IsVisibleOnNetwork
	{
		get
		{
			return ActiveMessage?.IsVisibleOnNetwork ?? false;
		}
		set
		{
			if (ActiveMessage != null && ActiveMessage.IsVisibleOnNetwork != value)
			{
				ActiveMessage.IsVisibleOnNetwork = value;
				MessagesEditEvent.Publish(MessageEditAction.SetWebNotification);
			}
		}
	}

	public Message? ActiveMessage
	{
		get
		{
			return _activeMessage;
		}
		set
		{
			SetValue<Message>("ActiveMessage", ref _activeMessage, value, delegate(Message o, Message n)
			{
				MessagesPreferences.Settings.SelectedMessageID = n?.ID ?? Guid.Empty;
				if (o != null)
				{
					o.PropertyChanged -= base.RaiseLinkedValues;
					o.Tokens.CollectionChanged -= OnTokensCollectionChanged;
				}
				if (n != null)
				{
					n.PropertyChanged += base.RaiseLinkedValues;
					n.Tokens.CollectionChanged += OnTokensCollectionChanged;
				}
				OnPropertyChanged("SelectedTemplate");
				OnPropertyChanged("DismissalLabel");
				OnPropertyChanged("Text");
				OnPropertyChanged("IsVisibleOnNetwork");
				OnPropertyChanged("ActiveMessageTokens");
				_showMessageCommand.NotifyCanExecuteChanged();
				_clearMessageCommand.NotifyCanExecuteChanged();
				AddTokenText = string.Empty;
			});
		}
	}

	public IEnumerable<MessageTokenBase>? ActiveMessageTokens => ActiveMessage?.Tokens.ToArray();

	public Message? SelectedMessage
	{
		get
		{
			return _selectedMessage;
		}
		set
		{
			SetValue("SelectedMessage", ref _selectedMessage, value);
		}
	}

	public ObservableCollection<Message> SelectedMessages { get; } = new ObservableCollection<Message>();

	public TransitionHandler TransitionHandler { get; } = new TransitionHandler(DataVault.Transitions);

	public TransitionParameters? SelectedTransition
	{
		get
		{
			return _manager.MessagesTransition;
		}
		set
		{
			_manager.MessagesTransition = value;
			_app.GlobalMessageTransition = value?.Serialize();
		}
	}

	public TimerCollection TimerCollection => DataVault.TimerDocument.Timers;

	public string? DismissalLabel => GetDismissalLabel();

	public bool RenameNextItem
	{
		get
		{
			return _renameNextItem;
		}
		set
		{
			SetValue("RenameNextItem", ref _renameNextItem, value);
		}
	}

	public string AddTokenText
	{
		get
		{
			return _addTokenText;
		}
		set
		{
			SetValue("AddTokenText", ref _addTokenText, value);
		}
	}

	public ICommand AddMessageCommand => new RelayCommand(OnAddMessageCommand);

	public ICommand ShowMessageCommand => _showMessageCommand;

	public ICommand ClearMessageCommand => _clearMessageCommand;

	public ICommand<TimerData?> StartCommand => new RelayCommand<TimerData>(delegate(TimerData? t)
	{
		OnTriggerTime(t, TimerActionType.Start);
	}, (TimerData? t) => t != null);

	public ICommand<TimerData?> StopCommand => new RelayCommand<TimerData>(delegate(TimerData? t)
	{
		OnTriggerTime(t, TimerActionType.Stop);
	}, (TimerData? t) => t != null);

	public ICommand<TimerData?> ResetCommand => new RelayCommand<TimerData>(delegate(TimerData? t)
	{
		OnTriggerTime(t, TimerActionType.Reset);
	}, (TimerData? t) => t != null);

	public ICommand<TemplateSlide> SelectTemplateCommand => new RelayCommand<TemplateSlide>(OnSelectTemplateCommand);

	public ICommand ClearAllMessagesCommand => new RelayCommand(OnClearAllMessagesCommand, () => ActiveMessages.Any());

	public ICommand ClearSelectedMessagesCommand => new RelayCommand(OnClearSelectedMessagesCommand, () => ActiveMessages.Any((Message a) => SelectedMessages.Any((Message m) => m.ID == a.ID)));

	public ICommand<MessageClearType> SetMessageClearTypeCommand => new RelayCommand<MessageClearType>(OnSetMessageClearTypeCommand, (MessageClearType c) => ActiveMessage != null);

	public ICommand<TimeSlice> SetMessageClearTimeCommand => new RelayCommand<TimeSlice>(OnSetMessageClearTimeCommand, (TimeSlice t) => ActiveMessage != null);

	public ICommand OpenNetworkMessagesCommand => new RelayCommand(OpenNetworkMessages, () => _toastNotificationService.CanSendToasts);

	public ICommand GotFocusCommand => new RelayCommand(delegate
	{
		this.StackChanged?.Invoke(Messages.UndoStack);
	});

	public ICommand<bool> DocumentChangeStartedCommand => new RelayCommand<bool>(OnDocumentChangedStarted);

	public ICommand<bool> DocumentChangeEndedCommand => new RelayCommand<bool>(OnDocumentChangedEnded);

	public ICommand<Message?> SelectMessageCommand => new RelayCommand<Message>(delegate(Message? m)
	{
		ActiveMessage = m;
	}, (Message? m) => m != null);

	public ICommand CutCommand => new RelayCommand(OnCutCommand, () => SelectedMessages.Any());

	public ICommand CopyCommand => new RelayCommand(OnCopyCommand, () => SelectedMessages.Any());

	public ICommand PasteCommand => new RelayCommand(OnPasteCommand, () => ClipboardManagerHelper.CanPasteIntoCollection<Message>());

	public ICommand DuplicateCommand => new RelayCommand(OnDuplicateCommand, () => SelectedMessages.Any());

	public ICommand DeleteCommand => new RelayCommand(OnDeleteCommand, () => SelectedMessages.Any());

	public ICommand<MessageTokenBase> AddTokenCommand => new RelayCommand<MessageTokenBase>(OnAddTokenCommand, (MessageTokenBase t) => ActiveMessage != null);

	public ICommand<string> AddCustomTokenCommand => new RelayCommand<string>(OnAddCustomTokenCommand, (string t) => ActiveMessage != null);

	public event Action<UndoStack?>? StackChanged;

	public MessagesVM(ICoreManager manager, ssAPIOutput outputController, IApp app, IProPresenterResourceService resourceService, ITriggeringFactory triggeringFactory, IServerStateHandler serverStateHandler, INetwork network, IToastNotificationService toastNotificationService, IThemeCollection themes)
	{
		_manager = manager;
		_serverStateHandler = serverStateHandler;
		_network = network;
		_toastNotificationService = toastNotificationService;
		_service = triggeringFactory.Create();
		OutputController = outputController;
		_app = app;
		Messages = resourceService.Messages;
		_fallbackTemplate = themes.DefaultTheme.FirstOrDefault();
		SetupManager();
		_showMessageCommand = new RelayCommand(OnShowMessageCommand, () => ActiveMessage != null && _manager.ActiveMessages.All((Message m) => m.ID != ActiveMessage.ID));
		_clearMessageCommand = new RelayCommand(OnHideMessageCommand, () => ActiveMessage != null && _manager.ActiveMessages.Any((Message m) => m.ID == ActiveMessage.ID));
		HookupLinkedProperties();
		LoadTransition();
		LoadAvailableTokens();
		LoadMessages();
	}

	private void OnTokensCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnPropertyChanged("ActiveMessageTokens");
	}

	private void SetupManager()
	{
		_manager.ActiveMessages.CollectionChanged += delegate
		{
			OnPropertyChanged("ActiveMessages");
			_showMessageCommand.NotifyCanExecuteChanged();
			_clearMessageCommand.NotifyCanExecuteChanged();
		};
		_manager.PropertyChanged += base.RaiseLinkedValues;
	}

	private void LoadMessages()
	{
		ActiveMessage = Messages.FirstOrDefault((Message m) => m.ID == MessagesPreferences.Settings.SelectedMessageID) ?? Messages.FirstOrDefault();
		Messages.LocationChanged += delegate
		{
			SelectedMessage = Messages.FirstOrDefault();
		};
	}

	private void LoadTransition()
	{
		SelectedTransition = _app.GlobalMessageTransition?.ToTransition(OutputController.AvailableTransitions) ?? DataVault.Transitions?.CutTransition?.LoadParameters();
		if (SelectedTransition != null)
		{
			TransitionHandler.ActivateTransition(SelectedTransition);
		}
		TransitionHandler.TransitionFinalized += delegate(TransitionParameters? t)
		{
			SelectedTransition = t;
		};
	}

	private void LoadAvailableTokens()
	{
		AvailableTokens.Clear();
		MessagesPreferences.Settings.DefaultTokens?.ForEach(delegate(MessageTextData t)
		{
			AvailableTokens.Add(new TextToken(t.Name, t.Text));
		});
		AvailableTokens.Add(new ClockToken());
	}

	private void HookupLinkedProperties()
	{
		LinkProperties("MessagesTransition", "SelectedTransition");
		LinkProperties(new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "TimeToRemove", "ClearType" }), "DismissalLabel");
		LinkProperties("Text", "Text");
		LinkProperties("SelectedTemplate", "SelectedTemplate");
		LinkProperties("IsVisibleOnNetwork", "IsVisibleOnNetwork");
		LinkAction("DefaultTokens", LoadAvailableTokens);
		MessagesPreferences.Settings.PropertyChanged += base.RaiseLinkedValues;
		if (DataVault.TimerDocument?.Timers != null)
		{
			DataVault.TimerDocument.Timers.CollectionChanged += delegate
			{
				OnPropertyChanged("Timers");
			};
		}
		Messages.CollectionChanged += delegate
		{
			OnPropertyChanged("HasMessages");
			if ((ActiveMessage != null && !Messages.Contains(ActiveMessage)) || ActiveMessage == null)
			{
				ActiveMessage = Messages.FirstOrDefaultBy((Message m) => m.ID == MessagesPreferences.Settings.SelectedMessageID, (Message _) => true);
			}
		};
	}

	private void OnShowMessageCommand()
	{
		if (ActiveMessage != null)
		{
			_service.TriggerMessage(ActiveMessage);
			MessagesStateEvent.Publish(MessageState.Show);
		}
	}

	private void OnHideMessageCommand()
	{
		if (ActiveMessage != null)
		{
			_service.ClearMessage(ActiveMessage);
			MessagesStateEvent.Publish(MessageState.Clear);
		}
	}

	private void OnAddMessageCommand()
	{
		RenameNextItem = true;
		Message message = Messages.AddNewMessage(LocalizedStrings.Get("MESSAGES_WINDOW_NEW_MESSAGE_name").DuplicateName(Messages.Select((Message m) => m.Name), (string s) => s));
		message.SelectedTemplate = SelectedTemplate;
		ActiveMessage = message;
		MessagesCreateEvent.Publish();
	}

	private void OnSelectTemplateCommand(TemplateSlide template)
	{
		if (ActiveMessage != null)
		{
			ActiveMessage.SelectedTemplate = template;
		}
		else
		{
			_fallbackTemplate = template;
		}
		OnPropertyChanged("SelectedTemplate");
		MessagesEditEvent.Publish(MessageEditAction.SetTheme);
	}

	private void OnClearAllMessagesCommand()
	{
		_service.ClearMessages();
	}

	private void OnClearSelectedMessagesCommand()
	{
		foreach (Message activeMessage in ActiveMessages)
		{
			if (SelectedMessages.Any((Message m) => m.ID == activeMessage.ID))
			{
				_service.ClearMessage(activeMessage);
			}
		}
	}

	private void OnSetMessageClearTypeCommand(MessageClearType clearType)
	{
		ActiveMessage.ClearType = clearType;
		if (clearType == MessageClearType.Manual || clearType == MessageClearType.AfterTimers)
		{
			ActiveMessage.TimeToRemove = TimeSlice.FromSeconds(-1.0);
		}
		MessagesEditEvent.Publish(MessageEditAction.SetDismissBehavior);
	}

	private void OnSetMessageClearTimeCommand(TimeSlice time)
	{
		if (ActiveMessage != null)
		{
			ActiveMessage.TimeToRemove = time;
			ActiveMessage.ClearType = MessageClearType.AfterTime;
			MessagesEditEvent.Publish(MessageEditAction.SetDismissBehavior);
		}
	}

	private void OnTriggerTime(TimerData? timer, TimerActionType timerActionType)
	{
		if (timer != null)
		{
			_service.TriggerTimerAction(timer, timerActionType, null);
		}
	}

	private void OpenNetworkMessages()
	{
		int port = _network.GetPort(_serverStateHandler.State.ConnectedPort);
		if (_network.EnableNetwork)
		{
			ProcessHelper.StartProcess($"http://{Dns.GetHostName()}.local:{port}/html/pages/messages");
		}
		else
		{
			MessageDialogService.ShowDialog(LocalizedStrings.Get("MESSAGES_WINDOW_NETWORK_ALERT_title"), LocalizedStrings.Get("MESSAGES_WINDOW_NETWORK_ALERT_label"), DefaultButtons.OK, DefaultButtons.OK);
		}
	}

	private void OnDocumentChangedStarted(bool isTokens)
	{
		Messages.UndoStack.BeginCommit((isTokens ? UndoActionTypes.MessageToken : UndoActionTypes.MessageText).ToAction());
	}

	private void OnDocumentChangedEnded(bool autoFinalize)
	{
		Messages.UndoStack.EndCommit(null, null, autoFinalize);
	}

	private string? GetDismissalLabel()
	{
		if (ActiveMessage == null)
		{
			return null;
		}
		return ActiveMessage.ClearType switch
		{
			MessageClearType.Manual => LocalizedStrings.Get("MESSAGES_WINDOW_DISMISS_OPTION_MANUAL_title"), 
			MessageClearType.AfterTimers => LocalizedStrings.Get("MESSAGES_WINDOW_DISMISS_OPTION_AFTER_TIMER_EXPIRES_title"), 
			MessageClearType.AfterTime => LocalizedStrings.Get("MESSAGES_WINDOW_DISMISS_OPTION_AFTER_TIME_label", new object[1] { ActiveMessage.TimeToRemove.TotalSeconds }), 
			_ => throw new NotSupportedException(), 
		};
	}

	private void OnCutCommand()
	{
		OnCopyCommand();
		OnDeleteCommand();
	}

	private void OnCopyCommand()
	{
		Message[] array = SelectedMessages.OrderBy((Message m) => Messages.IndexOf(m)).ToArray();
		if (array.Any())
		{
			ClipboardManagerHelper.CopyFromCollection(array);
		}
	}

	private void OnPasteCommand()
	{
		Message message = SelectedMessages.OrderBy((Message s) => Messages.IndexOf(s)).LastOrDefault() ?? ActiveMessage;
		IEnumerable<Message> pastedMessages = ClipboardManagerHelper.PasteIntoCollection<MessageCollection, Message>(Messages, (message != null) ? (Messages.IndexOf(message) + 1) : 0);
		SelectedMessages.Clear();
		SelectedMessages.AddRange(Messages.Where((Message m) => pastedMessages.Contains(m)));
	}

	private void OnDuplicateCommand()
	{
		OnCopyCommand();
		OnPasteCommand();
	}

	private void OnDeleteCommand()
	{
		Message[] array = SelectedMessages.ToArray();
		bool flag = ActiveMessage != null && array.Contains<Message>(ActiveMessage);
		int val = (flag ? Messages.IndexOf(ActiveMessage) : (-1));
		Message[] array2 = array;
		foreach (Message message in array2)
		{
			Messages.RemoveMessage(message);
		}
		if (flag)
		{
			ActiveMessage = Messages.ElementAtOrDefault(Math.Min(val, Messages.Count - 1)) ?? Messages.FirstOrDefault();
		}
		MessagesDeleteEvent.Publish();
	}

	private void OnAddTokenCommand(MessageTokenBase token)
	{
		AddToken(token);
		MessageEditAction? messageEditAction = tryGetAction();
		if (messageEditAction.HasValue)
		{
			MessageEditAction valueOrDefault = messageEditAction.GetValueOrDefault();
			MessagesEditEvent.Publish(valueOrDefault);
		}
		MessageEditAction? tryGetAction()
		{
			if (token is TextToken)
			{
				return MessageEditAction.AddTextToken;
			}
			if (token is TimerToken)
			{
				return MessageEditAction.AddTimerToken;
			}
			return null;
		}
	}

	private void OnAddCustomTokenCommand(string name)
	{
		AddToken(new TextToken(name, string.Empty));
		MessagesEditEvent.Publish(MessageEditAction.AddCustomToken);
	}

	private void AddToken(MessageTokenBase token)
	{
		token.Index = ActiveMessage.Text.Length + ActiveMessage.Tokens.Count;
		ActiveMessage.Tokens.Add(token);
	}
}
