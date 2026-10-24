using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using Pro.Common.Collections;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.DO.Label;
using Pro.Localization;
using Pro.Text;
using Pro.UI.DialogService;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.DO.Print;

public class PrintManager
{
	private static readonly double TableMargin = 20.0;

	private static readonly double PageMargin = 96.0;

	private readonly Dictionary<IDocumentCue, IEnumerable<DisposableRenderTargetBitmap>> _renderedPlaylistItemThumbnails = new Dictionary<IDocumentCue, IEnumerable<DisposableRenderTargetBitmap>>();

	private readonly IEnumerable<IDocumentCue> _targetDocumentCues;

	private readonly PrintOptions _printOptions;

	private readonly Lazy<PrintDialog> _printDialog = new Lazy<PrintDialog>(() => new PrintDialog());

	public PrintManager(IEnumerable<IDocumentCue> targetDocumentCues, PrintOptions printOptions)
	{
		_targetDocumentCues = targetDocumentCues;
		_printOptions = printOptions;
	}

	public FlowDocument CreatePrintDocument(IEnumerable<IDocumentCue> cues, PrintOptions options)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			FlowDocument flowDocument = new FlowDocument();
			Size printArea = GetPrintArea();
			flowDocument.PageWidth = ((Size)(ref printArea)).Width;
			flowDocument.PageHeight = ((Size)(ref printArea)).Height;
			flowDocument.ColumnWidth = flowDocument.PageWidth;
			((IDocumentPaginatorSource)flowDocument).DocumentPaginator.PageSize = new Size(flowDocument.PageWidth + 2.0 * PageMargin, flowDocument.PageHeight + 2.0 * PageMargin);
			AddPrintContent(flowDocument, cues, options);
			return flowDocument;
		}
		catch (Exception exception)
		{
			Log.Error(exception);
			throw new Exception("Failed to create print document.");
		}
	}

	private void AddPrintContent(FlowDocument printDoc, IEnumerable<IDocumentCue> cues, PrintOptions options)
	{
		foreach (IDocumentCue cue in cues)
		{
			CreatePrintHeader(printDoc, cue, options);
			CreateContent(printDoc, cue, options);
		}
	}

	public void CreatePrintHeader(FlowDocument printDoc, IDocumentCue documentCue, PrintOptions option)
	{
		IPresentation presentation = documentCue.DocumentAction?.Presentation;
		System.Windows.Documents.Paragraph item = new System.Windows.Documents.Paragraph
		{
			Margin = new Thickness(0.0),
			BreakPageBefore = true
		};
		printDoc.Blocks.Add(item);
		if (option.ShowCurrentDate)
		{
			item = ParagraphHelper.GenerateParagraph(ParagraphType.Date, DateTime.Now.ToString("MMM dd, yyyy", CultureInfo.CurrentCulture));
			item.Margin = new Thickness(0.0);
			item.TextAlignment = TextAlignment.Right;
			printDoc.Blocks.Add(item);
		}
		item = ParagraphHelper.GenerateParagraph(ParagraphType.Heading, presentation?.Name ?? string.Empty);
		printDoc.Blocks.Add(item);
		if (option.ShowMetaData)
		{
			item = ParagraphHelper.GenerateMetaDataParagraph(presentation?.CCLIInfo);
			printDoc.Blocks.Add(item);
		}
		if (option.ShowNotes)
		{
			item = ParagraphHelper.GenerateParagraph(ParagraphType.Notes, presentation?.Notes ?? string.Empty);
			printDoc.Blocks.Add(item);
		}
	}

	private void CreateContent(FlowDocument printDoc, IDocumentCue documentCue, PrintOptions option)
	{
		int num = 1;
		GroupLabel groupLabel = null;
		if (!option.IsThumbnail && documentCue.DocumentAction != null)
		{
			IEnumerable<ArrangedCue> enumerable = documentCue.DocumentAction.ActiveArrangement?.ArrangedCues;
			{
				foreach (ArrangedCue item2 in enumerable ?? Enumerable.Empty<ArrangedCue>())
				{
					if (!option.DisableSlides && !item2.IsEnabled)
					{
						continue;
					}
					StringBuilder stringBuilder = new StringBuilder();
					GroupLabel groupLabel2 = item2.GroupLabel;
					if (!(item2.Source.SlideAction?.Slide is CustomSlide customSlide))
					{
						continue;
					}
					Block item;
					if (option.ShowSlideLabels)
					{
						string text = item2.Source.SlideAction.Label?.Text ?? string.Empty;
						if (groupLabel2 != null && groupLabel2.Text != null && groupLabel2 != groupLabel)
						{
							text = "[" + groupLabel2.Text + "] " + text;
						}
						if (!string.IsNullOrEmpty(text))
						{
							item = ParagraphHelper.GenerateParagraph(ParagraphType.Label, text);
							printDoc.Blocks.Add(item);
						}
						groupLabel = groupLabel2;
					}
					if (option.ShowSlideNumbers)
					{
						stringBuilder.Append(num + ". ");
						num++;
					}
					IEnumerable<string> allText = customSlide.GetAllText();
					if (allText.Any())
					{
						stringBuilder.Append(string.Join(Environment.NewLine, allText));
					}
					item = ParagraphHelper.GenerateParagraph(ParagraphType.SlideText, stringBuilder.ToString());
					printDoc.Blocks.Add(item);
					if (option.ShowSlideNotes)
					{
						item = ParagraphHelper.GenerateParagraph(ParagraphType.SlideNotes, customSlide.Note?.GetText(Pro.Text.Range.All) ?? string.Empty);
						printDoc.Blocks.Add(item);
					}
					printDoc.Blocks.Add(new System.Windows.Documents.Paragraph
					{
						Margin = new Thickness(0.0)
					});
				}
				return;
			}
		}
		IEnumerable<DisposableRenderTargetBitmap> enumerable2 = _renderedPlaylistItemThumbnails[documentCue];
		int printColumns = option.PrintColumns;
		Table table = new Table();
		TableRowGroup tableRowGroup = new TableRowGroup();
		table.RowGroups.Add(tableRowGroup);
		table.Margin = new Thickness(TableMargin, 0.0, TableMargin, 0.0);
		TableRow tableRow = new TableRow();
		int num2 = 0;
		for (int i = 0; i < printColumns; i++)
		{
			table.Columns.Add(new TableColumn());
		}
		foreach (DisposableRenderTargetBitmap item3 in enumerable2)
		{
			Image uiElement = new Image
			{
				Source = (BitmapSource)item3
			};
			if (num2 % printColumns == 0)
			{
				tableRow = new TableRow();
				tableRowGroup.Rows.Add(tableRow);
			}
			tableRow.Cells.Add(new TableCell(new BlockUIContainer(uiElement)));
			num2++;
		}
		printDoc.Blocks.Add(table);
	}

	public void OnThumbnailRenderCompleted(IEnumerable<DisposableRenderTargetBitmap> bitmaps, IDocumentCue documentCue, Action<FlowDocument> managerAction)
	{
		if (_renderedPlaylistItemThumbnails.TryGetValue(documentCue, out IEnumerable<DisposableRenderTargetBitmap> value))
		{
			value?.ForEach(delegate(DisposableRenderTargetBitmap bitmap)
			{
				bitmap.Dispose();
			});
		}
		_renderedPlaylistItemThumbnails[documentCue] = bitmaps;
		if (_targetDocumentCues.Count() == _renderedPlaylistItemThumbnails.Count)
		{
			managerAction(CreatePrintDocument(_targetDocumentCues, _printOptions));
			_renderedPlaylistItemThumbnails.SelectMany<KeyValuePair<IDocumentCue, IEnumerable<DisposableRenderTargetBitmap>>, DisposableRenderTargetBitmap>((KeyValuePair<IDocumentCue, IEnumerable<DisposableRenderTargetBitmap>> b) => b.Value).ForEach(delegate(DisposableRenderTargetBitmap bitmap)
			{
				bitmap.Dispose();
			});
			_renderedPlaylistItemThumbnails.Clear();
		}
	}

	public bool? ShowPrintSettings()
	{
		return _printDialog.Value.ShowDialog();
	}

	public Size GetPrintArea()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		Size result = default(Size);
		PrintTicket printTicket = _printDialog.Value.PrintTicket;
		double num;
		double num2;
		if (printTicket.PageMediaSize != null)
		{
			if (printTicket.PageMediaSize.Width.HasValue)
			{
				num = printTicket.PageMediaSize.Width.Value;
				num2 = (printTicket.PageMediaSize.Height.HasValue ? printTicket.PageMediaSize.Height.Value : 0.0);
			}
			else
			{
				PageImageableArea pageImageableArea = _printDialog.Value.PrintQueue.GetPrintCapabilities(printTicket).PageImageableArea;
				num = pageImageableArea.ExtentWidth;
				num2 = pageImageableArea.ExtentHeight;
			}
		}
		else
		{
			try
			{
				num = _printDialog.Value.PrintableAreaWidth;
				num2 = _printDialog.Value.PrintableAreaHeight;
			}
			catch (Exception ex)
			{
				Log.Warning("[{0}]Failed to get print area. Using default values: {1}", "PrintManager", ex);
				num = 0.0;
				num2 = 0.0;
			}
		}
		num -= 2.0 * PageMargin;
		num2 -= 2.0 * PageMargin;
		if (printTicket.PageOrientation == PageOrientation.Landscape)
		{
			((Size)(ref result)).Width = Math.Max(0.0, num2);
			((Size)(ref result)).Height = Math.Max(0.0, num);
		}
		else
		{
			((Size)(ref result)).Width = Math.Max(0.0, num);
			((Size)(ref result)).Height = Math.Max(0.0, num2);
		}
		return result;
	}

	public IDocumentPaginatorSource? GetPreviewSource(FlowDocument printingDocument)
	{
		PrintQueue printQueue = _printDialog.Value.PrintQueue;
		if (printQueue == null)
		{
			return null;
		}
		using XpsDocument xpsDocument = new XpsDocument(Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()), FileAccess.ReadWrite);
		XpsDocumentWriter xpsDocumentWriter = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
		PrintTicket printTicket = _printDialog.Value.PrintTicket;
		PageImageableArea pageImageableArea = printQueue.GetPrintCapabilities(printTicket).PageImageableArea;
		PrintDocumentPaginator documentPaginator = CreatePaginator(printingDocument, pageImageableArea, printTicket);
		if (xpsDocumentWriter != null && pageImageableArea != null)
		{
			xpsDocumentWriter.Write(documentPaginator);
			return xpsDocument.GetFixedDocumentSequence();
		}
		return null;
	}

	public (bool DidPrint, string PrinterDeviceName) Print(FlowDocument printingDocument)
	{
		try
		{
			PrintQueue printQueue = _printDialog.Value.PrintQueue;
			if (printQueue != null)
			{
				XpsDocumentWriter xpsDocumentWriter = PrintQueue.CreateXpsDocumentWriter(printQueue);
				PrintTicket printTicket = _printDialog.Value.PrintTicket;
				PageImageableArea pageImageableArea = printQueue.GetPrintCapabilities(printTicket).PageImageableArea;
				if (xpsDocumentWriter != null)
				{
					PrintDocumentPaginator documentPaginator = CreatePaginator(printingDocument, pageImageableArea, printTicket);
					_printDialog.Value.PrintDocument(documentPaginator, LocalizedStrings.Get("PRINT_OPTIONS_PRINTING_MESSAGE_label"));
					return (DidPrint: true, PrinterDeviceName: _printDialog.Value.PrintQueue.FullName);
				}
				return (DidPrint: false, PrinterDeviceName: _printDialog.Value.PrintQueue.FullName);
			}
			MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("PRINT_OPTIONS_NO_PRINTER_WARNING_label"), DefaultButtons.OK, DefaultButtons.OK);
			return (DidPrint: false, PrinterDeviceName: string.Empty);
		}
		catch (Exception exception)
		{
			Log.Error(exception);
			MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("PRINT_PROCESS_UNKNOWN_ERROR_label"), DefaultButtons.OK, DefaultButtons.OK);
			return (DidPrint: false, PrinterDeviceName: _printDialog.Value.PrintQueue?.FullName ?? string.Empty);
		}
	}

	private static PrintDocumentPaginator CreatePaginator(FlowDocument printingDocument, PageImageableArea imageArea, PrintTicket ticket)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		DocumentPaginator documentPaginator = GetDocumentPaginator(printingDocument);
		PrintDocumentPaginator result = new PrintDocumentPaginator(documentPaginator, documentPaginator.PageSize, new Size(PageMargin, PageMargin));
		printingDocument.PagePadding = new Thickness(right: Math.Max(0.0, (!(ticket.PageMediaSize?.Width).HasValue) ? 0.0 : (ticket.PageMediaSize.Width.Value - (imageArea.OriginWidth + imageArea.ExtentWidth))), bottom: Math.Max(0.0, (!(ticket.PageMediaSize?.Height).HasValue) ? 0.0 : (ticket.PageMediaSize.Height.Value - (imageArea.OriginHeight + imageArea.ExtentHeight))), left: imageArea.OriginWidth, top: imageArea.OriginHeight);
		printingDocument.ColumnWidth = double.PositiveInfinity;
		return result;
	}

	private static DocumentPaginator GetDocumentPaginator(IDocumentPaginatorSource source)
	{
		return source.DocumentPaginator;
	}
}
