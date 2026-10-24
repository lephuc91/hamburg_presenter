using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Entity;
using Pro.Entity.Extensions;
using ProPresenter.DO.Media.Properties;

namespace ProPresenter.DO.Media;

public static class MediaBinderHelper
{
	public static IMedia.Types.IAudioProperties HandleAudioPropertiesModelChange(this AudioProperties audio, IUiScheduler scheduler, IEntityFactory entityFactory)
	{
		IMedia.Types.IAudioProperties audioProperties = entityFactory.Create<IMedia.Types.IAudioProperties>();
		ObjectBinder<AudioProperties, IMedia.Types.IAudioProperties> objectBinder = AudioProperties.CreateBinder(scheduler, entityFactory, audio, audioProperties);
		objectBinder.InitializeRightFromLeft();
		audioProperties.RegisterLinkedDisposable(objectBinder);
		return audioProperties;
	}

	public static void HandleAudioPropertiesCrdtChange(this AudioProperties audio, IMedia.Types.IAudioProperties audioEntity, IUiScheduler scheduler, IEntityFactory entityFactory)
	{
		ObjectBinder<AudioProperties, IMedia.Types.IAudioProperties> objectBinder = AudioProperties.CreateBinder(scheduler, entityFactory, audio, audioEntity);
		objectBinder.InitializeLeftFromRight();
		audioEntity.RegisterLinkedDisposable(objectBinder);
	}

	public static IMedia.Types.ITransportProperties HandleTransportPropertiesModelChange(this TransportProperties transport, IUiScheduler scheduler, IEntityFactory entityFactory)
	{
		IMedia.Types.ITransportProperties transportProperties = entityFactory.Create<IMedia.Types.ITransportProperties>();
		ObjectBinder<TransportProperties, IMedia.Types.ITransportProperties> objectBinder = TransportProperties.CreateBinder(transport, transportProperties);
		objectBinder.InitializeRightFromLeft();
		transportProperties.RegisterLinkedDisposable(objectBinder);
		return transportProperties;
	}

	public static void HandleTransportPropertiesCrdtChange(this TransportProperties transport, IMedia.Types.ITransportProperties transportEntity, IUiScheduler scheduelr, IEntityFactory entityFactory)
	{
		ObjectBinder<TransportProperties, IMedia.Types.ITransportProperties> objectBinder = TransportProperties.CreateBinder(transport, transportEntity);
		objectBinder.InitializeLeftFromRight();
		transportEntity.RegisterLinkedDisposable(objectBinder);
	}

	public static IFileProperties HandleFilePropertiesModelChange(this FileProperties file, IEntityFactory entityFactory)
	{
		IFileProperties fileProperties = entityFactory.Create<IFileProperties>();
		ObjectBinder<FileProperties, IFileProperties> objectBinder = FileProperties.CreateBinder(file, fileProperties);
		objectBinder.InitializeRightFromLeft();
		fileProperties.RegisterLinkedDisposable(objectBinder);
		return fileProperties;
	}

	public static void HandleFilePropertiesCrdtChange(this FileProperties file, IFileProperties fileEntity)
	{
		ObjectBinder<FileProperties, IFileProperties> objectBinder = FileProperties.CreateBinder(file, fileEntity);
		objectBinder.InitializeLeftFromRight();
		fileEntity.RegisterLinkedDisposable(objectBinder);
	}

	public static IMedia.Types.IDrawingProperties HandleDrawingPropertiesModelChange(this DrawingProperties drawing, IUiScheduler scheduler, IEntityFactory entityFactory)
	{
		IMedia.Types.IDrawingProperties drawingProperties = entityFactory.Create<IMedia.Types.IDrawingProperties>();
		ObjectBinder<DrawingProperties, IMedia.Types.IDrawingProperties> objectBinder = drawing.CreateBinder(scheduler, entityFactory, drawingProperties);
		objectBinder.InitializeRightFromLeft();
		drawingProperties.RegisterLinkedDisposable(objectBinder);
		return drawingProperties;
	}

	public static void HandleDrawingPropertiesCrdtChange(this DrawingProperties drawing, IMedia.Types.IDrawingProperties drawEntity, IUiScheduler scheduler, IEntityFactory entityFactory)
	{
		ObjectBinder<DrawingProperties, IMedia.Types.IDrawingProperties> objectBinder = drawing.CreateBinder(scheduler, entityFactory, drawEntity);
		objectBinder.InitializeLeftFromRight();
		drawEntity.RegisterLinkedDisposable(objectBinder);
	}
}
