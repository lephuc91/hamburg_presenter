using System;
using System.Linq.Expressions;
using System.Reflection;
using Pro.Common.Cache;

namespace Pro.Common.Reflection;

public class PropertyGetterCache : Cache<PropertyKey, PropertyGetter?>
{
	private static PropertyGetterCache _instance = new PropertyGetterCache();

	private PropertyGetterCache()
	{
	}

	public static PropertyGetter? GetGetter<T>(string propertyName)
	{
		return GetGetter(typeof(T), propertyName);
	}

	public static PropertyGetter? GetGetter(Type ownerType, string propertyName)
	{
		return _instance.Get(new PropertyKey(ownerType, propertyName));
	}

	protected override PropertyGetter? GenerateValue(PropertyKey target)
	{
		PropertyInfo property = target.OwnerType.GetProperty(target.PropertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		MethodInfo methodInfo = property?.GetMethod;
		if (property == null || methodInfo == null)
		{
			return null;
		}
		ParameterExpression parameterExpression = Expression.Parameter(typeof(object));
		UnaryExpression body = Expression.Convert(Expression.Call(Expression.Convert(parameterExpression, target.OwnerType), methodInfo), typeof(object));
		return new PropertyGetter(property.Name, property.PropertyType, Expression.Lambda<PropertyGetterDelegate>(body, new ParameterExpression[1] { parameterExpression }).Compile());
	}
}
