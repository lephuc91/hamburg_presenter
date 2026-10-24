using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using Pro.Common.Collections;
using Pro.Common.DataStore;
using Pro.Common.Utility;
using Pro.CoreApplication.Media;
using Pro.DO.Storage;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Settings;

public class Advanced : StoreBase, IAdvanced, INotifyPropertyChanged, IManageMediaAutoMaticallyProvider
{
	private const string SettingsFile = "AdvancedPreferences.proPref";

	private static Advanced _settings = new Advanced();

	private readonly List<WeakReference<Action>> _ignoreBackgroundColorsChangedActions = new List<WeakReference<Action>>();

	private readonly object _backgroundColorsLock = new object();

	private readonly SearchRootCollection _searchRoots = new SearchRootCollection();

	public static Advanced Settings => _settings;

	public IObservable<bool> WhenManageMediaAutomaticallyChanged => (from _ in this.WhenPropertyChanges("ManageMediaAutomatically")
		select ManageMediaAutomatically).StartWith(ManageMediaAutomatically);

	public bool ShowScreenStats
	{
		get
		{
			return GetValue("ShowScreenStats", defaultValue: false);
		}
		set
		{
			SetValue("ShowScreenStats", value);
			OnPropertyChanged("ShowScreenStats");
		}
	}

	public bool ManageMediaAutomatically
	{
		get
		{
			return GetValue("ManageMediaAutomatically", defaultValue: true);
		}
		set
		{
			SetValue("ManageMediaAutomatically", value);
			OnPropertyChanged("ManageMediaAutomatically");
		}
	}

	public bool SuppressVideoStart
	{
		get
		{
			return GetValue("SuppressVideoStart", defaultValue: false);
		}
		set
		{
			SetValue("SuppressVideoStart", value);
			OnPropertyChanged("SuppressVideoStart");
		}
	}

	public ForegroundMediaAudioBehavior PresentationForegroundMediaAudioBehavior
	{
		get
		{
			return GetValue("PresentationForegroundMediaAudioBehavior", ForegroundMediaAudioBehavior.ClearAlways);
		}
		set
		{
			SetValue("PresentationForegroundMediaAudioBehavior", value);
			OnPropertyChanged("PresentationForegroundMediaAudioBehavior");
		}
	}

	public ForegroundMediaAudioBehavior AnnouncementForegroundMediaAudioBehavior
	{
		get
		{
			return GetValue("AnnouncementForegroundMediaAudioBehavior", ForegroundMediaAudioBehavior.ClearAlways);
		}
		set
		{
			SetValue("AnnouncementForegroundMediaAudioBehavior", value);
			OnPropertyChanged("AnnouncementForegroundMediaAudioBehavior");
		}
	}

	public bool IgnoreBackgroundColors
	{
		get
		{
			return GetValue("IgnoreBackgroundColors", defaultValue: false);
		}
		set
		{
			SetValue("IgnoreBackgroundColors", value);
			OnPropertyChanged("IgnoreBackgroundColors");
			lock (_backgroundColorsLock)
			{
				int num = 0;
				while (num < _ignoreBackgroundColorsChangedActions.Count)
				{
					if (_ignoreBackgroundColorsChangedActions[num].TryGetTarget(out Action target))
					{
						target?.Invoke();
						num++;
					}
					else
					{
						_ignoreBackgroundColorsChangedActions.RemoveAt(num);
					}
				}
			}
		}
	}

	public bool EnableSearchRoots
	{
		get
		{
			return GetValue("EnableSearchRoots", defaultValue: false);
		}
		set
		{
			SetValue("EnableSearchRoots", value);
			OnPropertyChanged("EnableSearchRoots");
			RelativePath.NotifySearchRootsUpdated();
		}
	}

	public ISearchRootCollection SearchRoots => _searchRoots;

	public bool NDIShowLocalSources
	{
		get
		{
			return GetValue("NDIShowLocalSources", defaultValue: true);
		}
		set
		{
			SetValue("NDIShowLocalSources", value);
			OnPropertyChanged("NDIShowLocalSources");
		}
	}

	public string NDIInputGroups
	{
		get
		{
			return GetValue("NDIInputGroups", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("NDIInputGroups", value);
			OnPropertyChanged("NDIInputGroups");
		}
	}

	public string NDIExtraIPs
	{
		get
		{
			return GetValue("NDIExtraIPs", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("NDIExtraIPs", value);
			OnPropertyChanged("NDIExtraIPs");
		}
	}

	private Advanced()
		: base(Path.Combine(CommonPaths.Preferences, "AdvancedPreferences.proPref"))
	{
		RegisterEnumType<ForegroundMediaAudioBehavior>();
		RegisterCustomType((Tuple<SearchRootType, bool> r) => $"{r?.Item1 ?? SearchRootType.Documents}|{r?.Item2}", delegate(string v)
		{
			string[] array = v.Split('|');
			if (array.Length != 2)
			{
				throw new ArgumentException("There are not enough parts to the value '" + v + "'");
			}
			return new Tuple<SearchRootType, bool>((SearchRootType)int.Parse(array[0]), bool.Parse(array[1]));
		});
		RegisterListType<Tuple<SearchRootType, bool>, List<Tuple<SearchRootType, bool>>>();
		List<Tuple<SearchRootType, bool>> serializedRoots = GetValue<List<Tuple<SearchRootType, bool>>>("SearchRoots");
		List<Tuple<SearchRootType, bool>> list = serializedRoots;
		if (list != null && list.Any())
		{
			int i;
			for (i = 0; i < serializedRoots.Count; i++)
			{
				ISearchRoot[] array2 = SearchRoots.Where((ISearchRoot r) => r.Type == serializedRoots[i].Item1).ToArray();
				array2.ForEach(delegate(ISearchRoot r)
				{
					r.IsActive = serializedRoots[i].Item2;
				});
				_searchRoots.MoveTo(array2, i);
			}
		}
		_searchRoots.DataModified += SearchRoots_DataModified;
		RelativePath.SetSearchRootsProvider(() => (!EnableSearchRoots) ? null : _searchRoots);
	}

	public void RegisterIgnoreBackgroundColorsChangedAction(Action action)
	{
		lock (_backgroundColorsLock)
		{
			_ignoreBackgroundColorsChangedActions.RemoveAll((WeakReference<Action> action) => !action.TryGetTarget(out Action _));
			_ignoreBackgroundColorsChangedActions.Add(new WeakReference<Action>(action));
		}
	}

	private void SearchRoots_DataModified()
	{
		SetValue("SearchRoots", SearchRoots.Select((ISearchRoot r) => new Tuple<SearchRootType, bool>(r.Type, r.IsActive)).ToList());
		RelativePath.NotifySearchRootsUpdated();
	}
}
