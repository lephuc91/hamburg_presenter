using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Collections;
using ProPresenter.DO.ProContent.Model.Collection;

namespace ProPresenter.DO.ProContent.Model.Group;

public class ProContentSearchGroup : ProContentGroup, IInternalProContentSearchGroup, IInternalProContentGroup, IProContentGroup, INotifyEnumerableChanged<IProContentCollection>, IEnumerable<IProContentCollection>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged, IProContentSearchGroup
{
	private const string SEARCH_GROUP_ID = "INTERNAL_SEARCH_GROUP";

	[ObservableProperty]
	private string _searchTerm = string.Empty;

	[ObservableProperty]
	private bool _searchInProgress;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string SearchTerm
	{
		get
		{
			return _searchTerm;
		}
		[MemberNotNull("_searchTerm")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_searchTerm, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SearchTerm);
				_searchTerm = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SearchTerm);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool SearchInProgress
	{
		get
		{
			return _searchInProgress;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_searchInProgress, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SearchInProgress);
				_searchInProgress = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SearchInProgress);
			}
		}
	}

	public ProContentSearchGroup()
		: base("Search", null, "INTERNAL_SEARCH_GROUP")
	{
	}
}
