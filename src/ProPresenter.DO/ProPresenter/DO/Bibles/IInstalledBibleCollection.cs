using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;

namespace ProPresenter.DO.Bibles;

public interface IInstalledBibleCollection : INotifyEnumerableChanged<InstalledBible>, IEnumerable<InstalledBible>, IEnumerable, INotifyCollectionChanged
{
	string InstallPath { get; }

	event Action<AvailableBibleBase> BibleInstallStarted;

	event Action<AvailableBibleBase> BibleInstallFailed;

	event Action<InstalledBible> BibleInstallCompleted;

	event Action<InstalledBible> BibleUninstallCompleted;

	bool IsInstalling(AvailableBibleBase bible);

	void InstallBible(AvailableBibleBase bible, Action<InstalledBible> completedCallback);

	void UninstallBible(AvailableBibleBase bible);
}
