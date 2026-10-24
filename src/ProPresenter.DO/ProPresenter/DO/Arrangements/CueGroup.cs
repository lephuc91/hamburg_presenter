using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Label;
using Pro.DO.Reversibility;
using Pro.DO.Transitions;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Arrangements;

public class CueGroup : LinkedNotifyPropertyChangedBase
{
	private CueGroupData _data;

	private UndoStack _undoStack;

	public Guid ID => _data.ID;

	public GroupLabel Label => _data.Label;

	public CueCollection Cues => _data.Cues;

	public event Action<CueGroup>? DataModified;

	public static ObjectBinder<CueGroup, Pro.Entity.IPresentation.Types.ICueGroup> CreateBinder(IProPresenterDOFactoryProvider factoryProvider, CueGroup left, Pro.Entity.IPresentation.Types.ICueGroup right)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		ObjectBinder<CueGroup, Pro.Entity.IPresentation.Types.ICueGroup> objectBinder = new ObjectBinder<CueGroup, Pro.Entity.IPresentation.Types.ICueGroup>(left, right);
		objectBinder.Bind((CueGroup l) => l.WhenPropertyChanges("Label"), (Pro.Entity.IPresentation.Types.ICueGroup r) => r.Group.WhenValueChanges.ToUnit(), delegate(CueGroup l, Pro.Entity.IPresentation.Types.ICueGroup r)
		{
			IGroup group = entityFactory.Create<IGroup>();
			r.Group.Set(group);
			ObjectBinder<CueGroupData, IGroup> objectBinder2 = CueGroupData.CreateBinder(entityFactory, l._data, group);
			objectBinder2.InitializeRightFromLeft();
			group.RegisterLinkedDisposable(objectBinder2);
		}, delegate(Pro.Entity.IPresentation.Types.ICueGroup r, CueGroup l)
		{
			ObjectBinder<CueGroupData, IGroup> objectBinder3 = CueGroupData.CreateBinder(entityFactory, l._data, r.Group.Value);
			objectBinder3.InitializeLeftFromRight();
			r.Group.Value.RegisterLinkedDisposable(objectBinder3);
		});
		return objectBinder;
	}

	private CueGroup(CueGroupData data, UndoStack undoStack)
	{
		_data = data;
		_undoStack = undoStack;
		LinkProperties("Label", "Label");
		LinkAction("Label", OnDataModified);
		_data.PropertyChanged += base.RaiseLinkedValues;
		_data.Cues.DataModified += delegate
		{
			OnDataModified();
		};
	}

	public CueGroup(ProPresenter.DO.Presentation.IPresentation parentPresentation, GroupLabel label, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions)
		: this(new CueGroupData(new CueCollection(parentPresentation, factoryProvider, transitionDescriptions), label), parentPresentation.UndoStack)
	{
	}

	public CueGroup(CueGroup group)
		: this(group._data, group._undoStack)
	{
	}

	public void AssignLabel(GroupLabel label)
	{
		GroupLabel groupLabel = label.Clone();
		groupLabel.MasterLabel = label;
		_undoStack.Commit(new TaggedUndoAction<Pro.DO.Reversibility.UndoActionTypes>(Pro.DO.Reversibility.UndoActionTypes.AssignLabel), _data, "Label", _data.Label, groupLabel);
		_data.Label = groupLabel;
	}

	public bool IsSameGroup(CueGroup other)
	{
		return _data == other._data;
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}

	public Pro.SerializationInterop.RVProtoData.Presentation.Types.CueGroup Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Presentation.Types.CueGroup cueGroup = new Pro.SerializationInterop.RVProtoData.Presentation.Types.CueGroup();
		cueGroup.Group = new Group
		{
			ApplicationGroupIdentifier = _data.Label.MasterLabel?.ID.ToUUID(),
			ApplicationGroupName = (_data.Label.MasterLabel?.Text ?? string.Empty),
			Uuid = ID.ToUUID(),
			Name = (_data.Label.Text ?? string.Empty),
			Color = _data.Label.Color?.ToProtoColor(),
			HotKey = _data.Label.Hotkey.Serialize()
		};
		cueGroup.CueIdentifiers.AddRange(Cues.Select((SlideCue c) => c.ID.ToUUID()));
		return cueGroup;
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Presentation.Types.CueGroup cueGroup, IEnumerable<Cue> protoCues, ApplicationData? applicationData, string containerId)
	{
		_data.Deserialize(cueGroup, protoCues, applicationData, containerId);
	}
}
