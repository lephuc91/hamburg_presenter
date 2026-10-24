namespace Pro.Serialization.DataManagement;

public delegate void SyncedFileRenamedDelegate<in S, in T>(S sender, string oldFilename, string newFilename, T model);
public delegate void SyncedFileRenamedDelegate<in T>(string oldFilename, string newFilename, T model);
