using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace ProPresenter.DO.Organization.Avatar.Model;

public sealed class UnchangedAvatar : IAvatarResult
{
	public bool AvatarExists => true;

	public bool TryGetAvatarData([NotNullWhen(true)] out Stream? imageData, out DateTimeOffset avatarTimestamp)
	{
		imageData = null;
		avatarTimestamp = default(DateTimeOffset);
		return false;
	}
}
