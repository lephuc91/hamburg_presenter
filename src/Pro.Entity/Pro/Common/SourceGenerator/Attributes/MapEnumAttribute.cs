using System;

namespace Pro.Common.SourceGenerator.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
internal class MapEnumAttribute : Attribute
{
	public Type Source { get; }

	public Type Destination { get; }

	public string? SourceToDestinationMethodName { get; init; }

	public string? DestinationToSourceMethodName { get; init; }

	public string? SourceDefaultValue { get; init; }

	public string? DestinationDefaultValue { get; init; }

	public string[] UnmatchedSourceNames { get; init; } = Array.Empty<string>();

	public string[] UnmatchedDestinationNames { get; init; } = Array.Empty<string>();

	public string[] ExcludeSourceNames { get; init; } = Array.Empty<string>();

	public string[] ExcludeDestinationNames { get; init; } = Array.Empty<string>();

	public MapEnumAttribute(Type source, Type destination)
	{
		Source = source;
		Destination = destination;
	}
}
