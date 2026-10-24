using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.DO.Utility;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.NetworkLink;

public class Group : ImmutableObservableCollection<GroupMember>, ICloneable<Group>, IGroupDefinition, INotifyEnumerableChanged<GroupMember>, IEnumerable<GroupMember>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged
{
	private string _name = string.Empty;

	private string _secret = string.Empty;

	private DateTime? _timeStamp;

	public string Name
	{
		get
		{
			return _name;
		}
		private set
		{
			SetValue("Name", ref _name, value);
		}
	}

	public string Secret
	{
		get
		{
			return _secret;
		}
		private set
		{
			SetValue("Secret", ref _secret, value);
		}
	}

	public DateTime? TimeStamp
	{
		get
		{
			return _timeStamp;
		}
		private set
		{
			SetValue("TimeStamp", ref _timeStamp, value);
		}
	}

	public event System.Action? Updated;

	public event System.Action? MembersUpdated;

	public Group Clone()
	{
		Group group = new Group();
		group.Deserialize(Serialize());
		return group;
	}

	public void Deserialize(IEnumerable<ProLink.Types.MemberStatus> protoMembers)
	{
		if (protoMembers == null)
		{
			return;
		}
		foreach (ProLink.Types.MemberStatus protoMember in protoMembers)
		{
			base.Collection.FirstOrDefault((GroupMember m) => m.Ip == protoMember.Ip && m.Port == protoMember.Port)?.Update(protoMember);
		}
		this.Updated?.Invoke();
	}

	public void Deserialize(ProLink.Types.GroupDefinition protoGroupDefinition)
	{
		if (protoGroupDefinition != null)
		{
			Name = protoGroupDefinition.Name;
			Secret = protoGroupDefinition.Secret;
			TimeStamp = protoGroupDefinition.Timestamp?.ToDateTime();
			base.Collection.DeserializeCollection(protoGroupDefinition.Members, (GroupMember m, ProLink.Types.GroupDefinition.Types.Member p) => m.Ip == p.Ip && m.Port == p.Port, (ProLink.Types.GroupDefinition.Types.Member p) => new GroupMember(p), delegate(GroupMember m)
			{
				base.Collection.Add(m);
			}, delegate(GroupMember m)
			{
				base.Collection.Remove(m);
			}, delegate(GroupMember m, ProLink.Types.GroupDefinition.Types.Member p)
			{
				m.DataModified -= OnMemberStatusUpdated;
				m.Update(p);
				m.DataModified += OnMemberStatusUpdated;
			});
			this.Updated?.Invoke();
		}
	}

	private void OnMemberStatusUpdated()
	{
		this.MembersUpdated?.Invoke();
	}

	public ProLink.Types.GroupDefinition Serialize()
	{
		ProLink.Types.GroupDefinition groupDefinition = new ProLink.Types.GroupDefinition();
		groupDefinition.Name = Name ?? string.Empty;
		groupDefinition.Secret = Secret ?? string.Empty;
		groupDefinition.Timestamp = TimeStamp?.ToTimeStamp() ?? DateTime.Now.ToTimeStamp();
		groupDefinition.Members.AddRange(base.Collection.Select((GroupMember m) => m.Serialize()));
		return groupDefinition;
	}

	public IEnumerable<ProLink.Types.MemberStatus> SerializeStatuses()
	{
		return base.Collection.Select((GroupMember m) => m.SerializeStatus());
	}

	internal void UpdateTimestamp()
	{
		_timeStamp = DateTime.Now;
	}
}
