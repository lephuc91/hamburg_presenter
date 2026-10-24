using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Pro.Reporting.UserFeedback.AttachmentUpload.Model;

public record AttachmentSettings([property: JsonPropertyName("maxAttachments")] int MaxAttachments, [property: JsonPropertyName("maxAttachmentSize")] int MaxAttachmentSize, [property: JsonPropertyName("attachmentLimits")] List<AttachmentLimit> AttachmentLimits)
{
	public static AttachmentSettings RestrictiveDefault { get; } = new AttachmentSettings(14, 8388608, new List<AttachmentLimit>
	{
		new AttachmentLimit("txt", 8388608, 6),
		new AttachmentLimit("mdmp", 1073741824, 1),
		new AttachmentLimit("crash", 8388608, 1),
		new AttachmentLimit("json", 8388608, 1),
		new AttachmentLimit("systeminfo", 8388608, 1),
		new AttachmentLimit("log", 8388608, 6)
	});

	private const int CONSERVATIVE_DEFAULT_MAX_FILE_SIZE = 8388608;

	private const int CONSERVATIVE_DEFAULT_MAX_MDMP_SIZE = 1073741824;

	[CompilerGenerated]
	protected AttachmentSettings(AttachmentSettings original)
	{
		MaxAttachments = original.MaxAttachments;
		MaxAttachmentSize = original.MaxAttachmentSize;
		AttachmentLimits = original.AttachmentLimits;
	}
}
