using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.UI.ViewModels.Library.Cue;

namespace ProPresenter.ViewModels.Library.Cue;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class HeaderCueVM : ObservableObject, IHeaderCueVM, IProPresenterCueVM, INotifyPropertyChanged, IDisposable
{
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Name", "Name")]
	private readonly HeaderCue _header;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ProPresenterCue Cue => Header;

	public HeaderCue Header => _header;

	public HeaderAction HeaderAction => Header.HeaderAction;

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

	public HeaderCueVM(HeaderCue headerCue)
	{
		_header = headerCue;
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
	private void _header_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Name")
		{
			OnPropertyChanged("Name");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_header.PropertyChanged += _header_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_header.PropertyChanged -= _header_PropertyChanged;
	}
}
