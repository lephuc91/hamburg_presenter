using ProPresenter.DO;

namespace ProPresenter.Controller.Triggering;

public class BuildPositionCollection : OutputDestinationIndexedCollection<int>
{
	private readonly int[] _buildCounts;

	public BuildPositionCollection()
	{
		_buildCounts = new int[base.Count];
	}

	internal int GetBuildCount(OutputDestination destination)
	{
		return _buildCounts[(int)destination];
	}

	internal void ResetBuildPosition(OutputDestination destination, int buildCount)
	{
		_buildCounts[(int)destination] = buildCount;
		base.Items[(int)destination] = 0;
	}

	internal void SetBuildPosition(OutputDestination destination, int buildIndex)
	{
		base.Items[(int)destination] = buildIndex;
	}
}
