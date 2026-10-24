using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Pro.Common.Mathematics;
using Pro.Common.Reflection;

namespace Pro.UI.Utility;

public static class LayoutHelper
{
	private const string LayoutContextFromMethodName = "From";

	private const string LayoutContextEnterMeasureMethodName = "EnterMeasure";

	private const string LayoutContextExitMeasureMethodName = "ExitMeasure";

	private const string LayoutContextEnterArrangeMethodName = "EnterArrange";

	private const string LayoutContextExitArrangeMethodName = "ExitArrange";

	private const string LayoutQueueRemoveMethodName = "Remove";

	private static readonly Func<UIElement, Size, Size>? DoMeasureCore;

	private static readonly FieldInfo? DesiredSizeField;

	private static readonly FieldInfo? MeasureRequestField;

	private static readonly FieldInfo? PreviousAvailableSizeField;

	private static readonly PropertyGetter? NeverMeasuredPropertyGetter;

	private static readonly PropertySetter? MeasureDirtyPropertySetter;

	private static readonly PropertySetter? MeasureInProgressPropertySetter;

	private static readonly Action<UIElement, Rect>? DoArrangeCore;

	private static readonly FieldInfo? FinalRectField;

	private static readonly FieldInfo? ArrangeRequestField;

	private static readonly PropertyGetter? NeverArrangedPropertyGetter;

	private static readonly PropertySetter? ArrangeDirtyPropertySetter;

	private static readonly PropertySetter? ArrangeInProgressPropertySetter;

	private static readonly PropertyGetter? RenderingInvalidatedPropertyGetter;

	private static readonly PropertySetter? RenderingInvalidatedPropertySetter;

	private static readonly Action<UIElement, Size>? DoEnsureClip;

	private static readonly Func<UIElement, Size, Size, bool>? DoMarkSizeChanged;

	private static readonly Func<UIElement, DrawingContext>? DoRenderOpen;

	private static readonly Action<UIElement, DrawingContext>? DoOnRender;

	private static readonly Action<UIElement>? DoUpdatePixelSnappingGuidelines;

	private const string CLMTypeName = "System.Windows.ContextLayoutManager";

	private const string CLMMeasureQueuePropertyName = "MeasureQueue";

	private const string CLMArrangeQueuePropertyName = "ArrangeQueue";

	private static readonly Func<Dispatcher, object>? DoCLMFrom;

	private static readonly Action<object>? DoCLMEnterMeasure;

	private static readonly Action<object>? DoCLMExitMeasure;

	private static readonly Action<object>? DoCLMEnterArrange;

	private static readonly Action<object>? DoCLMExitArrange;

	private static readonly PropertyGetter? CLMMeasureQueuePropertyGetter;

	private static readonly PropertyGetter? CLMArrangeQueuePropertyGetter;

	private const string LQTypeName = "LayoutQueue";

	private static Action<object, UIElement>? DoLQRemove;

