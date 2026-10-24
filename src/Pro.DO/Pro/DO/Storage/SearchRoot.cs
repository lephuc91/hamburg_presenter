using System.ComponentModel;
using Pro.Common.Components;

namespace Pro.DO.Storage;

public class SearchRoot : NotifyPropertyChangedBase, ISearchRoot, INotifyPropertyChanged
{
	private bool _isActive = true;

	public SearchRootType Type { get; }

	public bool IsActive
	{
		get
		{
			return _isActive;
		}
		set
		{
			SetValue("IsActive", ref _isActive, value);
		}
	}

	public SearchRoot(SearchRootType type)
	{
		Type = type;
	}
}
