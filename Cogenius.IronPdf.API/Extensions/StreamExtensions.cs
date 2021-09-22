using System.IO;
using System.Threading.Tasks;

namespace Cogenius.IronPdf.API.Extensions
{
    public static class StreamExtensions
    {
        public static async Task<byte[]> ToBytesAsync(this Stream stream)
        {
            await using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            var bytes = memoryStream.ToArray();
            return bytes;
        }
    }
}
