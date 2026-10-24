using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Logging;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;

namespace ProPresenter.DO.ClearGroups;

public class ClearGroup : NotifyPropertyChangedBase, ICloneable<ClearGroup>, IIdentifiable, ITriggerable
{
	private Guid _id = Guid.NewGuid();

	private string _name = string.Empty;

	private readonly ObservableCollection<ClearType> _clearTargets = new ObservableCollection<ClearType>();

	private readonly ObservableCollection<OutputDestination> _timelineTargets = new ObservableCollection<OutputDestination>();

	private bool _clearNextSlide;

	private bool _isHiddenInPreview;

	private BitmapSource? _icon;

	private ImageType _imageType;

	private bool _isIconTinted;

	private System.Windows.Media.Color _iconTint = Colors.White;

	public Guid ID => _id;

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
				UndoStack?.Commit(UndoActionTypes.ClearGroupName.ToAction(), this, "Name", o, n);
				OnDataModified();
			});
		}
	}

	public IReadOnlyList<ClearType> ClearTargets => _clearTargets;

	public IReadOnlyList<OutputDestination> TimelineTargets => _timelineTargets;

	public bool ClearNextSlide
	{
		get
		{
			return _clearNextSlide;
		}
		set
		{
			SetValue("ClearNextSlide", ref _clearNextSlide, value, delegate(bool n, bool o)
			{
				UndoStack?.Commit(UndoActionTypes.ClearGroupTargets.ToAction(), this, "ClearNextSlide", o, n);
				OnDataModified();
			});
		}
	}

	public bool IsHiddenInPreview
	{
		get
		{
			return _isHiddenInPreview;
		}
		set
		{
			SetValue("IsHiddenInPreview", ref _isHiddenInPreview, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(UndoActionTypes.ClearGroupIsHiddenInPreview.ToAction(), this, "IsHiddenInPreview", o, n);
				OnDataModified();
			});
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
			SetValue<BitmapSource>("Icon", ref _icon, value, delegate(BitmapSource o, BitmapSource n)
			{
				UndoStack?.Commit(UndoActionTypes.ClearGroupIcon.ToAction(), this, "Icon", o, n);
				OnDataModified();
			});
		}
	}

	public ImageType ImageType
	{
		get
		{
			return _imageType;
		}
		set
		{
			SetValue("ImageType", ref _imageType, value, delegate(ImageType o, ImageType n)
			{
				UndoStack?.Commit(UndoActionTypes.ClearGroupIconType.ToAction(), this, "ImageType", o, n);
				OnDataModified();
			});
		}
	}

	public bool IsIconTinted
	{
		get
		{
			return _isIconTinted;
		}
		set
		{
			SetValue("IsIconTinted", ref _isIconTinted, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(UndoActionTypes.ClearGroupIsIconTinted.ToAction(), this, "IsIconTinted", o, n);
				OnDataModified();
				OnPropertyChanged("IconFill");
			});
		}
	}

	public System.Windows.Media.Color IconFill
	{
		get
		{
			if (!IsIconTinted)
			{
				return Colors.White;
			}
			return IconTint;
		}
	}

	public System.Windows.Media.Color IconTint
	{
		get
		{
			return _iconTint;
		}
		set
		{
			SetValue("IconTint", ref _iconTint, value, delegate(System.Windows.Media.Color o, System.Windows.Media.Color n)
			{
				UndoStack?.Commit(UndoActionTypes.ClearGroupIconTint.ToAction(), this, "IconTint", o, n);
				OnDataModified();
				OnPropertyChanged("IconFill");
			});
		}
	}

	public UndoStack? UndoStack { get; set; }

	public event System.Action? DataModified;

	public ObjectBinder<IClearGroupsDocument.Types.IClearGroup, ClearGroup> Bind(IClearGroupsDocument.Types.IClearGroup clearGroup, IUiScheduler uiScheduler)
	{
		return new ObjectBinder<IClearGroupsDocument.Types.IClearGroup, ClearGroup>(clearGroup, this).Bind((IClearGroupsDocument.Types.IClearGroup e) => e.Uuid.WhenValueChanges, (ClearGroup m) => m.WhenPropertyChanges("ID"), delegate(IClearGroupsDocument.Types.IClearGroup entity, ClearGroup model)
		{
			model._id = entity.Uuid.Value;
		}, delegate(ClearGroup model, IClearGroupsDocument.Types.IClearGroup entity)
		{
			entity.Uuid.Set(model.ID);
		}).Bind((IClearGroupsDocument.Types.IClearGroup x) => x.Name.WhenValueChanges, (ClearGroup x) => x.WhenPropertyChanges("Name"), delegate(IClearGroupsDocument.Types.IClearGroup entity, ClearGroup model)
		{
			model.Name = entity.Name.Value;
		}, delegate(ClearGroup model, IClearGroupsDocument.Types.IClearGroup entity)
		{
			entity.Name.Set(model.Name);
		}).Bind((IClearGroupsDocument.Types.IClearGroup x) => x.LayerTargets.WhenCollectionChanges, (ClearGroup x) => x._clearTargets.WhenCollectionChanges(), delegate(IClearGroupsDocument.Types.IClearGroup entity, ClearGroup model)
		{
			entity.LayerTargets.Items.SynchronizeTo(model._clearTargets, Equals, delegate(Pro.Entity.IAction.Types.ClearType entity, int index)
			{
				model._clearTargets.Insert(index, entity.ToClearType());
			}, model._clearTargets.Move, model._clearTargets.RemoveAt);
		}, delegate(ClearGroup model, IClearGroupsDocument.Types.IClearGroup entity)
		{
			model.ClearTargets.SynchronizeTo(entity.LayerTargets.Items, Equals, delegate(ClearType model, int index)
			{
				entity.LayerTargets.Insert(index, model.ToEntityClearType());
			}, entity.LayerTargets.Move, entity.LayerTargets.RemoveAt);
		}, uiScheduler.Scheduler)
			.Bind((IClearGroupsDocument.Types.IClearGroup x) => x.TimelineTargets.WhenCollectionChanges, (ClearGroup x) => x._timelineTargets.WhenCollectionChanges(), delegate(IClearGroupsDocument.Types.IClearGroup entity, ClearGroup model)
			{
				entity.TimelineTargets.Items.SynchronizeTo(model._timelineTargets, Equals, delegate(Pro.Entity.IAction.Types.ContentDestination entity, int index)
				{
					model._timelineTargets.Insert(index, entity.ToOutputDestination());
				}, model._timelineTargets.Move, model._timelineTargets.RemoveAt);
			}, delegate(ClearGroup model, IClearGroupsDocument.Types.IClearGroup entity)
			{
				model.TimelineTargets.SynchronizeTo(entity.TimelineTargets.Items, Equals, delegate(OutputDestination model, int index)
				{
					entity.TimelineTargets.Insert(index, model.ToContentDestination());
				}, entity.TimelineTargets.Move, entity.TimelineTargets.RemoveAt);
			}, uiScheduler.Scheduler)
			.Bind((IClearGroupsDocument.Types.IClearGroup x) => x.ClearPresentationNextSlide.WhenValueChanges, (ClearGroup x) => x.WhenPropertyChanges("ClearNextSlide"), delegate(IClearGroupsDocument.Types.IClearGroup entity, ClearGroup model)
			{
				model.ClearNextSlide = entity.ClearPresentationNextSlide.Value;
			}, delegate(ClearGroup model, IClearGroupsDocument.Types.IClearGroup entity)
			{
				entity.ClearPresentationNextSlide.Set(model.ClearNextSlide);
			})
			.Bind((IClearGroupsDocument.Types.IClearGroup x) => x.IsHiddenInPreview.WhenValueChanges, (ClearGroup x) => x.WhenPropertyChanges("IsHiddenInPreview"), delegate(IClearGroupsDocument.Types.IClearGroup entity, ClearGroup model)
			{
				model.IsHiddenInPreview = entity.IsHiddenInPreview.Value;
			}, delegate(ClearGroup model, IClearGroupsDocument.Types.IClearGroup entity)
			{
				entity.IsHiddenInPreview.Set(model.IsHiddenInPreview);
			})
			.Bind((IClearGroupsDocument.Types.IClearGroup x) => x.ImageType.WhenValueChanges, (ClearGroup x) => x.WhenPropertyChanges("ImageType"), delegate(IClearGroupsDocument.Types.IClearGroup entity, ClearGroup model)
			{
				model.ImageType = entity.ImageType.Value.ToImageType();
			}, delegate(ClearGroup model, IClearGroupsDocument.Types.IClearGroup entity)
			{
				entity.ImageType.Set(model.ImageType.ToEntityImageType());
			}, uiScheduler.Scheduler)
			.Bind((IClearGroupsDocument.Types.IClearGroup x) => x.IsIconTinted.WhenValueChanges, (ClearGroup x) => x.WhenPropertyChanges("IsIconTinted"), delegate(IClearGroupsDocument.Types.IClearGroup entity, ClearGroup model)
			{
				model.IsIconTinted = entity.IsIconTinted.Value;
			}, delegate(ClearGroup model, IClearGroupsDocument.Types.IClearGroup entity)
			{
				entity.IsIconTinted.Set(model.IsIconTinted);
			})
			.Bind((IClearGroupsDocument.Types.IClearGroup x) => x.IconTintColor.WhenValueChanges, (ClearGroup x) => x.WhenPropertyChanges("IconTint"), delegate(IClearGroupsDocument.Types.IClearGroup entity, ClearGroup model)
			{
				model.IconTint = entity.IconTintColor.Value?.ToColor() ?? Colors.White;
			}, delegate(ClearGroup model, IClearGroupsDocument.Types.IClearGroup entity)
			{
				entity.IconTintColor.Set(model.IconTint.ToEntityColor());
			})
			.Bind((IClearGroupsDocument.Types.IClearGroup x) => x.ImageData.WhenValueChanges, (ClearGroup x) => x.WhenPropertyChanges("Icon"), delegate(IClearGroupsDocument.Types.IClearGroup entity, ClearGroup model)
			{
				model.Icon = entity.ImageData.Value?.ToBitmapSource();
			}, delegate(ClearGroup model, IClearGroupsDocument.Types.IClearGroup entity)
			{
				entity.ImageData.Set(model.Icon?.ToByteArray());
			});
	}

	private static bool Equals(Pro.Entity.IAction.Types.ClearType x, ClearType y)
	{
		return x.ToClearType() == y;
	}

	private static bool Equals(ClearType x, Pro.Entity.IAction.Types.ClearType y)
	{
		return y.ToClearType() == x;
	}

	private static bool Equals(Pro.Entity.IAction.Types.ContentDestination x, OutputDestination y)
	{
		return x.ToOutputDestination() == y;
	}

	private static bool Equals(OutputDestination x, Pro.Entity.IAction.Types.ContentDestination y)
	{
		return y.ToOutputDestination() == x;
	}

	public ClearGroup()
	{
		_clearTargets.CollectionChanged += OnClearTargetsCollectionChanged;
		_timelineTargets.CollectionChanged += OnTimelineTargetsCollectionChanged;
	}

	public ClearGroup(UndoStack? undoStack)
		: this()
	{
		UndoStack = undoStack;
	}

	public ClearGroup Clone()
	{
		ClearGroup obj = new ClearGroup
		{
			Name = Name,
			IsHiddenInPreview = IsHiddenInPreview,
			Icon = Icon,
			ImageType = ImageType,
			IsIconTinted = IsIconTinted,
			IconTint = IconTint,
			ClearNextSlide = ClearNextSlide
		};
		obj._clearTargets.AddRange(ClearTargets);
		obj._timelineTargets.AddRange(TimelineTargets);
		return obj;
	}

	public void ClearTargetLayers()
	{
		_clearTargets.Clear();
	}

	public void ClearTimelineTargets()
	{
		_timelineTargets.Clear();
	}

	public void ToggleClearTarget(ClearType clearType)
	{
		if (_clearTargets.Contains(clearType))
		{
			_clearTargets.Remove(clearType);
		}
		else
		{
			_clearTargets.Add(clearType);
		}
		UndoStack?.Commit(UndoActionTypes.ClearGroupTargets.ToAction(), delegate
		{
			ToggleClearTarget(clearType);
		}, delegate
		{
			ToggleClearTarget(clearType);
		}, null, null, autoFinalize: true);
	}

	public void ToggleTimelineTarget(OutputDestination contentDestination)
	{
		if (_timelineTargets.Contains(contentDestination))
		{
			_timelineTargets.Remove(contentDestination);
		}
		else
		{
			_timelineTargets.Add(contentDestination);
		}
		UndoStack?.Commit(UndoActionTypes.ClearGroupTargets.ToAction(), delegate
		{
			ToggleTimelineTarget(contentDestination);
		}, delegate
		{
			ToggleTimelineTarget(contentDestination);
		}, null, null, autoFinalize: true);
	}

	public ClearGroupsDocument.Types.ClearGroup Serialize()
	{
		ClearGroupsDocument.Types.ClearGroup clearGroup = new ClearGroupsDocument.Types.ClearGroup
		{
			Uuid = ID.ToUUID(),
			Name = (Name ?? string.Empty),
			IsHiddenInPreview = IsHiddenInPreview,
			ImageType = ImageType.ToProto(),
			IsIconTinted = IsIconTinted,
			IconTintColor = IconTint.ToProtoColor(),
			ClearPresentationNextSlide = ClearNextSlide
		};
		foreach (ClearType clearTarget in ClearTargets)
		{
			if (clearTarget != 0)
			{
				Pro.SerializationInterop.RVProtoData.Action.Types.ContentDestination destination;
				Pro.SerializationInterop.RVProtoData.Action.Types.ClearType item = new Pro.SerializationInterop.RVProtoData.Action.Types.ClearType
				{
					TargetLayer = clearTarget.ToProtoClearTargetLayer(out destination),
					ContentDestination = destination
				};
				clearGroup.LayerTargets.Add(item);
			}
		}
		clearGroup.TimelineTargets.AddRange(TimelineTargets.Select((OutputDestination t) => t.ToProtoDestination()));
		clearGroup.ImageData = Icon?.ToByteString() ?? ByteString.Empty;
		return clearGroup;
	}

	public void Deserialize(ClearGroupsDocument.Types.ClearGroup protoClearGroup)
	{
		if (protoClearGroup == null)
		{
			return;
		}
		_id = protoClearGroup.Uuid.ToGuid();
		Name = protoClearGroup.Name;
		IsHiddenInPreview = protoClearGroup.IsHiddenInPreview;
		ImageType = protoClearGroup.ImageType.ToImageType();
		IsIconTinted = protoClearGroup.IsIconTinted;
		IconTint = protoClearGroup.IconTintColor.ToColor();
		ClearNextSlide = protoClearGroup.ClearPresentationNextSlide;
		ClearTargetLayers();
		ClearTimelineTargets();
		foreach (Pro.SerializationInterop.RVProtoData.Action.Types.ClearType layerTarget in protoClearGroup.LayerTargets)
		{
			try
			{
				ClearType clearType = layerTarget.TargetLayer.ToClearType();
				if (layerTarget.ContentDestination == Pro.SerializationInterop.RVProtoData.Action.Types.ContentDestination.Announcements)
				{
					clearType = ClearType.Announcement;
				}
				if (clearType != 0)
				{
					_clearTargets.Add(clearType);
				}
			}
			catch (Exception ex)
			{
				Log.Warning("Failed to deserialize clear group target {0}", ex);
			}
		}
		_timelineTargets.AddRange(protoClearGroup.TimelineTargets.Select((Pro.SerializationInterop.RVProtoData.Action.Types.ContentDestination t) => t.ToDestination()));
		Icon = protoClearGroup.ImageData.ToBitmapSource();
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	private void OnClearTargetsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnDataModified();
		OnPropertyChanged("ClearTargets");
	}

	private void OnTimelineTargetsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnDataModified();
		OnPropertyChanged("TimelineTargets");
	}
}
