using System.ComponentModel.DataAnnotations;

namespace Cogenius.IronPdf.API.Options
{
    public class AppSettings
    {
        [Required]
        public string IronPdfLicenseKey { get; set; }
    }
}
