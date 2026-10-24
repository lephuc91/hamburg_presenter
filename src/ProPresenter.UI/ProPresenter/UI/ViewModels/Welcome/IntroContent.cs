using System;
using System.IO;
using Pro.Common.FileSystem;

namespace ProPresenter.UI.ViewModels.Welcome;

public class IntroContent : IIntroContent
{
	public ContentType Type { get; }

	public string Source { get; }

	public IntroContent(string source)
	{
		Source = Path.GetFullPath(source);
		Type = GetContentType(Source);
	}

	private static ContentType GetContentType(string source)
	{
		if (source.IsVideoFile())
		{
			return ContentType.Video;
		}
		if (source.IsImageFile())
		{
			return ContentType.Image;
		}
		throw new NotSupportedException();
	}
}
