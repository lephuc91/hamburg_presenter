using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Pro.Common.Nullability;
using Pro.Common.SourceGenerator.Attributes;
using Pro.DO.Storage;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.UI.ViewModels.Library.Cue;

namespace ProPresenter.ViewModels.Library.Cue;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class MediaCueVM : ObservableObject, IMediaCueVM, IProPresenterCueVM, INotifyPropertyChanged, IDisposable, IFileResource
{
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Name", "Name")]
	private readonly MediaCue _media;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ProPresenterCue Cue => Media;

	public MediaCue Media => _media;

	public MediaAction MediaAction
	{
		get
		{
			Media.MediaAction.ThrowWhenNull("Media.MediaAction");
			return Media.MediaAction;
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

	public RelativePath? Path => Media.Path;

	public MediaCueVM(MediaCue media)
	{
		_media = media;
		AddPropertyLinks();
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
		RemovePropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _media_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Name")
		{
			OnPropertyChanged("Name");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_media.PropertyChanged += _media_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_media.PropertyChanged -= _media_PropertyChanged;
	}
}
