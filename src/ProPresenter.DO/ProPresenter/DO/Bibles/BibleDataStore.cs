using System;
using System.IO;
using System.Linq;
using Pro.Common.DataStore;
using Pro.Common.Nullability;

namespace ProPresenter.DO.Bibles;

public class BibleDataStore : StoreBase, IBibleDataStore
{
	private const string SettingsFile = "BibleData.proPref";

	private const string OldInstalledBiblesKey = "InstalledBibles";

	private const string InstalledBiblesKey = "InstalledBiblesNew";

	private InstalledBible[]? _installedBibles;

	public InstalledBible[]? InstalledBibles
	{
		get
		{
			if (_installedBibles == null)
			{
				InstalledBible[] installedBibles = GetValue("InstalledBiblesNew", Array.Empty<InstalledBible>()) ?? Array.Empty<InstalledBible>();
				InstalledBible[] value = GetValue("InstalledBibles", Array.Empty<InstalledBible>());
				if (installedBibles != null)
				{
					value.ThrowWhenNull("oldInstalledBibles");
					installedBibles = installedBibles.Concat(value.Where((InstalledBible ob) => !Array.Exists(installedBibles, (InstalledBible nb) => ob.TrackingAbbreviation.Equals(nb.TrackingAbbreviation, StringComparison.OrdinalIgnoreCase) || ob.ID == nb.ID))).ToArray();
				}
				_installedBibles = installedBibles;
			}
			return _installedBibles;
		}
		set
		{
			_installedBibles = null;
			SetValue("InstalledBiblesNew", value);
			OnPropertyChanged("InstalledBibles");
		}
	}

	public BibleDataStore(string path)
		: base(Path.Combine(path, "BibleData.proPref"))
	{
		RegisterCustomType(InstalledBible.Encode, InstalledBible.Decode);
		RegisterArrayType<InstalledBible>();
	}
}
