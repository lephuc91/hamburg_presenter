using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Mathematics;

namespace Pro.Text;

internal class Line
{
	public Character[] Characters { get; }

	public int IndexOffset { get; }

	public double Left { get; set; }

	public double Right { get; set; }

	public double Top { get; private set; }

	public double LineHeight { get; private set; }

	public double Baseline { get; private set; }

	public double AnnotationLineHeight { get; private set; }

	public double AnnotationBaseline { get; private set; }

	public double NonAnnotatedOffset { get; }

	public ParagraphAlignment Alignment { get; }

	public Line(IEnumerable<Character> characters, int indexOffset, double left, double right, double top, double lineHeight, bool offsetNonAnnotated, ParagraphAlignment alignment)
	{
		Characters = characters.ToArray();
		IndexOffset = indexOffset;
		Left = left;
		Right = right;
		Top = top;
		LineHeight = lineHeight;
		AnnotationLineHeight = 0.0;
		Alignment = alignment;
		CalculateLineInfo();
		AlignCharacters();
		if (offsetNonAnnotated)
		{
			NonAnnotatedOffset = Math.Max(LineHeight, AnnotationLineHeight);
			OffsetNonAnnotatedCharacters(NonAnnotatedOffset);
		}
	}

	private void CalculateLineInfo()
	{
		Character[] characters = Characters;
		foreach (Character character in characters)
		{
			if (!character.IsAnnotation)
			{
				LineHeight = Math.Max(LineHeight, character.LineHeight);
				Baseline = Math.Max(Baseline, character.Baseline.GetValueOrDefault());
			}
			else
			{
				AnnotationLineHeight = Math.Max(AnnotationLineHeight, character.LineHeight);
				AnnotationBaseline = Math.Max(AnnotationBaseline, character.Baseline.GetValueOrDefault());
			}
		}
	}

	private void AlignCharacters()
	{
		Character[] characters = Characters;
		foreach (Character character in characters)
		{
			double num = ((!character.IsAnnotation) ? Baseline : AnnotationBaseline);
			character.Position += new Vector2<double>(0.0, num - (character.Baseline ?? num));
		}
	}

	private void OffsetNonAnnotatedCharacters(double offset)
	{
		Characters.Where((Character c) => !c.IsAnnotation).ForEach(delegate(Character c)
		{
			c.Position += new Vector2<double>(0.0, offset);
		});
	}

	public void OffsetLineTop(double offset)
	{
		Top += offset;
		Characters.ForEach(delegate(Character c)
		{
			c.Position += new Vector2<double>(0.0, offset);
		});
	}
}
