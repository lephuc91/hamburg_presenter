using System.Collections.Generic;

namespace Pro.Text.RTF;

internal class ListData
{
	public int ID { get; }

	public List<LevelData> Levels { get; } = new List<LevelData>();

	public ListData(int listID)
	{
		ID = listID;
	}
}
