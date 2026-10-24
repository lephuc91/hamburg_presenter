using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Pro.Entity.Collections;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

public interface IProAudienceLook : IEntity, IDisposable
{
	public class Types
	{
		public interface IProScreenLook : IEntity, IDisposable
		{
			IObservableProperty<Guid> ProScreenUuid { get; }

			IObservableProperty<bool> PropsEnabled { get; }

			IObservableProperty<bool> LiveVideoEnabled { get; }

			IObservableProperty<bool> PresentationBackgroundEnabled { get; }

			IObservableProperty<Url?> TemplateDocumentFilePath { get; }

			IObservableProperty<Guid?> TemplateSlideUuid { get; }

			IObservableProperty<bool> PresentationForegroundEnabled { get; }

			IObservableProperty<Guid?> MaskUuid { get; }

			IObservableProperty<bool> AnnouncementsEnabled { get; }

			IObservableProperty<bool> PropsLayerEnabled { get; }

			IObservableProperty<bool> MessagesLayerEnabled { get; }
		}

		internal sealed class ProScreenLook : IProScreenLook, IEntity, IDisposable, IInternalEntity, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
		{
			private LoroMap _map;

			private CompositeDisposable _linkedDisposables;

			private GuidObservableProperty ProScreenUuid_;

			private BoolObservableProperty PropsEnabled_;

			private BoolObservableProperty LiveVideoEnabled_;

			private BoolObservableProperty PresentationBackgroundEnabled_;

			private OptionalAtomicObservableProperty<Url> TemplateDocumentFilePath_;

			private OptionalGuidObservableProperty TemplateSlideUuid_;

			private BoolObservableProperty PresentationForegroundEnabled_;

			private OptionalGuidObservableProperty MaskUuid_;

			private BoolObservableProperty AnnouncementsEnabled_;

			private BoolObservableProperty PropsLayerEnabled_;

			private BoolObservableProperty MessagesLayerEnabled_;

			public LoroMap LoroMap => _map;

			public IObservable<Unit> WhenChangeHappens { get; }

			public IObservableProperty<Guid> ProScreenUuid => ProScreenUuid_;

			public IObservableProperty<bool> PropsEnabled => PropsEnabled_;

			public IObservableProperty<bool> LiveVideoEnabled => LiveVideoEnabled_;

			public IObservableProperty<bool> PresentationBackgroundEnabled => PresentationBackgroundEnabled_;

			public IObservableProperty<Url?> TemplateDocumentFilePath => TemplateDocumentFilePath_;

			public IObservableProperty<Guid?> TemplateSlideUuid => TemplateSlideUuid_;

			public IObservableProperty<bool> PresentationForegroundEnabled => PresentationForegroundEnabled_;

			public IObservableProperty<Guid?> MaskUuid => MaskUuid_;

			public IObservableProperty<bool> AnnouncementsEnabled => AnnouncementsEnabled_;

			public IObservableProperty<bool> PropsLayerEnabled => PropsLayerEnabled_;

			public IObservableProperty<bool> MessagesLayerEnabled => MessagesLayerEnabled_;

			public void UpdateMap(LoroMap value)
			{
				_map = value;
				ProScreenUuid_.UpdateMap(_map);
				PropsEnabled_.UpdateMap(_map);
				LiveVideoEnabled_.UpdateMap(_map);
				PresentationBackgroundEnabled_.UpdateMap(_map);
				TemplateDocumentFilePath_.UpdateMap(_map);
				TemplateSlideUuid_.UpdateMap(_map);
				PresentationForegroundEnabled_.UpdateMap(_map);
				MaskUuid_.UpdateMap(_map);
				AnnouncementsEnabled_.UpdateMap(_map);
				PropsLayerEnabled_.UpdateMap(_map);
				MessagesLayerEnabled_.UpdateMap(_map);
			}

			public void UpdateMapOnInternalMapUpdate(LoroMap value)
			{
				_map = value;
				ProScreenUuid_.UpdateMapOnInternalMapUpdate(_map);
				PropsEnabled_.UpdateMapOnInternalMapUpdate(_map);
				LiveVideoEnabled_.UpdateMapOnInternalMapUpdate(_map);
				PresentationBackgroundEnabled_.UpdateMapOnInternalMapUpdate(_map);
				TemplateDocumentFilePath_.UpdateMapOnInternalMapUpdate(_map);
				TemplateSlideUuid_.UpdateMapOnInternalMapUpdate(_map);
				PresentationForegroundEnabled_.UpdateMapOnInternalMapUpdate(_map);
				MaskUuid_.UpdateMapOnInternalMapUpdate(_map);
				AnnouncementsEnabled_.UpdateMapOnInternalMapUpdate(_map);
				PropsLayerEnabled_.UpdateMapOnInternalMapUpdate(_map);
				MessagesLayerEnabled_.UpdateMapOnInternalMapUpdate(_map);
			}

