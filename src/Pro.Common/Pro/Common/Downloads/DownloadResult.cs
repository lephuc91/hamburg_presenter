namespace Pro.Common.Downloads;

public record DownloadResult(bool IsSuccessful, bool IsDuplicate = false, string? Destination = null);
