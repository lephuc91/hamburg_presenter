using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Collections;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings;

public class SettingsSearchVM : ObservableObject, ISettingsSearchVM, INotifyPropertyChanged
{
	private sealed class SearchResultCollection : ImmutableObservableCollection<ISettingsSearchResultItemVM>
	{
		public void Clear()
		{
			base.Collection.Clear();
		}

		public void Add(ISettingsSearchResultItemVM result)
		{
			base.Collection.Add(result);
		}
	}

	private readonly SearchResultCollection _results = new SearchResultCollection();

	private readonly ISettingsSearchEngine _searchEngine;

	private readonly ISettingsSearchFactory _factory;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsSearching")]
	private string _searchText = string.Empty;

	[ObservableProperty]
	private ISettingsSearchResultItemVM? _activeItem;

	[ObservableProperty]
	private ISettingsSearchResultItemVM? _selectedItem;

	public bool IsSearching => !string.IsNullOrWhiteSpace(SearchText?.Trim());

	public INotifyEnumerableChanged<ISettingsSearchResultItemVM> SearchResults => _results;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string SearchText
	{
		get
		{
			return _searchText;
		}
		[MemberNotNull("_searchText")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_searchText, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SearchText);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsSearching);
				_searchText = value;
				OnSearchTextChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SearchText);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsSearching);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ISettingsSearchResultItemVM? ActiveItem
	{
		get
		{
			return _activeItem;
		}
		set
		{
			if (!EqualityComparer<ISettingsSearchResultItemVM>.Default.Equals(_activeItem, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ActiveItem);
				_activeItem = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ActiveItem);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ISettingsSearchResultItemVM? SelectedItem
	{
		get
		{
			return _selectedItem;
		}
		set
		{
			if (!EqualityComparer<ISettingsSearchResultItemVM>.Default.Equals(_selectedItem, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedItem);
				_selectedItem = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedItem);
			}
		}
	}

	public SettingsSearchVM(ISettingsSearchEngine searchEngine, ISettingsSearchFactory factory)
	{
		_searchEngine = searchEngine;
		_factory = factory;
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSearchTextChanged(string value)
	{
		_results.Clear();
		List<ISettingsSearchPageField> results = _searchEngine.Search(value).ToList();
		foreach (IGrouping<ISettingsItemVM, ISettingsSearchPageField> item in (from f in results
			group f by f.Page).ToList())
		{
			results.Clear();
			foreach (ISettingsSearchPageField item2 in item)
			{
				if (item2.LinkedField != null)
				{
					onAdd(results, item2.LinkedField);
				}
				else
				{
					onAdd(results, item2);
				}
			}
			if (results.Empty())
			{
				continue;
			}
			if (results.Count == 1 && !results.FirstOrDefault().IsComponent)
			{
				item.Key.Fields.Where((ISettingsSearchPageField f) => f.LinkedField == null && f.IsComponent).ForEach(delegate(ISettingsSearchPageField f)
				{
					onAdd(results, f);
				});
			}
			if (item.Key.PageField != null && results.TrueForAll((ISettingsSearchPageField f) => f.IsComponent))
			{
				results.Insert(0, item.Key.PageField);
			}
			ISettingsSearchPageField settingsSearchPageField = results.FirstOrDefault((ISettingsSearchPageField f) => !f.IsComponent);
			if (settingsSearchPageField != null)
			{
				results.MoveTo(settingsSearchPageField.ToEnumerable(), 0);
			}
			results.Select(_factory.Create).ForEach(_results.Add);
		}
		static void onAdd(List<ISettingsSearchPageField> fieldResults, ISettingsSearchPageField field)
		{
			if (!fieldResults.Contains(field))
			{
				fieldResults.Add(field);
			}
		}
	}
}
