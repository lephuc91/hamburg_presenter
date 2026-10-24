namespace Pro.Loro;

public record CommitOptions(string? origin, bool immediateRenew, long? timestamp, string? commitMsg);
