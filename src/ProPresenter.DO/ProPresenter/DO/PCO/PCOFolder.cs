namespace ProPresenter.DO.PCO;

public class PCOFolder : PCOObject
{
	public PCOFolder[] Folders { get; }

	public PCOServiceType[] ServiceTypes { get; }

	internal PCOFolder(string? id, string? name, PCOFolder[] subfolders, PCOServiceType[] serviceTypes)
		: base(id, name)
	{
		Folders = subfolders;
		ServiceTypes = serviceTypes;
	}
}
