using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Looks;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Actions;

public class AudienceLookAction : ActionBase, IScrimSource, IActionDataIdentifier, ITimelineItem, ITriggerable, INotifyPropertyChanged
{
	private Identification _lookIdentification = Identification.Empty();

	private readonly IAudienceLookCollection _audienceLooks;

	public override ActionType ActionType => ActionType.AudienceLook;

	public Guid LookID => LookIdentification.Id;

	public string LookName => LookIdentification.Name;

	private Identification LookIdentification
	{
		get
		{
			return _lookIdentification;
		}
		set
		{
			SetValue("LookIdentification", ref _lookIdentification, value, (Action<Identification, Identification>?)delegate
			{
				OnPropertyChanged("LookID");
				OnPropertyChanged("LookName");
				OnPropertyChanged("IsValid");
				OnDataModified();
			}, (Predicate<Identification>?)null, referenceComparison: false);
		}
	}

	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public ListViewType ListViewType => ListViewType.Content;

	public bool IsEditable => true;

	public override bool IsValid => _audienceLooks.FirstOrDefaultBy((AudienceLook l) => l.ID == LookID, (AudienceLook l) => l.Name.Equals(LookName)) != null;

	protected override bool CanRename => false;

	protected override string DefaultName => LocalizedStrings.Get("ACTION_TYPE_AUDIENCE_LOOK_title");

	public TimelineItemType TimelineItemType => TimelineItemType.Actions;

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, AudienceLookAction left, Pro.Entity.IAction right)
	{
		ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> objectBinder = ActionBase.CreateBinder(scheduler, entityFactory, left, right, delegate
		{
		});
		Pro.Entity.IAction.Types.IActionTypeData.IAudienceLook audienceLook = right.ActionTypeData.Value as Pro.Entity.IAction.Types.IActionTypeData.IAudienceLook;
		if (audienceLook == null)
		{
			audienceLook = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.IAudienceLook>();
			right.ActionTypeData.Set(audienceLook);
		}
		ObjectBinder<AudienceLookAction, Pro.Entity.IAction.Types.IAudienceLookType> audienceLookActionBinder = new ObjectBinder<AudienceLookAction, Pro.Entity.IAction.Types.IAudienceLookType>(left, audienceLook.Value);
		audienceLookActionBinder.Bind((AudienceLookAction l) => l.WhenPropertyChanges("LookIdentification"), (Pro.Entity.IAction.Types.IAudienceLookType r) => r.Identification.WhenAnyValueChanges, delegate(AudienceLookAction model, Pro.Entity.IAction.Types.IAudienceLookType entity)
		{
			entity.Identification.Value.ParameterUuid.Set(model.LookID);
			entity.Identification.Value.ParameterName.Set(model.LookName);
		}, delegate(Pro.Entity.IAction.Types.IAudienceLookType entity, AudienceLookAction model)
		{
			model.LookIdentification = model.LookIdentification with
			{
				Id = entity.Identification.Value.ParameterUuid.ToGuidOrEmpty(),
				Name = (entity.Identification.Value.ParameterName.Value ?? string.Empty)
			};
		}, null, scheduler.Scheduler);
		objectBinder.DoOnInitializeRightFromLeft(audienceLookActionBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(audienceLookActionBinder.InitializeLeftFromRight).RegisterChildDisposable(() => audienceLookActionBinder);
		return objectBinder;
	}

	public AudienceLookAction(IAudienceLookCollection audienceLooks)
	{
		_audienceLooks = audienceLooks;
		_audienceLooks.ForEach(delegate(AudienceLook l)
		{
			l.PropertyChanged += AudienceLook_PropertyChanged;
		});
		_audienceLooks.CollectionChanged += AudienceLooks_CollectionChanged;
	}

	public void SetIdentifier(Guid id, string name)
	{
		Guid oldId = LookID;
		string oldName = LookName;
		base.UndoStack?.Commit(UndoActionTypes.ActionSetLook.ToAction(), delegate
		{
			LookIdentification = LookIdentification with
			{
				Id = oldId,
				Name = oldName
			};
		}, delegate
		{
			LookIdentification = LookIdentification with
			{
				Id = id,
				Name = name
			};
		}, null, null, autoFinalize: true);
		LookIdentification = LookIdentification with
		{
			Id = id,
			Name = name
		};
	}

	public override Pro.DO.Triggering.IAction Clone()
	{
		return CopyProperties(new AudienceLookAction(_audienceLooks));
	}

	protected override T CopyProperties<T>(T action)
	{
		if (action is AudienceLookAction audienceLookAction)
		{
			audienceLookAction.SetIdentifier(LookID, LookName);
		}
		return base.CopyProperties(action);
	}

	public override Pro.SerializationInterop.RVProtoData.Action Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Action action = base.Serialize();
		action.AudienceLook = new Pro.SerializationInterop.RVProtoData.Action.Types.AudienceLookType
		{
			Identification = new CollectionElementType
			{
				ParameterUuid = LookID.ToUUID(),
				ParameterName = (LookName ?? string.Empty)
			}
		};
		return action;
	}

	public override void Deserialize(Pro.SerializationInterop.RVProtoData.Action data, ApplicationData? applicationData, string containerId)
	{
		if (data?.AudienceLook != null)
		{
			base.Deserialize(data, applicationData, containerId);
			Pro.SerializationInterop.RVProtoData.Action.Types.AudienceLookType audienceLook = data.AudienceLook;
			LookIdentification = LookIdentification with
			{
				Id = (audienceLook.Identification.ParameterUuid?.ToGuid() ?? Guid.Empty),
				Name = audienceLook.Identification.ParameterName
			};
		}
	}

	private void AudienceLooks_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<AudienceLook>().ForEach(delegate(AudienceLook l)
		{
			l.PropertyChanged -= AudienceLook_PropertyChanged;
		});
		e.NewItems?.OfType<AudienceLook>().ForEach(delegate(AudienceLook l)
		{
			l.PropertyChanged += AudienceLook_PropertyChanged;
		});
		OnPropertyChanged("IsValid");
	}

	private void AudienceLook_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string? propertyName = e.PropertyName;
		if (propertyName != null && propertyName.Equals("Name"))
		{
			UpdateName(sender as AudienceLook);
			OnPropertyChanged("IsValid");
		}
	}

	private void UpdateName(AudienceLook? look)
	{
		if (look != null && !(look.ID != LookID))
		{
			LookIdentification = LookIdentification with
			{
				Name = look.Name
			};
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_audienceLooks.ForEach(delegate(AudienceLook l)
			{
				l.PropertyChanged -= AudienceLook_PropertyChanged;
			});
			_audienceLooks.CollectionChanged -= AudienceLooks_CollectionChanged;
		}
		base.Dispose(disposing);
	}
}
