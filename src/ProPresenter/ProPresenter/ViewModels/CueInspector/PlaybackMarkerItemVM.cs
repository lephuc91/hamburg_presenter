using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Components.Reversibility;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.UI.ViewModels.CueInspector;

namespace ProPresenter.ViewModels.CueInspector;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class PlaybackMarkerItemVM : ObservableObject, IPlaybackMarkerItemVM, INotifyPropertyChanged, IDisposable
{
	private bool _isDragging;

	[ObservableProperty]
	private string _playbackMarkerTooltip = string.Empty;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? startDragCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? stopDragCommand;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("VisualTimestamp", "Timestamp")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Color", "Color")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Name", "Name")]
	public IPlaybackMarker Marker { get; }

	public TimeSlice Timestamp
	{
		get
		{
			return Marker.VisualTimestamp;
		}
		set
		{
			Marker.VisualTimestamp = value;
			if (!_isDragging)
			{
				Marker.Timestamp = value;
			}
		}
	}

	public Color Color
	{
		get
		{
			return Marker.Color;
		}
		set
		{
			Marker.Color = value;
		}
	}

	public string Name
	{
		get
		{
			return Marker.Name;
		}
		set
		{
			Marker.Name = value;
		}
	}

	public IEnumerable<IScrimSource> ScrimItems => Marker.Actions.OfType<IScrimSource>();

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string PlaybackMarkerTooltip
	{
		get
		{
			return _playbackMarkerTooltip;
		}
		[MemberNotNull("_playbackMarkerTooltip")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_playbackMarkerTooltip, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.PlaybackMarkerTooltip);
				_playbackMarkerTooltip = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.PlaybackMarkerTooltip);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand StartDragCommand => startDragCommand ?? (startDragCommand = new RelayCommand(StartDrag));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand StopDragCommand => stopDragCommand ?? (stopDragCommand = new RelayCommand(StopDrag));

	[RelayCommand]
	private void StartDrag()
	{
		_isDragging = true;
		Marker.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MovePlaybackMarker));
	}

	[RelayCommand]
	private void StopDrag()
	{
		Marker.UndoStack?.EndCommit(null, null, autoFinalize: true);
		Marker.Timestamp = Marker.VisualTimestamp;
		_isDragging = false;
	}

	public PlaybackMarkerItemVM(IPlaybackMarker source)
	{
		Marker = source;
		AddPropertyLinks();
		Marker.Actions.CollectionChanged += SourceActionCollectionChanged;
	}

	private void SourceActionCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnPropertyChanged("ScrimItems");
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
		Marker.Actions.CollectionChanged -= SourceActionCollectionChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void Marker_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "VisualTimestamp":
			OnPropertyChanged("Timestamp");
			break;
		case "Color":
			OnPropertyChanged("Color");
			break;
		case "Name":
			OnPropertyChanged("Name");
			break;
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		Marker.PropertyChanged += Marker_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		Marker.PropertyChanged -= Marker_PropertyChanged;
	}
}
