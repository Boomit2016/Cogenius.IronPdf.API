using Cogenius.IronPdf.API.Extensions;
using Cogenius.IronPdf.API.Pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Cogenius.IronPdf.API.Controllers
{
    [Route("api/Pdf")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        protected const string PdfPreviewRoute = "Pdf_PdfPreview";

        private readonly IPdfService _pdfService;

        public PdfController(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        /// <summary>
        /// Create PDF preview
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("Preview", Name = PdfPreviewRoute)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CreatePdfPreview([Required] IFormFile formFile, CancellationToken cancellationToken = default)
        {
            await using var stream = formFile.OpenReadStream();
            var documentData = await stream.ToBytesAsync();

            var (data, filename) = await _pdfService.CreatePdfPreviewAsync(documentData, formFile.FileName, cancellationToken);

            return File(data, "application/pdf", filename);
        }
    }
}
