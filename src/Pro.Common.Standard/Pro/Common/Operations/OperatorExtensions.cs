using System.Diagnostics;

namespace Pro.Common.Operations;

public static class OperatorExtensions
{
	[DebuggerStepThrough]
	public static T Add<T>(this T lhs, T rhs)
	{
		return OperatorAdd<T>.Invoke(lhs, rhs);
	}

	[DebuggerStepThrough]
	public static T Subtract<T>(this T lhs, T rhs)
	{
		return OperatorSubtract<T>.Invoke(lhs, rhs);
	}

	[DebuggerStepThrough]
	public static T Multiply<T>(this T lhs, T rhs)
	{
		return OperatorMultiply<T>.Invoke(lhs, rhs);
	}

	[DebuggerStepThrough]
	public static T Divide<T>(this T lhs, T rhs)
	{
		return OperatorDivide<T>.Invoke(lhs, rhs);
	}

	[DebuggerStepThrough]
	public static T Modulo<T>(this T lhs, T rhs)
	{
		return OperatorModulo<T>.Invoke(lhs, rhs);
	}

	[DebuggerStepThrough]
	public static T Negate<T>(this T arg)
	{
		return OperatorNegate<T>.Invoke(arg);
	}

	[DebuggerStepThrough]
	public static bool Equal<T>(this T lhs, T rhs)
	{
		return OperatorEqual<T>.Invoke(lhs, rhs);
	}

	[DebuggerStepThrough]
	public static bool GreaterThan<T>(this T lhs, T rhs)
	{
		return OperatorGreaterThan<T>.Invoke(lhs, rhs);
	}

	[DebuggerStepThrough]
	public static bool GreaterThanOrEqual<T>(this T lhs, T rhs)
	{
		return OperatorGreaterThanOrEqual<T>.Invoke(lhs, rhs);
	}

	[DebuggerStepThrough]
	public static bool LessThan<T>(this T lhs, T rhs)
	{
		return OperatorLessThan<T>.Invoke(lhs, rhs);
	}

	[DebuggerStepThrough]
	public static bool LessThanOrEqual<T>(this T lhs, T rhs)
	{
		return OperatorLessThanOrEqual<T>.Invoke(lhs, rhs);
	}

	[DebuggerStepThrough]
	public static T Halve<T>(this T arg)
	{
		return OperatorHalve<T>.Invoke(arg);
	}

	[DebuggerStepThrough]
	public static T Quarter<T>(this T arg)
	{
		return OperatorQuarter<T>.Invoke(arg);
	}

	[DebuggerStepThrough]
	public static T Double<T>(this T arg)
	{
		return OperatorDouble<T>.Invoke(arg);
	}

	[DebuggerStepThrough]
	public static T Invert<T>(this T arg)
	{
		return OperatorInvert<T>.Invoke(arg);
	}

	[DebuggerStepThrough]
	public static T Cast<T, K>(this K arg)
	{
		return OperatorCast<T, K>.Invoke(arg);
	}
}
