using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenterCore.ProCore.Interop;

public delegate void ResourceStateChangedDelegate(ResourceAddress address, ProResourceState resourceState, ResourceUpdateInfo? updateInfo);
