using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Pro.UI.DialogService;

public record DialogIcon(ImageSource? Icon, bool HideIcon = false)
{
	public static DialogIcon Default { get; } = new DialogIcon(null);

	public static DialogIcon WithHiddenIcon { get; } = new DialogIcon(null, HideIcon: true);

	public static implicit operator DialogIcon(ImageSource? image)
	{
		return new DialogIcon(image);
	}

	[CompilerGenerated]
	protected DialogIcon(DialogIcon original)
	{
		Icon = original.Icon;
		HideIcon = original.HideIcon;
	}
}
