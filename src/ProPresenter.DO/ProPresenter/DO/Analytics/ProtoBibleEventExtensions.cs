using Pro.SerializationInterop.RVProtoData.Analytics.UI;
using ProPresenter.DO.Bibles;

namespace ProPresenter.DO.Analytics;

public static class ProtoBibleEventExtensions
{
	public static Location ToProtoLocation(this BibleLocation location)
	{
		return location switch
		{
			BibleLocation.Presentation => Location.Presentation, 
			BibleLocation.BibleModule => Location.BibleModule, 
			_ => Location.Unknown, 
		};
	}

	public static BibleGenerateSlides.Types.TextBoxLocation ToProtoTextBoxLocation(this BibleTextBoxLocation location)
	{
		return location switch
		{
			BibleTextBoxLocation.None => BibleGenerateSlides.Types.TextBoxLocation.LocationNone, 
			BibleTextBoxLocation.TextBox => BibleGenerateSlides.Types.TextBoxLocation.LocationTextBox, 
			BibleTextBoxLocation.WithVerse => BibleGenerateSlides.Types.TextBoxLocation.LocationWithVerse, 
			_ => BibleGenerateSlides.Types.TextBoxLocation.Unknown, 
		};
	}

	public static BibleGenerateSlides.Types.ReferenceType ToProtoReferenceType(this ReferenceType referenceType)
	{
		return referenceType switch
		{
			ReferenceType.NoReference => BibleGenerateSlides.Types.ReferenceType.PassageNone, 
			ReferenceType.PassageEach => BibleGenerateSlides.Types.ReferenceType.PassageEach, 
			ReferenceType.PassageLast => BibleGenerateSlides.Types.ReferenceType.PassageLast, 
			ReferenceType.VerseRefs => BibleGenerateSlides.Types.ReferenceType.Verse, 
			_ => BibleGenerateSlides.Types.ReferenceType.Unknown, 
		};
	}

	public static BibleSaveSlides.Types.SlideDestination ToProtoBibleSlideDestination(this BibleSlideDestination destination)
	{
		return destination switch
		{
			BibleSlideDestination.SaveToLibrary => BibleSaveSlides.Types.SlideDestination.SaveToLibrary, 
			BibleSlideDestination.SaveToPlaylist => BibleSaveSlides.Types.SlideDestination.SaveToPlaylist, 
			BibleSlideDestination.CopyToPresentation => BibleSaveSlides.Types.SlideDestination.CopyToPresentation, 
			_ => BibleSaveSlides.Types.SlideDestination.Unknown, 
		};
	}

	public static BibleLookup.Types.Location ToProtoBibleLookupLocation(this BibleLookupLocation location)
	{
		return location switch
		{
			BibleLookupLocation.TextReference => BibleLookup.Types.Location.TextReference, 
			BibleLookupLocation.MenuBook => BibleLookup.Types.Location.MenuBook, 
			BibleLookupLocation.MenuChapter => BibleLookup.Types.Location.MenuChapter, 
			BibleLookupLocation.MenuVerse => BibleLookup.Types.Location.MenuVerse, 
			BibleLookupLocation.TextSearchChapter => BibleLookup.Types.Location.TextSearchChapter, 
			BibleLookupLocation.TextSearchVerse => BibleLookup.Types.Location.TextSearchVerse, 
			_ => BibleLookup.Types.Location.Unknown, 
		};
	}
}