	static LayoutHelper()
	{
		DoMeasureCore = CreateDelegate<Func<UIElement, Size, Size>>("MeasureCore");
		DesiredSizeField = GetField("_desiredSize");
		MeasureRequestField = GetField("MeasureRequest");
		PreviousAvailableSizeField = GetField("_previousAvailableSize");
		NeverMeasuredPropertyGetter = PropertyGetterCache.GetGetter<UIElement>("NeverMeasured");
		MeasureDirtyPropertySetter = PropertySetterCache.GetSetter<UIElement>("MeasureDirty");
		MeasureInProgressPropertySetter = PropertySetterCache.GetSetter<UIElement>("MeasureInProgress");
		DoArrangeCore = CreateDelegate<Action<UIElement, Rect>>("ArrangeCore");
		FinalRectField = GetField("_finalRect");
		ArrangeRequestField = GetField("ArrangeRequest");
		NeverArrangedPropertyGetter = PropertyGetterCache.GetGetter<UIElement>("NeverArranged");
		ArrangeDirtyPropertySetter = PropertySetterCache.GetSetter<UIElement>("ArrangeDirty");
		ArrangeInProgressPropertySetter = PropertySetterCache.GetSetter<UIElement>("ArrangeInProgress");
		RenderingInvalidatedPropertyGetter = PropertyGetterCache.GetGetter<UIElement>("RenderingInvalidated");
		RenderingInvalidatedPropertySetter = PropertySetterCache.GetSetter<UIElement>("RenderingInvalidated");
		DoEnsureClip = CreateDelegate<Action<UIElement, Size>>("ensureClip");
		DoMarkSizeChanged = CreateDelegate<Func<UIElement, Size, Size, bool>>("markForSizeChangedIfNeeded");
		DoRenderOpen = CreateDelegate<Func<UIElement, DrawingContext>>("RenderOpen");
		DoOnRender = CreateDelegate<Action<UIElement, DrawingContext>>("OnRender");
		DoUpdatePixelSnappingGuidelines = CreateDelegate<Action<UIElement>>("updatePixelSnappingGuidelines");
		Type type = Assembly.GetAssembly(typeof(UIElement))?.GetType("System.Windows.ContextLayoutManager");
		if ((object)type == null)
		{
			return;
		}
		Type type2 = typeof(Action<>).MakeGenericType(type);
		MethodInfo methodInfo = typeof(LayoutHelper).GetMethod("DelegateWrapper", BindingFlags.Static | BindingFlags.NonPublic)?.MakeGenericMethod(type);
		MethodInfo method = type.GetMethod("From", BindingFlags.Static | BindingFlags.NonPublic);
		if (method != null)
		{
			DoCLMFrom = (Func<Dispatcher, object>)Delegate.CreateDelegate(typeof(Func<Dispatcher, object>), method);
		}
		MethodInfo method2 = type.GetMethod("EnterMeasure", BindingFlags.Instance | BindingFlags.NonPublic);
		if (method2 != null)
		{
			object obj;
			if ((object)methodInfo == null)
			{
				obj = null;
			}
			else
			{
				object[] parameters = new Delegate[1] { Delegate.CreateDelegate(type2, method2) };
				obj = methodInfo.Invoke(null, parameters);
			}
			DoCLMEnterMeasure = (Action<object>)obj;
		}
		MethodInfo method3 = type.GetMethod("ExitMeasure", BindingFlags.Instance | BindingFlags.NonPublic);
		if (method3 != null)
		{
			object obj2;
			if ((object)methodInfo == null)
			{
				obj2 = null;
			}
			else
			{
				object[] parameters = new Delegate[1] { Delegate.CreateDelegate(type2, method3) };
				obj2 = methodInfo.Invoke(null, parameters);
			}
			DoCLMExitMeasure = (Action<object>)obj2;
		}
		MethodInfo method4 = type.GetMethod("EnterArrange", BindingFlags.Instance | BindingFlags.NonPublic);
		if (method4 != null)
		{
			object obj3;
			if ((object)methodInfo == null)
			{
				obj3 = null;
			}
			else
			{
				object[] parameters = new Delegate[1] { Delegate.CreateDelegate(type2, method4) };
				obj3 = methodInfo.Invoke(null, parameters);
			}
			DoCLMEnterArrange = (Action<object>)obj3;
		}
		MethodInfo method5 = type.GetMethod("ExitArrange", BindingFlags.Instance | BindingFlags.NonPublic);
		if (method5 != null)
		{
			object obj4;
			if ((object)methodInfo == null)
			{
				obj4 = null;
			}
			else
			{
				object[] parameters = new Delegate[1] { Delegate.CreateDelegate(type2, method5) };
				obj4 = methodInfo.Invoke(null, parameters);
			}
			DoCLMExitArrange = (Action<object>)obj4;
		}
		CLMMeasureQueuePropertyGetter = PropertyGetterCache.GetGetter(type, "MeasureQueue");
		CLMArrangeQueuePropertyGetter = PropertyGetterCache.GetGetter(type, "ArrangeQueue");
		Type nestedType = type.GetNestedType("LayoutQueue", BindingFlags.NonPublic);
		if ((object)nestedType == null)
		{
			return;
		}
		Type type3 = typeof(Action<, >).MakeGenericType(nestedType, typeof(UIElement));
		MethodInfo methodInfo2 = typeof(LayoutHelper).GetMethod("DelegateWrapperArg", BindingFlags.Static | BindingFlags.NonPublic)?.MakeGenericMethod(nestedType, typeof(UIElement));
		MethodInfo method6 = nestedType.GetMethod("Remove", BindingFlags.Instance | BindingFlags.NonPublic);
		if (method6 != null)
		{
			object obj5;
			if ((object)methodInfo2 == null)
			{
				obj5 = null;
			}
			else
			{
				object[] parameters = new Delegate[1] { Delegate.CreateDelegate(type3, method6) };
				obj5 = methodInfo2.Invoke(null, parameters);
			}
			DoLQRemove = (Action<object, UIElement>)obj5;
		}
	}

	private static T? CreateDelegate<T>(string methodName) where T : Delegate
	{
		MethodInfo method = typeof(UIElement).GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
		if (method != null)
		{
			return (T)Delegate.CreateDelegate(typeof(T), method);
		}
		return null;
	}

