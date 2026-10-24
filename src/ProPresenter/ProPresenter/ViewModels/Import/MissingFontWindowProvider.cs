using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Pro.Localization.Services;
using Pro.Text;
using ProPresenter.DO;
using ProPresenter.DO.Analytics.Events.TrackedEvents.MissingFonts;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Themes;
using ProPresenter.UI.Import;

namespace ProPresenter.ViewModels.Import;

public class MissingFontWindowProvider : IMissingFontWindowProvider
{
	private readonly IMissingFontService _missingFontService;

	private readonly ILocalization _localization;

	private readonly IFontReplacementEventPublisher _fontReplacementEventPublisher;

	private readonly IProPresenterResourceService _resourceService;

	public MissingFontWindowProvider(IMissingFontService missingFontService, ILocalization localization, IFontReplacementEventPublisher fontReplacementEventPublisher, IProPresenterResourceService resourceService)
	{
		_missingFontService = missingFontService;
		_localization = localization;
		_fontReplacementEventPublisher = fontReplacementEventPublisher;
		_resourceService = resourceService;
	}

	public void HandleImportProcess(ImportProcess importProcess)
	{
		importProcess.MissingFontsDetected += OnMissingFontsDetected;
	}

	private void OnMissingFontsDetected(IImportProcess process, IEnumerable<MissingFontInfo> missingFonts)
	{
		if (process is ImportProcess importProcess)
		{
			importProcess.MissingFontsDetected -= OnMissingFontsDetected;
		}
		if (missingFonts.Any())
		{
			Dictionary<FontInfo, FontInfo> dictionary = ShowMissingFontDialog(missingFonts, MissingFontContext.Import);
			if (dictionary != null)
			{
				ApplyReplacementsToImportedContent(process, dictionary, missingFonts);
			}
		}
	}

	public Dictionary<FontInfo, FontInfo>? ShowMissingFontDialog(IEnumerable<MissingFontInfo> missingFonts, MissingFontContext context)
	{
		MissingFontVM missingFontVM = new MissingFontVM(_missingFontService, _localization, _fontReplacementEventPublisher)
		{
			CanCancel = (context != MissingFontContext.Import)
		};
		missingFontVM.Initialize(missingFonts, context);
		if (new MissingFontWindow
		{
			Owner = Application.Current.MainWindow,
			DataContext = missingFontVM
		}.ShowDialog() != true)
		{
			return null;
		}
		return missingFontVM.GetFontReplacements();
	}

	private void ApplyReplacementsToImportedContent(IImportProcess process, Dictionary<FontInfo, FontInfo> replacements, IEnumerable<MissingFontInfo> missingFonts)
	{
		IEnumerable<MissingFontInfo> presentationMissingFonts = missingFonts.Where((MissingFontInfo mf) => mf.Source == MissingFontSource.Presentation);
		IEnumerable<MissingFontInfo> themeMissingFonts = missingFonts.Where((MissingFontInfo mf) => mf.Source == MissingFontSource.Theme);
		ApplyReplacementsToImportedPresentations(process, replacements, presentationMissingFonts);
		ApplyReplacementsToImportedThemes(replacements, themeMissingFonts);
	}

	private void ApplyReplacementsToImportedPresentations(IImportProcess process, Dictionary<FontInfo, FontInfo> replacements, IEnumerable<MissingFontInfo> presentationMissingFonts)
	{
		ILibrary selectedLibrary = process.SelectedLibrary;
		if (selectedLibrary == null)
		{
			return;
		}
		List<string> list = new List<string>();
		foreach (MissingFontInfo presentationMissingFont in presentationMissingFonts)
		{
			string[] array = presentationMissingFont.PresentationOrThemeName.Split(',', StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				string item = array[i].Trim();
				list.Add(item);
			}
		}
		foreach (string presentationName in list.Distinct<string>(StringComparer.OrdinalIgnoreCase))
		{
			IPresentation presentation = selectedLibrary.FirstOrDefault((DocumentCue cue) => cue.DocumentAction?.Presentation?.Name != null && string.Equals(cue.DocumentAction.Presentation.Name, presentationName, StringComparison.OrdinalIgnoreCase))?.DocumentAction?.Presentation;
			if (presentation != null)
			{
				_missingFontService.ApplyFontReplacements(presentation, replacements);
				presentation.InvalidateMissingFontsCache();
			}
		}
	}

	private void ApplyReplacementsToImportedThemes(Dictionary<FontInfo, FontInfo> replacements, IEnumerable<MissingFontInfo> themeMissingFonts)
	{
		List<string> list = new List<string>();
		foreach (MissingFontInfo themeMissingFont in themeMissingFonts)
		{
			string[] array = themeMissingFont.PresentationOrThemeName.Split(',', StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				string item = array[i].Trim();
				list.Add(item);
			}
		}
		foreach (string item2 in list.Distinct<string>(StringComparer.OrdinalIgnoreCase))
		{
			Theme theme = FindThemeByName(item2);
			if (theme != null)
			{
				_missingFontService.ApplyFontReplacements(theme, replacements);
			}
		}
	}

	private Theme? FindThemeByName(string themeName)
	{
		foreach (Theme theme in _resourceService.Themes)
		{
			if (string.Equals(theme.Name, themeName, StringComparison.OrdinalIgnoreCase))
			{
				return theme;
			}
		}
		return null;
	}
}
