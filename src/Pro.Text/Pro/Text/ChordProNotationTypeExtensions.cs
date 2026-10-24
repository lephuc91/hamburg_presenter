using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;

namespace Pro.Text;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ChordProNotationType), typeof(IGraphics.Types.IText.Types.IChordPro.Types.Notation), SourceToDestinationMethodName = "ToEntityChordProNotationType", DestinationToSourceMethodName = "ToChordProNotationType")]
public static class ChordProNotationTypeExtensions
{
	public static IGraphics.Types.IText.Types.IChordPro.Types.Notation ToEntityChordProNotationType(this ChordProNotationType source)
	{
		return source switch
		{
			ChordProNotationType.Chords => IGraphics.Types.IText.Types.IChordPro.Types.Notation.Chords, 
			ChordProNotationType.Numbers => IGraphics.Types.IText.Types.IChordPro.Types.Notation.Numbers, 
			ChordProNotationType.Numerals => IGraphics.Types.IText.Types.IChordPro.Types.Notation.Numerals, 
			ChordProNotationType.DoReMi => IGraphics.Types.IText.Types.IChordPro.Types.Notation.DoReMi, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static ChordProNotationType ToChordProNotationType(this IGraphics.Types.IText.Types.IChordPro.Types.Notation source)
	{
		return source switch
		{
			IGraphics.Types.IText.Types.IChordPro.Types.Notation.Chords => ChordProNotationType.Chords, 
			IGraphics.Types.IText.Types.IChordPro.Types.Notation.Numbers => ChordProNotationType.Numbers, 
			IGraphics.Types.IText.Types.IChordPro.Types.Notation.Numerals => ChordProNotationType.Numerals, 
			IGraphics.Types.IText.Types.IChordPro.Types.Notation.DoReMi => ChordProNotationType.DoReMi, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
