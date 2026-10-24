using Pro.Common.Mathematics;

namespace ProPresenter.UI.ProContent;

public class ProContentAssetViewData
{
	public int ColumnCount { get; }

	public Vector2<double> PreviewSize { get; }

	public ProContentAssetViewData(int columnCount, Vector2<double> previewSize)
	{
		ColumnCount = columnCount;
		PreviewSize = previewSize;
	}
}
