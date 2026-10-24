using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Utility;
using Pro.Text;
using Pro.Text.Reversibility;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;
using ProPresenter.UI.ViewModels;
using ProPresenter.ViewModels.TextStyle;

namespace ProPresenter.ViewModels;

public class TextStyleVM : LinkedNotifyPropertyChangedBase, ITextStyleVM, INotifyPropertyChanged
{
	private readonly ITextStyleFacade _textStyleFacade;

	public bool CanShowTextStylePopover => _textStyleFacade.CanShowTextStylePopover;

	public ICommand<TargetStrategy> CopyTextStyleCommand => new RelayCommand<TargetStrategy>(OnCopyTextStyleCommand, CanCopyTextStyle);

	public ICommand<TargetStrategy> PasteTextStyleCommand => new RelayCommand<TargetStrategy>(OnPasteTextStyleCommand, CanPasteTextStyle);

	public ICommand ApplyTextStyleToAllSlidesCommand => new RelayCommand(OnApplyTextStyleToAllSlidesCommand, CanApplyTextStyleToAllSlides);

	public ICommand<TemplateSlide> ApplyTemplateCommand => new RelayCommand<TemplateSlide>(OnApplyTemplateCommand);

	public ICommand<(Action<TextDocumentSettings>, Pro.Text.Reversibility.UndoActionTypes, bool)> ApplyDocumentSettingsCommand => new RelayCommand<(Action<TextDocumentSettings>, Pro.Text.Reversibility.UndoActionTypes, bool)>(ApplyDocumentSettings);

	public ICommand<(Action<ParagraphSettings>, Pro.Text.Reversibility.UndoActionTypes, bool)> ApplyParagraphSettingsCommand => new RelayCommand<(Action<ParagraphSettings>, Pro.Text.Reversibility.UndoActionTypes, bool)>(ApplyParagraphSettings);

	public ICommand<(Action<RunSettings>, Pro.Text.Reversibility.UndoActionTypes, bool)> ApplyRunSettingsCommand => new RelayCommand<(Action<RunSettings>, Pro.Text.Reversibility.UndoActionTypes, bool)>(ApplyRunSettings);

	public TextStyleVM(ITextStyleFacade textStyleFacade)
	{
		_textStyleFacade = textStyleFacade;
		LinkProperties("CanShowTextStylePopover", "CanShowTextStylePopover");
		_textStyleFacade.PropertyChanged += base.RaiseLinkedValues;
	}

	private void OnCopyTextStyleCommand(TargetStrategy strategy)
	{
		ClipboardManager.SetData(_textStyleFacade.GetCurrentTextStyle(strategy));
	}

	private bool CanCopyTextStyle(TargetStrategy strategy)
	{
		return _textStyleFacade.CanCopyTextStyle(strategy);
	}

	private void OnPasteTextStyleCommand(TargetStrategy strategy)
	{
		ClipboardManager.GetData<ProPresenter.DO.TextStyle>()?.Apply(_textStyleFacade.GetTargetElements(strategy).ToArray());
	}

	private bool CanPasteTextStyle(TargetStrategy strategy)
	{
		if (ClipboardManager.ContainsData<ProPresenter.DO.TextStyle>())
		{
			return _textStyleFacade.GetTargetElements(strategy).Any();
		}
		return false;
	}

	private void OnApplyTextStyleToAllSlidesCommand()
	{
		_textStyleFacade.GetCurrentTextStyle(TargetStrategy.SelectedElements)?.Apply(_textStyleFacade.GetTargetElements(TargetStrategy.AllSlides).ToArray());
	}

	private bool CanApplyTextStyleToAllSlides()
	{
		return _textStyleFacade.CanCopyTextStyle(TargetStrategy.SelectedElements);
	}

	private void OnApplyTemplateCommand(TemplateSlide template)
	{
		_textStyleFacade.ApplyTemplate(template);
	}

	private void ApplyDocumentSettings((Action<TextDocumentSettings> action, Pro.Text.Reversibility.UndoActionTypes undoType, bool autoFinalize) p)
	{
		ApplyChange(delegate(ClosedBezierPath e)
		{
			p.action(e.Text.Settings);
		}, p.undoType, p.autoFinalize);
	}

	private void ApplyParagraphSettings((Action<ParagraphSettings> action, Pro.Text.Reversibility.UndoActionTypes undoType, bool autoFinalize) p)
	{
		ApplyChange(delegate(ClosedBezierPath e)
		{
			e.Text.IterateParagraphs(Pro.Text.Range.All, delegate(Paragraph paragraph)
			{
				p.action(paragraph.Settings);
			});
		}, p.undoType, p.autoFinalize);
	}

	private void ApplyRunSettings((Action<RunSettings> action, Pro.Text.Reversibility.UndoActionTypes undoType, bool autoFinalize) p)
	{
		ApplyChange(delegate(ClosedBezierPath e)
		{
			e.Text.IterateRuns(Pro.Text.Range.All, splitRuns: false, delegate(RunBase r)
			{
				p.action(r.Settings);
			});
		}, p.undoType, p.autoFinalize);
	}

	private void ApplyChange(Action<ClosedBezierPath> action, Pro.Text.Reversibility.UndoActionTypes undoType, bool autoFinalize)
	{
		IEnumerable<ClosedBezierPath> targetElements = _textStyleFacade.GetTargetElements(TargetStrategy.SelectedSlides);
		if (targetElements.Empty())
		{
			return;
		}
		foreach (var (undoStack2, source) in from t in targetElements
			group t by t.UndoStack)
		{
			undoStack2?.BeginCommit(undoType.ToAction());
			source.ForEach(action);
			undoStack2?.EndCommit(null, null, autoFinalize);
		}
	}
}
