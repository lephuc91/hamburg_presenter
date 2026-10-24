using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Label;

public class GroupLabel : LabelBase<GroupLabel>, IIdentifiable
{
	private Hotkey _hotkey;

	public Guid ID { get; private set; } = Guid.NewGuid();

	public string Name
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
		}
	}

	public Hotkey Hotkey
	{
		get
		{
			if (base.MasterLabel == null)
			{
				return _hotkey;
			}
			return base.MasterLabel.Hotkey;
		}
	}

	public static ObjectBinder<GroupLabel, IGroup> CreateBinder(IUiScheduler scheduler, GroupLabel left, IGroup right, IEnumerable<GroupLabel> mainCollection)
	{
		return new ObjectBinder<GroupLabel, IGroup>(left, right).Bind((GroupLabel l) => l.WhenPropertyChanges("ID"), (IGroup r) => r.Uuid.WhenValueChanges, delegate(GroupLabel l, IGroup r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IGroup r, GroupLabel l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((GroupLabel l) => l.WhenPropertyChanges("MasterLabel"), (IGroup r) => r.ApplicationGroupIdentifier.WhenValueChanges, delegate(GroupLabel l, IGroup r)
		{
			r.ApplicationGroupIdentifier.Set(l.MasterLabel?.ID ?? l.ID);
		}, delegate(IGroup r, GroupLabel l)
		{
			GroupLabel groupLabel = mainCollection.FirstOrDefault(delegate(GroupLabel l)
			{
				if (r.ApplicationGroupIdentifier.Value.HasValue)
				{
					Guid iD = l.ID;
					Guid? value = r.ApplicationGroupIdentifier.Value;
					return iD == value;
				}
				return false;
			});
			if (groupLabel == null || l.MasterLabel == null || !(l.MasterLabel.ID == groupLabel.ID))
			{
				l.MasterLabel = groupLabel;
			}
		}, null, scheduler.Scheduler).Bind((GroupLabel l) => l.WhenPropertyChanges("Color"), (IGroup r) => r.Color.WhenValueChanges, delegate(GroupLabel l, IGroup r)
		{
			r.Color.Set(l.Color?.ToEntityColor());
		}, delegate(IGroup r, GroupLabel l)
		{
			l.Color = r.Color.Value?.ToColor();
		})
			.Bind((GroupLabel l) => l.WhenPropertyChanges("Hotkey"), (IGroup r) => r.HotKey.WhenAnyValueChanges, delegate(GroupLabel l, IGroup r)
			{
				//IL_0016: Unknown result type (might be due to invalid IL or missing references)
				r.HotKey.Value.Code.Set(l.Hotkey.Key.ToEntityKeyCode().GetValueOrDefault());
			}, delegate(IGroup r, GroupLabel l)
			{
				//IL_001e: Unknown result type (might be due to invalid IL or missing references)
				l.Hotkey.Key = r.HotKey.Value.Code.ToKey().GetValueOrDefault();
			})
			.Bind((GroupLabel l) => l.WhenPropertyChanges("Text"), (IGroup r) => r.Name.WhenValueChanges, delegate(GroupLabel l, IGroup r)
			{
				r.Name.Set(l.Text);
			}, delegate(IGroup r, GroupLabel l)
			{
				l.Text = r.Name.Value;
			});
	}

	public GroupLabel()
		: this(string.Empty)
	{
	}

	public GroupLabel(string text)
		: this(text, null)
	{
	}

	public GroupLabel(string text, System.Windows.Media.Color? color, Key key)
		: this(text, color, new Hotkey(key))
	{
	}//IL_0003: Unknown result type (might be due to invalid IL or missing references)


	public GroupLabel(string text, System.Windows.Media.Color? color, Hotkey? hotkey = null)
		: base(text, color)
	{
		_hotkey = hotkey ?? new Hotkey((Key)0);
		_hotkey.PropertyChanged += Hotkey_PropertyChanged;
		Hotkey.Color = base.Color ?? Colors.Transparent;
		LinkProperties("Hotkey", "Hotkey");
	}

	public override GroupLabel Clone()
	{
		GroupLabel groupLabel = CopyProperties(new GroupLabel());
		groupLabel._hotkey = Hotkey.Clone();
		return groupLabel;
	}

	private void Hotkey_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		OnPropertyChanged("Hotkey");
		OnDataModified();
	}

	public void Deserialize(Group protoGroupLabel)
	{
		base.UndoStack?.StartIgnoring();
		ID = protoGroupLabel?.Uuid?.ToGuid() ?? Guid.Empty;
		if (protoGroupLabel?.HotKey != null)
		{
			Hotkey?.Deserialize(protoGroupLabel.HotKey);
		}
		System.Windows.Media.Color? color = protoGroupLabel?.Color?.ToColor();
		if (protoGroupLabel != null && !string.IsNullOrEmpty(protoGroupLabel.Name))
		{
			OnDeserialize(protoGroupLabel.Name, color);
		}
		base.UndoStack?.StopIgnoring();
	}

	public Group Serialize()
	{
		return new Group
		{
			ApplicationGroupIdentifier = (base.MasterLabel?.ID ?? ID).ToUUID(),
			ApplicationGroupName = base.Text,
			Color = base.OriginalColor?.ToProtoColor(),
			HotKey = _hotkey.Serialize(),
			Name = base.OriginalText,
			Uuid = ID.ToUUID()
		};
	}
}
