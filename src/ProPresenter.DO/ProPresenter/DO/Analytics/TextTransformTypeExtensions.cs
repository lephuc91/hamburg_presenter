using Pro.Text;

namespace ProPresenter.DO.Analytics;

public static class TextTransformTypeExtensions
{
	public static TextTransformType ToTextTransformType(this TextTransform textTransform)
	{
		return textTransform switch
		{
			TextTransform.RemoveLineReturns => TextTransformType.RemoveLineReturns, 
			TextTransform.ReplaceLineReturns => TextTransformType.ReplaceLineReturns, 
			TextTransform.SingleWordPerLine => TextTransformType.OneWordPerLine, 
			TextTransform.SingleCharacterPerLine => TextTransformType.OneCharacterPerLine, 
			_ => TextTransformType.None, 
		};
	}
}
