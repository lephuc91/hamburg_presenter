using System;

namespace Pro.Common.Versioning;

[AttributeUsage(AttributeTargets.Assembly)]
public class GitCommitAttribute : Attribute
{
	public string Hash { get; }

	public GitCommitAttribute(string hash)
	{
		Hash = hash;
	}
}
