namespace Pro.Entity;

public interface ICanExportSnapshot
{
	byte[] ExportFullSnapshot();

	byte[] ExportUpdateFromVersionVector(byte[] versionVector);
}
