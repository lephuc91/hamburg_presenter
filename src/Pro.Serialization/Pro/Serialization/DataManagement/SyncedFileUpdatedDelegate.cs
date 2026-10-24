namespace Pro.Serialization.DataManagement;

public delegate void SyncedFileUpdatedDelegate<in S, in K, in T>(S sender, string filename, K data, T model);
public delegate void SyncedFileUpdatedDelegate<in K, in T>(string filename, K data, T model);
