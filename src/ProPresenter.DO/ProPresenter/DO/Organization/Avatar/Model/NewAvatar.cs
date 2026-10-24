using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using ProPresenter.DO.Organization.Avatar.RemoteModel;

namespace ProPresenter.DO.Organization.Avatar.Model;

public sealed class NewAvatar(AvatarData avatarData) : IAvatarResult
{
	public bool AvatarExists => true;

	public bool TryGetAvatarData([NotNullWhen(true)] out Stream? imageData, out DateTimeOffset avatarTimestamp)
	{
		imageData = avatarData.ImageData;
		avatarTimestamp = avatarData.AvatarTimestamp;
		return true;
	}
}
