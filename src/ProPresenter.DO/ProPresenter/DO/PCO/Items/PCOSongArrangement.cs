using System;
using System.Collections.Generic;
using System.Linq;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Arrangement;

namespace ProPresenter.DO.PCO.Items;

public class PCOSongArrangement
{
	public string? ID { get; }

	public string? Name { get; }

	public string[]? Sequence { get; }

	public bool IsCustom { get; }

	public PCOSongArrangement(ArrangementData arrangement)
	{
		ID = arrangement.Id;
		Name = arrangement.Attributes?.Name;
		Sequence = arrangement.Attributes?.Sequence ?? Array.Empty<string>();
	}

	public PCOSongArrangement(string? id, string name, IEnumerable<string> sequence, bool isCustom = false)
	{
		ID = id;
		Name = name;
		Sequence = sequence?.ToArray();
		IsCustom = isCustom;
	}
}
