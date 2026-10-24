using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace ProPresenter.DO.Organization.Avatar.Model;

public interface IAvatarResult
{
	bool AvatarExists { get; }

	bool TryGetAvatarData([NotNullWhen(true)] out Stream? imageData, out DateTimeOffset avatarTimestamp);
}
