using Cogenius.IronPdf.API.Pdf;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Cogenius.IronPdf.API.PdfHelpers
{
    public class PdfService : IPdfService
    {
        private readonly IPdfGenerator _pdfGenerator;

        public PdfService(IPdfGenerator pdfGenerator)
        {
            _pdfGenerator = pdfGenerator;
        }

        public async Task<(byte[] data, string filename)> CreatePdfPreviewAsync(byte[] document, string filename, CancellationToken cancellationToken = default)
        {
            var data = await _pdfGenerator.GenerateAsync(document);

            filename = Path.ChangeExtension(filename, "pdf");

            return (data, filename);
        }
    }
}
