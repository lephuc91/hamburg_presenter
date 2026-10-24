namespace Pro.UI.Converters;

public class CountToVisibilityConverter : ValueToVisibilityConverter
{
	public int CountTarget { get; set; }

	protected override bool EvaluateValue(object? value, object? parameter)
	{
		if (value is int num)
		{
			return num > CountTarget;
		}
		return false;
	}
}
