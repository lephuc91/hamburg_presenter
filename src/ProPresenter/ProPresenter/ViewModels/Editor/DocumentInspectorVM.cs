using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Components.Reversibility;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.UI.Components;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.ViewModels.Editor;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class DocumentInspectorVM : ObservableObject, IDocumentInspectorVM, IDisposable
{
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("ShowHoW", "ShowCCLIInfo")]
	private readonly IGeneral _general;

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("IgnoreBackgroundColors", "IgnoreBackgroundColors")]
	private readonly IAdvanced _advanced;

	[ObservableProperty]
	[NotifyPropertyChangedFor("SelectedTransition")]
	private CustomPresentation? _presentation;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public TransitionParameters? SelectedTransition
	{
		get
		{
			return Presentation?.SelectedTransition;
		}
		set
		{
			if (Presentation != null && Presentation.SelectedTransition != value)
			{
				Presentation.SelectedTransition = value;
				TransitionHandler.ActivateTransition(value);
			}
		}
	}

	public bool ShowCCLIInfo => _general.ShowHoW;

	public ssAPIOutput OutputController { get; }

	public TransitionHandler TransitionHandler { get; } = new TransitionHandler(DataVault.Transitions);

	public ICommand RemoveTransitionCommand => new RelayCommand(TransitionHandler.RemoveTransition);

	public ICommand<ColorPair> ColorChangeStartedCommand => new RelayCommand<ColorPair>(delegate
	{
		Presentation?.UndoStack.BeginCommit(UndoActionTypes.ChangeDocumentColor.ToAction());
	}, (ColorPair c) => c.OldColor.HasValue);

	public ICommand<ColorPair> ColorChangeFinishedCommand => new RelayCommand<ColorPair>(delegate
	{
		Presentation?.UndoStack.EndCommit(null, null, autoFinalize: true);
	}, (ColorPair c) => c.OldColor.HasValue && (Presentation?.UndoStack.IsRecording ?? false));

	public bool IgnoreBackgroundColors => _advanced.IgnoreBackgroundColors;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public CustomPresentation? Presentation
	{
		get
		{
			return _presentation;
		}
		set
		{
			if (!EqualityComparer<CustomPresentation>.Default.Equals(_presentation, value))
			{
				CustomPresentation presentation = _presentation;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Presentation);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedTransition);
				_presentation = value;
				OnPresentationChanged(presentation, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Presentation);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedTransition);
			}
		}
	}

	public DocumentInspectorVM(ssAPIOutput outputController, IGeneral general, IAdvanced advanced)
	{
		OutputController = outputController;
		_general = general;
		_advanced = advanced;
		TransitionHandler.TransitionFinalized += delegate(TransitionParameters? t)
		{
			SelectedTransition = t;
		};
		AddPropertyLinks();
	}

	private void Presentation_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "SelectedTransition")
		{
			OnPropertyChanged("SelectedTransition");
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnPresentationChanged(CustomPresentation? oldValue, CustomPresentation? newValue)
	{
		if (oldValue != null)
		{
			oldValue.PropertyChanged -= Presentation_PropertyChanged;
		}
		if (newValue != null)
		{
			newValue.PropertyChanged += Presentation_PropertyChanged;
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
		RemovePropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _general_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ShowHoW")
		{
			OnPropertyChanged("ShowCCLIInfo");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _advanced_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IgnoreBackgroundColors")
		{
			OnPropertyChanged("IgnoreBackgroundColors");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_general.PropertyChanged += _general_PropertyChanged;
		_advanced.PropertyChanged += _advanced_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_general.PropertyChanged -= _general_PropertyChanged;
		_advanced.PropertyChanged -= _advanced_PropertyChanged;
	}
}
