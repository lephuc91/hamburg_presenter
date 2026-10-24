using System;

namespace ProPresenter.DO.ChangeDirectory;

public record ChangeDirectoryListener(Action Start, Action<bool> Complete);
