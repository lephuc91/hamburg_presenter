using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Nullability;

namespace ProPresenter.DO.Bibles;

public class LoadedBibleCollection : ImmutableObservableCollection<BibleBase>
{
	private readonly InstalledBibleCollection _installedBibles;

	private readonly AvailableBibleCollection _availableBibles;

	public LoadedBibleCollection(InstalledBibleCollection installedBibles, AvailableBibleCollection availableBibles)
	{
		_installedBibles = installedBibles;
		_availableBibles = availableBibles;
		_installedBibles.BibleUninstallStarted += UnloadInstalledBible;
		_installedBibles.CollectionChanged += InstalledBiblesCollectionChanged;
		_availableBibles.CollectionChanged += AvailableBiblesCollectionChanged;
		_installedBibles.ForEach(TryLoadInstalledBible);
		_availableBibles.ForEach(OnAvailableBibleAdded);
	}

	public bool IsBibleLoaded(string abbreviation)
	{
		return GetLoadedBible(abbreviation) != null;
	}

	public BibleBase? GetLoadedBible(string? abbreviation)
	{
		return base.Collection.FirstOrDefault((BibleBase b) => b.TrackingAbbreviation.Equals(abbreviation, StringComparison.OrdinalIgnoreCase));
	}

	private void UnloadBible(BibleBase bible)
	{
		bible.Dispose();
		base.Collection.Remove(bible);
	}

	private void TryLoadInstalledBible(InstalledBible installedBible)
	{
		AvailableBibleBase availableBible = _availableBibles.GetAvailableBible(installedBible.TrackingAbbreviation, requireActive: true);
		if (availableBible != null)
		{
			LoadBible(availableBible, installedBible);
		}
	}

	private void UnloadInstalledBible(InstalledBible installedBible)
	{
		BibleBase loadedBible = GetLoadedBible(installedBible.TrackingAbbreviation);
		if (loadedBible != null)
		{
			UnloadBible(loadedBible);
		}
	}

	private void LoadBible(AvailableBibleBase availableBible, InstalledBible installedBible)
	{
		if (!IsBibleLoaded(availableBible.TrackingAbbreviation))
		{
			BibleBase bibleBase = BibleLoader.TryLoad(_installedBibles.InstallPath, installedBible);
			if (bibleBase != null && !string.IsNullOrEmpty(bibleBase.Name) && bibleBase.TrackingAbbreviation.Equals(availableBible.TrackingAbbreviation, StringComparison.OrdinalIgnoreCase))
			{
				base.Collection.Add(bibleBase);
			}
		}
	}

	private void InstalledBiblesCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.NewItems?.Cast<InstalledBible>().ForEach(TryLoadInstalledBible);
	}

	private void AvailableBiblesCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.NewItems?.Cast<AvailableBibleBase>().ForEach(OnAvailableBibleAdded);
		e.OldItems?.Cast<AvailableBibleBase>().ForEach(OnAvailableBibleRemoved);
	}

	private void OnAvailableBibleAdded(AvailableBibleBase availableBible)
	{
		availableBible.PropertyChanged += AvailableBiblePropertyChanged;
		if (availableBible.IsActive)
		{
			TryLoadAvailableBible(availableBible);
		}
	}

	private void OnAvailableBibleRemoved(AvailableBibleBase availableBible)
	{
		availableBible.PropertyChanged -= AvailableBiblePropertyChanged;
		TryUnloadAvailableBible(availableBible);
	}

	private void AvailableBiblePropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsActive")
		{
			AvailableBibleBase availableBibleBase = sender as AvailableBibleBase;
			if (availableBibleBase != null && availableBibleBase.IsActive)
			{
				TryLoadAvailableBible(availableBibleBase);
			}
			else if (availableBibleBase != null)
			{
				TryUnloadAvailableBible(availableBibleBase);
			}
		}
	}

	private void TryUnloadAvailableBible(AvailableBibleBase availableBible)
	{
		if (!_availableBibles.IsBibleAvailable(availableBible.TrackingAbbreviation, requireActive: true))
		{
			BibleBase loadedBible = GetLoadedBible(availableBible.TrackingAbbreviation);
			if (loadedBible != null)
			{
				UnloadBible(loadedBible);
			}
		}
	}

	private void TryLoadAvailableBible(AvailableBibleBase availableBible)
	{
		InstalledBible installedBible = _installedBibles.GetInstalledBible(availableBible);
		if (installedBible != null)
		{
			LoadBible(availableBible, installedBible);
		}
		else if (availableBible is AvailableSideBible sideBible)
		{
			LoadSideBible(sideBible);
		}
	}

	private void LoadSideBible(AvailableSideBible sideBible)
	{
		_installedBibles.InstallSideBible(sideBible, delegate(BibleFormat format, string biblePath)
		{
			BibleBase bibleBase = BibleLoader.TryLoad(biblePath, format, Path.GetFileNameWithoutExtension(biblePath));
			bibleBase.ThrowWhenNull("loadedBible");
			base.Collection.Add(bibleBase);
			return (bibleBase.Name, bibleBase.TrackingAbbreviation);
		});
	}
}
