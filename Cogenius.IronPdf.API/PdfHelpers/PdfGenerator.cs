using IronPdf;
using IronPdf.Rendering;
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
            renderer.RenderingOptions.SetCustomPaperSizeInInches(8.5, 11);
            renderer.RenderingOptions.PaperOrientation = PdfPaperOrientation.Portrait;
            renderer.RenderingOptions.RenderDelay = 50;
            renderer.RenderingOptions.CssMediaType = PdfCssMediaType.Screen;
            renderer.RenderingOptions.Zoom = 100;
            renderer.RenderingOptions.ViewPortWidth = 1280;
            renderer.RenderingOptions.CreatePdfFormsFromHtml = true;
            renderer.RenderingOptions.MarginTop = 10;
            renderer.RenderingOptions.MarginLeft = 10;
            renderer.RenderingOptions.MarginRight = 10;
            renderer.RenderingOptions.MarginBottom = 10;

            var pdfDocument = await renderer.RenderHtmlAsPdfAsync(htmlString);
            return pdfDocument.Stream.ToArray();
        }
    }
}
