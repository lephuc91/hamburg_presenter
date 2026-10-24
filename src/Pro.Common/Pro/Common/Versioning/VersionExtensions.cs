using System;

namespace Pro.Common.Versioning;

public static class VersionExtensions
{
	public static string ToShortDisplayAppString(this Version version)
	{
		return $"{version.Major}.{version.Minor}{((version.Revision <= 0) ? "" : $".{version.Revision}")}";
	}
}
