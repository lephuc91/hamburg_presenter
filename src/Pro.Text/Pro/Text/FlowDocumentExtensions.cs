using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using Pro.Common.Mathematics;
using Pro.Common.Strings;

namespace Pro.Text;

public static class FlowDocumentExtensions
{
	public static IEnumerable<TextRange> FindTextRanges(this FlowDocument document, IEnumerable<Range> ranges, string text)
	{
		return document.FindTextRanges(ranges, 0, text, text);
	}

	public static IEnumerable<TextRange> FindTextRanges(this FlowDocument document, IEnumerable<Range> ranges, int offset, string completeText, string subText)
	{
		List<TextRange> list = new List<TextRange>();
		int[] utf32Indices = completeText.GetUTF32Indices().ToArray();
		Func<int, int> func = (int i) => utf32Indices.Count((int u) => u < i);
		if (ranges != null)
		{
			foreach (Range range in ranges)
			{
				int num = offset + subText.Length - 1;
				int num2 = func(range.Start);
				int num3 = func(range.End);
				int num4 = range.Start - offset + num2;
				int num5 = range.End - offset + num3;
				int num6 = num4.Clamp(0, num);
				int num7 = num5.Clamp(0, num);
				if (num4 > num || num5 < 0)
				{
					continue;
				}
				int num8 = 0;
				for (TextPointer textPointer = document.ContentStart; textPointer != null; textPointer = textPointer.GetNextContextPosition(LogicalDirection.Forward))
				{
					if (textPointer.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
					{
						string textInRun = textPointer.GetTextInRun(LogicalDirection.Forward);
						int num9 = completeText.Substring(offset + num8).IndexOf(textInRun);
						if (num9 >= 0)
						{
							num9 += offset + num8;
							num4 = range.Start - num9 + num2;
							num5 = range.End - num9 + num3;
							int num10 = textInRun.Length - 1;
							if (num4 <= num10 && num5 >= 0)
							{
								num6 = num4.Clamp(0, num10);
								num7 = num5.Clamp(0, num10);
								TextPointer positionAtOffset = textPointer.GetPositionAtOffset(num6);
								TextPointer positionAtOffset2 = positionAtOffset.GetPositionAtOffset(num7 - num6 + 1);
								list.Add(new TextRange(positionAtOffset, positionAtOffset2));
							}
							num8 += textInRun.Length;
						}
					}
				}
			}
		}
		return list;
	}
}