			public ProScreenLook()
				: this(new LoroMap())
			{
			}

			public ProScreenLook(LoroMap values)
			{
				_map = values;
				ProScreenUuid_ = new GuidObservableProperty("pro_screen_uuid__1", LoroMap);
				PropsEnabled_ = new BoolObservableProperty("props_enabled__2", LoroMap);
				LiveVideoEnabled_ = new BoolObservableProperty("live_video_enabled__3", LoroMap);
				PresentationBackgroundEnabled_ = new BoolObservableProperty("presentation_background_enabled__4", LoroMap);
				TemplateDocumentFilePath_ = new OptionalAtomicObservableProperty<Url>("template_document_file_path__5", LoroMap, UrlExtension.Deserialize, UrlExtension.Serialize);
				TemplateSlideUuid_ = new OptionalGuidObservableProperty("template_slide_uuid__6", LoroMap);
				PresentationForegroundEnabled_ = new BoolObservableProperty("presentation_foreground_enabled__7", LoroMap);
				MaskUuid_ = new OptionalGuidObservableProperty("mask_uuid__8", LoroMap);
				AnnouncementsEnabled_ = new BoolObservableProperty("announcements_enabled__9", LoroMap);
				PropsLayerEnabled_ = new BoolObservableProperty("props_layer_enabled__10", LoroMap);
				MessagesLayerEnabled_ = new BoolObservableProperty("messages_layer_enabled__11", LoroMap);
				_linkedDisposables = new CompositeDisposable();
				WhenChangeHappens = Observable.Merge<Unit>(ProScreenUuid_.WhenChangeHappens, PropsEnabled_.WhenChangeHappens, LiveVideoEnabled_.WhenChangeHappens, PresentationBackgroundEnabled_.WhenChangeHappens, TemplateDocumentFilePath_.WhenChangeHappens, TemplateSlideUuid_.WhenChangeHappens, PresentationForegroundEnabled_.WhenChangeHappens, MaskUuid_.WhenChangeHappens, AnnouncementsEnabled_.WhenChangeHappens, PropsLayerEnabled_.WhenChangeHappens, MessagesLayerEnabled_.WhenChangeHappens);
			}

			public void Dispose()
			{
				ProScreenUuid_.Dispose();
				PropsEnabled_.Dispose();
				LiveVideoEnabled_.Dispose();
				PresentationBackgroundEnabled_.Dispose();
				TemplateDocumentFilePath_.Dispose();
				TemplateSlideUuid_.Dispose();
				PresentationForegroundEnabled_.Dispose();
				MaskUuid_.Dispose();
				AnnouncementsEnabled_.Dispose();
				PropsLayerEnabled_.Dispose();
				MessagesLayerEnabled_.Dispose();
				LoroMap.Dispose();
				_linkedDisposables.Dispose();
			}

			public void OnDiff(ReadOnlySpan<PathItem> path, Diff diff)
			{
				ProScreenUuid_.OnDiff(path, diff);
				PropsEnabled_.OnDiff(path, diff);
				LiveVideoEnabled_.OnDiff(path, diff);
				PresentationBackgroundEnabled_.OnDiff(path, diff);
				TemplateDocumentFilePath_.OnDiff(path, diff);
				TemplateSlideUuid_.OnDiff(path, diff);
				PresentationForegroundEnabled_.OnDiff(path, diff);
				MaskUuid_.OnDiff(path, diff);
				AnnouncementsEnabled_.OnDiff(path, diff);
				PropsLayerEnabled_.OnDiff(path, diff);
				MessagesLayerEnabled_.OnDiff(path, diff);
			}

			public void RegisterLinkedDisposable(IDisposable disposable)
			{
				_linkedDisposables.Add(disposable);
			}
		}
	}

	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<string?> Name { get; }

	IComplexCollection<Types.IProScreenLook> ScreenLooks { get; }

	IObservableProperty<Guid?> OriginalLookUuid { get; }

	IObservableProperty<double> TransitionDuration { get; }
}
