using System;

namespace Pro.Data.SQLite.Migration;

[Flags]
public enum MigrationTypes
{
	All = 0,
	Cookies = 1
}
