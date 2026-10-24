using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Librarian;

public sealed record PresentationAndLoadData(IPresentation Presentation, IPresentationLoadData? LoadData);
