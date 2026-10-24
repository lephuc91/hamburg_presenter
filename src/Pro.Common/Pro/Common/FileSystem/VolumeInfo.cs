using System;

namespace Pro.Common.FileSystem;

public sealed class VolumeInfo : IEquatable<VolumeInfo>
{
	public string Letter { get; }

	public string Path { get; }

	public string Name { get; }

	public string SerialNumber { get; }

	public VolumeInfo(string letter, string name, string serialNumber)
	{
		Letter = letter.ToUpperInvariant();
		Path = Letter + ":\\";
		Name = name;
		SerialNumber = serialNumber;
	}

	public bool Equals(VolumeInfo? other)
	{
		if (other != null)
		{
			return other.Letter == Letter;
		}
		return false;
	}

	public override bool Equals(object? obj)
	{
		if (obj is VolumeInfo other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Letter.GetHashCode();
	}
}
