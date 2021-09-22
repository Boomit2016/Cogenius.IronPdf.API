using System.Threading;
using System.Threading.Tasks;

namespace Cogenius.IronPdf.API.Pdf
{
    public interface IPdfService
    {
        Task<(byte[] data, string filename)> CreatePdfPreviewAsync(byte[] documentData, string filename, CancellationToken cancellationToken = default);
    }
}