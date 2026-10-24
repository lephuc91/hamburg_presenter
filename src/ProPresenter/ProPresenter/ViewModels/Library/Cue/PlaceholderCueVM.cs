using System;
using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Pro.Common.Nullability;
using Pro.Common.SourceGenerator.Attributes;
using Pro.DO.Storage;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.UI.ViewModels.Library.Cue;

namespace ProPresenter.ViewModels.Library.Cue;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class PlaceholderCueVM : ObservableObject, IPlaceholderCueVM, IProPresenterCueVM, INotifyPropertyChanged, IDisposable, IDocumentCueVM, IFileResource
{
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Name", "Name")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("IsLinked", "IsLinked")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("DocumentAction", "DocumentAction")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Path", "Path")]
	private readonly PlaceholderCue _placeholder;

	private readonly ILibraryCollection _libraries;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ProPresenterCue Cue => Placeholder;

	public PlaceholderCue Placeholder => _placeholder;

	public PlaceholderAction PlaceholderAction
	{
		get
		{
			Placeholder.PlaceholderAction.ThrowWhenNull("Placeholder.PlaceholderAction");
			return Placeholder.PlaceholderAction;
		}
	}

	public CueType Type => Cue.Type;

	public string Name
	{
		get
		{
			return Cue.Name;
		}
		set
		{
			Cue.Name = value;
		}
	}

	public bool IsLinked => Placeholder.IsLinked;

	public IDocumentCue Document => _placeholder;

	public IDocumentAction? DocumentAction => _placeholder.DocumentAction;

	public RelativePath? Path => _placeholder.Path;

	public PlaceholderCueVM(PlaceholderCue placeholderCue, ILibraryCollection libraries)
	{
		_placeholder = placeholderCue;
		_libraries = libraries;
		EnsureDocumentCueValid();
		libraries.LibraryCollectionChanged += Libraries_LibraryCollectionChanged;
		AddPropertyLinks();
	}

	private void Libraries_LibraryCollectionChanged(ILibrary library, NotifyCollectionChangedEventArgs args)
	{
		EnsureDocumentCueValid();
	}

	private void EnsureDocumentCueValid()
	{
		if (Placeholder.IsLinked)
		{
			DocumentAction?.EnsurePresentationResolved(_libraries);
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
		_libraries.LibraryCollectionChanged -= Libraries_LibraryCollectionChanged;
		RemovePropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _placeholder_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "Name":
			OnPropertyChanged("Name");
			break;
		case "IsLinked":
			OnPropertyChanged("IsLinked");
			break;
		case "DocumentAction":
			OnPropertyChanged("DocumentAction");
			break;
		case "Path":
			OnPropertyChanged("Path");
			break;
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_placeholder.PropertyChanged += _placeholder_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_placeholder.PropertyChanged -= _placeholder_PropertyChanged;
	}
}
