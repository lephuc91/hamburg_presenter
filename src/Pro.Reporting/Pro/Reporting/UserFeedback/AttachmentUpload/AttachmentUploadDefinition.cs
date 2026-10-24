using System;
using System.Collections.Generic;

namespace Pro.Reporting.UserFeedback.AttachmentUpload;

public record AttachmentUploadDefinition(string FilePath, Uri UploadUrl, long FileSize, Dictionary<string, string> UploadHeaders);
