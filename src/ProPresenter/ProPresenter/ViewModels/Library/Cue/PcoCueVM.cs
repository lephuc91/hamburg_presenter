using System;
using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.DO.Storage;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Actions.PCO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.PCO;
using ProPresenter.UI.ViewModels.Library.Cue;

namespace ProPresenter.ViewModels.Library.Cue;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_changeSubscription", "_actionChangeSubscription" })]
public class PcoCueVM : ObservableObject, IPcoCueVM, IProPresenterCueVM, INotifyPropertyChanged, IDisposable, IDocumentCueVM, IFileResource
{
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Name", "Name")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("PCOItemType", "PCOItemType")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("DocumentAction", "DocumentAction")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Path", "Path")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("IsLinked", "Name")]
	private readonly PCOCueBase _pco;

	private readonly ILibraryCollection _libraries;

	private IDisposable? _changeSubscription;

	private readonly IDisposable? _actionChangeSubscription;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ProPresenterCue Cue => Pco;

	public PCOCueBase Pco => _pco;

	public PCOActionBase? PCOAction => _pco.PCOAction;

	public HeaderAction? HeaderAction
	{
		get
		{
			if (!(_pco is PCOHeaderCue pCOHeaderCue))
			{
				return null;
			}
			return pCOHeaderCue.HeaderAction;
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

	public PCOItemType PCOItemType => _pco.PCOItemType;

	public IDocumentCue Document => _pco;

	public IDocumentAction? DocumentAction => _pco.DocumentAction;

	public RelativePath? Path => _pco.Path;

	public PcoCueVM(PCOCueBase pcoCue, ILibraryCollection libraries)
	{
		_pco = pcoCue;
		_libraries = libraries;
		EnsureDocumentCueValid();
		libraries.LibraryCollectionChanged += Libraries_LibraryCollectionChanged;
		_actionChangeSubscription = _pco.WhenPropertyChanges("IsLinked").ToUnit().StartWith(Unit.Default)
			.Subscribe(delegate
			{
				if (_pco.IsLinked)
				{
					SetupActionPropertyChanged(_pco.PCOAction);
				}
				else
				{
					TeardownActionPropertyChanged();
				}
			});
		AddPropertyLinks();
	}

	private void TeardownActionPropertyChanged()
	{
		_changeSubscription?.Dispose();
		_changeSubscription = null;
	}

	private void SetupActionPropertyChanged(PCOActionBase? action)
	{
		_changeSubscription?.Dispose();
		if (action?.DocumentAction != null)
		{
			_changeSubscription = action.DocumentAction.WhenPropertyChanges("Name").Subscribe(delegate
			{
				OnPropertyChanged("Name");
			});
		}
		else if (action?.MediaAction != null)
		{
			_changeSubscription = action.MediaAction.WhenPropertyChanges("Name").Subscribe(delegate
			{
				OnPropertyChanged("Name");
			});
		}
	}

	private void Libraries_LibraryCollectionChanged(ILibrary library, NotifyCollectionChangedEventArgs args)
	{
		EnsureDocumentCueValid();
	}

	private void EnsureDocumentCueValid()
	{
		if (_pco.IsLinked)
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
			_changeSubscription?.Dispose();
			_actionChangeSubscription?.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		_libraries.LibraryCollectionChanged -= Libraries_LibraryCollectionChanged;
		RemovePropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _pco_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "Name":
			OnPropertyChanged("Name");
			break;
		case "PCOItemType":
			OnPropertyChanged("PCOItemType");
			break;
		case "DocumentAction":
			OnPropertyChanged("DocumentAction");
			break;
		case "Path":
			OnPropertyChanged("Path");
			break;
		case "IsLinked":
			OnPropertyChanged("Name");
			break;
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_pco.PropertyChanged += _pco_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_pco.PropertyChanged -= _pco_PropertyChanged;
	}
}
