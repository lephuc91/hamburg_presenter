using System;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using ProPresenter.DO.PanelSourcing;

namespace ProPresenter.UI.Thumbnails;

internal delegate void RenderImageDelegate(IThumbnailSource thumbnailSource, Vector2<int> size, Action<IThumbnailSource, IBitmapHandle?> completeCallback);
