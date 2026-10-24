namespace Pro.Serialization.DataManagement;

public delegate void SyncedFolderRenamedDelegate<TSender>(TSender sender, string oldFolderPath, string newFolderPath);
