namespace Pro.Serialization.DataManagement;

public delegate T SyncedFileDeserializeDelegate<in S, in K, out T>(S sender, string filename, K data);
public delegate T SyncedFileDeserializeDelegate<in K, out T>(string filename, K data);
