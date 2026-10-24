using System;
using Pro.Entity.Properties;

namespace Pro.Entity;

public interface IMusicKeyScale : IEntity, IDisposable
{
	public class Types
	{
		public enum MusicKey
		{
			AFlat,
			A,
			ASharp,
			BFlat,
			B,
			BSharp,
			CFlat,
			C,
			CSharp,
			DFlat,
			D,
			DSharp,
			EFlat,
			E,
			ESharp,
			FFlat,
			F,
			FSharp,
			GFlat,
			G,
			GSharp
		}

		public enum MusicScale
		{
			Major,
			Minor
		}
	}

	IObservableProperty<Types.MusicKey> MusicKey { get; }

	IObservableProperty<Types.MusicScale> MusicScale { get; }
}
