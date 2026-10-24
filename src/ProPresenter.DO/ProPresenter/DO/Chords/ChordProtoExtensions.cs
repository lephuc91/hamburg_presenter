using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Chords;

public static class ChordProtoExtensions
{
	public static MusicKeyScale ToProtoMusicKeyScale(this Key key)
	{
		return new MusicKeyScale
		{
			MusicKey = key.Note.ToProtoMusicNote(),
			MusicScale = key.Scale.ToProtoMusicScale()
		};
	}

	public static MusicKeyScale.Types.MusicKey ToProtoMusicNote(this Note note)
	{
		return note switch
		{
			Note.Ces => MusicKeyScale.Types.MusicKey.CFlat, 
			Note.Cis => MusicKeyScale.Types.MusicKey.CSharp, 
			Note.Des => MusicKeyScale.Types.MusicKey.DFlat, 
			Note.D => MusicKeyScale.Types.MusicKey.D, 
			Note.Dis => MusicKeyScale.Types.MusicKey.DSharp, 
			Note.Ees => MusicKeyScale.Types.MusicKey.EFlat, 
			Note.E => MusicKeyScale.Types.MusicKey.E, 
			Note.Eis => MusicKeyScale.Types.MusicKey.ESharp, 
			Note.Fes => MusicKeyScale.Types.MusicKey.FFlat, 
			Note.F => MusicKeyScale.Types.MusicKey.F, 
			Note.Fis => MusicKeyScale.Types.MusicKey.FSharp, 
			Note.Ges => MusicKeyScale.Types.MusicKey.GFlat, 
			Note.G => MusicKeyScale.Types.MusicKey.G, 
			Note.Gis => MusicKeyScale.Types.MusicKey.GSharp, 
			Note.Aes => MusicKeyScale.Types.MusicKey.AFlat, 
			Note.A => MusicKeyScale.Types.MusicKey.A, 
			Note.Ais => MusicKeyScale.Types.MusicKey.ASharp, 
			Note.Bes => MusicKeyScale.Types.MusicKey.BFlat, 
			Note.B => MusicKeyScale.Types.MusicKey.B, 
			Note.Bis => MusicKeyScale.Types.MusicKey.BSharp, 
			_ => MusicKeyScale.Types.MusicKey.C, 
		};
	}

	public static IMusicKeyScale.Types.MusicKey ToEntityMusicNote(this Note note)
	{
		return note switch
		{
			Note.Ces => IMusicKeyScale.Types.MusicKey.CFlat, 
			Note.Cis => IMusicKeyScale.Types.MusicKey.CSharp, 
			Note.Des => IMusicKeyScale.Types.MusicKey.DFlat, 
			Note.D => IMusicKeyScale.Types.MusicKey.D, 
			Note.Dis => IMusicKeyScale.Types.MusicKey.DSharp, 
			Note.Ees => IMusicKeyScale.Types.MusicKey.EFlat, 
			Note.E => IMusicKeyScale.Types.MusicKey.E, 
			Note.Eis => IMusicKeyScale.Types.MusicKey.ESharp, 
			Note.Fes => IMusicKeyScale.Types.MusicKey.FFlat, 
			Note.F => IMusicKeyScale.Types.MusicKey.F, 
			Note.Fis => IMusicKeyScale.Types.MusicKey.FSharp, 
			Note.Ges => IMusicKeyScale.Types.MusicKey.GFlat, 
			Note.G => IMusicKeyScale.Types.MusicKey.G, 
			Note.Gis => IMusicKeyScale.Types.MusicKey.GSharp, 
			Note.Aes => IMusicKeyScale.Types.MusicKey.AFlat, 
			Note.A => IMusicKeyScale.Types.MusicKey.A, 
			Note.Ais => IMusicKeyScale.Types.MusicKey.ASharp, 
			Note.Bes => IMusicKeyScale.Types.MusicKey.BFlat, 
			Note.B => IMusicKeyScale.Types.MusicKey.B, 
			Note.Bis => IMusicKeyScale.Types.MusicKey.BSharp, 
			_ => IMusicKeyScale.Types.MusicKey.C, 
		};
	}

	public static MusicKeyScale.Types.MusicScale ToProtoMusicScale(this Scale scale)
	{
		if (scale == Scale.Minor)
		{
			return MusicKeyScale.Types.MusicScale.Minor;
		}
		return MusicKeyScale.Types.MusicScale.Major;
	}

