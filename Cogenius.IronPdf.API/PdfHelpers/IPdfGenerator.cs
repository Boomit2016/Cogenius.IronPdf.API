using System.Threading.Tasks;

namespace Cogenius.IronPdf.API.PdfHelpers
{
    public interface IPdfGenerator
    {
        Task<byte[]> GenerateAsync(byte[] document);
    }
}