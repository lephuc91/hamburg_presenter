using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Pro.Common.DataStore;
using Pro.Common.Nullability;
using Pro.Common.Reflection;
using Pro.Serialization.Utility;

namespace Pro.Serialization.XSerialization;

public static class Deserializer
{
	public static T? DeserializeNode<T>(XElement node, string rootNamespace)
	{
		return (T)DeserializeNode(node, typeof(T), rootNamespace);
	}

	public static object? DeserializeNode(XElement node, Type type, string rootNamespace)
	{
		if (!type.HasEncoder())
		{
			object obj = type.Construct();
			ComplexType complexType = type.GetComplexType();
			PropertyMetadata[] traits = complexType.Traits;
			foreach (PropertyMetadata propertyMetadata in traits)
			{
				PropertySetter setter = propertyMetadata.Setter;
				XAttribute xAttribute = null;
				if (setter != null)
				{
					xAttribute = node.Attribute(setter.Name);
				}
				if (xAttribute != null)
				{
					setter?.Invoke(obj, DecodeValue(setter.TargetType, xAttribute.Value));
				}
				else if (!propertyMetadata.IsOptional)
				{
					throw new Exception("Trait data is missing");
				}
			}
			ChildPropertyMetadata[] children = complexType.Children;
			foreach (ChildPropertyMetadata childPropertyMetadata in children)
			{
				PropertySetter setter2 = childPropertyMetadata.Setter;
				XElement xElement = null;
				if (setter2 != null)
				{
					xElement = FindElement(node.Elements(), childPropertyMetadata.NameAlias, setter2.Name);
				}
				if (xElement != null)
				{
					Type type2 = null;
					if (setter2 != null)
					{
						type2 = FindItemType(xElement, childPropertyMetadata.TypeAlias, setter2.TargetType, childPropertyMetadata.SubTypes);
					}
					if (!(type2 != null))
					{
						throw new Exception("Child type is unknown");
					}
					setter2?.Invoke(obj, DeserializeNode(xElement, type2, rootNamespace));
				}
				else if (!childPropertyMetadata.IsOptional)
				{
					throw new Exception("Child element is missing");
				}
			}
			CollectionPropertyMetadata[] collections = complexType.Collections;
			foreach (CollectionPropertyMetadata collectionPropertyMetadata in collections)
			{
				PropertySetter setter3 = collectionPropertyMetadata.Setter;
				if (!collectionPropertyMetadata.IsMixed)
				{
					string text = ((!string.IsNullOrWhiteSpace(collectionPropertyMetadata.NameAlias)) ? collectionPropertyMetadata.NameAlias : "array");
					if (!string.IsNullOrEmpty(rootNamespace))
					{
						text = $"{{{rootNamespace}}}{text}";
					}
					XElement xElement2 = null;
					if (setter3 != null)
					{
						xElement2 = FindElement(node.Elements(text), collectionPropertyMetadata.NameAlias, setter3.Name);
					}
					if (xElement2 != null)
					{
						setter3?.Invoke(obj, DeserializeArrayNode(xElement2, setter3.TargetType, collectionPropertyMetadata.ItemType, rootNamespace, collectionPropertyMetadata.SubTypes));
					}
					else if (!collectionPropertyMetadata.IsOptional)
					{
						throw new Exception("Collection is missing");
					}
				}
				else
				{
					setter3?.Invoke(obj, DeserializeArrayNode(node, setter3.TargetType, collectionPropertyMetadata.ItemType, rootNamespace, collectionPropertyMetadata.SubTypes));
				}
			}
			if (complexType.Text != null)
			{
				PropertySetter setter4 = complexType.Text.Setter;
				if (!string.IsNullOrWhiteSpace(node.Value))
				{
					setter4?.Invoke(obj, DecodeValue(setter4.TargetType, node.Value));
				}
				else if (!complexType.Text.IsOptional)
				{
					throw new Exception("Text data is missing");
				}
			}
			return obj;
		}
		return DecodeValue(type, node.Value);
	}

	private static XElement? FindElement(IEnumerable<XElement> elements, string? alias, string name)
	{
		if (string.IsNullOrWhiteSpace(alias))
		{
			return elements.FirstOrDefault((XElement e) => e.Attribute("rvXMLIvarName")?.Value == name);
		}
		return elements.FirstOrDefault((XElement e) => alias == e.Name.LocalName);
	}

	private static object? DecodeValue(Type targetType, string value)
	{
		if (targetType.IsEnum)
		{
			return Enum.Parse(targetType, value);
		}
		if (targetType.IsProtoMessage())
		{
			return targetType.DecodeBase64(value);
		}
		return targetType.GetDecoder()(value);
	}

	public static T DeserializeArrayNode<T, I>(XElement node, string rootNamespace, Type[]? subTypes = null) where T : IList<I>
	{
		return (T)DeserializeArrayNode(node, typeof(T), typeof(I), rootNamespace, subTypes);
	}

	public static IList DeserializeArrayNode(XElement node, Type collectionType, Type itemType, string rootNamespace, Type[]? subTypes = null)
	{
		IList list = (IList)Activator.CreateInstance(collectionType);
		list.ThrowWhenNull("collectionInstance");
		foreach (XElement item in node.Elements())
		{
			if (!itemType.HasEncoder())
			{
				Type type = FindItemType(item, null, itemType, subTypes);
				if (type != null)
				{
					list.Add(DeserializeNode(item, type, rootNamespace));
				}
			}
			else if (item.Name.LocalName == "NSString")
			{
				list.Add(DeserializeNode(item, itemType, rootNamespace));
			}
		}
		return list;
	}

	private static Type? FindItemType(XElement element, Type? typeAlias, Type itemType, Type[]? subTypes)
	{
		if (typeAlias != null)
		{
			return typeAlias;
		}
		string name = element.Name.LocalName;
		if (!itemType.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
		{
			return subTypes?.FirstOrDefault((Type t) => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
		}
		return itemType;
	}
}
