namespace Pro.UI.DragDropHelper;

public struct DragResult
{
	public static readonly DragResult DefaultResult = new DragResult(wasDragCanceled: false, wasDataAccepted: true);

	public bool WasDragCanceled { get; set; }

	public bool WasDataAccepted { get; set; }

	public DragResult(bool wasDragCanceled, bool wasDataAccepted)
	{
		WasDragCanceled = wasDragCanceled;
		WasDataAccepted = wasDataAccepted;
	}

	public static implicit operator bool(DragResult result)
	{
		if (!result.WasDragCanceled)
		{
			return result.WasDataAccepted;
		}
		return false;
	}
}
