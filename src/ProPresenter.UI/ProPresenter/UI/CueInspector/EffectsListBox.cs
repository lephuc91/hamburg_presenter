using System.Windows;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.DO.Effects;
using Pro.UI.Controls;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.CueInspector;

public class EffectsListBox : DragDropListBox<EffectParameters>
{
	public static readonly DependencyProperty EffectsProperty = DependencyProperty.Register("Effects", typeof(EffectsCollection), typeof(EffectsListBox));

	protected override IDragDropCollection<EffectParameters>? SourceCollection => Effects;

	public EffectsCollection? Effects
	{
		get
		{
			return (EffectsCollection)((DependencyObject)this).GetValue(EffectsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EffectsProperty, (object)value);
		}
	}

	public EffectsListBox()
	{
		AddDropType<EffectParameters>();
	}

	protected override bool ShouldDeselectOnMouseUp(MouseButtonEventArgs e)
	{
		return false;
	}
}
