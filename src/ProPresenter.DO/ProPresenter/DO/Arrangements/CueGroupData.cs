using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO;
using Pro.DO.Application;
using Pro.DO.Label;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Arrangements;

public class CueGroupData : LinkedNotifyPropertyChangedBase
{
	private Guid _id = Guid.NewGuid();

	private GroupLabel _label;

	public Guid ID => _id;

	public GroupLabel Label
	{
		get
		{
			return _label;
		}
		[MemberNotNull("_label")]
		set
		{
			SetValue("Label", ref _label, value, delegate(GroupLabel o, GroupLabel n)
			{
				if (o != null)
				{
					o.PropertyChanged -= base.RaiseLinkedValues;
				}
				n.PropertyChanged += base.RaiseLinkedValues;
			});
		}
	}

	public CueCollection Cues { get; }

	public static ObjectBinder<CueGroupData, IGroup> CreateBinder(IEntityFactory entityFactory, CueGroupData left, IGroup right)
	{
		ObjectBinder<GroupLabel, IGroup> masterLabelBinder = new ObjectBinder<GroupLabel, IGroup>(left.Label, right);
		masterLabelBinder.Bind((GroupLabel l) => l.WhenPropertyChanges("MasterLabel"), (IGroup r) => r.ApplicationGroupIdentifier.WhenValueChanges, delegate(GroupLabel l, IGroup r)
		{
			r.ApplicationGroupIdentifier.Set(l.MasterLabel?.ID);
		}, delegate(IGroup r, GroupLabel l)
		{
			l.MasterLabel = FindMasterLabel(new Pro.SerializationInterop.RVProtoData.Presentation.Types.CueGroup
			{
				Group = new Group
				{
					ApplicationGroupIdentifier = r.ApplicationGroupIdentifier.Value?.ToUUID(),
					Name = r.Name.Value
				}
			});
		}).Bind((GroupLabel l) => l.WhenPropertyChanges("Name"), (IGroup r) => r.Name.WhenValueChanges, delegate(GroupLabel l, IGroup r)
		{
			r.Name.Set(l.Name);
		}, delegate(IGroup r, GroupLabel l)
		{
			l.Name = r.Name.Value;
		}).Bind((GroupLabel l) => l.WhenPropertyChanges("Color"), (IGroup r) => r.Color.WhenValueChanges, delegate(GroupLabel l, IGroup r)
		{
			r.Color.Set(l.Color?.ToEntityColor());
		}, delegate(IGroup r, GroupLabel l)
		{
			l.Color = r.Color.Value?.ToColor();
		})
			.Bind((GroupLabel l) => l.WhenPropertyChanges("Hotkey"), (IGroup r) => r.HotKey.WhenValueChanges, delegate(GroupLabel l, IGroup r)
			{
				IHotKey hotKey = entityFactory.Create<IHotKey>();
				r.HotKey.Set(hotKey);
				ObjectBinder<Pro.DO.Hotkey, IHotKey> objectBinder = Pro.DO.Hotkey.CreateBinder(l.Hotkey, hotKey);
				objectBinder.InitializeRightFromLeft();
				hotKey.RegisterLinkedDisposable(objectBinder);
			}, delegate(IGroup r, GroupLabel l)
			{
				ObjectBinder<Pro.DO.Hotkey, IHotKey> objectBinder2 = Pro.DO.Hotkey.CreateBinder(l.Hotkey, r.HotKey.Value);
				objectBinder2.InitializeLeftFromRight();
				r.HotKey.Value.RegisterLinkedDisposable(objectBinder2);
			});
		ObjectBinder<CueGroupData, IGroup> objectBinder3 = new ObjectBinder<CueGroupData, IGroup>(left, right);
		objectBinder3.Bind((CueGroupData l) => l.WhenPropertyChanges("ID"), (IGroup r) => r.Uuid.WhenValueChanges, delegate(CueGroupData l, IGroup r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IGroup r, CueGroupData l)
		{
			l._id = r.Uuid.Value;
		}).DoOnInitializeLeftFromRight(masterLabelBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(masterLabelBinder.InitializeRightFromLeft)
			.RegisterChildDisposable(() => masterLabelBinder);
		return objectBinder3;
	}

	public CueGroupData(CueCollection cues, GroupLabel label)
	{
		if (label == null)
		{
			throw new InvalidOperationException();
		}
		Label = label.Clone();
		if (Label.MasterLabel == null)
		{
			Label.MasterLabel = label;
		}
		Cues = cues;
		LinkProperties(new string[3] { "Color", "Text", "Hotkey" }, "Label");
	}

	internal void Deserialize(Pro.SerializationInterop.RVProtoData.Presentation.Types.CueGroup protoCueGroup, IEnumerable<Cue> protoCues, ApplicationData? applicationData, string containerId)
	{
		if (protoCueGroup == null)
		{
			return;
		}
		if (Label != null)
		{
			Label.MasterLabel = FindMasterLabel(protoCueGroup);
		}
		if (protoCueGroup.Group?.Uuid != null)
		{
			_id = protoCueGroup.Group.Uuid.ToGuid();
		}
		IEnumerable<Guid> source = protoCueGroup.CueIdentifiers.Select((UUID i) => i.ToGuid());
		Cues.Deserialize(source.Select((Guid i) => protoCues.FirstOrDefault((Cue c) => c.Uuid.ToGuid() == i)).NotNull(), applicationData, containerId);
	}

	private static GroupLabel? FindMasterLabel(Pro.SerializationInterop.RVProtoData.Presentation.Types.CueGroup protoCueGroup)
	{
		Guid? appID = protoCueGroup.Group?.ApplicationGroupIdentifier?.ToGuid();
		string appName = protoCueGroup.Group?.ApplicationGroupName;
		string name = protoCueGroup.Group?.Name;
		return DataVault.GroupLabels?.FirstOrDefaultBy(delegate(GroupLabel l)
		{
			if (appID.HasValue)
			{
				Guid iD = l.ID;
				Guid? guid = appID;
				return iD == guid;
			}
			return false;
		}, (GroupLabel l) => !string.IsNullOrWhiteSpace(appName) && l.Text == appName, (GroupLabel l) => !string.IsNullOrWhiteSpace(name) && l.Text == name);
	}
}
