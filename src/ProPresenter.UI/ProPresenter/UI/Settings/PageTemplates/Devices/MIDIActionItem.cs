using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using CommunityToolkit.Mvvm.Input;
using Pro.MIDI;
using Pro.UI.Utility;
using ProPresenter.DO.Communication.MIDI;

namespace ProPresenter.UI.Settings.PageTemplates.Devices;

public partial class MIDIActionItem : UserControl, IComponentConnector
{
	private static readonly DependencyProperty ActionProperty = DependencyProperty.Register("Action", typeof(MIDIAction), typeof(MIDIActionItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)MIDIAction.ClearAll));

	private static readonly DependencyProperty NoteNumberProperty = DependencyProperty.Register("NoteNumber", typeof(int), typeof(MIDIActionItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((MIDIActionItem)(object)s).OnNoteNumberChanged((int)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}));

	private static readonly DependencyProperty PitchValueProperty = DependencyProperty.Register("PitchValue", typeof(Pitch), typeof(MIDIActionItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)default(Pitch)));

	private static readonly DependencyProperty MIDIMapProperty = DependencyProperty.Register("MIDIMap", typeof(MIDIActionMap), typeof(MIDIActionItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((MIDIActionItem)(object)s).OnMIDIMapChangd(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as MIDIActionMap, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as MIDIActionMap);
	}));

	private static readonly DependencyProperty AssignNoteNumberCommandProperty = DependencyProperty.Register("AssignNoteNumberCommand", typeof(IRelayCommand<KeyValuePair<MIDIAction, int>>), typeof(MIDIActionItem));

	public MIDIAction Action
	{
		get
		{
			return (MIDIAction)((DependencyObject)this).GetValue(ActionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActionProperty, (object)value);
		}
	}

	private int NoteNumber
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(NoteNumberProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NoteNumberProperty, (object)value);
		}
	}

	private Pitch PitchValue
	{
		get
		{
			return (Pitch)((DependencyObject)this).GetValue(PitchValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PitchValueProperty, (object)value);
		}
	}

	public MIDIActionMap? MIDIMap
	{
		get
		{
			return (MIDIActionMap)((DependencyObject)this).GetValue(MIDIMapProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MIDIMapProperty, (object)value);
		}
	}

	public IRelayCommand<KeyValuePair<MIDIAction, int>>? AssignNoteNumberCommand
	{
		get
		{
			return (IRelayCommand<KeyValuePair<MIDIAction, int>>)((DependencyObject)this).GetValue(AssignNoteNumberCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AssignNoteNumberCommandProperty, (object)value);
		}
	}

	public MIDIActionItem()
	{
		InitializeComponent();
	}

	private void OnNoteNumberChanged(int newValue)
	{
		AssignNoteNumberCommand?.Invoke(new KeyValuePair<MIDIAction, int>(Action, newValue));
	}

	private void OnMIDIMapChangd(MIDIActionMap? oldMap, MIDIActionMap? newMap)
	{
		if (oldMap != null)
		{
			oldMap.CollectionChanged -= Map_CollectionChanged;
		}
		if (newMap != null)
		{
			newMap.CollectionChanged += Map_CollectionChanged;
		}
		UpdateNoteNumber();
	}

	private void Map_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		UpdateNoteNumber();
	}

	private void UpdateNoteNumber()
	{
		if (MIDIMap != null)
		{
			((DependencyObject)this).SetCurrentValue(NoteNumberProperty, (object)MIDIMap[Action]);
			((DependencyObject)this).SetCurrentValue(PitchValueProperty, (object)new Pitch(NoteNumber));
		}
	}
}
