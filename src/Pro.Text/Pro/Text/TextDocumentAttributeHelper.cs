using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Pro.Text;

public static class TextDocumentAttributeHelper
{
	public record PropertyAttributeMap(PropertyInfo Property, TextDocumentAttribute? Attribute);

	private static IReadOnlyCollection<PropertyAttributeMap>? _paragraphSettingsPropertiesWithAttributes;

	private static IReadOnlyCollection<PropertyAttributeMap>? _runSettingsPropertiesWithAttributes;

	public static IReadOnlyCollection<PropertyAttributeMap> ParagraphSettingsPropertiesWithAttributes => _paragraphSettingsPropertiesWithAttributes ?? (_paragraphSettingsPropertiesWithAttributes = GenerateTextDocumentPropertyMap(typeof(ParagraphSettings)));

	public static IReadOnlyCollection<PropertyAttributeMap> RunSettingsPropertiesWithAttributes => _runSettingsPropertiesWithAttributes ?? (_runSettingsPropertiesWithAttributes = GenerateTextDocumentPropertyMap(typeof(RunSettings)));

	private static IReadOnlyCollection<PropertyAttributeMap> GenerateTextDocumentPropertyMap(Type type)
	{
		return (IReadOnlyCollection<PropertyAttributeMap>)(object)(from x in type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
			where Attribute.IsDefined(x, typeof(TextDocumentAttribute), inherit: false)
			select x into pi
			select new PropertyAttributeMap(pi, pi.GetCustomAttribute(typeof(TextDocumentAttribute)) as TextDocumentAttribute)).ToArray();
	}
}
