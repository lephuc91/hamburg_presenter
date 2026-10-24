using Pro.Common.Components;

namespace Pro.UI;

public record DraggedItems<T>(IDragDropCollection<T>? SourceCollection, T[] Items);
