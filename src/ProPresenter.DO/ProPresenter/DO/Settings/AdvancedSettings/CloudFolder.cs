using System;

namespace ProPresenter.DO.Settings.AdvancedSettings;

public class CloudFolder : FolderBase, IEquatable<CloudFolder>
{
	private bool _isLinked;

	private readonly int _cloudLibraryId;

	public override FolderType Type => FolderType.Cloud;

	public int CloudLibraryID => _cloudLibraryId;

	public bool IsLinked
	{
		get
		{
			return _isLinked;
		}
		set
		{
			if (_isLinked != value)
			{
				_isLinked = value;
				OnPropertyChanged("IsLinked");
			}
		}
	}

	public CloudFolder(string name, bool isLinked, int cloudLibraryId = 0)
	{
		base.Name = name;
		_isLinked = isLinked;
		_cloudLibraryId = cloudLibraryId;
	}

	public override bool Equals(object? obj)
	{
		if (obj is CloudFolder other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(CloudFolder? other)
	{
		if (other != null)
		{
			return CloudLibraryID == other.CloudLibraryID;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(CloudLibraryID);
	}
}
