namespace Pro.Common.Components;

public interface ICloneable<out T>
{
	T Clone();
}
