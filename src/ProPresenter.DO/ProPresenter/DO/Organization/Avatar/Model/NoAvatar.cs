using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace ProPresenter.DO.Organization.Avatar.Model;

public sealed class NoAvatar : IAvatarResult
{
	public bool AvatarExists => false;

	public bool TryGetAvatarData([NotNullWhen(true)] out Stream? imageData, out DateTimeOffset avatarTimestamp)
	{
		imageData = null;
		avatarTimestamp = default(DateTimeOffset);
		return false;
	}
}
