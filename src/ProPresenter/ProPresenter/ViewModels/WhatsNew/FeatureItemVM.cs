using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using System.Windows.Media;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.Localization.Services;
using Pro.UI.SVG;
using ProPresenter.DO.WhatsNew;
using ProPresenter.UI.ViewModels.WhatsNew;

namespace ProPresenter.ViewModels.WhatsNew;

public class FeatureItemVM : IFeatureItemVM
{
	private readonly IHyperlinkService _hyperlinkService;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? gotoLinkCommand;

	public string Title { get; }

	public string Description { get; }

	public Uri? FeatureLinkUri { get; }

	public string FeatureLinkText { get; } = string.Empty;

	public bool FeatureContainsLink { get; }

	public bool ColorizeImage { get; }

	public ImageSource? Icon { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand GotoLinkCommand => gotoLinkCommand ?? (gotoLinkCommand = new RelayCommand(GotoLink));

	public FeatureItemVM(IFeatureItem featureItem, ILocalization localization, IFileSystem fileSystem, IHyperlinkService hyperlinkService)
	{
		_hyperlinkService = hyperlinkService;
		Title = localization.Get(featureItem.Title);
		Description = localization.Get(featureItem.Description);
		string text = fileSystem.Path.Combine("resources\\Whats New", featureItem.ImageName);
		if (fileSystem.File.Exists(text))
		{
			string fileNameWithoutExtension = fileSystem.Path.GetFileNameWithoutExtension(text);
			ColorizeImage = fileNameWithoutExtension.EndsWith("Template", StringComparison.OrdinalIgnoreCase);
			if (!string.IsNullOrEmpty(text) && fileSystem.File.Exists(text))
			{
				if (text.EndsWith(".svg"))
				{
					string svgContent = fileSystem.File.ReadAllText(text);
					Icon = svgContent.ToSvgImageSource();
					if (Icon == null)
					{
						Icon = ImageHelper.LoadImage(text);
					}
				}
				else
				{
					Icon = ImageHelper.LoadImage(text);
					string svgContent2 = fileSystem.File.ReadAllText(text);
					if (Icon == null)
					{
						Icon = svgContent2.ToSvgImageSource();
					}
				}
			}
		}
		if (featureItem.FeatureLink != null)
		{
			if (Uri.TryCreate(featureItem.FeatureLink.Url, UriKind.Absolute, out Uri result))
			{
				FeatureContainsLink = true;
				FeatureLinkUri = result;
				FeatureLinkText = localization.Get(featureItem.FeatureLink.TitleKey);
			}
			else
			{
				Log.Error("Parsing Url failed.");
			}
		}
	}

	[RelayCommand]
	private void GotoLink()
	{
		if (FeatureLinkUri != null)
		{
			_hyperlinkService.Open(FeatureLinkUri);
		}
	}
}
