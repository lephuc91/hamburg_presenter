using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Editor;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Editor;

public class OutputScreenLinkVM : NotifyPropertyChangedBase, IOutputScreenLinkVM
{
	private readonly ObservableCollection<ICanvasElement> _selectedCanvasElements;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedCanvasElements.OfType<ClosedBezierPath>();

	private ClosedBezierPath? FirstElement => SelectedElements.FirstOrDefault();

	private UndoStack? UndoStack => FirstElement?.UndoStack;

	public IEnumerable<ScreenArrangementBase> Screens => OutputVault.AllScreens;

	public ScreenArrangementBase? SelectedScreen
	{
		get
		{
			return (FirstElement?.FillLink.LinkedObject as OutputScreenLinkedObject)?.Screen;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.LinkScreen.ToAction());
			foreach (ClosedBezierPath selectedElement in SelectedElements)
			{
				if (selectedElement.FillLink.LinkedObject is OutputScreenLinkedObject outputScreenLinkedObject)
				{
					outputScreenLinkedObject.Screen = value;
				}
				else
				{
					selectedElement.FillLink.LinkedObject = new OutputScreenLinkedObject(value);
				}
			}
			OnPropertyChanged("SelectedScreen");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public ICommand<ScreenArrangementBase> SelectScreeenCommand => new RelayCommand<ScreenArrangementBase>(delegate(ScreenArrangementBase s)
	{
		SelectedScreen = s;
	});

	public OutputScreenLinkVM(ObservableCollection<ICanvasElement> selectedCanvasElements)
	{
		_selectedCanvasElements = selectedCanvasElements;
		_selectedCanvasElements.CollectionChanged += delegate
		{
			OnPropertyChanged("SelectedScreen");
		};
		if (OutputVault.AudienceScreenArrangementCollection != null)
		{
			OutputVault.AudienceScreenArrangementCollection.CollectionChanged += OnScreenCollectionChanged;
		}
		if (OutputVault.StageScreenArrangementCollection != null)
		{
			OutputVault.StageScreenArrangementCollection.CollectionChanged += OnScreenCollectionChanged;
		}
	}

	private void OnScreenCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnPropertyChanged("Screens");
	}
}
