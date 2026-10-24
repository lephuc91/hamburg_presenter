using System;
using System.ComponentModel;
using System.Reactive.Linq;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Actions;

public abstract class PlaylistAction : ActionBase, IScrimSource, IActionDataIdentifier, ITimelineItem, ITriggerable, INotifyPropertyChanged
{
	private IPlaylistActionValidatorFactory? _validatorFactory;

	private IPlaylistActionValidator? _validator;

	private bool _alwaysRetrigger;

	private Identification _playlistIdenfication = Identification.Empty();

	private Identification? _playlistItemIdentification;

	public override bool IsValid => _validator?.IsValid ?? false;

	protected override bool CanRename => false;

	public ScrimPosition Position => ScrimPosition.TopLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public bool IsEditable => true;

	public ListViewType ListViewType => ListViewType.Content;

	public Guid PlaylistID => PlaylistIdentification.Id;

	public string PlaylistName => PlaylistIdentification.Name;

	public Guid PlaylistItemID => PlaylistItemIdentification?.Id ?? Guid.Empty;

	public string PlaylistItemName => PlaylistItemIdentification?.Name ?? PlaylistName;

	public Identification PlaylistIdentification
	{
		get
		{
			return _playlistIdenfication;
		}
		set
		{
			SetValue("PlaylistIdentification", ref _playlistIdenfication, value, (System.Action)delegate
			{
				OnPropertyChanged("PlaylistID");
				OnPropertyChanged("PlaylistName");
				OnDataModified();
			}, (Predicate<Identification>?)null, referenceComparison: false);
		}
	}

	public Identification? PlaylistItemIdentification
	{
		get
		{
			return _playlistItemIdentification;
		}
		set
		{
			SetValue("PlaylistItemIdentification", ref _playlistItemIdentification, value, (System.Action)delegate
			{
				OnPropertyChanged("PlaylistItemID");
				OnPropertyChanged("PlaylistItemName");
				OnDataModified();
			}, (Predicate<Identification>?)null, referenceComparison: false);
		}
	}

