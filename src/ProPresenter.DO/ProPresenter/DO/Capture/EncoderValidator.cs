using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Delay;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Capture;

public class EncoderValidator : ObservableObject, IEncoderValidator, INotifyPropertyChanged
{
	private const int MIN_VALIDATION_TIME_SECONDS = 2;

	private readonly IProCoreInstance _procore;

	private readonly IDelayFactory _delayFactory;

	private readonly ConcurrentDictionary<int, TaskCompletionSource<bool>> _validationRequests = new ConcurrentDictionary<int, TaskCompletionSource<bool>>();

	[ObservableProperty]
	private bool _isValidationTakingTime;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsValidationTakingTime
	{
		get
		{
			return _isValidationTakingTime;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isValidationTakingTime, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsValidationTakingTime);
				_isValidationTakingTime = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsValidationTakingTime);
			}
		}
	}

	public EncoderValidator(IProCoreInstance procore, IDelayFactory delayFactory)
	{
		_procore = procore;
		_delayFactory = delayFactory;
	}

	public void OnValidationDone(int id, bool isValid)
	{
		if (_validationRequests.TryGetValue(id, out TaskCompletionSource<bool> value))
		{
			value.SetResult(isValid);
			_validationRequests.TryRemove(id, out TaskCompletionSource<bool> _);
		}
	}

	public async Task<bool> ValidateEncoderAsync(Encoder encoder, CancellationToken cancellationToken)
	{
		IsValidationTakingTime = false;
		Task delayTask = _delayFactory.Delay(TimeSpan.FromSeconds(2L), cancellationToken);
		Task<bool> validateTask = ValidateEncoder(encoder, cancellationToken);
		bool result;
		if (await Task.WhenAny(delayTask, validateTask) == delayTask)
		{
			IsValidationTakingTime = true;
			result = await validateTask;
		}
		else
		{
			result = validateTask.Result;
		}
		IsValidationTakingTime = false;
		return result;
	}

	private Task<bool> ValidateEncoder(Encoder encoder, CancellationToken cancellationToken)
	{
		TaskCompletionSource<bool> validationCompletionSource = new TaskCompletionSource<bool>();
		cancellationToken.Register(delegate
		{
			validationCompletionSource.TrySetCanceled();
		});
		SendData data = new SendData
		{
			ValidateEncoderRequest = new ValidateEncoderRequest
			{
				Encoder = encoder.Serialize()
			}
		};
		if (_procore.SendData(data, out var messageId) == ProResult.Success)
		{
			_validationRequests[messageId] = validationCompletionSource;
			return validationCompletionSource.Task;
		}
		return Task.FromResult(result: false);
	}
}
