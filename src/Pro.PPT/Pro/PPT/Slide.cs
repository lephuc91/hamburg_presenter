using System;
using System.IO;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using Pro.Common.Logging;
using Pro.Common.Mathematics;

namespace Pro.PPT;

public class Slide
{
	private const string DefaultImageExtension = "jpg";

	private readonly Microsoft.Office.Interop.PowerPoint.Slide _slide;

	public Notes? Notes { get; }

	internal Slide(Microsoft.Office.Interop.PowerPoint.Slide slide)
	{
		_slide = slide;
		try
		{
			if (_slide.HasNotesPage == MsoTriState.msoTrue)
			{
				Notes = new Notes(_slide.NotesPage);
			}
		}
		catch (Exception exception)
		{
			Log.Error(exception);
		}
	}

	public string Export(string targetDirectory, Vector2<int> scalar, string extension = "jpg")
	{
		string text = Path.Combine(targetDirectory, Guid.NewGuid().ToString() + "." + extension);
		_slide.Export(text, extension, scalar.X, scalar.Y);
		return text;
	}
}
