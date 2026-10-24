using System.Windows.Media;
using ProPresenter.DO.PanelSourcing;

namespace ProPresenter.UI.Thumbnails;

internal delegate Color GetColorDelegate(IThumbnailSource thumbnailSource, Color? settingsColor);
