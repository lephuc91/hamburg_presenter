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
public class DocumentCueVM : ObservableObject, IDocumentCueVM, IProPresenterCueVM, INotifyPropertyChanged, IDisposable, IFileResource
{
	private readonly ILibraryCollection _libraries;

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Name", "Name")]
	private readonly DocumentCue _documentCue;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ProPresenterCue Cue => _documentCue;

	public IDocumentCue Document => _documentCue;

	public IDocumentAction? DocumentAction => Document.DocumentAction;

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

	public RelativePath? Path => Document.Path;

	public DocumentCueVM(DocumentCue documentCue, ILibraryCollection libraries)
	{
		_documentCue = documentCue;
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
		Document.DocumentAction.ThrowWhenNull("Document.DocumentAction");
		Document.DocumentAction.EnsurePresentationResolved(_libraries);
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
	private void _documentCue_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Name")
		{
			OnPropertyChanged("Name");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_documentCue.PropertyChanged += _documentCue_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_documentCue.PropertyChanged -= _documentCue_PropertyChanged;
	}
}
