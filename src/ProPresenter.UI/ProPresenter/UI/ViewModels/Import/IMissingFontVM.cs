using System.Collections.Generic;
using CommunityToolkit.Mvvm.Input;
using Pro.Text;
using ProPresenter.DO.Import;

namespace ProPresenter.UI.ViewModels.Import;

public interface IMissingFontVM
{
	IMissingFontItemCollection MissingFontItems { get; }

	IFontReplacementOptionCollection AvailableFontOptions { get; }

	string DisplayMessage { get; }

	bool CanCancel { get; }

	IRelayCommand ContinueCommand { get; }

	void Initialize(IEnumerable<MissingFontInfo> missingFonts, MissingFontContext context);

	Dictionary<FontInfo, FontInfo> GetFontReplacements();
}
