using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.Text.Reversibility;

namespace Pro.Text.Runs;

[DebuggerDisplay("{Text}")]
public class TextRun : RunBase
{
	private string _text;

	private int? _hashCode;

	public override RunType RunType => RunType.Text;

	protected internal override string PlainText => Text;

	public override bool IsEmpty => string.IsNullOrEmpty(Text);

	public string Text
	{
		get
		{
			return _text;
		}
		[MemberNotNull("_text")]
		set
		{
			if (_text != value)
			{
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.Text), this, "Text", _text, value);
				_text = value;
				OnRunChanged();
			}
		}
	}

	public TextRun(string text, RunSettings settings)
		: base(settings)
	{
		Text = text;
	}

	protected internal override void Clear()
	{
		Text = string.Empty;
	}

	protected internal override bool CanMerge(RunBase otherRun)
	{
		return otherRun is TextRun;
	}

	protected internal override void MergeFrom(RunBase otherRun)
	{
		Text += ((TextRun)otherRun).Text;
	}

	protected internal override bool CanSplit(int characterIndex)
	{
		return characterIndex.IsInRangeInclusive(0, Text.Length);
	}

	protected internal override RunBase Split(int characterIndex)
	{
		string text = Text;
		Text = text.Substring(0, characterIndex);
		return new TextRun(text.Substring(characterIndex), base.Settings.Clone());
	}

	protected internal override void RemoveCharacter(int characterIndex)
	{
		if (char.IsHighSurrogate(Text[characterIndex]) && char.IsLowSurrogate(Text[characterIndex + 1]))
		{
			Text = Text.Remove(characterIndex, 2);
		}
		else if (char.IsLowSurrogate(Text[characterIndex]) && char.IsHighSurrogate(Text[characterIndex - 1]))
		{
			Text = Text.Remove(characterIndex - 1, 2);
		}
		else
		{
			Text = Text.Remove(characterIndex, 1);
		}
	}

	public override int GetHashCode()
	{
		if (!_hashCode.HasValue)
		{
			_hashCode = HashCodeHelper.GenerateHashCode(base.GetHashCode(), _text);
		}
		return _hashCode.Value;
	}

	protected override bool OnEquals(RunBase other)
	{
		return _text == ((TextRun)other)._text;
	}

	public override RunBase Clone()
	{
		return new TextRun(Text, base.Settings.Clone());
	}
}
