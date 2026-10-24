using ProPresenter.DO;
using ProPresenter.DO.Arrangements;

namespace ProPresenter.Controller;

public delegate void SlideTriggeredAction(ArrangedCue slide, int buildIndex, OutputDestination destination);
