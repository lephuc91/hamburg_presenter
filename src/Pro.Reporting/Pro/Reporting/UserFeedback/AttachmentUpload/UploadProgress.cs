using System.Runtime.CompilerServices;

namespace Pro.Reporting.UserFeedback.AttachmentUpload;

public record UploadProgress(long BytesUploaded, long TotalBytes)
{
	public static UploadProgress Empty { get; } = new UploadProgress(0L, 0L);

	public static UploadProgress operator +(UploadProgress a, UploadProgress b)
	{
		return new UploadProgress(a.BytesUploaded + b.BytesUploaded, a.TotalBytes + b.TotalBytes);
	}

	[CompilerGenerated]
	protected UploadProgress(UploadProgress original)
	{
		BytesUploaded = original.BytesUploaded;
		TotalBytes = original.TotalBytes;
	}
}
