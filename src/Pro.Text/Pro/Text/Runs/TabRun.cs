using System.Diagnostics;
using Pro.Common.Utility;

namespace Pro.Text.Runs;

[DebuggerDisplay("Tabs ({TabCount})")]
public class TabRun : RunBase
{
	private const char TabCharacter = '\t';

	private int _tabCount;

	private int? _hashCode;

	public override RunType RunType => RunType.Tab;

	public override int Length => TabCount;

	protected internal override string PlainText
	{
		get
		{
			if (!IsEmpty)
			{
				return new string('\t', TabCount);
			}
			return string.Empty;
		}
	}

	public override bool IsEmpty => _tabCount <= 0;

	public int TabCount
	{
		get
		{
			return _tabCount;
		}
		set
		{
			_tabCount = value;
			OnRunChanged();
		}
	}

	public TabRun(int tabCount, RunSettings settings)
		: base(settings)
	{
		_tabCount = tabCount;
	}

	protected internal override void Clear()
	{
		TabCount = 0;
	}

	protected internal override bool CanMerge(RunBase otherRun)
	{
		return otherRun is TabRun;
	}

	protected internal override void MergeFrom(RunBase otherRun)
	{
		TabCount += ((TabRun)otherRun).TabCount;
	}

	protected internal override bool CanSplit(int characterIndex)
	{
		return characterIndex <= TabCount;
	}

	protected internal override RunBase Split(int characterIndex)
	{
		TabCount -= characterIndex;
		return new TabRun(characterIndex, base.Settings.Clone());
	}

	protected internal override void RemoveCharacter(int characterIndex)
	{
		TabCount--;
	}

	public override int GetHashCode()
	{
		if (!_hashCode.HasValue)
		{
			_hashCode = HashCodeHelper.GenerateHashCode(base.GetHashCode(), _tabCount);
		}
		return _hashCode.Value;
	}

	protected override bool OnEquals(RunBase other)
	{
		return _tabCount == ((TabRun)other)._tabCount;
	}

	public override RunBase Clone()
	{
		return new TabRun(TabCount, base.Settings.Clone());
	}
}
