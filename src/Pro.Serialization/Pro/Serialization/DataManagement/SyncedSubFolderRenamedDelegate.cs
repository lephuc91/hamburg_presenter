namespace Pro.Serialization.DataManagement;

public delegate void SyncedSubFolderRenamedDelegate<TSender>(TSender sender, string oldFolderPath, string newFolderPath);
