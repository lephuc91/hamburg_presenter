using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.DataStore;
using Pro.Common.Reflection;
using Pro.Serialization.Utility;

namespace Pro.Serialization.XSerialization;

public static class Serializer
{
	public static XElement? SerializeNode<T>(T instance, string alias = "", bool isEscaped = false, bool displayName = false, string name = "", IEnumerable<KeyValuePair<string, string>>? staticHeaders = null)
	{
		return SerializeNode(instance, typeof(T), alias, isEscaped, displayName, name, staticHeaders);
	}

	public static XElement? SerializeNode(object? instance, Type type, string nameAlias = "", bool isEscaped = false, bool displayName = false, string name = "", IEnumerable<KeyValuePair<string, string>>? staticHeaders = null)
	{
		XElement node = null;
		if (!type.HasEncoder())
		{
			node = new XElement(string.IsNullOrWhiteSpace(nameAlias) ? type.Name : nameAlias);
			ComplexType complexType = type.GetComplexType();
			PropertyMetadata[] traits = complexType.Traits;
			foreach (PropertyMetadata propertyMetadata in traits)
			{
				PropertyGetter getter = propertyMetadata.Getter;
				if (instance == null)
				{
					continue;
				}
				object obj = getter?.Invoke(instance);
				if (obj != null && getter?.TargetType != null)
				{
					string value = EncodeValue(getter.TargetType, obj);
					if (!propertyMetadata.IsOptional || !string.IsNullOrEmpty(value))
					{
						node.Add(new XAttribute(getter.Name, value));
					}
				}
			}
			ChildPropertyMetadata[] children = complexType.Children;
			foreach (ChildPropertyMetadata childPropertyMetadata in children)
			{
				PropertyGetter getter2 = childPropertyMetadata.Getter;
				if (instance != null)
				{
					object obj2 = getter2?.Invoke(instance);
					if (obj2 != null)
					{
						string nameAlias2 = childPropertyMetadata.NameAlias ?? string.Empty;
						string name2 = getter2?.Name ?? string.Empty;
						node.Add(SerializeNode(obj2, obj2.GetType(), nameAlias2, childPropertyMetadata.IsEscaped, childPropertyMetadata.IsNameDisplayed, name2, childPropertyMetadata.StaticHeaders));
					}
					else if (!childPropertyMetadata.IsOptional)
					{
						throw new Exception("Non optional child was not set");
					}
				}
			}
			CollectionPropertyMetadata[] collections = complexType.Collections;
			foreach (CollectionPropertyMetadata collectionPropertyMetadata in collections)
			{
				PropertyGetter getter3 = collectionPropertyMetadata.Getter;
				if (instance != null)
				{
					if (getter3?.Invoke(instance) is IList collection)
					{
						string nameAlias3 = collectionPropertyMetadata.NameAlias ?? string.Empty;
						string name3 = getter3?.Name ?? string.Empty;
						node.Add(SerializeArrayNode(collection, nameAlias3, collectionPropertyMetadata.IsEscaped, collectionPropertyMetadata.IsNameDisplayed, name3, collectionPropertyMetadata.StaticHeaders));
					}
					else if (!collectionPropertyMetadata.IsOptional)
					{
						throw new Exception("Non optional collection was not set");
					}
				}
			}
			PropertyGetter propertyGetter = complexType.Text?.Getter;
			if (propertyGetter?.TargetType != null && instance != null)
			{
				object obj3 = propertyGetter.Invoke(instance);
				if (obj3 != null)
				{
					node.Value = EncodeValue(propertyGetter.TargetType, obj3);
				}
			}
			if (instance != null && string.IsNullOrWhiteSpace(node.Value) && instance.GetType().IsEnum)
			{
				node.Value = EncodeValue(instance.GetType(), instance);
			}
		}
		else if (instance != null)
		{
			string text = EncodeValue(type, instance);
			node = new XElement((!string.IsNullOrWhiteSpace(nameAlias)) ? nameAlias : "NSString", (!isEscaped) ? ((object)text) : ((object)new XCData(text)));
		}
		if (node != null && !string.IsNullOrWhiteSpace(name) && (string.IsNullOrWhiteSpace(nameAlias) || displayName))
		{
			node.Add(new XAttribute("rvXMLIvarName", name));
		}
		if (node != null)
		{
			staticHeaders?.ForEach<KeyValuePair<string, string>>(delegate(KeyValuePair<string, string> h)
			{
				node.Add(new XAttribute(h.Key, h.Value));
			});
		}
		return node;
	}

	private static string EncodeValue(Type targetType, object value)
	{
		if (targetType.IsEnum)
		{
			return Convert.ToUInt64(value).ToString();
		}
		if (targetType.IsProtoMessage())
		{
			return ((IMessage)value).EncodeBase64();
		}
		return targetType.GetEncoder()(value) ?? string.Empty;
	}

	public static XElement SerializeArrayNode(IList collection, string nameAlias = "", bool isEscaped = false, bool displayName = false, string name = "", IEnumerable<KeyValuePair<string, string>>? staticHeaders = null)
	{
		XElement node = new XElement((!string.IsNullOrWhiteSpace(nameAlias)) ? nameAlias : "array");
		if (!string.IsNullOrWhiteSpace(name) && (string.IsNullOrWhiteSpace(nameAlias) || displayName))
		{
			node.Add(new XAttribute("rvXMLIvarName", name));
		}
		staticHeaders?.ForEach<KeyValuePair<string, string>>(delegate(KeyValuePair<string, string> h)
		{
			node.Add(new XAttribute(h.Key, h.Value));
		});
		foreach (object item in collection)
		{
			node.Add(SerializeNode(item, item.GetType(), "", isEscaped));
		}
		return node;
	}
}