	private static FieldInfo? GetField(string name)
	{
		return typeof(UIElement).GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
	}

	private static Action<object> DelegateWrapper<T>(Action<T> del)
	{
		return delegate(object i)
		{
			del((T)i);
		};
	}

	private static Action<object, V> DelegateWrapperArg<T, V>(Action<T, V> del)
	{
		return delegate(object i, V p)
		{
			del((T)i, p);
		};
	}

	public static void ForceMeasure(this UIElement element, Vector2<double> availableSize, bool ignoreDirtyFlag = false)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		object obj = NeverMeasuredPropertyGetter?.Invoke(element);
		if (obj is bool && (bool)obj)
		{
			element.Measure(availableSize);
			return;
		}
		DispatcherProcessingDisabled val = ((DispatcherObject)element).Dispatcher.DisableProcessing();
		try
		{
			object obj2 = DoCLMFrom?.Invoke(((DispatcherObject)element).Dispatcher);
			if (obj2 == null)
			{
				return;
			}
			if (MeasureRequestField?.GetValue(element) != null)
			{
				object obj3 = CLMMeasureQueuePropertyGetter?.Invoke(obj2);
				if (obj3 != null)
				{
					DoLQRemove?.Invoke(obj3, element);
				}
			}
			if (ignoreDirtyFlag || !element.IsMeasureValid || (Vector2<double>?)(Size?)PreviousAvailableSizeField?.GetValue(element) != availableSize)
			{
				MeasureInProgressPropertySetter?.Invoke(element, true);
				element.InvalidateArrange();
				DoCLMEnterMeasure?.Invoke(obj2);
				Size? val2 = DoMeasureCore?.Invoke(element, availableSize);
				PreviousAvailableSizeField?.SetValue(element, (Size)availableSize);
				DesiredSizeField?.SetValue(element, val2);
				MeasureDirtyPropertySetter?.Invoke(element, false);
				MeasureInProgressPropertySetter?.Invoke(element, false);
				DoCLMExitMeasure?.Invoke(obj2);
			}
		}
		finally
		{
			((IDisposable)(DispatcherProcessingDisabled)(ref val)/*cast due to .constrained prefix*/).Dispose();
		}
	}

	public static void ForceArrange(this UIElement element, Rect<double> finalRect, bool ignoreDirtyFlag = false, bool forceRender = false)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		object obj = NeverArrangedPropertyGetter?.Invoke(element);
		if (obj is bool && (bool)obj)
		{
			element.Arrange(finalRect);
			return;
		}
		DispatcherProcessingDisabled val = ((DispatcherObject)element).Dispatcher.DisableProcessing();
		try
		{
			object obj2 = DoCLMFrom?.Invoke(((DispatcherObject)element).Dispatcher);
			if (obj2 == null)
			{
				return;
			}
			if (ArrangeRequestField?.GetValue(element) != null)
			{
				object obj3 = CLMArrangeQueuePropertyGetter?.Invoke(obj2);
				if (obj3 != null)
				{
					DoLQRemove?.Invoke(obj3, element);
				}
			}
			if (!ignoreDirtyFlag && element.IsArrangeValid && !((Rect<double>?)(Rect?)FinalRectField?.GetValue(element) != finalRect))
			{
				return;
			}
			ArrangeInProgressPropertySetter?.Invoke(element, true);
			Size renderSize = element.RenderSize;
			DoCLMEnterArrange?.Invoke(obj2);
			DoArrangeCore?.Invoke(element, finalRect);
			DoEnsureClip?.Invoke(element, finalRect.Size);
			bool flag = DoMarkSizeChanged?.Invoke(element, renderSize, element.RenderSize) ?? false;
			FinalRectField?.SetValue(element, (Rect)finalRect);
			ArrangeDirtyPropertySetter?.Invoke(element, false);
			ArrangeInProgressPropertySetter?.Invoke(element, false);
			DoCLMExitArrange?.Invoke(obj2);
			if (!(forceRender || flag))
			{
				obj = RenderingInvalidatedPropertyGetter?.Invoke(element);
				if (!(obj is bool) || !(bool)obj)
				{
					return;
				}
			}
			DrawingContext drawingContext = DoRenderOpen?.Invoke(element);
			if (drawingContext != null)
			{
				DoOnRender?.Invoke(element, drawingContext);
				drawingContext.Close();
				RenderingInvalidatedPropertySetter?.Invoke(element, false);
				DoUpdatePixelSnappingGuidelines?.Invoke(element);
			}
		}
		finally
		{
			((IDisposable)(DispatcherProcessingDisabled)(ref val)/*cast due to .constrained prefix*/).Dispose();
		}
	}
}
