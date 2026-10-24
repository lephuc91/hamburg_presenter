using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

public class AudioCountdownLinkedVisibilityObject : NotifyPropertyChangedBase, ILinkedVisibilityObject, ILinkedObject, IRenderEquatable<ILinkedVisibilityObject>, IRenderHashable, ICloneable<ILinkedVisibilityObject>, INotifyPropertyChanged
{
	private AudioCountdownVisibilityCriteria _selectedCriterion;

	public VisibilityLinkType Type => VisibilityLinkType.AudioCountdown;

	public string DisplayText => string.Empty;

	public string Content => LocalizedStrings.Get("TEXT_LINK_AUDIO_COUNTDOWN_title");

	public UndoStack? UndoStack { get; set; }

	public AudioCountdownVisibilityCriteria SelectedCriterion
	{
		get
		{
			return _selectedCriterion;
		}
		set
		{
			SetValue("SelectedCriterion", ref _selectedCriterion, value, delegate(AudioCountdownVisibilityCriteria o, AudioCountdownVisibilityCriteria n)
			{
				UndoStack?.Commit(UndoActionTypes.VisibilityLinkChangeTimerCondition.ToAction(), this, "SelectedCriterion", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public event System.Action? DataModified;

	public static ObjectBinder<AudioCountdownLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility> CreateBinder(AudioCountdownLinkedVisibilityObject left, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility right)
	{
		ObjectBinder<AudioCountdownLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility> objectBinder = new ObjectBinder<AudioCountdownLinkedVisibilityObject, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility>(left, right);
		objectBinder.Bind((AudioCountdownLinkedVisibilityObject l) => l.WhenPropertyChanges("SelectedCriterion"), (ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility r) => r.VisibilityCriterion.WhenValueChanges, delegate(AudioCountdownLinkedVisibilityObject l, ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility r)
		{
			r.VisibilityCriterion.Set(l.SelectedCriterion.ToEntityAudioCountdownVisibilityCriterion());
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IVisibilityLink.Types.ICondition.Types.IAudioCountdownVisibility r, AudioCountdownLinkedVisibilityObject l)
		{
			l.SelectedCriterion = r.VisibilityCriterion.Value.ToAudioCountdownVisibilityCriteria();
		});
		return objectBinder;
	}

	public bool RenderEquals([NotNullWhen(true)] ILinkedVisibilityObject? other)
	{
		return other is AudioCountdownLinkedVisibilityObject;
	}

	public int GetRenderHashCode()
	{
		return 0;
	}

	public ILinkedVisibilityObject Clone()
	{
		return new AudioCountdownLinkedVisibilityObject
		{
			SelectedCriterion = SelectedCriterion
		};
	}

	public void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition protoVisibilityLinkCondition)
	{
		protoVisibilityLinkCondition.AudioCountdownVisibility = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility
		{
			VisibilityCriterion = SelectedCriterion.ToProtoAudioCountdownVisibilityCriterion()
		};
	}

	public static AudioCountdownLinkedVisibilityObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VisibilityLink.Types.Condition.Types.AudioCountdownVisibility protoAudioCountdownVisibility)
	{
		return new AudioCountdownLinkedVisibilityObject
		{
			SelectedCriterion = protoAudioCountdownVisibility.VisibilityCriterion.ToAudioCountdownVisibilityCriteria()
		};
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}
}
