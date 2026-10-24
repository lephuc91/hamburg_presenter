using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace ProPresenter.DO.Capture;

public interface IEncoderValidator : INotifyPropertyChanged
{
	bool IsValidationTakingTime { get; }

	Task<bool> ValidateEncoderAsync(Encoder encoder, CancellationToken cancellationToken);

	void OnValidationDone(int id, bool isValid);
}
