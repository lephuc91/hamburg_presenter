using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Nullability;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Presentation;
using ProPresenter.UI.ArrangementView;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class ArrangementVM : NotifyPropertyChangedBase, IArrangementVM, INotifyPropertyChanged, IDragDropCollection<IArrangement>, IDisposable
{
	private readonly Lazy<ArrangementManager> _arrangementManager;

	private readonly ICoreManager _coreManager;

	private DocumentAction? _documentAction;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public DocumentAction? DocumentAction
	{
		get
		{
			return _documentAction;
		}
		set
		{
			SetValue("DocumentAction", ref _documentAction, value, null, false, "ActiveGroup");
		}
	}

	public string PresentationName => Presentation?.Name ?? string.Empty;

	public CueGroup? ActiveGroup => _coreManager.ActiveSlides[DocumentAction?.Destination ?? OutputDestination.Presentation]?.Group;

	private IPresentation? Presentation => DocumentAction?.Presentation;

	private UndoStack? UndoStack => Presentation?.UndoStack;

	public ICommand<Arrangement> SelectArrangementCommand => new RelayCommand<Arrangement>(OnSelectArrangementCommand);

	public ICommand AddArrangementCommand => new RelayCommand(OnAddArrangementCommand);

	public ICommand OpenArrangementManagerCommand => new RelayCommand(OnOpenArrangementManagerCommand);

	public ICommand<Arrangement> DuplicateArrangementCommand => new RelayCommand<Arrangement>(OnDuplicateArrangementsCommand, (Arrangement a) => a != null);

	public ICommand<Arrangement> RemoveArrangementCommand => new RelayCommand<Arrangement>(OnRemoveArrangementsCommand, (Arrangement a) => a != null);

	public ICommand<CueGroup> RemoveGroupCommand => new RelayCommand<CueGroup>(OnRemoveGroupCommand);

	public ICommand<ArrangementDragCommandParameters> MoveGroupCommand => new RelayCommand<ArrangementDragCommandParameters>(OnMoveGroupCommand);

	public ArrangementVM(ICoreManager coreManager)
	{
		_arrangementManager = new Lazy<ArrangementManager>(() => new ArrangementManager().WithDataContext(this));
		_coreManager = coreManager;
		_coreManager.SlideTriggered += CoreManager_SlideTriggered;
	}

	private void CoreManager_SlideTriggered(ArrangedCue slide, int buildIndex, OutputDestination destination)
	{
		OnPropertyChanged("ActiveGroup");
	}

	private void OnSelectArrangementCommand(IArrangement arrangement)
	{
		if (DocumentAction != null)
		{
			IArrangement original = DocumentAction.ActiveArrangement;
			UndoStack?.Commit(UndoActionTypes.ChangeArrangement.ToAction(), delegate
			{
				DocumentAction.ActiveArrangement = original;
			}, delegate
			{
				DocumentAction.ActiveArrangement = arrangement;
			});
			DocumentAction.ActiveArrangement = arrangement;
		}
	}

	private void OnAddArrangementCommand()
	{
		if (Presentation == null)
		{
			return;
		}
		NewArrangementDialog newArrangementDialog = new NewArrangementDialog();
		if (MessageDialogService.ShowSimpleContent(LocalizedStrings.Get("PRESENTATION_HEADER_ARRANGEMENTS_NEW_ARRANGEMENT_title"), (DependencyObject)(object)newArrangementDialog) && !newArrangementDialog.ArrangementName.NullableIsNullOrWhiteSpace())
		{
			UndoStack?.BeginCommit(UndoActionTypes.AddArrangement.ToAction());
			IArrangement original = DocumentAction.ActiveArrangement;
			IArrangement newArrangement = Presentation.Arrangements.AddArrangement(newArrangementDialog.ArrangementName, Presentation.DefaultArrangement);
			UndoStack?.Commit(delegate
			{
				DocumentAction.ActiveArrangement = original;
			}, delegate
			{
				DocumentAction.ActiveArrangement = newArrangement;
			});
			DocumentAction.ActiveArrangement = newArrangement;
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	private void OnOpenArrangementManagerCommand()
	{
		_arrangementManager.Value.ShowDialog();
	}

	private void OnDuplicateArrangementsCommand(Arrangement arrangement)
	{
		if (Presentation != null)
		{
			OnSelectArrangementCommand(Presentation.Arrangements.DuplicateArrangement(arrangement));
		}
	}

	private void OnRemoveArrangementsCommand(Arrangement arrangement)
	{
		if (Presentation != null)
		{
			Presentation.Arrangements.RemoveArrangement(arrangement);
			if (DocumentAction.ActiveArrangement == arrangement)
			{
				DocumentAction? documentAction = DocumentAction;
				IArrangement activeArrangement = (Presentation.ActiveArrangement = Presentation.DefaultArrangement);
				documentAction.ActiveArrangement = activeArrangement;
			}
		}
	}

	private void OnRemoveGroupCommand(CueGroup group)
	{
		if (DocumentAction?.ActiveArrangement != null)
		{
			DocumentAction.ActiveArrangement.RemoveArrangementGroup(group);
		}
	}

	private void OnMoveGroupCommand(ArrangementDragCommandParameters parameters)
	{
		Arrangement arrangement = parameters.Arrangement;
		bool isMove = parameters.IsMove;
		int dropIndex = parameters.DropIndex;
		parameters.Groups.ThrowWhenNull("parameters.Groups");
		IEnumerable<CueGroup> groups = parameters.Groups;
		if (arrangement != null && !arrangement.IsMaster)
		{
			if (isMove)
			{
				arrangement.MoveArrangementGroups(groups, parameters.DropIndex);
			}
			else
			{
				arrangement.InsertArrangementGroups(parameters.DropIndex, groups);
			}
		}
		else if (Presentation != null)
		{
			if (isMove)
			{
				Presentation.ArrangementGroups.MoveArrangementGroups(dropIndex, groups);
			}
			else
			{
				Presentation.ArrangementGroups.InsertArrangementGroups(dropIndex, groups);
			}
		}
	}

	public int IndexOf(IArrangement item)
	{
		return Presentation?.Arrangements.IndexOf(item) ?? (-1);
	}

	public void DraggedFrom(IEnumerable<IArrangement> items)
	{
	}

	public void DroppedInto(IEnumerable<IArrangement> items, int index, bool isCopy)
	{
	}

	public void MoveTo(IEnumerable<IArrangement> items, int index)
	{
		Presentation?.Arrangements.MoveArrangement(items, index);
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
		_coreManager.SlideTriggered -= CoreManager_SlideTriggered;
	}
}
