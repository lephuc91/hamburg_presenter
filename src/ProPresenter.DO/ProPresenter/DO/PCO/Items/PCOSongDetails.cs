using System.IO;
using System.Linq;
using Pro.Common.FileSystem;
using Pro.DO.Storage;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.PCO.RemoteDataModel.Services.Song;

namespace ProPresenter.DO.PCO.Items;

public class PCOSongDetails : PCOAttachableDetailsBase, IPCOContent
{
	private string _filename = string.Empty;

	public string? Admin { get; private set; }

	public string? Author { get; private set; }

	public uint CCLI { get; private set; }

	public string? Copyright { get; private set; }

	public bool Hidden { get; private set; }

	public string? Title { get; private set; }

	public RelativePath? LocalDownloadPath { get; set; }

	public RelativePath? LocalWorkingPath { get; set; }

	public string Filename
	{
		get
		{
			return _filename;
		}
		private set
		{
			_filename = value.SanitizeFilename();
		}
	}

	public string? AttachmentID { get; private set; }

	public string RemoteDownloadURL { get; private set; } = string.Empty;

	public PCOSongDetails(SongData songDetails, string pcoItemID)
		: base(songDetails.Id, songDetails.Attributes?.UpdatedAt, songDetails.Attributes?.CreatedAt, songDetails.GetLinkToSelf(), pcoItemID)
	{
		if (songDetails.Attributes != null)
		{
			Admin = songDetails.Attributes.Admin;
			Author = songDetails.Attributes.Author;
			CCLI = songDetails.Attributes.CcliNumber;
			Copyright = songDetails.Attributes.Copyright;
			Hidden = songDetails.Attributes.Hidden;
			Title = songDetails.Attributes.Title;
		}
	}

	internal PCOSongDetails(string id, Pro.SerializationInterop.RVProtoData.Presentation.Types.CCLI protoCCLI)
		: base(id, null, null, null, null)
	{
		if (protoCCLI != null)
		{
			Admin = protoCCLI.ArtistCredits;
			Author = protoCCLI.Author;
			Copyright = protoCCLI.CopyrightYear.ToString();
			Hidden = !protoCCLI.Display;
			CCLI = protoCCLI.SongNumber;
			Title = protoCCLI.SongTitle;
		}
	}

	protected override void PostLoadAttachments()
	{
		base.PostLoadAttachments();
		PCOAttachmentDetails pCOAttachmentDetails = base.Attachments.OrderByDescending((PCOAttachmentDetails a) => a.UpdatedAt).FirstOrDefault();
		if (pCOAttachmentDetails != null)
		{
			Filename = pCOAttachmentDetails.Filename;
			RemoteDownloadURL = pCOAttachmentDetails.RemoteDownloadURL;
			AttachmentID = pCOAttachmentDetails.ID;
		}
	}

	protected override void PostReplaceAttachment(PCOAttachmentDetails newAttachment)
	{
		base.PostReplaceAttachment(newAttachment);
		string? title = Title;
		if (title != null && title.Equals(Path.GetFileNameWithoutExtension(newAttachment.Filename)))
		{
			Filename = newAttachment.Filename;
			RemoteDownloadURL = newAttachment.RemoteDownloadURL;
			AttachmentID = newAttachment.ID;
		}
	}

	protected internal Pro.SerializationInterop.RVProtoData.Presentation.Types.CCLI SerializeCCLI()
	{
		uint result;
		return new Pro.SerializationInterop.RVProtoData.Presentation.Types.CCLI
		{
			ArtistCredits = (Admin ?? string.Empty),
			Author = (Author ?? string.Empty),
			CopyrightYear = (uint.TryParse(Copyright, out result) ? result : 0u),
			Display = !Hidden,
			SongNumber = CCLI,
			SongTitle = (Title ?? string.Empty)
		};
	}
}
