using System.Globalization;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace ProPresenter.DO.Print;

public class PrintDocumentPaginator : DocumentPaginator
{
	private static Typeface DefaultTextTypeface = new Typeface("Segoe UI");

	private Size _pageSize;

	private Size _margin;

	private DocumentPaginator _paginator;

	public override bool IsPageCountValid => _paginator.IsPageCountValid;

	public override int PageCount => _paginator.PageCount;

	public override Size PageSize
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return _paginator.PageSize;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			_paginator.PageSize = value;
		}
	}

	public override IDocumentPaginatorSource Source => _paginator.Source;

	public PrintDocumentPaginator(DocumentPaginator paginator, Size pageSize, Size margin)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		_pageSize = pageSize;
		_margin = margin;
		_paginator = paginator;
		_paginator.PageSize = new Size(((Size)(ref _pageSize)).Width - ((Size)(ref margin)).Width * 2.0, ((Size)(ref _pageSize)).Height - ((Size)(ref margin)).Height * 2.0);
	}

	public Rect Move(Rect rect)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		if (!((Rect)(ref rect)).IsEmpty)
		{
			return new Rect(((Rect)(ref rect)).Left + ((Size)(ref _margin)).Width, ((Rect)(ref rect)).Top + ((Size)(ref _margin)).Height, ((Rect)(ref rect)).Width, ((Rect)(ref rect)).Height);
		}
		return rect;
	}

	public override DocumentPage GetPage(int pageNumber)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		DocumentPage page = _paginator.GetPage(pageNumber);
		ContainerVisual containerVisual = new ContainerVisual();
		DrawingVisual drawingVisual = new DrawingVisual();
		using (DrawingContext drawingContext = drawingVisual.RenderOpen())
		{
			FormattedText formattedText = new FormattedText("Page " + (pageNumber + 1), CultureInfo.CurrentCulture, FlowDirection.LeftToRight, DefaultTextTypeface, 14.0, Brushes.Black);
			drawingContext.DrawText(formattedText, new Point(0.0, -24.0));
		}
		ContainerVisual containerVisual2 = new ContainerVisual();
		containerVisual2.Children.Add(page.Visual);
		Rect contentBox = page.ContentBox;
		double offsetX = 0.025 * ((Rect)(ref contentBox)).Width;
		contentBox = page.ContentBox;
		containerVisual2.Transform = new MatrixTransform(0.95, 0.0, 0.0, 0.95, offsetX, 0.025 * ((Rect)(ref contentBox)).Height);
		containerVisual.Children.Add(containerVisual2);
		containerVisual.Children.Add(drawingVisual);
		containerVisual.Transform = new TranslateTransform(((Size)(ref _margin)).Width, ((Size)(ref _margin)).Height);
		return new DocumentPage(containerVisual, _pageSize, Move(page.BleedBox), Move(page.ContentBox));
	}
}
