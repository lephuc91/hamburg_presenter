using System;
using Pro.Entity.Collections;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface ICue : IEntity, IDisposable
{
	public class Types
	{
		public enum CompletionActionType
		{
			First,
			Last,
			AfterAction,
			AfterTime
		}

		public enum CompletionTargetType
		{
			None,
			Next,
			Random,
			Cue,
			First
		}
	}

	IObservableProperty<Guid> Uuid { get; }

	IObservableProperty<string?> Name { get; }

	IObservableProperty<Types.CompletionTargetType> CompletionTargetType { get; }

	IObservableProperty<Guid?> CompletionTargetUuid { get; }

	IObservableProperty<Types.CompletionActionType> CompletionActionType { get; }

	IObservableProperty<Guid?> CompletionActionUuid { get; }

	IComplexObservableProperty<IHotKey> HotKey { get; }

	IComplexCollection<IAction> Actions { get; }

	IObservableProperty<bool> IsEnabled { get; }

	IObservableProperty<double> CompletionTime { get; }
}
