using System;

namespace Pro.CoreApplication.Media.V2;

public sealed record ImportSuccessData(string ContainerId, Guid MediaReferenceId, string FinalUrl);
