using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace Pro.UI.Utility;

public static class VisualExtensions
{
	private static readonly Action<Visual>? DoPropagateSuspendLayout = CreateStaticDelegate<Action<Visual>>("PropagateSuspendLayout");

	private static readonly Action<Visual?, Visual>? DoPropagateResumeLayout = CreateStaticDelegate<Action<Visual, Visual>>("PropagateResumeLayout");

	private static T? CreateStaticDelegate<T>(string methodName) where T : Delegate
	{
		MethodInfo method = typeof(UIElement).GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic);
		if (method != null)
		{
			return (T)Delegate.CreateDelegate(typeof(T), method);
		}
		return null;
	}

	public static void PropagateSuspendLayout(this Visual visual)
	{
		DoPropagateSuspendLayout?.Invoke(visual);
	}

	public static void PropagateResumeLayout(this Visual visual, Visual? parent)
	{
		DoPropagateResumeLayout?.Invoke(parent, visual);
	}
}
