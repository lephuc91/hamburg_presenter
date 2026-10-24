namespace Pro.Reporting;

public static class StargazerValueExtensions
{
	public static string ToStargazerValue(this bool value)
	{
		if (!value)
		{
			return "false";
		}
		return "true";
	}
}
