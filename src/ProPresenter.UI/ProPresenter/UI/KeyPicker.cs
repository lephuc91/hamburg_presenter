using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO.Chords;

namespace ProPresenter.UI;

public partial class KeyPicker : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ShowMajorMinorSelectorProperty = DependencyProperty.Register("ShowMajorMinorSelector", typeof(bool), typeof(KeyPicker), new PropertyMetadata((object)true));

	public static readonly DependencyProperty SelectedKeyProperty = DependencyProperty.Register("SelectedKey", typeof(Note), typeof(KeyPicker), new PropertyMetadata((object)Note.C));

	public static readonly DependencyProperty SelectedScaleProperty = DependencyProperty.Register("SelectedScale", typeof(Scale), typeof(KeyPicker), new PropertyMetadata((object)Scale.Major));

	public bool ShowMajorMinorSelector
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowMajorMinorSelectorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowMajorMinorSelectorProperty, (object)value);
		}
	}

	public Note SelectedKey
	{
		get
		{
			return (Note)((DependencyObject)this).GetValue(SelectedKeyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedKeyProperty, (object)value);
		}
	}

	public Scale SelectedScale
	{
		get
		{
			return (Scale)((DependencyObject)this).GetValue(SelectedScaleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedScaleProperty, (object)value);
		}
	}

	public List<Note> Notes { get; private set; }

	public List<Scale> Scales { get; private set; }

	public KeyPicker()
	{
		Scales = new List<Scale>
		{
			Scale.Major,
			Scale.Minor
		};
		Notes = new List<Note>
		{
			Note.Aes,
			Note.A,
			Note.Ais,
			Note.Bes,
			Note.B,
			Note.C,
			Note.Cis,
			Note.Des,
			Note.D,
			Note.Dis,
			Note.Ees,
			Note.E,
			Note.F,
			Note.Fis,
			Note.Ges,
			Note.G,
			Note.Gis
		};
		InitializeComponent();
	}
}
