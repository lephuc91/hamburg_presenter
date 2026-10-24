using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Collections;
using Pro.Common.SourceGenerator.Attributes;
using Pro.UI.SVG;
using ProPresenter.DO.ProContent.Model.Collection;
using ProPresenter.DO.ProContent.Model.Group;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.ProContent.Collection;
using ProPresenter.UI.ViewModels.ProContent.Group;

namespace ProPresenter.ViewModels.ProContent.Group;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class ProContentGroupVM : ObservableObject, IProContentGroupVMInternal, IProContentGroupVM, INavigationItem, INotifyPropertyChanged, IDisposable
{
	private readonly INavigationItem _parent;

	private readonly PairedCollection<IProContentCollection, IProContentCollectionVM> _collection;

	[ObservableProperty]
	private ImageSource? _icon;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public string Name => Group.DisplayName;

	public INavigationItem Parent => _parent;

	public INotifyEnumerableChanged<IProContentCollectionVM> Collection => _collection;

	public IEnumerable Children => Array.Empty<INavigationItem>();

	public double ThumbnailAspectRatio => 1.7777777777777777;

	public int Index => 0;

	public IProContentGroup Group { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ImageSource? Icon
	{
		get
		{
			return _icon;
		}
		set
		{
			if (!EqualityComparer<ImageSource>.Default.Equals(_icon, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Icon);
				_icon = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Icon);
			}
		}
	}

	public ProContentGroupVM(IProContentGroup group, INavigationItem parent, IProContentVMsFactory factory)
	{
		ProContentGroupVM group2 = this;
		Group = group;
		_parent = parent;
		Icon = Group.Icon?.ToSvgImageSource();
		_collection = new PairedCollection<IProContentCollection, IProContentCollectionVM>(Group, (IProContentCollection c) => factory.CreateCollection(c, group2), delegate(IProContentCollectionVM c)
		{
			c.Dispose();
		});
		group.PropertyChanged += Group_PropertyChanged;
	}

	private void Group_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "DisplayName"))
		{
			if (propertyName == "Icon")
			{
				Icon = Group.Icon?.ToSvgImageSource();
			}
		}
		else
		{
			OnPropertyChanged("Name");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		Group.PropertyChanged -= Group_PropertyChanged;
		_collection.ClearSource();
	}
}
