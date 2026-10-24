using System;
using System.Linq.Expressions;
using Pro.Common.Cache;

namespace Pro.Common.Reflection;

public static class Assembler
{
	private sealed class CtorCache : Cache<Type, Func<object>>
	{
		protected override Func<object> GenerateValue(Type target)
		{
			return Expression.Lambda<Func<object>>(Expression.New(target), Array.Empty<ParameterExpression>()).Compile();
		}
	}

	private static CtorCache _ctorCache = new CtorCache();

	public static T Construct<T>()
	{
		return (T)typeof(T).Construct();
	}

	public static object Construct(this Type type)
	{
		Func<object> func = _ctorCache.Get(type);
		if (func == null)
		{
			throw new MissingMethodException(type.FullName);
		}
		return func();
	}
}
