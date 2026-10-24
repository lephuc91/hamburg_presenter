using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Operations;
using Pro.Common.Reflection;

namespace Pro.Common.Utility;

public abstract class CollectionPropertyWrapperBase<I, T, V> : DynamicObject, INotifyPropertyChanged where I : class where V : INotifyPropertyChanged
{
	private readonly IEnumerable _items;

	public event PropertyChangedEventHandler? PropertyChanged;

	protected CollectionPropertyWrapperBase(IEnumerable items)
	{
		_items = items;
		_items.OfType<I>().ForEach(delegate(I i)
		{
			V value = GetValue(i);
			value.PropertyChanged += Item_PropertyChanged;
		});
		if (!(_items is INotifyCollectionChanged))
		{
			return;
		}
		((INotifyCollectionChanged)_items).CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			e.OldItems?.OfType<I>().ForEach(delegate(I i)
			{
				V value2 = GetValue(i);
				value2.PropertyChanged -= Item_PropertyChanged;
			});
			e.NewItems?.OfType<I>().ForEach(delegate(I i)
			{
				V value3 = GetValue(i);
				value3.PropertyChanged += Item_PropertyChanged;
			});
		};
	}

	protected abstract V GetValue(I item);

	protected abstract T GetValueType(I item);

	protected abstract V GenerateValue(T type);

	protected abstract void SetValue(I item, V value);

	protected abstract void StartPropertyChanged(T valueType, string propertyName);

	protected abstract void EndPropertyChanged(T valueType, string propertyName);

	public override bool TryGetMember(GetMemberBinder binder, out object? result)
	{
		I val = _items.FirstOrDefaultOf<I>();
		result = ((val == null) ? null : PropertyGetterCache.GetGetter(GetValue(val).GetType(), binder.Name)?.Invoke(GetValue(val)));
		return true;
	}

	public override bool TrySetMember(SetMemberBinder binder, object? value)
	{
		I item = _items.FirstOf<I>();
		T valueType = GetValueType(item);
		V val = GetValue(item);
		PropertySetter setter = PropertySetterCache.GetSetter(val.GetType(), binder.Name);
		if (setter == null)
		{
			throw new InvalidOperationException();
		}
		StartPropertyChanged(valueType, binder.Name);
		foreach (I item2 in _items.OfType<I>())
		{
			V val2 = GetValue(item2);
			if (!GetValueType(item2).Equal(valueType))
			{
				ref V reference = ref val2;
				val = default(V);
				if (val == null)
				{
					val = reference;
					reference = ref val;
				}
				reference.PropertyChanged -= Item_PropertyChanged;
				val2 = GenerateValue(valueType);
				ref V reference2 = ref val2;
				val = default(V);
				if (val == null)
				{
					val = reference2;
					reference2 = ref val;
				}
				reference2.PropertyChanged += Item_PropertyChanged;
				SetValue(item2, val2);
			}
			if (value != null || !setter.TargetType.IsValueType)
			{
				setter.Invoke(val2, value);
			}
		}
		EndPropertyChanged(valueType, binder.Name);
		return true;
	}

	private void Item_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		this.PropertyChanged?.Invoke(this, e);
	}
}
