using System.Collections.Generic;
using System.ComponentModel;

namespace ProPresenter.DO.Import;

public interface IMissingFontItemVM : INotifyPropertyChanged
{
	IReadOnlyList<MissingFontInfo> MissingFontInfo { get; }

	string FontName { get; }

	int UsageCount { get; }

	IFontReplacementOption? SelectedReplacement { get; set; }
}
