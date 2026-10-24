using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Text;
using ProPresenter.DO.Bibles;

namespace ProPresenter.UI.Bibles.Converters;

public class VerseContentToFormattedContentConverter : IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is SearchResult searchResult)
		{
			FlowDocument flowDocument = new FlowDocument();
			flowDocument.ContentStart.InsertTextInRun(searchResult.Verse.Content.Text);
			flowDocument.FindTextRanges(from ar in searchResult.Verse.Content.AttributeRanges
				where ar.Type == AttributeType.WordsOfJesus
				select ar.Range, searchResult.Verse.Content.Text).ForEach(delegate(TextRange r)
			{
				r.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
			});
			flowDocument.FindTextRanges(searchResult.KeywordRanges, searchResult.Verse.Content.Text).ForEach(delegate(TextRange r)
			{
				r.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);
				r.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
			});
			return flowDocument.Blocks.OfType<System.Windows.Documents.Paragraph>().SelectMany((System.Windows.Documents.Paragraph p) => p.Inlines.OfType<Run>()).ToArray();
		}
		return null;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