	public static IMusicKeyScale.Types.MusicScale ToEntityMusicScale(this Scale scale)
	{
		if (scale == Scale.Minor)
		{
			return IMusicKeyScale.Types.MusicScale.Minor;
		}
		return IMusicKeyScale.Types.MusicScale.Major;
	}

	public static Key ToKey(this MusicKeyScale protoMusicKey)
	{
		return new Key(protoMusicKey.MusicKey.ToNote(), protoMusicKey.MusicScale.ToScale());
	}

	public static Note ToNote(this MusicKeyScale.Types.MusicKey protoMusicNote)
	{
		return protoMusicNote switch
		{
			MusicKeyScale.Types.MusicKey.AFlat => Note.Aes, 
			MusicKeyScale.Types.MusicKey.A => Note.A, 
			MusicKeyScale.Types.MusicKey.ASharp => Note.Ais, 
			MusicKeyScale.Types.MusicKey.BFlat => Note.Bes, 
			MusicKeyScale.Types.MusicKey.B => Note.B, 
			MusicKeyScale.Types.MusicKey.BSharp => Note.Bis, 
			MusicKeyScale.Types.MusicKey.CFlat => Note.Ces, 
			MusicKeyScale.Types.MusicKey.CSharp => Note.Cis, 
			MusicKeyScale.Types.MusicKey.DFlat => Note.Des, 
			MusicKeyScale.Types.MusicKey.D => Note.D, 
			MusicKeyScale.Types.MusicKey.DSharp => Note.Dis, 
			MusicKeyScale.Types.MusicKey.EFlat => Note.Ees, 
			MusicKeyScale.Types.MusicKey.E => Note.E, 
			MusicKeyScale.Types.MusicKey.ESharp => Note.Eis, 
			MusicKeyScale.Types.MusicKey.FFlat => Note.Fes, 
			MusicKeyScale.Types.MusicKey.F => Note.F, 
			MusicKeyScale.Types.MusicKey.FSharp => Note.Fis, 
			MusicKeyScale.Types.MusicKey.GFlat => Note.Ges, 
			MusicKeyScale.Types.MusicKey.G => Note.G, 
			MusicKeyScale.Types.MusicKey.GSharp => Note.Gis, 
			_ => Note.C, 
		};
	}

	public static Note ToNote(this IMusicKeyScale.Types.MusicKey entityMusicNote)
	{
		return entityMusicNote switch
		{
			IMusicKeyScale.Types.MusicKey.AFlat => Note.Aes, 
			IMusicKeyScale.Types.MusicKey.A => Note.A, 
			IMusicKeyScale.Types.MusicKey.ASharp => Note.Ais, 
			IMusicKeyScale.Types.MusicKey.BFlat => Note.Bes, 
			IMusicKeyScale.Types.MusicKey.B => Note.B, 
			IMusicKeyScale.Types.MusicKey.BSharp => Note.Bis, 
			IMusicKeyScale.Types.MusicKey.CFlat => Note.Ces, 
			IMusicKeyScale.Types.MusicKey.CSharp => Note.Cis, 
			IMusicKeyScale.Types.MusicKey.DFlat => Note.Des, 
			IMusicKeyScale.Types.MusicKey.D => Note.D, 
			IMusicKeyScale.Types.MusicKey.DSharp => Note.Dis, 
			IMusicKeyScale.Types.MusicKey.EFlat => Note.Ees, 
			IMusicKeyScale.Types.MusicKey.E => Note.E, 
			IMusicKeyScale.Types.MusicKey.ESharp => Note.Eis, 
			IMusicKeyScale.Types.MusicKey.FFlat => Note.Fes, 
			IMusicKeyScale.Types.MusicKey.F => Note.F, 
			IMusicKeyScale.Types.MusicKey.FSharp => Note.Fis, 
			IMusicKeyScale.Types.MusicKey.GFlat => Note.Ges, 
			IMusicKeyScale.Types.MusicKey.G => Note.G, 
			IMusicKeyScale.Types.MusicKey.GSharp => Note.Gis, 
			_ => Note.C, 
		};
	}

	public static Scale ToScale(this IMusicKeyScale.Types.MusicScale entityMusicScale)
	{
		if (entityMusicScale == IMusicKeyScale.Types.MusicScale.Minor)
		{
			return Scale.Minor;
		}
		return Scale.Major;
	}

	public static Scale ToScale(this MusicKeyScale.Types.MusicScale entityMusicScale)
	{
		if (entityMusicScale == MusicKeyScale.Types.MusicScale.Minor)
		{
			return Scale.Minor;
		}
		return Scale.Major;
	}
}
