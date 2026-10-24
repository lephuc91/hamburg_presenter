using System;
using System.Windows.Media;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public class PDFFill : FillBase
{
	public override FillType Type => FillType.PDF;

	public override string DisplayName => string.Empty;

	public string? Filename { get; }

	public int PageNumber { get; }

	public PDFFill(string? filename, int pageNumber = 1)
	{
		Filename = filename;
		PageNumber = pageNumber;
	}

	public override IFill Clone()
	{
		throw new NotSupportedException();
	}

	public override Color Sample()
	{
		throw new NotSupportedException();
	}
}
