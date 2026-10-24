namespace Pro.CoreApplication.Workspace;

public record ActiveSync : ISyncStatus
{
	public bool IsPaused => false;
}
