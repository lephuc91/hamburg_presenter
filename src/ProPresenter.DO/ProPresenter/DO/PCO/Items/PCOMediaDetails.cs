using System;
using System.IO;
using Pro.Common.FileSystem;
using Pro.DO.Storage;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Media;

namespace ProPresenter.DO.PCO.Items;

public class PCOMediaDetails : PCOAttachableDetailsBase, IPCOContent
{
	public string CreatorName { get; }

	public string ImageUrl { get; }

	public long Length { get; }

	public string MediaType { get; }

	public string MediaTypeName { get; }

	public string PreviewContentType { get; }

	public string PreviewFileName { get; }

	public long PreviewFileSize { get; }

	public DateTime? PreviewUpdatedAt { get; }

	public string PreviewUrl { get; }

	public string Themes { get; }

	public string ThumbnailContentType { get; }

	public string ThumbnailFileName { get; }

	public long ThumbnailFileSize { get; }

	public DateTime? ThumbnailUpdatedAt { get; }

	public string ThumbnailUrl { get; }

	public string Title { get; }

	public RelativePath? LocalDownloadPath { get; set; }

	public RelativePath? LocalWorkingPath { get; set; }

	public string Filename { get; }

	public string RemoteDownloadURL => PreviewUrl;

	public PCOMediaDetails(MediaData mediaDetails, string pcoItemID)
		: base(mediaDetails.Id ?? string.Empty, mediaDetails.Attributes?.UpdatedAt, mediaDetails.Attributes?.CreatedAt, mediaDetails.GetLinkToSelf(), pcoItemID)
	{
		CreatorName = mediaDetails.Attributes?.CreatorName ?? string.Empty;
		ImageUrl = mediaDetails.Attributes?.ImageUrl ?? string.Empty;
		Length = mediaDetails.Attributes?.Length ?? 0;
		MediaType = mediaDetails.Attributes?.MediaType.ToString() ?? string.Empty;
		MediaTypeName = mediaDetails.Attributes?.MediaTypeName ?? string.Empty;
		PreviewContentType = mediaDetails.Attributes?.PreviewContentType ?? string.Empty;
		PreviewFileName = mediaDetails.Attributes?.PreviewFileName ?? string.Empty;
		PreviewFileSize = mediaDetails.Attributes?.PreviewFileSize ?? 0;
		PreviewUpdatedAt = mediaDetails.Attributes?.PreviewUpdatedAt;
		PreviewUrl = mediaDetails.Attributes?.PreviewUrl ?? string.Empty;
		Filename = Path.GetFileName(PreviewUrl)?.SanitizeFilename() ?? string.Empty;
		Themes = mediaDetails.Attributes?.Themes ?? string.Empty;
		ThumbnailContentType = mediaDetails.Attributes?.ThumbnailContentType ?? string.Empty;
		ThumbnailFileName = mediaDetails.Attributes?.ThumbnailFileName ?? string.Empty;
		ThumbnailFileSize = mediaDetails.Attributes?.ThumbnailFileSize ?? 0;
		ThumbnailUpdatedAt = mediaDetails.Attributes?.ThumbnailUpdatedAt;
		ThumbnailUrl = mediaDetails.Attributes?.ThumbnailUrl ?? string.Empty;
		Title = mediaDetails.Attributes?.Title ?? string.Empty;
	}
}
