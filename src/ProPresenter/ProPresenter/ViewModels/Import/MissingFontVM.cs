using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Localization.Services;
using Pro.Text;
using ProPresenter.DO.Analytics.Events.TrackedEvents.MissingFonts;
using ProPresenter.DO.Import;
using ProPresenter.UI.ViewModels.Import;

namespace ProPresenter.ViewModels.Import;

public class MissingFontVM : ObservableObject, IMissingFontVM
{
	private readonly IMissingFontService _missingFontService;

	private readonly ILocalization _localization;

	private MissingFontContext _context;

	private readonly IFontReplacementEventPublisher _fontReplacementEventPublisher;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? continueCommand;

	public IMissingFontItemCollection MissingFontItems { get; }

	public IFontReplacementOptionCollection AvailableFontOptions { get; }

	public string DisplayMessage => _context switch
	{
		MissingFontContext.Import => _localization.Get("ISSUE_RESOLVER_FONTS_IMPORT_message"), 
		MissingFontContext.Standalone => _localization.Get("ISSUE_RESOLVER_FONTS_STANDALONE_message"), 
		_ => string.Empty, 
	};

	public bool CanCancel { get; init; } = true;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ContinueCommand => continueCommand ?? (continueCommand = new RelayCommand(Continue));

	public MissingFontVM(IMissingFontService missingFontService, ILocalization localization, IFontReplacementEventPublisher fontReplacementEventPublisher)
	{
		_missingFontService = missingFontService;
		_localization = localization;
		_context = MissingFontContext.Import;
		_fontReplacementEventPublisher = fontReplacementEventPublisher;
		MissingFontItems = new MissingFontItemCollection();
		AvailableFontOptions = new FontReplacementOptionCollection();
		LoadAvailableFonts();
	}

	[RelayCommand]
	private void Continue()
	{
		PublishFontReplacementAnalytics();
	}

	private void PublishFontReplacementAnalytics()
	{
		ReplacementFontSource source = _context.MissingFontDestinationToReplacementFontSource();
		foreach (IMissingFontItemVM missingFontItem in MissingFontItems)
		{
			string fontName = missingFontItem.FontName;
			string replacementFont = missingFontItem.SelectedReplacement?.FontInfo?.SystemFamilyName ?? string.Empty;
			_fontReplacementEventPublisher.Publish(fontName, replacementFont, source);
		}
	}

	public void Initialize(IEnumerable<MissingFontInfo> missingFonts, MissingFontContext context)
	{
		_context = context;
		OnPropertyChanged("DisplayMessage");
		MissingFontItems.Clear();
		IFontReplacementOption selectedReplacement = AvailableFontOptions.FirstOrDefault((IFontReplacementOption r) => r.IsDefault);
		foreach (IGrouping<string, MissingFontInfo> item in missingFonts.ToLookup((MissingFontInfo mf) => mf.OriginalFont.DisplayName ?? mf.OriginalFont.SystemFamilyName))
		{
			IMissingFontItemVM fontItem = new MissingFontItemVM(item.Key, item.ToArray())
			{
				SelectedReplacement = selectedReplacement
			};
			MissingFontItems.Add(fontItem);
		}
	}

	public Dictionary<FontInfo, FontInfo> GetFontReplacements()
	{
		Dictionary<FontInfo, FontInfo> dictionary = new Dictionary<FontInfo, FontInfo>();
		foreach (IMissingFontItemVM missingFontItem in MissingFontItems)
		{
			if (!(missingFontItem.SelectedReplacement?.FontInfo).HasValue)
			{
				continue;
			}
			foreach (MissingFontInfo item in missingFontItem.MissingFontInfo)
			{
				dictionary[item.OriginalFont] = item.OriginalFont with
				{
					SystemFamilyName = missingFontItem.SelectedReplacement.FontInfo.Value.SystemFamilyName,
					DisplayFamilyName = missingFontItem.SelectedReplacement.FontInfo.Value.DisplayFamilyName,
					PSName = missingFontItem.SelectedReplacement.FontInfo.Value.PSName,
					DisplayFaceName = missingFontItem.SelectedReplacement.FontInfo.Value.DisplayFaceName,
					SystemFaceName = missingFontItem.SelectedReplacement.FontInfo.Value.SystemFaceName
				};
			}
		}
		return dictionary;
	}

	private void LoadAvailableFonts()
	{
		AvailableFontOptions.Clear();
		FontReplacementOption fontOption = new FontReplacementOption
		{
			DisplayName = _localization.Get("ISSUE_RESOLVER_FONTS_DONT_REPLACE"),
			FontInfo = null,
			IsDefault = true
		};
		AvailableFontOptions.Add(fontOption);
		foreach (FontReplacementOption item in from f in _missingFontService.GetAvailableSystemFonts()
			group f by f.SystemFamilyName into g
			select g.First() into f
			orderby f.SystemFamilyName
			select new FontReplacementOption
			{
				DisplayName = f.SystemFamilyName,
				FontInfo = f
			})
		{
			AvailableFontOptions.Add(item);
		}
	}
}
