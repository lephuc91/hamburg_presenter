using ProPresenter.DO.Bibles;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Presentation;

public interface IPresentationFactory
{
	IPresentation Create(PresentationType type, TemplateSlide? templateSlide = null);

	CustomPresentation CreateCustom(TemplateSlide? templateSlide = null);

	BiblePresentation CreateBible(TemplateSlide? templateSlide = null, BibleTranslationCollection? translations = null);

	MultiTracksPresentation CreateMultiTracks(TemplateSlide? templateSlide = null, MultiTracksLicenseData? licenseData = null);
}
