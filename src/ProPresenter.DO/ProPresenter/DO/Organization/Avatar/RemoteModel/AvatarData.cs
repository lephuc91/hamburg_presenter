using System;
using System.IO;

namespace ProPresenter.DO.Organization.Avatar.RemoteModel;

public sealed record AvatarData(Stream ImageData, DateTimeOffset AvatarTimestamp);
