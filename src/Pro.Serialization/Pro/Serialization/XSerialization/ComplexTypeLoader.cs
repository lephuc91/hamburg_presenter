using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Pro.Common.Collections;
using Pro.Common.Reflection;
using Pro.Serialization.Control;

namespace Pro.Serialization.XSerialization;

internal static class ComplexTypeLoader
{
	private static ComplexTypeCache _typeCache = new ComplexTypeCache(LoadComplexType);

	public static ComplexType GetComplexType<T>()
	{
		return typeof(T).GetComplexType();
	}

	public static ComplexType GetComplexType(this Type type)
	{
		return _typeCache.Get(type);
	}

	private static ComplexType LoadComplexType(Type type)
	{
		List<PropertyMetadata> list = new List<PropertyMetadata>();
		List<ChildPropertyMetadata> list2 = new List<ChildPropertyMetadata>();
		List<CollectionPropertyMetadata> list3 = new List<CollectionPropertyMetadata>();
		PropertyMetadata propertyMetadata = null;
		PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
		foreach (PropertyInfo propertyInfo in properties)
		{
			ControlAttributeBase[] source = propertyInfo.GetCustomAttributes<ControlAttributeBase>().ToArray();
			AliasAttribute aliasAttribute = source.FirstOrDefaultOf<AliasAttribute>();
			bool isOptional = source.AnyOf<OptionalAttribute>();
			bool isEscaped = source.AnyOf<EscapedAttribute>();
			bool flag = source.AnyOf<MixedCollectionAttribute>();
			Type[] subTypes = source.FirstOrDefaultOf<KnownTypesAttribute>()?.KnownTypes;
			KeyValuePair<string, string>[] staticHeaders = (from s in source.OfType<StaticHeaderAttribute>()
				select new KeyValuePair<string, string>(s.Header, s.Content)).ToArray();
			PropertyMetadata propertyMetadata2 = new PropertyMetadata(aliasAttribute?.NameAlias, aliasAttribute?.TypeAlias, isOptional, isEscaped, aliasAttribute?.DisplayName ?? false, staticHeaders, PropertyGetterCache.GetGetter(type, propertyInfo.Name), PropertySetterCache.GetSetter(type, propertyInfo.Name));
			if (source.AnyOf<TraitAttribute>())
			{
				list.Add(propertyMetadata2);
			}
			else if (source.AnyOf<ChildAttribute>())
			{
				list2.Add(new ChildPropertyMetadata(propertyMetadata2, propertyInfo.PropertyType, subTypes));
			}
			else if ((source.AnyOf<CollectionAttribute>() || flag) && typeof(IList).IsAssignableFrom(propertyInfo.PropertyType))
			{
				list3.Add(new CollectionPropertyMetadata(propertyMetadata2, flag, propertyInfo.PropertyType.GenericTypeArguments[0], subTypes));
			}
			else if (propertyMetadata == null && source.AnyOf<TextAttribute>())
			{
				propertyMetadata = propertyMetadata2;
			}
		}
		return new ComplexType(list, list2, list3, propertyMetadata);
	}
}
