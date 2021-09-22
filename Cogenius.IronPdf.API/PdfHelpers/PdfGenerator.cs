using IronPdf;
using System.IO;
using System.Threading.Tasks;

namespace Cogenius.IronPdf.API.PdfHelpers
{
    public class PdfGenerator : IPdfGenerator
    {
        public async Task<byte[]> GenerateAsync(byte[] document)
        {
            var stream = new MemoryStream(document);

            using var streamReader = new StreamReader(stream);
            var htmlString = await streamReader.ReadToEndAsync();

            var renderer = new ChromePdfRenderer();
            var pdfDocument = await renderer.RenderHtmlAsPdfAsync(htmlString);
            return pdfDocument.Stream.ToArray();
        }
    }
}
