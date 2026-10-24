namespace Pro.Serialization.DataManagement;

public delegate void SyncedFileLoadedDelegate<in S, in T>(S sender, T model);
public delegate void SyncedFileLoadedDelegate<in T>(T model);
