using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IClearGroupsDocument : IEntity, IDisposable
{
	public class Types
	{
		public interface IClearGroup : IEntity, IDisposable
		{
			public class Types
			{
				public enum ImageType
				{
					Custom,
					One,
					Two,
					Three,
					Four,
					Five,
					Six,
					Seven,
					Eight,
					Nine,
					Zero,
					All,
					Megahorn,
					Play,
					Bulb,
					Sunglasses,
					Arrow,
					Target,
					Star,
					Sun,
					Bell,
					Paperclip,
					Flask,
					Eyeglasses,
					Cupcake,
					Slide,
					Hat,
					Flower,
					Heart,
					Message,
					Audio,
					Cloud,
					Exclamation
				}
			}

			IObservableProperty<Guid> Uuid { get; }

			IObservableProperty<string> Name { get; }

			ICollection<IAction.Types.ClearType> LayerTargets { get; }

			IObservableProperty<bool> IsHiddenInPreview { get; }

			IObservableProperty<byte[]?> ImageData { get; }

			IObservableProperty<Types.ImageType> ImageType { get; }

			IObservableProperty<bool> IsIconTinted { get; }

			IObservableProperty<Color?> IconTintColor { get; }

			ICollection<IAction.Types.ContentDestination> TimelineTargets { get; }

			IObservableProperty<bool> ClearPresentationNextSlide { get; }
		}

		internal sealed class ClearGroup : IClearGroup, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty Uuid_;

			private StringObservableProperty Name_;

			private AtomicMapCollection<IAction.Types.ClearType> LayerTargets_;

			private BoolObservableProperty IsHiddenInPreview_;

			private OptionalBytesObservableProperty ImageData_;

			private EnumObservableProperty<IClearGroup.Types.ImageType> ImageType_;

			private BoolObservableProperty IsIconTinted_;

			private OptionalAtomicObservableProperty<Color> IconTintColor_;

			private EnumCollection<IAction.Types.ContentDestination> TimelineTargets_;

			private BoolObservableProperty ClearPresentationNextSlide_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> Uuid => Uuid_;

			public IObservableProperty<string> Name => Name_;

			public ICollection<IAction.Types.ClearType> LayerTargets => LayerTargets_;

			public IObservableProperty<bool> IsHiddenInPreview => IsHiddenInPreview_;

			public IObservableProperty<byte[]?> ImageData => ImageData_;

			public IObservableProperty<IClearGroup.Types.ImageType> ImageType => ImageType_;

			public IObservableProperty<bool> IsIconTinted => IsIconTinted_;

			public IObservableProperty<Color?> IconTintColor => IconTintColor_;

			public ICollection<IAction.Types.ContentDestination> TimelineTargets => TimelineTargets_;

			public IObservableProperty<bool> ClearPresentationNextSlide => ClearPresentationNextSlide_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMap(_map);
				Name_.UpdateMap(_map);
				LayerTargets_.UpdateMap(_map);
				IsHiddenInPreview_.UpdateMap(_map);
				ImageData_.UpdateMap(_map);
				ImageType_.UpdateMap(_map);
				IsIconTinted_.UpdateMap(_map);
				IconTintColor_.UpdateMap(_map);
				TimelineTargets_.UpdateMap(_map);
				ClearPresentationNextSlide_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				Uuid_.UpdateMapOnInternalMapUpdate(_map);
				Name_.UpdateMapOnInternalMapUpdate(_map);
				LayerTargets_.UpdateMapOnInternalMapUpdate(_map);
				IsHiddenInPreview_.UpdateMapOnInternalMapUpdate(_map);
				ImageData_.UpdateMapOnInternalMapUpdate(_map);
				ImageType_.UpdateMapOnInternalMapUpdate(_map);
				IsIconTinted_.UpdateMapOnInternalMapUpdate(_map);
				IconTintColor_.UpdateMapOnInternalMapUpdate(_map);
				TimelineTargets_.UpdateMapOnInternalMapUpdate(_map);
				ClearPresentationNextSlide_.UpdateMapOnInternalMapUpdate(_map);
			}

			public ClearGroup()
				: this(new LoroMap())
			{
			}

			public ClearGroup(LoroMap values)
			{
				_map = values;
				Uuid_ = new GuidObservableProperty("uuid__1", LoroMap);
				Name_ = new StringObservableProperty("name__2", LoroMap);
				LayerTargets_ = new AtomicMapCollection<IAction.Types.ClearType>(LoroMap, "layer_targets__3", new EntityFactory(), IAction.Types.ClearTypeExtension.Serialize);
				IsHiddenInPreview_ = new BoolObservableProperty("is_hidden_in_preview__4", LoroMap);
				ImageData_ = new OptionalBytesObservableProperty("image_data__5", LoroMap);
				ImageType_ = new EnumObservableProperty<IClearGroup.Types.ImageType>("image_type__6", LoroMap);
				IsIconTinted_ = new BoolObservableProperty("is_icon_tinted__7", LoroMap);
				IconTintColor_ = new OptionalAtomicObservableProperty<Color>("icon_tint_color__8", LoroMap, ColorExtension.Deserialize, ColorExtension.Serialize);
				TimelineTargets_ = new EnumCollection<IAction.Types.ContentDestination>(LoroMap, "timeline_targets__9");
				ClearPresentationNextSlide_ = new BoolObservableProperty("clear_presentation_next_slide__10", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(Uuid_.WhenChangeHappens, Name_.WhenChangeHappens, LayerTargets_.WhenChangeHappens, IsHiddenInPreview_.WhenChangeHappens, ImageData_.WhenChangeHappens, ImageType_.WhenChangeHappens, IsIconTinted_.WhenChangeHappens, IconTintColor_.WhenChangeHappens, TimelineTargets_.WhenChangeHappens, ClearPresentationNextSlide_.WhenChangeHappens);
			}

			public void Dispose()
			{
				Uuid_.Dispose();
				Name_.Dispose();
				LayerTargets_.Dispose();
				IsHiddenInPreview_.Dispose();
				ImageData_.Dispose();
				ImageType_.Dispose();
				IsIconTinted_.Dispose();
				IconTintColor_.Dispose();
				TimelineTargets_.Dispose();
				ClearPresentationNextSlide_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				Uuid_.OnDiff(path, diff);
				Name_.OnDiff(path, diff);
				LayerTargets_.OnDiff(path, diff);
				IsHiddenInPreview_.OnDiff(path, diff);
				ImageData_.OnDiff(path, diff);
				ImageType_.OnDiff(path, diff);
				IsIconTinted_.OnDiff(path, diff);
				IconTintColor_.OnDiff(path, diff);
				TimelineTargets_.OnDiff(path, diff);
				ClearPresentationNextSlide_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}

	IComplexCollection<Types.IClearGroup> Groups { get; }
}
