using System;
using Pro.Common.Components;

namespace ProPresenter.DO.Settings.AdvancedSettings;

public abstract class FolderBase : NotifyPropertyChangedBase
{
	private string _name = string.Empty;

	public abstract FolderType Type { get; }

	public Guid ID { get; } = Guid.NewGuid();

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, TryChangeName(_name, value) ? value : _name);
		}
	}

	protected virtual bool TryChangeName(string oldName, string newName)
	{
		return true;
	}
}
