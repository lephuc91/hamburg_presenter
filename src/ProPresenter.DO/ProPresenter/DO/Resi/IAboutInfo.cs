using System;

namespace ProPresenter.DO.Resi;

public interface IAboutInfo
{
	string CustomerName { get; }

	string EncoderName { get; }

	Version? EncoderVersion { get; }

	string ManageUrl { get; }
}
