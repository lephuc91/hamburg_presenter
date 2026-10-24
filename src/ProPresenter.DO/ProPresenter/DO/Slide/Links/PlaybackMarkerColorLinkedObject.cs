using System.Diagnostics.CodeAnalysis;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Media;
using Pro.Common.Components.Reversibility;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.DO.Slide.Links;

public class PlaybackMarkerColorLinkedObject : LinkedFillObjectBase
{
	private PlaybackMarkerIdentifier _markerIdentifier;

	public override LinkedFillType LinkedFillType => LinkedFillType.PlaybackMarkerColor;

	public PlaybackMarkerIdentifier MarkerIdentifier
	{
		get
		{
			return _markerIdentifier;
		}
		set
		{
			SetValue("MarkerIdentifier", ref _markerIdentifier, value, delegate(PlaybackMarkerIdentifier o, PlaybackMarkerIdentifier n)
			{
				base.UndoStack?.Commit(UndoActionTypes.PlaybackMarkerIdentifier.ToAction(), this, "MarkerIdentifier", o, n);
			});
		}
	}

	public override string DisplayText => LocalizedStrings.Get(LinkedFillType) + " - " + MarkerIdentifier.DisplayText;

	public static ObjectBinder<PlaybackMarkerColorLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier> CreateBinder(PlaybackMarkerColorLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier right)
	{
		ObjectBinder<PlaybackMarkerColorLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier> objectBinder = new ObjectBinder<PlaybackMarkerColorLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier>(left, right);
		objectBinder.Bind((PlaybackMarkerColorLinkedObject l) => l.WhenPropertyChanges("MarkerIdentifier"), (ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier r) => Observable.Merge<Unit>(r.Destination.WhenValueChanges.ToUnit(), r.Name.WhenValueChanges.ToUnit(), r.Type.WhenValueChanges.ToUnit()), delegate(PlaybackMarkerColorLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier r)
		{
			r.Destination.Set(l.MarkerIdentifier.Destination.ToEntityPlaybackMarkerIdentificationDestination());
			r.Type.Set(l.MarkerIdentifier.Type.ToEntityPlaybackMarkerIdentifierType());
			r.Name.Set(l.MarkerIdentifier.Name);
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier r, PlaybackMarkerColorLinkedObject l)
		{
			l.MarkerIdentifier = new PlaybackMarkerIdentifier(r.Destination.Value.ToPlaybackMarkerIdentifierDestination(), r.Type.Value.ToPlaybackMarkerIdentifierType(), r.Name.Value);
		});
		return objectBinder;
	}

	public PlaybackMarkerColorLinkedObject()
	{
		_markerIdentifier = new PlaybackMarkerIdentifier(PlaybackMarkerIdentifierDestination.Presentation, PlaybackMarkerIdentifierType.Next);
	}

	public PlaybackMarkerColorLinkedObject(PlaybackMarkerIdentifier markerIdentifier)
	{
		_markerIdentifier = markerIdentifier;
	}

	public override IFill GetFill(ILinkData? linkData)
	{
		IPlaybackMarker playbackMarker = MarkerIdentifier.SelectLinkData(linkData)?.FindMarker(MarkerIdentifier, Colors.Transparent);
		if (playbackMarker != null)
		{
			return new SolidColorFill
			{
				Color = playbackMarker.Color
			};
		}
		return new SolidColorFill
		{
			Color = Colors.Transparent
		};
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedFillObject? other)
	{
		if (other is PlaybackMarkerColorLinkedObject { MarkerIdentifier: var markerIdentifier })
		{
			return markerIdentifier.Equals(MarkerIdentifier);
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(MarkerIdentifier);
	}

	public override ILinkedFillObject Clone()
	{
		return new PlaybackMarkerColorLinkedObject(MarkerIdentifier.Clone());
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.PlaybackMarkerColor = MarkerIdentifier.Serialize();
	}

	public static PlaybackMarkerColorLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier proto)
	{
		return new PlaybackMarkerColorLinkedObject(proto.Deserialize());
	}
}
