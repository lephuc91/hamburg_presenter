using System;
using System.Linq.Expressions;
using System.Reflection;
using Pro.Common.Cache;

namespace Pro.Common.Reflection;

public class PropertySetterCache : Cache<PropertyKey, PropertySetter?>
{
	private static PropertySetterCache _instance = new PropertySetterCache();

	private PropertySetterCache()
	{
	}

	public static PropertySetter? GetSetter<T>(string propertyName)
	{
		return GetSetter(typeof(T), propertyName);
	}

	public static PropertySetter? GetSetter(Type ownerType, string propertyName)
	{
		return _instance.Get(new PropertyKey(ownerType, propertyName));
	}

	protected override PropertySetter? GenerateValue(PropertyKey target)
	{
		PropertyInfo property = target.OwnerType.GetProperty(target.PropertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		MethodInfo methodInfo = property?.SetMethod;
		if (methodInfo == null)
		{
			return null;
		}
		ParameterExpression parameterExpression = Expression.Parameter(typeof(object));
		UnaryExpression instance = Expression.Convert(parameterExpression, target.OwnerType);
		ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object));
		UnaryExpression unaryExpression = Expression.Convert(parameterExpression2, property.PropertyType);
		MethodCallExpression body = Expression.Call(instance, methodInfo, unaryExpression);
		return new PropertySetter(property.Name, property.PropertyType, Expression.Lambda<PropertySetterDelegate>(body, new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile());
	}
}
