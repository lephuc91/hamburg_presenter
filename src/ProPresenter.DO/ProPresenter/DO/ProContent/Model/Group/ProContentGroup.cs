using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Collections;
using ProPresenter.DO.ProContent.Model.Collection;

namespace ProPresenter.DO.ProContent.Model.Group;

public class ProContentGroup : ObservableObject, IInternalProContentGroup, IProContentGroup, INotifyEnumerableChanged<IProContentCollection>, IEnumerable<IProContentCollection>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged
{
	[ObservableProperty]
	private string _displayName = string.Empty;

	[ObservableProperty]
	private string _icon = string.Empty;

	public string Id { get; }

	private ObservableCollection<IProContentCollection> Collection { get; } = new ObservableCollection<IProContentCollection>();

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string DisplayName
	{
		get
		{
			return _displayName;
		}
		[MemberNotNull("_displayName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_displayName, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.DisplayName);
				_displayName = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.DisplayName);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string Icon
	{
		get
		{
			return _icon;
		}
		[MemberNotNull("_icon")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_icon, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Icon);
				_icon = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Icon);
			}
		}
	}

	public event NotifyCollectionChangedEventHandler? CollectionChanged
	{
		add
		{
			Collection.CollectionChanged += value;
		}
		remove
		{
			Collection.CollectionChanged -= value;
		}
	}

	public ProContentGroup(string displayName, string? icon, string id)
	{
		DisplayName = displayName;
		Icon = icon ?? string.Empty;
		Id = id;
	}

	public void Add(IProContentCollection collection)
	{
		Collection.Add(collection);
	}

	public IEnumerator<IProContentCollection> GetEnumerator()
	{
		return Collection.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)Collection).GetEnumerator();
	}

	public void Clear()
	{
		Collection.Clear();
	}
}
