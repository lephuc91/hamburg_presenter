namespace ProPresenter.DO.OutputConfiguration;

public record WorkspaceChangedArgs(bool Immediate, bool LiveLookChanged = false);
