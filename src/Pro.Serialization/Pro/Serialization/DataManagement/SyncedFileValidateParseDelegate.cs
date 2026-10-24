namespace Pro.Serialization.DataManagement;

public delegate bool SyncedFileValidateParseDelegate<in S, in K>(S sender, string filename, K data);
public delegate bool SyncedFileValidateParseDelegate<in K>(string filename, K data);
