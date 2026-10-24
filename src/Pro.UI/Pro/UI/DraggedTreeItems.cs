using Pro.Common.Components;

namespace Pro.UI;

public record DraggedTreeItems<T>(IDragDropTreeCollection<T>? SourceTreeCollection, T[] Items) where T : IDragDropTreeCollection<T>, IIdentifiable;
