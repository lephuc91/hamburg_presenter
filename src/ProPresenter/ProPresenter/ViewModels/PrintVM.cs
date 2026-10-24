using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.ErrorReporting;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.UI.Components;
using ProPresenter.DO.Analytics.Events.TrackedEvents;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Print;
using ProPresenter.DO.Settings;
using ProPresenter.UI.Print;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class PrintVM : NotifyPropertyChangedBase, IPrintVM, INotifyPropertyChanged
{
	private readonly IPrintPrompt _prompt;

	private readonly IApp _app;

	private readonly ObservableCollection<IDocumentCue> _cues = new ObservableCollection<IDocumentCue>();

	private readonly IErrorReporter _errorReporter;

	public PrintOptions PrintOptions { get; }

	public PrintManager PrintManager { get; }

	public ICommand OpenPrintSettingCommand => new RelayCommand(OnOpenPrintSetting);

	public ICommand OpenPreviewCommand => new RelayCommand(OnOpenPreviewCommand);

	public ICommand PrintCommand => new RelayCommand(delegate
	{
		OnPrintCommand(printing: true);
	});

	public ICommand<IEnumerable<IDocumentCue>> SetPrintTargetCommmand => new RelayCommand<IEnumerable<IDocumentCue>>(OnSetPrintTargetCommmand, (IEnumerable<IDocumentCue> t) => t.Any() && CheckBlankDocuments(t));

	public PrintVM(IApp app, IErrorReporter errorReporter, IPrintPrompt? prompt = null)
	{
		_app = app;
		_errorReporter = errorReporter;
		_prompt = prompt ?? new PrintPrompt();
		PrintOptions = new PrintOptions(app);
		PrintManager = new PrintManager(_cues, PrintOptions);
	}

	private void OnOpenPrintSetting()
	{
		if (PrintManager.ShowPrintSettings() == true)
		{
			OnPrintCommand(printing: true);
		}
	}

	private void OnPrintCommand(bool printing)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if (PrintOptions.IsThumbnail)
		{
			foreach (IDocumentCue cue in _cues)
			{
				Size printArea;
				if (printing)
				{
					printArea = PrintManager.GetPrintArea();
					RenderPrintThumbnails(cue, ((Size)(ref printArea)).Width, delegate(FlowDocument document)
					{
						PublishPrintEvent(PrintManager.Print(document));
					});
				}
				else
				{
					printArea = PrintManager.GetPrintArea();
					RenderPrintThumbnails(cue, ((Size)(ref printArea)).Width, showPrintPreview);
				}
			}
			return;
		}
		FlowDocument flowDocument = PrintManager.CreatePrintDocument(_cues, PrintOptions);
		if (printing)
		{
			try
			{
				PublishPrintEvent(PrintManager.Print(flowDocument));
				return;
			}
			catch (Exception e)
			{
				_errorReporter.Error(e, "Error printing document: " + flowDocument.Name);
				return;
			}
		}
		showPrintPreview(flowDocument);
		void PublishPrintEvent((bool didPrint, string printDeviceName) args)
		{
			if (args.didPrint)
			{
				PrintEvent.Publish((uint)_cues.Count, (!PrintOptions.IsThumbnail) ? PrintEvent.PrintMode.Outline : PrintEvent.PrintMode.Thumbnail, new PrintEvent.PrintInclusionFlags(PrintOptions.ShowMetaData, PrintOptions.ShowNotes, PrintOptions.ShowCurrentDate, PrintOptions.ShowSlideLabels, PrintOptions.ShowSlideNotes, PrintOptions.DisableSlides), (uint)PrintOptions.PrintColumns, args.printDeviceName);
			}
		}
		void showPrintPreview(FlowDocument doc)
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			IDocumentPaginatorSource previewSource = PrintManager.GetPreviewSource(doc);
			if (previewSource != null)
			{
				PrintPreview obj = new PrintPreview
				{
					PrintableDocument = previewSource
				};
				Size pageSize = previewSource.DocumentPaginator.PageSize;
				obj.Width = ((Size)(ref pageSize)).Width;
				obj.ShowDialog();
			}
		}
	}

	private void OnOpenPreviewCommand()
	{
		OnPrintCommand(printing: false);
	}

	private void RenderPrintThumbnails(IDocumentCue documentCue, double availableWidth, Action<FlowDocument> managerAction)
	{
		if (!(availableWidth <= 0.0))
		{
			(documentCue.DocumentAction?.ActiveArrangement).ThrowWhenNull("documentCue.DocumentAction?.ActiveArrangement");
			IImmutableObservableCollection<ArrangedCue> arrangedCues = documentCue.DocumentAction.ActiveArrangement.ArrangedCues;
			ThumbnailRenderer.RenderThumbnails(arrangedCues, availableWidth / (double)Math.Min(arrangedCues.Count, PrintOptions.PrintColumns), delegate(IEnumerable<DisposableRenderTargetBitmap> bitmaps)
			{
				PrintManager.OnThumbnailRenderCompleted(bitmaps, documentCue, managerAction);
			}, _app);
		}
	}

	private void OnSetPrintTargetCommmand(IEnumerable<IDocumentCue> cues)
	{
		_cues.Clear();
		_cues.AddRange(cues.Where(IsValid));
	}

	private bool CheckBlankDocuments(IEnumerable<IDocumentCue> cues)
	{
		bool num = cues.Any(IsValid);
		if (!num)
		{
			_prompt.ConfirmPrintingBlank();
		}
		return num;
	}

	private static bool IsValid(IDocumentCue cue)
	{
		if (cue.DocumentAction?.ActiveArrangement != null)
		{
			return cue.DocumentAction.ActiveArrangement.ArrangedCues.Any();
		}
		return false;
	}
}
