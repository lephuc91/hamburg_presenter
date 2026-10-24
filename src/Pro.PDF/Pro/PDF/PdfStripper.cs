using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Pro.PDF;

public class PdfStripper
{
	private PdfDocument _document;

	public int PageCount => _document.PageCount;

	public PdfStripper(string pdfFilename)
	{
		_document = PdfReader.Open(pdfFilename, PdfDocumentOpenMode.Modify);
	}

	public void Save(string pdfFilename)
	{
		_document.Save(pdfFilename);
	}

	public void RemovePage(int pageNumber)
	{
		_document.Pages.RemoveAt(pageNumber - 1);
	}

	public void RemoveAllPagesExcept(int pageNumber)
	{
		for (int num = PageCount; num > 0; num--)
		{
			if (num != pageNumber)
			{
				RemovePage(num);
			}
		}
	}
}
