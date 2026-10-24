using System.Collections.Generic;
using Pro.Common.Collections;

namespace ProPresenter.DO.Migration;

public class MigrationLibraryCollection : ImmutableObservableCollection<MigrationLibrary>
{
	public void AddFolder(string folder)
	{
		ReplaceFolder(null, folder);
	}

	public void AddFolder(MigrationLibrary library)
	{
		base.Collection.Add(library);
	}

	public void AddFolders(IEnumerable<MigrationLibrary> libraries)
	{
		libraries.ForEach(AddFolder);
	}

	public void ReplaceFolder(MigrationLibrary? target, string folder)
	{
		MigrationLibrary migrationLibrary = new MigrationLibrary(folder);
		if (target == null)
		{
			base.Collection.Add(migrationLibrary);
			return;
		}
		int num = base.Collection.IndexOf(target);
		if (num >= 0)
		{
			base.Collection[num] = migrationLibrary;
		}
		else
		{
			base.Collection.Add(migrationLibrary);
		}
	}

	public void RemoveAll()
	{
		base.Collection.Clear();
	}
}
