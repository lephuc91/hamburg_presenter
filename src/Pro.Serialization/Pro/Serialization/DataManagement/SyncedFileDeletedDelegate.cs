namespace Pro.Serialization.DataManagement;

public delegate void SyncedFileDeletedDelegate<in S, in T>(S sender, string filename, T model);
public delegate void SyncedFileDeletedDelegate<in T>(string filename, T model);
