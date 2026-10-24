using System;

namespace Pro.UI.Controls;

[AttributeUsage(AttributeTargets.Field)]
public class IconSizeAttribute : Attribute
{
	public double Height { get; set; }

	public double Width { get; set; }

	public IconSizeAttribute()
	{
	}

	public IconSizeAttribute(double width, double height)
	{
		Width = width;
		Height = height;
	}
}
