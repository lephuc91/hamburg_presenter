using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Entity.Merged.Entities;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Events;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Messages;

public class Message : NotifyPropertyChangedBase, ITriggerable, ICloneable<Message>, IIdentifiable
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass46_0
	{
		public int[] tokenIndexGrouping;

		public Func<MessageTokenBase, int> _003C_003E9__3;

		internal global::_003C_003Ef__AnonymousType1<MessageTokenBase, int> _003CEncodeToComponents_003Eb__2(MessageTokenBase t)
		{
			return new
			{
				Token = t,
				Index = t.Index - tokenIndexGrouping.IndexOf(t.Index)
			};
		}

		internal int _003CEncodeToComponents_003Eb__3(MessageTokenBase t)
		{
			return t.Index - tokenIndexGrouping.IndexOf(t.Index);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass46_1
	{
		public TimerToken timerToken;

		internal bool _003CEncodeToComponents_003Eb__4(TimerData t)
		{
			return t.ID == timerToken.Timer.ID;
		}

		internal bool _003CEncodeToComponents_003Eb__5(TimerData t)
		{
			return t.Name == timerToken.Timer.Name;
		}
	}

	[CompilerGenerated]
	private sealed class _003CEncodeToComponents_003Ed__46 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private string _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public Message _003C_003E4__this;

		private bool isFormatting;

		public bool _003C_003E3__isFormatting;

		private string textFormat;

		public string _003C_003E3__textFormat;

		private string timerFormat;

		public string _003C_003E3__timerFormat;

		private bool serializing;

		public bool _003C_003E3__serializing;

		private IEnumerator<IGrouping<int, MessageTokenBase>> _003C_003E7__wrap1;

		private IGrouping<int, MessageTokenBase> _003CindexGroup_003E5__3;

		private int _003Cindex_003E5__4;

		private IEnumerator<MessageTokenBase> _003C_003E7__wrap4;

		string IEnumerator<string>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CEncodeToComponents_003Ed__46(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if ((uint)(num - -4) <= 1u || (uint)(num - 1) <= 4u)
			{
				try
				{
					if (num == -4 || (uint)(num - 2) <= 3u)
					{
						try
						{
						}
						finally
						{
							_003C_003Em__Finally2();
						}
					}
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003CindexGroup_003E5__3 = null;
			_003C_003E7__wrap4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				Message message = _003C_003E4__this;
				int num2;
				string empty;
				switch (num)
				{
				default:
					return false;
				case 0:
				{
					_003C_003E1__state = -1;
					_003C_003Ec__DisplayClass46_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass46_0();
					IOrderedEnumerable<MessageTokenBase> source = message.Tokens.OrderBy((MessageTokenBase t) => t.Index);
					CS_0024_003C_003E8__locals3.tokenIndexGrouping = source.Select((MessageTokenBase t) => t.Index).Distinct().ToArray();
					source.Select((MessageTokenBase t) => new
					{
						Token = t,
						Index = t.Index - CS_0024_003C_003E8__locals3.tokenIndexGrouping.IndexOf(t.Index)
					});
					empty = string.Empty;
					num2 = 0;
					_003C_003E7__wrap1 = (from t in source
						group t by t.Index - CS_0024_003C_003E8__locals3.tokenIndexGrouping.IndexOf(t.Index)).GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_039b;
				}
				case 1:
					_003C_003E1__state = -3;
					goto IL_0174;
				case 2:
					_003C_003E1__state = -4;
					goto IL_036f;
				case 3:
					_003C_003E1__state = -4;
					goto IL_036f;
				case 4:
					_003C_003E1__state = -4;
					goto IL_036f;
				case 5:
					_003C_003E1__state = -4;
					goto IL_036f;
				case 6:
					{
						_003C_003E1__state = -1;
						break;
					}
					IL_036f:
					while (_003C_003E7__wrap4.MoveNext())
					{
						MessageTokenBase current = _003C_003E7__wrap4.Current;
						if (isFormatting)
						{
							string text = ((current is TextToken) ? textFormat : ((current is TimerToken || current is ClockToken) ? timerFormat : null));
							if (text != null && current != null)
							{
								MessageTokenBase messageTokenBase = current;
								string arg = (serializing ? messageTokenBase.ID.ToString() : current.Content);
								_003C_003E2__current = string.Format(text, arg);
								_003C_003E1__state = 2;
								return true;
							}
							continue;
						}
						if (current is TextToken textToken)
						{
							_003C_003E2__current = textToken.TextData.Text;
							_003C_003E1__state = 3;
							return true;
						}
						_003C_003Ec__DisplayClass46_1 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass46_1
						{
							timerToken = (current as TimerToken)
						};
						if (CS_0024_003C_003E8__locals8.timerToken != null)
						{
							TimerData timerData = DataVault.TimerDocument?.Timers.FirstOrDefaultBy((TimerData t) => t.ID == CS_0024_003C_003E8__locals8.timerToken.Timer.ID, (TimerData t) => t.Name == CS_0024_003C_003E8__locals8.timerToken.Timer.Name);
							_003C_003E2__current = ((timerData == null || timerData.Active == null) ? string.Empty : (CS_0024_003C_003E8__locals8.timerToken.Format?.FormatTime(timerData.Active.RunningTime) ?? string.Empty));
							_003C_003E1__state = 4;
							return true;
						}
						if (current is ClockToken clockToken)
						{
							_003C_003E2__current = clockToken.ClockData.FormatDateTime(DateTime.Now);
							_003C_003E1__state = 5;
							return true;
						}
					}
					_003C_003Em__Finally2();
					_003C_003E7__wrap4 = null;
					num2 = _003Cindex_003E5__4;
					_003CindexGroup_003E5__3 = null;
					goto IL_039b;
					IL_0174:
					_003C_003E7__wrap4 = _003CindexGroup_003E5__3.GetEnumerator();
					_003C_003E1__state = -4;
					goto IL_036f;
					IL_039b:
					if (_003C_003E7__wrap1.MoveNext())
					{
						_003CindexGroup_003E5__3 = _003C_003E7__wrap1.Current;
						_003Cindex_003E5__4 = _003CindexGroup_003E5__3.Key;
						empty = new string(message.Text.Skip(num2).Take(_003Cindex_003E5__4 - num2).ToArray());
						if (!string.IsNullOrEmpty(empty))
						{
							_003C_003E2__current = empty;
							_003C_003E1__state = 1;
							return true;
						}
						goto IL_0174;
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap1 = null;
					empty = new string(message.Text.Skip(num2).Take(message.Text.Length - num2).ToArray());
					if (!string.IsNullOrEmpty(empty))
					{
						_003C_003E2__current = empty;
						_003C_003E1__state = 6;
						return true;
					}
					break;
				}
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		private void _003C_003Em__Finally2()
		{
			_003C_003E1__state = -3;
			if (_003C_003E7__wrap4 != null)
			{
				_003C_003E7__wrap4.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			_003CEncodeToComponents_003Ed__46 _003CEncodeToComponents_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CEncodeToComponents_003Ed__ = this;
			}
			else
			{
				_003CEncodeToComponents_003Ed__ = new _003CEncodeToComponents_003Ed__46(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003CEncodeToComponents_003Ed__.textFormat = _003C_003E3__textFormat;
			_003CEncodeToComponents_003Ed__.timerFormat = _003C_003E3__timerFormat;
			_003CEncodeToComponents_003Ed__.isFormatting = _003C_003E3__isFormatting;
			_003CEncodeToComponents_003Ed__.serializing = _003C_003E3__serializing;
			return _003CEncodeToComponents_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	private const string TokenFormat = "${{{0}}}";

	private string _name = string.Empty;

	private string _text = string.Empty;

	private bool _isVisibleOnNetwork;

	private TimeSlice _timeToRemove;

	private TemplateSlide? _selectedTemplate;

	private Guid? _templateID;

	private string _templateName = string.Empty;

	private MessageClearType _clearType;

	private UndoStack? _undoStack;

	private readonly IThemeCollection _themes;

	public Guid ID { get; protected set; } = Guid.NewGuid();

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, value, delegate(string o, string n)
			{
				UndoStack?.Commit(UndoActionTypes.RenameMessage.ToAction(), this, "Name", o, n, null, null, autoFinalize: true);
				OnDataModified("Name");
			});
		}
	}

	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			SetValue("Text", ref _text, value, delegate(string o, string n)
			{
				UndoStack?.Commit(UndoActionTypes.MessageText.ToAction(), this, "Text", o, n);
				OnDataModified("Text");
			});
		}
	}

	public bool IsVisibleOnNetwork
	{
		get
		{
			return _isVisibleOnNetwork;
		}
		set
		{
			SetValue("IsVisibleOnNetwork", ref _isVisibleOnNetwork, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(UndoActionTypes.MessageNetWorkVisible.ToAction(), this, "IsVisibleOnNetwork", o, n, null, null, autoFinalize: true);
				OnDataModified("IsVisibleOnNetwork");
			});
		}
	}

	public MessageTokenCollection Tokens { get; } = new MessageTokenCollection();

	public TimeSlice TimeToRemove
	{
		get
		{
			return _timeToRemove;
		}
		set
		{
			SetValue("TimeToRemove", ref _timeToRemove, value, delegate(TimeSlice o, TimeSlice n)
			{
				UndoStack?.Commit(UndoActionTypes.MessageTimeToRemove.ToAction(), this, "TimeToRemove", o, n, null, null, autoFinalize: true);
				OnDataModified("TimeToRemove");
			});
		}
	}

	public TemplateSlide? SelectedTemplate
	{
		get
		{
			if (_templateID.HasValue && _templateID != _selectedTemplate?.Slide.ID)
			{
				_selectedTemplate = _themes.FindTemplate(_templateID.Value, _templateName, useDefault: false);
				if (_selectedTemplate != null)
				{
					_templateID = _selectedTemplate.Slide?.ID;
					_templateName = _selectedTemplate.Name;
					_selectedTemplate.DataModified += OnTemplateDataModified;
				}
			}
			return _selectedTemplate ?? _themes.DefaultTheme.FirstOrDefault();
		}
		set
		{
			SetValue<TemplateSlide>("SelectedTemplate", ref _selectedTemplate, value, delegate(TemplateSlide o, TemplateSlide n)
			{
				if (o != null)
				{
					o.DataModified -= OnTemplateDataModified;
				}
				if (n != null)
				{
					n.DataModified += OnTemplateDataModified;
				}
				_templateID = n?.Slide.ID;
				_templateName = n?.Name ?? string.Empty;
				UndoStack?.Commit(UndoActionTypes.MessageTemplate.ToAction(), this, "SelectedTemplate", o, n, null, null, autoFinalize: true);
				OnDataModified("SelectedTemplate");
			});
		}
	}

	public MessageClearType ClearType
	{
		get
		{
			return _clearType;
		}
		set
		{
			SetValue("ClearType", ref _clearType, value, delegate(MessageClearType o, MessageClearType n)
			{
				UndoStack?.Commit(UndoActionTypes.MessageClearType.ToAction(), this, "ClearType", o, n, null, null, autoFinalize: true);
				OnDataModified("ClearType");
			});
		}
	}

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			Tokens.UndoStack = value;
		}
	}

	public event System.Action? DataModified;

	public IReadOnlyObjectBinder<Message, IMergedMessage> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IMergedMessage entity)
	{
		ObjectBinder<MessageTokenCollection, IComplexCollection<IMessage.Types.ITokenValue>> objectBinder = MessageTokenCollection.CreateTokenValuesBinder(scheduler, entityFactory, Tokens, entity.TokenValues);
		ObjectBinder<Message, IMergedMessage> objectBinder2 = new ObjectBinder<Message, IMergedMessage>(this, entity);
		objectBinder2.Bind((Message l) => l.WhenPropertyChanges("ID"), (IMergedMessage r) => r.Uuid.WhenValueChanges, delegate(Message l, IMergedMessage r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IMergedMessage r, Message l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((Message l) => l.WhenPropertyChanges("Name"), (IMergedMessage r) => r.Title.WhenValueChanges, delegate(Message l, IMergedMessage r)
		{
			r.Title.Set(l.Name);
		}, delegate(IMergedMessage r, Message l)
		{
			l.SetValue("Name", ref l._name, r.Title.Value, (Action<string, string>?)delegate
			{
				l.OnDataModified("Name");
			}, (Predicate<string>?)null, referenceComparison: false);
		}).Bind((Message l) => l.WhenPropertyChanges("IsVisibleOnNetwork"), (IMergedMessage r) => r.VisibleOnNetwork.WhenValueChanges, delegate(Message l, IMergedMessage r)
		{
			r.VisibleOnNetwork.Set(l.IsVisibleOnNetwork);
		}, delegate(IMergedMessage r, Message l)
		{
			l.SetValue("IsVisibleOnNetwork", ref l._isVisibleOnNetwork, r.VisibleOnNetwork.Value, (Action<bool, bool>?)delegate
			{
				l.OnDataModified("IsVisibleOnNetwork");
			}, (Predicate<bool>?)null, referenceComparison: false);
		})
			.Bind((Message l) => l.WhenPropertyChanges("TimeToRemove"), (IMergedMessage r) => r.TimeToRemove.WhenValueChanges, delegate(Message l, IMergedMessage r)
			{
				r.TimeToRemove.Set(l.TimeToRemove.TotalSeconds);
			}, delegate(IMergedMessage r, Message l)
			{
				l.SetValue("TimeToRemove", ref l._timeToRemove, TimeSlice.FromSeconds(r.TimeToRemove.Value), (Action<TimeSlice, TimeSlice>?)delegate
				{
					l.OnDataModified("TimeToRemove");
				}, (Predicate<TimeSlice>?)null, referenceComparison: false);
			})
			.Bind((Message l) => l.WhenPropertyChanges("ClearType"), (IMergedMessage r) => r.ClearType.WhenValueChanges, delegate(Message l, IMergedMessage r)
			{
				r.ClearType.Set(l.ClearType.ToEntityClearType());
			}, delegate(IMergedMessage r, Message l)
			{
				l.SetValue("ClearType", ref l._clearType, r.ClearType.Value.ToMessageClearType(), (Action<MessageClearType, MessageClearType>?)delegate
				{
					l.OnDataModified("ClearType");
				}, (Predicate<MessageClearType>?)null, referenceComparison: false);
			})
			.Bind((Message l) => l.WhenPropertyChanges("SelectedTemplate"), (IMergedMessage r) => r.Template.WhenAnyValueChanges, delegate(Message l, IMergedMessage r)
			{
				ITemplateIdentification templateIdentification = r.Template.Value;
				if (templateIdentification == null)
				{
					templateIdentification = entityFactory.Create<ITemplateIdentification>();
					r.Template.Set(templateIdentification);
				}
				templateIdentification.SlideUuid.Set(l._templateID ?? Guid.Empty);
				templateIdentification.SlideName.Set(l._templateName);
			}, delegate(IMergedMessage r, Message l)
			{
				l._templateID = r.Template.Value?.SlideUuid.Value;
				l._templateName = r.Template.Value?.SlideName.Value ?? string.Empty;
				l.OnPropertyChanged("SelectedTemplate");
				l.OnDataModified("SelectedTemplate");
			})
			.DoOnInitializeLeftFromRight(objectBinder.InitializeLeftFromRight)
			.DoOnInitializeRightFromLeft(objectBinder.InitializeRightFromLeft)
			.RegisterChildDisposable(new CompositeDisposable { objectBinder });
		return objectBinder2;
	}

	[GeneratedRegex("\\$\\{([a-zA-Z0-9\\-]+)\\}")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex GuidToken()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__GuidToken_15.Instance;
	}

	public Message(IThemeCollection themes)
	{
		_themes = themes;
		Tokens.CollectionModified += Tokens_CollectionModified;
	}

	private void Tokens_CollectionModified()
	{
		OnDataModified("Tokens");
	}

	[IteratorStateMachine(typeof(_003CEncodeToComponents_003Ed__46))]
	public IEnumerable<string> EncodeToComponents(string textFormat = "${{{0}}}", string timerFormat = "${{{0}}}", bool isFormatting = true, bool serializing = false)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CEncodeToComponents_003Ed__46(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__textFormat = textFormat,
			_003C_003E3__timerFormat = timerFormat,
			_003C_003E3__isFormatting = isFormatting,
			_003C_003E3__serializing = serializing
		};
	}

	public Pro.SerializationInterop.RVProtoData.Message Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Message message = new Pro.SerializationInterop.RVProtoData.Message();
		message.Uuid = ID.ToUUID();
		message.Title = Name;
		message.VisibleOnNetwork = IsVisibleOnNetwork;
		message.Template = new TemplateIdentification
		{
			SlideUuid = _templateID?.ToUUID(),
			SlideName = (_templateName ?? string.Empty)
		};
		message.TimeToRemove = TimeToRemove.TotalSeconds;
		message.ClearType = ClearType.ToProtoMessageClearType();
		message.MessageText = string.Join(string.Empty, EncodeToComponents("${{{0}}}", "${{{0}}}", isFormatting: true, serializing: true));
		message.Tokens.AddRange(Tokens.SerializeTokens());
		message.TokenValues.AddRange(Tokens.SerializeTokenValues());
		return message;
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Message protoMessage)
	{
		ID = protoMessage.Uuid.ToGuid();
		Name = protoMessage.Title;
		IsVisibleOnNetwork = protoMessage.VisibleOnNetwork;
		TimeToRemove = TimeSlice.FromSeconds(protoMessage.TimeToRemove);
		ClearType = protoMessage.ClearType.ToMessageClearType();
		_templateID = protoMessage.Template?.SlideUuid?.ToGuid();
		_templateName = protoMessage.Template?.SlideName ?? string.Empty;
		Text = GuidToken().Replace(protoMessage.MessageText, string.Empty);
		Tokens.CollectionModified -= Tokens_CollectionModified;
		Tokens.DeserializeTokens(protoMessage.Tokens);
		Tokens.DeserializeTokenValues(protoMessage.TokenValues);
		DecodeComponents(protoMessage.MessageText);
		Tokens.SortTokens(Tokens.OrderBy((MessageTokenBase t) => t.Index).ToArray());
		Tokens.CollectionModified += Tokens_CollectionModified;
	}

	private void DecodeComponents(string serializedText)
	{
		int num = 0;
		int num2 = 0;
		foreach (Match item in GuidToken().Matches(serializedText))
		{
			string value = item.Groups[1].Value;
			if (item.Success && Guid.TryParse(value, out var id))
			{
				MessageTokenBase messageTokenBase = Tokens.OfType<MessageTokenBase>().FirstOrDefault((MessageTokenBase t) => t.ID == id);
				if (messageTokenBase != null)
				{
					messageTokenBase.Index = item.Index + num - (value.Length + 3) * num2;
					num2++;
					num++;
				}
			}
		}
	}

	public void NotifyThemeChanged()
	{
		OnPropertyChanged("SelectedTemplate");
	}

	private void OnTemplateDataModified(string propName, TemplateSlide slide)
	{
		OnDataModified(propName);
	}

	private void OnDataModified(string propName)
	{
		this.DataModified?.Invoke();
		MessageUpdated.Publish(this);
	}

	public Message Clone()
	{
		Pro.SerializationInterop.RVProtoData.Message protoMessage = Serialize();
		Message message = new Message(_themes);
		message.Deserialize(protoMessage);
		message.ID = Guid.NewGuid();
		return message;
	}
}
