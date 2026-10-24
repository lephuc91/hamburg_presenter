using System;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using ProPresenter.DO.DependencyInjection;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public static class FillBinderHelper
{
	public static ObjectBinder<ClosedBezierPath, IGraphics.Types.IFill> CreateFillBinder(this ClosedBezierPath closedBezierPath, IUiScheduler uiScheduler, IProPresenterDOFactoryProvider factoryProvider, IGraphics.Types.IFill right)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		ObjectBinder<ClosedBezierPath, IGraphics.Types.IFill> objectBinder = new ObjectBinder<ClosedBezierPath, IGraphics.Types.IFill>(closedBezierPath, right);
		objectBinder.Bind((ClosedBezierPath l) => l.WhenPropertyChanges("Fill"), (IGraphics.Types.IFill r) => r.FillType.WhenValueChanges, delegate(ClosedBezierPath l, IGraphics.Types.IFill r)
		{
			ObjectBinder<IFill, IGraphics.Types.IFill> objectBinder2 = CreateEnableFillBinder(l, r);
			objectBinder2.InitializeRightFromLeft();
			r.RegisterLinkedDisposable(objectBinder2);
			CreateAndSetFillType(entityFactory, l.Fill, r);
			CreateAndAssignFillTypeBinder(uiScheduler, entityFactory, l.Fill, r, initializeFromLeft: true);
		}, delegate(IGraphics.Types.IFill r, ClosedBezierPath l)
		{
			IFill fill = CreateFill(r.FillType.Value, factoryProvider, l.ContainerId);
			if (fill != null)
			{
				l.Fill = fill;
				CreateAndAssignFillTypeBinder(uiScheduler, entityFactory, fill, r, initializeFromLeft: false);
				ObjectBinder<IFill, IGraphics.Types.IFill> objectBinder3 = CreateEnableFillBinder(l, r);
				objectBinder3.InitializeLeftFromRight();
				r.RegisterLinkedDisposable(objectBinder3);
			}
		});
		return objectBinder;
	}

	private static ObjectBinder<IFill, IGraphics.Types.IFill> CreateEnableFillBinder(ClosedBezierPath closedBezierPath, IGraphics.Types.IFill right)
	{
		ObjectBinder<IFill, IGraphics.Types.IFill> objectBinder = new ObjectBinder<IFill, IGraphics.Types.IFill>(closedBezierPath.Fill, right);
		objectBinder.Bind((IFill l) => l.WhenPropertyChanges("IsEnabled"), (IGraphics.Types.IFill r) => r.Enable.WhenValueChanges, delegate(IFill l, IGraphics.Types.IFill r)
		{
			r.Enable.Set(l.IsEnabled);
		}, delegate(IGraphics.Types.IFill r, IFill l)
		{
			l.IsEnabled = r.Enable.Value;
		});
		return objectBinder;
	}

	private static void CreateAndAssignFillTypeBinder(IUiScheduler uiScheduler, IEntityFactory entityFactory, IFill left, IGraphics.Types.IFill right, bool initializeFromLeft)
	{
		if (!(left is SolidColorFill left2))
		{
			if (!(left is GradientColorFill left3))
			{
				if (!(left is MediaFill left4))
				{
					if (!(left is LiveVideoFill left5))
					{
						if (!(left is HTMLFill left6))
						{
							if (!(left is BackgroundEffectBlurFill left7))
							{
								if (left is BackgroundEffectInvertFill)
								{
									IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect backgroundEffect = right.FillType.Value as IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect;
									if (backgroundEffect == null)
									{
										backgroundEffect = entityFactory.Create<IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect>();
										IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundInvert value = entityFactory.Create<IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundInvert>();
										backgroundEffect.Value.EffectType.Set(value);
										right.FillType.Set(backgroundEffect);
									}
								}
							}
							else
							{
								IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect backgroundEffect2 = right.FillType.Value as IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect;
								if (backgroundEffect2 == null)
								{
									backgroundEffect2 = entityFactory.Create<IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect>();
									right.FillType.Set(backgroundEffect2);
								}
								ObjectBinder<BackgroundEffectBlurFill, IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect> objectBinder = BackgroundEffectBlurFill.CreateBinder(entityFactory, left7, backgroundEffect2);
								right.RegisterLinkedDisposable(objectBinder);
								initialize<BackgroundEffectBlurFill, IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect>(objectBinder, initializeFromLeft);
							}
						}
						else
						{
							IGraphics.Types.IFill.Types.IFillType.IMedia media = right.FillType.Value as IGraphics.Types.IFill.Types.IFillType.IMedia;
							if (media == null)
							{
								media = entityFactory.Create<IGraphics.Types.IFill.Types.IFillType.IMedia>();
								right.FillType.Set(media);
							}
							ObjectBinder<HTMLFill, IGraphics.Types.IFill.Types.IFillType.IMedia> objectBinder2 = HTMLFill.CreateBinder(uiScheduler, entityFactory, left6, media);
							right.RegisterLinkedDisposable(objectBinder2);
							initialize<HTMLFill, IGraphics.Types.IFill.Types.IFillType.IMedia>(objectBinder2, initializeFromLeft);
						}
					}
					else
					{
						IGraphics.Types.IFill.Types.IFillType.IMedia media2 = right.FillType.Value as IGraphics.Types.IFill.Types.IFillType.IMedia;
						if (media2 == null)
						{
							media2 = entityFactory.Create<IGraphics.Types.IFill.Types.IFillType.IMedia>();
							right.FillType.Set(media2);
						}
						ObjectBinder<LiveVideoFill, IGraphics.Types.IFill.Types.IFillType.IMedia> objectBinder3 = LiveVideoFill.CreateBinder(uiScheduler, entityFactory, left5, media2);
						right.RegisterLinkedDisposable(objectBinder3);
						initialize<LiveVideoFill, IGraphics.Types.IFill.Types.IFillType.IMedia>(objectBinder3, initializeFromLeft);
					}
				}
				else
				{
					IGraphics.Types.IFill.Types.IFillType.IMedia media3 = right.FillType.Value as IGraphics.Types.IFill.Types.IFillType.IMedia;
					if (media3 == null)
					{
						media3 = entityFactory.Create<IGraphics.Types.IFill.Types.IFillType.IMedia>();
						right.FillType.Set(media3);
					}
					ObjectBinder<MediaFill, IGraphics.Types.IFill.Types.IFillType.IMedia> objectBinder4 = MediaFill.CreateBinder(uiScheduler, entityFactory, left4, media3);
					right.RegisterLinkedDisposable(objectBinder4);
					initialize<MediaFill, IGraphics.Types.IFill.Types.IFillType.IMedia>(objectBinder4, initializeFromLeft);
				}
			}
			else
			{
				IGraphics.Types.IFill.Types.IFillType.IGradient gradient = right.FillType.Value as IGraphics.Types.IFill.Types.IFillType.IGradient;
				if (gradient == null)
				{
					gradient = entityFactory.Create<IGraphics.Types.IFill.Types.IFillType.IGradient>();
					right.FillType.Set(gradient);
				}
				ObjectBinder<GradientColorFill, IGraphics.Types.IFill.Types.IFillType.IGradient> objectBinder5 = GradientColorFill.CreateBinder(uiScheduler, entityFactory, left3, gradient);
				right.RegisterLinkedDisposable(objectBinder5);
				initialize<GradientColorFill, IGraphics.Types.IFill.Types.IFillType.IGradient>(objectBinder5, initializeFromLeft);
			}
		}
		else
		{
			IGraphics.Types.IFill.Types.IFillType.IColor color = right.FillType.Value as IGraphics.Types.IFill.Types.IFillType.IColor;
			if (color == null)
			{
				color = entityFactory.Create<IGraphics.Types.IFill.Types.IFillType.IColor>();
				right.FillType.Set(color);
			}
			ObjectBinder<SolidColorFill, IGraphics.Types.IFill.Types.IFillType.IColor> objectBinder6 = SolidColorFill.CreateBinder(uiScheduler, left2, color);
			right.RegisterLinkedDisposable(objectBinder6);
			initialize<SolidColorFill, IGraphics.Types.IFill.Types.IFillType.IColor>(objectBinder6, initializeFromLeft);
		}
		static void initialize<L, R>(ObjectBinder<L, R> child, bool initializeFromLeft) where L : class where R : class
		{
			if (initializeFromLeft)
			{
				child.InitializeRightFromLeft();
			}
			else
			{
				child.InitializeLeftFromRight();
			}
		}
	}

	private static void CreateAndSetFillType(IEntityFactory entityFactory, IFill left, IGraphics.Types.IFill right)
	{
		IGraphics.Types.IFill.Types.IFillType fillType = null;
		switch (left.Type)
		{
		case FillType.Solid:
			fillType = entityFactory.Create<IGraphics.Types.IFill.Types.IFillType.IColor>();
			break;
		case FillType.Gradient:
			fillType = entityFactory.Create<IGraphics.Types.IFill.Types.IFillType.IGradient>();
			break;
		case FillType.Media:
			fillType = entityFactory.Create<IGraphics.Types.IFill.Types.IFillType.IMedia>();
			break;
		case FillType.Live:
			fillType = entityFactory.Create<IGraphics.Types.IFill.Types.IFillType.IMedia>();
			break;
		case FillType.HTML:
			fillType = entityFactory.Create<IGraphics.Types.IFill.Types.IFillType.IMedia>();
			break;
		case FillType.BackgroundEffectBlur:
		{
			IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect backgroundEffect2 = entityFactory.Create<IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect>();
			IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundBlur value2 = entityFactory.Create<IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundBlur>();
			backgroundEffect2.Value.EffectType.Set(value2);
			fillType = backgroundEffect2;
			break;
		}
		case FillType.BackgroundEffectInvert:
		{
			IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect backgroundEffect = entityFactory.Create<IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect>();
			IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundInvert value = entityFactory.Create<IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundInvert>();
			backgroundEffect.Value.EffectType.Set(value);
			fillType = backgroundEffect;
			break;
		}
		default:
			throw new NotSupportedException($"Fill type {left.Type} not supported.");
		case FillType.SlidePreview:
		case FillType.OutputScreen:
		case FillType.PDF:
		case FillType.Bitmap:
			break;
		}
		if (fillType != null)
		{
			right.FillType.Set(fillType);
		}
	}

	private static IFill? CreateFill(IGraphics.Types.IFill.Types.IFillType fillType, IProPresenterDOFactoryProvider factoryProvider, string containerId)
	{
		if (!(fillType is IGraphics.Types.IFill.Types.IFillType.IColor))
		{
			if (!(fillType is IGraphics.Types.IFill.Types.IFillType.IGradient))
			{
				if (!(fillType is IGraphics.Types.IFill.Types.IFillType.IMedia media))
				{
					if (fillType is IGraphics.Types.IFill.Types.IFillType.IBackgroundEffect backgroundEffect)
					{
						if (backgroundEffect.Value.EffectType.Value is IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundBlur)
						{
							return new BackgroundEffectBlurFill();
						}
						if (backgroundEffect.Value.EffectType.Value is IGraphics.Types.IBackgroundEffect.Types.IEffectType.IBackgroundInvert)
						{
							return new BackgroundEffectInvertFill();
						}
						return null;
					}
					return null;
				}
				if (media.Value.TypeProperties.Value is IMedia.Types.ITypeProperties.IWebContent)
				{
					return new HTMLFill();
				}
				if (media.Value.TypeProperties.Value is IMedia.Types.ITypeProperties.ILiveVideo)
				{
					return new LiveVideoFill(factoryProvider.MediaFactory);
				}
				if (media.Value.TypeProperties.Value is IMedia.Types.ITypeProperties.IImage || media.Value.TypeProperties.Value is IMedia.Types.ITypeProperties.IVideo)
				{
					return new MediaFill(factoryProvider.MediaFactory, containerId);
				}
				return null;
			}
			return new GradientColorFill();
		}
		return new SolidColorFill();
	}
}
