using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using Pro.Common.Collections;

namespace Pro.PPTViewer;

public static class PPUtility
{
	public static int StripPresentation(string presentationPath, bool removeAnimations, bool removeTransitions, bool removeHidden, out double slideAspectRatio)
	{
		slideAspectRatio = 1.0;
		using PresentationDocument presentationDocument = PresentationDocument.Open(presentationPath, isEditable: true, new OpenSettings
		{
			AutoSave = true
		});
		SlideSize slideSize = presentationDocument.PresentationPart.Presentation.Descendants<SlideSize>().First();
		slideAspectRatio = (double)(int)slideSize.Cx / (double)(int)slideSize.Cy;
		SlidePart[] array = GetOrderedSlideParts(presentationDocument, !removeHidden).ToArray();
		if (removeAnimations)
		{
			foreach (SlideMasterPart slideMasterPart in presentationDocument.PresentationPart.SlideMasterParts)
			{
				slideMasterPart.SlideMaster.RemoveAllChildren<AlternateContent>();
				foreach (SlideLayoutPart slideLayoutPart in slideMasterPart.SlideLayoutParts)
				{
					slideLayoutPart.SlideLayout.RemoveAllChildren<AlternateContent>();
				}
			}
			array.ForEach(delegate(SlidePart s)
			{
				s.Slide.RemoveAllChildren<AlternateContent>();
			});
		}
		if (removeTransitions)
		{
			array.ForEach(delegate(SlidePart s)
			{
				s.Slide.RemoveAllChildren<Timing>();
			});
		}
		presentationDocument.Save();
		((OpenXmlPackage)presentationDocument).Close();
		return array.Length;
	}

	private static IEnumerable<SlidePart> GetOrderedSlideParts(PresentationDocument presentationDoc, bool includeHidden)
	{
		PresentationPart presentationPart = presentationDoc.PresentationPart;
		Presentation presentation = presentationPart.Presentation;
		SlideIdList slideIDList = presentation.SlideIdList;
		SlideId[] array = slideIDList.OfType<SlideId>().ToArray();
		foreach (SlideId slideId in array)
		{
			OpenXmlPart openXmlPart = presentationPart?.GetPartById(slideId.RelationshipId);
			if (openXmlPart != null && openXmlPart is SlidePart)
			{
				SlidePart slidePart = (SlidePart)openXmlPart;
				if (includeHidden || IsSlidePartVisible(slidePart))
				{
					yield return slidePart;
					continue;
				}
				slideIDList.RemoveChild(slideId);
				presentationPart.DeletePart(slidePart);
			}
		}
	}

	private static bool IsSlidePartVisible(SlidePart slidePart)
	{
		if (slidePart.Slide != null)
		{
			if ((object)slidePart.Slide.Show != null)
			{
				if (slidePart.Slide.Show.HasValue)
				{
					return slidePart.Slide.Show.Value;
				}
				return false;
			}
			return true;
		}
		return false;
	}
}
