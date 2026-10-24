using System.Collections.Generic;
using ProPresenter.DO.Arrangements;

namespace ProPresenter.UI.ArrangementView;

public class ArrangementDragCommandParameters
{
	public Arrangement? Arrangement { get; }

	public IEnumerable<CueGroup>? Groups { get; }

	public int DropIndex { get; }

	public bool IsMove { get; }

	public ArrangementDragCommandParameters(Arrangement? arrangement, IEnumerable<CueGroup> groups, int dropIndex, bool isMove)
	{
		Arrangement = arrangement;
		Groups = groups;
		DropIndex = dropIndex;
		IsMove = isMove;
	}
}
