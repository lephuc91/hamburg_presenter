using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Reversibility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Localization;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Triggering;

public class Macro : LinkedNotifyPropertyChangedBase, IMacro, ICloneable<IMacro>, IIdentifiable, INotifyPropertyChanged
{
	private Guid _id = Guid.NewGuid();

	private string _name = string.Empty;

	private Guid _parentCollectionID = Guid.Empty;

	private string _parentCollectionName = string.Empty;

	private UndoStack? _undoStack;

	private System.Windows.Media.Color _color;

	private bool _triggerOnStartup;

	private ImageType _imageType;

	private BitmapSource? _icon;

	public Guid ID
	{
		get
		{
			return _id;
		}
		protected set
		{
			SetValue("ID", ref _id, value, OnDataModified);
		}
	}

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
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MacroName), this, "Name", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public Guid ParentCollectionID
	{
		get
		{
			return _parentCollectionID;
		}
		set
		{
			SetValue("ParentCollectionID", ref _parentCollectionID, value, delegate(Guid o, Guid n)
			{
				OnParentCollectionIdChanged(o, n);
				OnDataModified();
			});
		}
	}

	public string ParentCollectionName
	{
		get
		{
			return _parentCollectionName;
		}
		set
		{
			SetValue("ParentCollectionName", ref _parentCollectionName, value, OnDataModified);
		}
	}

	public System.Windows.Media.Color Color
	{
		get
		{
			return _color;
		}
		set
		{
			SetValue("Color", ref _color, value, delegate(System.Windows.Media.Color o, System.Windows.Media.Color n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MacroColor), this, "Color", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public bool TriggerOnStartup
	{
		get
		{
			return _triggerOnStartup;
		}
		protected set
		{
			SetValue("TriggerOnStartup", ref _triggerOnStartup, value, OnDataModified);
		}
	}

	public ActionCollection Actions { get; }

	public ImageType ImageType
	{
		get
		{
			return _imageType;
		}
		set
		{
			SetValue("ImageType", ref _imageType, value, OnDataModified);
		}
	}

	public BitmapSource? Icon
	{
		get
		{
			return _icon;
		}
		set
		{
			SetValue("Icon", ref _icon, value, OnDataModified);
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
			if (value != null)
			{
				Actions.UndoStack = value;
			}
		}
	}

	public bool IsValid => Actions.All((IAction a) => a.IsValid);

	public event System.Action? DataModified;

	public static ObjectBinder<Macro, IMacrosDocument.Types.IMacro> CreateBinder(IUiScheduler scheduler, IActionBinderFactory actionBinderFactory, IEntityFactory entityFactory, Macro left, IMacrosDocument.Types.IMacro right)
	{
		ObjectBinder<Macro, IMacrosDocument.Types.IMacro> objectBinder = new ObjectBinder<Macro, IMacrosDocument.Types.IMacro>(left, right);
		ObjectBinder<ActionCollection, IComplexCollection<Pro.Entity.IAction>> actionsBinder = ActionCollection.CreateBinder(scheduler, entityFactory, actionBinderFactory, left.Actions, right.Actions);
		objectBinder.Bind((Macro l) => l.WhenPropertyChanges("ID"), (IMacrosDocument.Types.IMacro r) => r.Uuid.WhenValueChanges, delegate(Macro l, IMacrosDocument.Types.IMacro r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IMacrosDocument.Types.IMacro r, Macro l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((Macro l) => l.WhenPropertyChanges("Name"), (IMacrosDocument.Types.IMacro r) => r.Name.WhenValueChanges, delegate(Macro l, IMacrosDocument.Types.IMacro r)
		{
			r.Name.Set(l.Name);
		}, delegate(IMacrosDocument.Types.IMacro r, Macro l)
		{
			l._name = r.Name.Value;
			l.OnPropertyChanged("Name");
			l.OnDataModified();
		}).Bind((Macro l) => l.WhenPropertyChanges("Color"), (IMacrosDocument.Types.IMacro r) => r.Color.WhenValueChanges, delegate(Macro l, IMacrosDocument.Types.IMacro r)
		{
			r.Color.Set(l.Color.ToEntityColor());
		}, delegate(IMacrosDocument.Types.IMacro r, Macro l)
		{
			l._color = r.Color.Value.ToColor();
			l.OnPropertyChanged("Color");
			l.OnDataModified();
		})
			.Bind((Macro l) => l.WhenPropertyChanges("TriggerOnStartup"), (IMacrosDocument.Types.IMacro r) => r.TriggerOnStartup.WhenValueChanges, delegate(Macro l, IMacrosDocument.Types.IMacro r)
			{
				r.TriggerOnStartup.Set(l.TriggerOnStartup);
			}, delegate(IMacrosDocument.Types.IMacro r, Macro l)
			{
				l.TriggerOnStartup = r.TriggerOnStartup.Value;
			})
			.Bind((Macro l) => l.WhenPropertyChanges("ImageType"), (IMacrosDocument.Types.IMacro r) => r.ImageType.WhenValueChanges, delegate(Macro l, IMacrosDocument.Types.IMacro r)
			{
				r.ImageType.Set(l.ImageType.ToEntityImageType());
			}, delegate(IMacrosDocument.Types.IMacro r, Macro l)
			{
				l.ImageType = r.ImageType.Value.ToImageType();
			})
			.Bind((Macro l) => l.WhenPropertyChanges("Icon"), (IMacrosDocument.Types.IMacro r) => r.ImageData.WhenValueChanges, delegate(Macro l, IMacrosDocument.Types.IMacro r)
			{
				r.ImageData.Set(l.Icon?.ToByteArray());
			}, delegate(IMacrosDocument.Types.IMacro r, Macro l)
			{
				l.Icon = r.ImageData.Value?.ToBitmapSource();
			})
			.RegisterChildDisposable(() => actionsBinder)
			.DoOnInitializeLeftFromRight(actionsBinder.InitializeLeftFromRight)
			.DoOnInitializeRightFromLeft(actionsBinder.InitializeRightFromLeft);
		return objectBinder;
	}

	public Macro()
	{
		Actions = new ActionCollection();
		Actions.DataModified += OnDataModified;
		Name = LocalizedStrings.Get("MACROS_WINDOW_NEW_MACRO_name");
		LinkProperties("IsValid", "IsValid");
		LinkProperties("ImageType", "ImageType");
		Actions.CollectionChanged += Actions_CollectionChanged;
		Actions.ForEach(delegate(IAction a)
		{
			a.PropertyChanged += base.RaiseLinkedValues;
		});
	}

	public Macro(UndoStack? undoStack)
		: this()
	{
		UndoStack = undoStack;
	}

	private void Actions_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<IAction>().ForEach(delegate(IAction a)
		{
			a.PropertyChanged -= base.RaiseLinkedValues;
		});
		e.NewItems?.OfType<IAction>().ForEach(delegate(IAction a)
		{
			a.PropertyChanged += base.RaiseLinkedValues;
		});
		OnPropertyChanged("IsValid");
	}

	public void AddAction(IAction action, bool addMediaReferences = false)
	{
		AddActions(action.ToEnumerable(), addMediaReferences);
	}

	public void AddActions(IEnumerable<IAction> actions, bool addMediaReferences = false)
	{
		InsertActions(actions, Actions.Count, addMediaReferences);
	}

	public void InsertActions(IEnumerable<IAction> actions, int index, bool addMediaReferences = false)
	{
		UndoStack?.BeginCommit(UndoActionTypes.AddAction.ToAction());
		actions = actions.NonNull().ToArray();
		int num = index;
		foreach (IAction action in actions)
		{
			Actions.Insert(action, Actions.ClampIndexExclusive(num++));
			OnInsertAction(action, addMediaReferences);
		}
		UndoStack?.Commit(delegate
		{
			RemoveActions(actions);
		}, delegate
		{
			InsertActions(actions, index);
		});
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	protected virtual void OnInsertAction(IAction action, bool addMediaReferences = false)
	{
	}

	public void RemoveAction(IAction action)
	{
		RemoveActions(action.ToEnumerable());
	}

	public void RemoveActions(IEnumerable<IAction> actions)
	{
		if (actions.Empty())
		{
			return;
		}
		UndoStack?.BeginCommit(UndoActionTypes.RemoveAction.ToAction());
		var originalValues = actions.Select((IAction a) => new
		{
			Action = a,
			Index = Actions.IndexOf(a)
		}).ToArray();
		foreach (IAction action in actions)
		{
			if (Actions.Remove(action))
			{
				OnRemoveAction(action);
			}
		}
		UndoStack?.Commit(delegate
		{
			originalValues.ForEach(v =>
			{
				InsertActions(v.Action.ToEnumerable(), v.Index);
			});
		}, delegate
		{
			RemoveActions(actions);
		});
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	protected virtual void OnRemoveAction(IAction action)
	{
	}

	protected virtual void OnParentCollectionIdChanged(Guid oldValue, Guid newValue)
	{
	}

	public MacrosDocument.Types.Macro Serialize()
	{
		MacrosDocument.Types.Macro macro = new MacrosDocument.Types.Macro();
		macro.Uuid = ID.ToUUID();
		macro.Name = Name;
		macro.Color = Color.ToProtoColor();
		macro.TriggerOnStartup = TriggerOnStartup;
		macro.ImageType = ImageType.ToProtoImageType();
		macro.ImageData = Icon?.ToByteString() ?? ByteString.Empty;
		macro.Actions.AddRange(Actions.Select((IAction a) => a.Serialize()));
		return macro;
	}

	public void Deserialize(MacrosDocument.Types.Macro protoMacro, ApplicationData? applicationData)
	{
		ID = protoMacro.Uuid.ToGuid();
		Name = protoMacro.Name;
		Color = protoMacro.Color.ToColor();
		TriggerOnStartup = protoMacro.TriggerOnStartup;
		Actions.Deserialize(protoMacro.Actions, applicationData, MediaContainerIds.Macro(ParentCollectionID));
		ImageType = protoMacro.ImageType.ToImageType();
		Icon = protoMacro.ImageData.ToBitmapSource();
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public virtual IMacro Clone()
	{
		return CopyProperties(new Macro());
	}

	protected virtual Macro CopyProperties(Macro macro)
	{
		macro.Name = Name;
		macro.Color = Color;
		macro.ImageType = ImageType;
		Actions.CloneItems().ForEach(macro.Actions.Add);
		return macro;
	}
}
