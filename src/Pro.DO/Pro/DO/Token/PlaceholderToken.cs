using System;

namespace Pro.DO.Token;

public class PlaceholderToken : TokenBase
{
	private string _placeholderContent = string.Empty;

	public override string Content => PlaceholderContent;

	public string PlaceholderContent
	{
		get
		{
			return _placeholderContent;
		}
		set
		{
			SetValue("PlaceholderContent", ref _placeholderContent, value, (Action)delegate
			{
				OnPropertyChanged("Content");
			}, (Predicate<string>?)null, referenceComparison: false);
		}
	}

	public override TokenBase Clone()
	{
		return new PlaceholderToken
		{
			_placeholderContent = _placeholderContent
		};
	}
}