	public bool AlwaysRetrigger
	{
		get
		{
			return _alwaysRetrigger;
		}
		set
		{
			SetValue("AlwaysRetrigger", ref _alwaysRetrigger, value, delegate(bool o, bool n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ActionPlaylistAlwaysRetrigger.ToAction(), this, "AlwaysRetrigger", o, n);
				OnDataModified();
			});
		}
	}

	public TimelineItemType TimelineItemType => TimelineItemType.Actions;

	public static ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, PlaylistAction left, Pro.Entity.IAction right)
	{
		ObjectBinder<Pro.DO.Triggering.IAction, Pro.Entity.IAction> objectBinder = ActionBase.CreateBinder(scheduler, entityFactory, left, right, delegate
		{
		});
		Pro.Entity.IAction.Types.IActionTypeData.IPlaylistItem playlistItem = right.ActionTypeData.Value as Pro.Entity.IAction.Types.IActionTypeData.IPlaylistItem;
		if (playlistItem == null)
		{
			playlistItem = entityFactory.Create<Pro.Entity.IAction.Types.IActionTypeData.IPlaylistItem>();
			right.ActionTypeData.Set(playlistItem);
		}
		ObjectBinder<PlaylistAction, Pro.Entity.IAction.Types.IPlaylistItemType> binder = CreateBinder(scheduler, left, playlistItem.Value);
		objectBinder.DoOnInitializeRightFromLeft(binder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(binder.InitializeLeftFromRight).RegisterChildDisposable(() => binder);
		return objectBinder;
	}

	protected static ObjectBinder<PlaylistAction, Pro.Entity.IAction.Types.IPlaylistItemType> CreateBinder(IUiScheduler scheduler, PlaylistAction left, Pro.Entity.IAction.Types.IPlaylistItemType right)
	{
		return new ObjectBinder<PlaylistAction, Pro.Entity.IAction.Types.IPlaylistItemType>(left, right).Bind((PlaylistAction l) => l.WhenPropertyChanges("PlaylistIdentification"), (Pro.Entity.IAction.Types.IPlaylistItemType r) => r.PlaylistUuid.WhenValueChanges.ToUnit().Merge(r.PlaylistName.WhenValueChanges.ToUnit()), delegate(PlaylistAction l, Pro.Entity.IAction.Types.IPlaylistItemType r)
		{
			r.PlaylistUuid.Set(l.PlaylistID);
			r.PlaylistName.Set(l.PlaylistName);
		}, delegate(Pro.Entity.IAction.Types.IPlaylistItemType r, PlaylistAction l)
		{
			l.SetIdentifier(r.PlaylistUuid.ToGuidOrEmpty(), r.PlaylistName.Value ?? string.Empty);
		}).Bind((PlaylistAction l) => l.WhenPropertyChanges("PlaylistItemIdentification"), (Pro.Entity.IAction.Types.IPlaylistItemType r) => r.ItemUuid.WhenValueChanges.ToUnit().Merge(r.ItemName.WhenValueChanges.ToUnit()), delegate(PlaylistAction l, Pro.Entity.IAction.Types.IPlaylistItemType r)
		{
			r.ItemUuid.Set(l.PlaylistItemID);
			r.ItemName.Set(l.PlaylistItemName);
		}, delegate(Pro.Entity.IAction.Types.IPlaylistItemType r, PlaylistAction l)
		{
			l.SetPlaylistItem(r.ItemUuid.ToGuidOrEmpty(), r.ItemName.Value ?? string.Empty);
		}).Bind((PlaylistAction l) => l.WhenPropertyChanges("AlwaysRetrigger"), (Pro.Entity.IAction.Types.IPlaylistItemType r) => r.AlwaysRetrigger.WhenValueChanges, delegate(PlaylistAction l, Pro.Entity.IAction.Types.IPlaylistItemType r)
		{
			r.AlwaysRetrigger.Set(l.AlwaysRetrigger);
		}, delegate(Pro.Entity.IAction.Types.IPlaylistItemType r, PlaylistAction l)
		{
			l.AlwaysRetrigger = r.AlwaysRetrigger.Value;
		});
	}

	protected PlaylistAction(IPlaylistActionValidatorFactory? validatorFactory)
	{
		LinkProperties("IsValid", "IsValid");
		_validatorFactory = validatorFactory;
		SetValidator();
	}

	public void SetIdentifier(Guid id, string name)
	{
		Guid oldID = PlaylistID;
		string oldName = PlaylistName;
		base.UndoStack?.Commit(UndoActionTypes.ActionSetPlaylist.ToAction(), delegate
		{
			SetIdentifier(oldID, oldName);
		}, delegate
		{
			SetIdentifier(id, name);
		}, null, null, autoFinalize: true);
		PlaylistIdentification = PlaylistIdentification with
		{
			Id = id
		};
		SetName(name);
		OnDataModified();
	}

	public void SetPlaylistItem(Guid id, string name)
	{
		PlaylistItemIdentification = Identification.Empty()with
		{
			Id = id,
			Name = name
		};
		OnDataModified();
	}

	private void SetName(string? name)
	{
		PlaylistIdentification = PlaylistIdentification with
		{
			Name = (name ?? string.Empty)
		};
		OnPropertyChanged("DefaultName");
	}

	private void SetValidator()
	{
		IPlaylistActionValidator playlistActionValidator = _validatorFactory?.Create(this);
		if (playlistActionValidator != null)
		{
			if (_validator != null)
			{
				_validator.PropertyChanged -= base.RaiseLinkedValues;
				_validator.UpdateName -= SetName;
			}
			_validator = playlistActionValidator;
			_validator.PropertyChanged += base.RaiseLinkedValues;
			_validator.UpdateName += SetName;
		}
	}

	protected override T CopyProperties<T>(T action)
	{
		if (action is PlaylistAction playlistAction)
		{
			base.CopyProperties(playlistAction);
			playlistAction.SetIdentifier(PlaylistID, PlaylistName);
			playlistAction.AlwaysRetrigger = AlwaysRetrigger;
			playlistAction._validatorFactory = _validatorFactory;
			playlistAction.SetValidator();
			playlistAction.SetPlaylistItem(PlaylistItemID, PlaylistItemName);
		}
		return action;
	}

	public override Pro.SerializationInterop.RVProtoData.Action Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Action action = base.Serialize();
		action.PlaylistItem = new Pro.SerializationInterop.RVProtoData.Action.Types.PlaylistItemType
		{
			PlaylistUuid = PlaylistID.ToUUID(),
			PlaylistName = (PlaylistName ?? string.Empty),
			AlwaysRetrigger = AlwaysRetrigger,
			ItemUuid = PlaylistItemID.ToUUID(),
			ItemName = (PlaylistItemName ?? string.Empty)
		};
		return action;
	}

	public override void Deserialize(Pro.SerializationInterop.RVProtoData.Action data, ApplicationData? applicationData, string containerId)
	{
		base.Deserialize(data, applicationData, containerId);
		Pro.SerializationInterop.RVProtoData.Action.Types.PlaylistItemType playlistItemType = data?.PlaylistItem;
		SetIdentifier(playlistItemType?.PlaylistUuid?.ToGuid() ?? Guid.Empty, playlistItemType?.PlaylistName ?? string.Empty);
		AlwaysRetrigger = playlistItemType?.AlwaysRetrigger ?? false;
		PlaylistItemIdentification = ((data?.PlaylistItem?.ItemUuid != null) ? Identification.Empty()with
		{
			Id = data.PlaylistItem.ItemUuid.ToGuid(),
			Name = (data.PlaylistItem.ItemName ?? string.Empty)
		} : null);
	}
}
