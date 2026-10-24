using System;

namespace Pro.CoreApplication.Media;

public sealed record MediaManagementStatus(bool Idle, bool Paused, DateTimeOffset? PausedUntil, uint Count, uint Total);
