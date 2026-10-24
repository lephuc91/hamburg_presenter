using System;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Print;

public static class ParagraphHelper
{
	private const string DefaultFont = "Arial";

	private const double HeadingFontSize = 22.0;

	private const double LabelFontSize = 17.0;

	private const double SlideTextFontSize = 17.0;

	private const double DateFontSize = 14.0;

	private const double NotesFontSize = 14.0;

	private const double MetaDataFontSize = 11.0;

	private static Thickness HeadingMargin = new Thickness(0.0, 0.0, 0.0, 4.0);

	private static Thickness MetaDataMargin = new Thickness(0.0, 0.0, 0.0, 10.0);

	private static Thickness PresentationNoteMargin = new Thickness(0.0, 10.0, 0.0, 10.0);

	public static Paragraph GenerateMetaDataParagraph(CCLIData? ccliInfo)
	{
		if (ccliInfo == null)
		{
			return GenerateParagraph(ParagraphType.MetaData, string.Empty);
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append($"Artist: {ccliInfo.Artist}");
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append($"Author: {ccliInfo.Author}");
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append($"Publisher: {ccliInfo.Publisher}");
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append($"Copyright Year: {ccliInfo.Copyright}");
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append($"Song Number: {ccliInfo.SongNumber}");
		return GenerateParagraph(ParagraphType.MetaData, stringBuilder.ToString());
	}

	public static Paragraph GenerateParagraph(ParagraphType type, string text)
	{
		return new Paragraph(new Run
		{
			Text = text,
			FontFamily = new FontFamily("Arial"),
			FontSize = GetFontSize(type),
			FontWeight = GetFontWeight(type),
			FontStyle = GetFontStyle(type)
		})
		{
			Margin = GetMargin(type),
			TextAlignment = GetTextAlignment(type)
		};
	}

	private static TextAlignment GetTextAlignment(ParagraphType type)
	{
		switch (type)
		{
		case ParagraphType.Label:
		case ParagraphType.SlideText:
		case ParagraphType.MetaData:
		case ParagraphType.Notes:
		case ParagraphType.SlideNotes:
		case ParagraphType.Date:
			return TextAlignment.Left;
		case ParagraphType.Heading:
			return TextAlignment.Center;
		default:
			throw new NotSupportedException();
		}
	}

	private static Thickness GetMargin(ParagraphType type)
	{
		switch (type)
		{
		case ParagraphType.Label:
		case ParagraphType.SlideText:
		case ParagraphType.SlideNotes:
		case ParagraphType.Date:
			return default(Thickness);
		case ParagraphType.MetaData:
			return MetaDataMargin;
		case ParagraphType.Notes:
			return PresentationNoteMargin;
		case ParagraphType.Heading:
			return HeadingMargin;
		default:
			throw new NotSupportedException();
		}
	}

	private static FontStyle GetFontStyle(ParagraphType type)
	{
		switch (type)
		{
		case ParagraphType.Heading:
		case ParagraphType.Label:
		case ParagraphType.SlideText:
		case ParagraphType.MetaData:
		case ParagraphType.SlideNotes:
		case ParagraphType.Date:
			return default(FontStyle);
		case ParagraphType.Notes:
			return FontStyles.Italic;
		default:
			throw new NotSupportedException();
		}
	}

	private static FontWeight GetFontWeight(ParagraphType type)
	{
		switch (type)
		{
		case ParagraphType.SlideText:
		case ParagraphType.MetaData:
		case ParagraphType.Notes:
		case ParagraphType.SlideNotes:
		case ParagraphType.Date:
			return default(FontWeight);
		case ParagraphType.Heading:
		case ParagraphType.Label:
			return FontWeights.Bold;
		default:
			throw new NotSupportedException();
		}
	}

	private static double GetFontSize(ParagraphType type)
	{
		switch (type)
		{
		case ParagraphType.Date:
			return 14.0;
		case ParagraphType.Heading:
			return 22.0;
		case ParagraphType.MetaData:
			return 11.0;
		case ParagraphType.Notes:
		case ParagraphType.SlideNotes:
			return 14.0;
		case ParagraphType.SlideText:
			return 17.0;
		case ParagraphType.Label:
			return 17.0;
		default:
			throw new NotSupportedException();
		}
	}
}
