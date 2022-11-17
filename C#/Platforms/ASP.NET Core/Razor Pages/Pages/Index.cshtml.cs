using GemBox.Imaging;
using ImagingCorePages.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;

namespace ImagingCorePages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IWebHostEnvironment environment;

        [BindProperty]
        public CropImageModel Model { get; set; }

        public IndexModel(IWebHostEnvironment environment)
        {
            this.environment = environment;
            this.Model = new CropImageModel();

            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            ComponentInfo.FreeLimitReached += (sender, e) => e.FreeLimitReachedAction = FreeLimitReachedAction.ContinueAsTrial;
        }

        public void OnGet() { }

        public FileStreamResult OnPost()
        {
            // Load the image.
            using var imageStream = this.Model.Image.OpenReadStream();
            using var image = Image.Load(imageStream);

            // Execute crop process.
            image.Crop(this.Model.PosX, this.Model.PosY, this.Model.Width, this.Model.Height);

            // Save image in specified file format.
            var stream = new MemoryStream();
            image.Save(stream, this.Model.TargetFileFormat);
            stream.Position = 0;
            // Download file.
            return File(stream, this.Model.TargetContentType, $"Output{this.Model.TargetFormat}");
        }
    }
}

namespace ImagingCorePages.Models
{
    public class CropImageModel
    {
        public IFormFile Image { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string TargetFormat
        {
            get
            {
                var format = Path.GetExtension(Image.FileName).ToLowerInvariant();
                return FormatMappingDictionary.ContainsKey(format) ? format : ".png";
            }
        }
        public ImageFileFormat TargetFileFormat => FormatMappingDictionary[this.TargetFormat];
        public string TargetContentType => ContentTypeMappingDictionary[this.TargetFormat];

        public static IDictionary<string, ImageFileFormat> FormatMappingDictionary => new Dictionary<string, ImageFileFormat>()
        {
            [".png"] = ImageFileFormat.Png,
            [".jpeg"] = ImageFileFormat.Jpeg,
            [".gif"] = ImageFileFormat.Gif,
            [".tiff"] = ImageFileFormat.Tiff
        };

        public static IDictionary<string, string> ContentTypeMappingDictionary => new Dictionary<string, string>()
        {
            [".png"] = "image/png",
            [".jpeg"] = "image/jpeg",
            [".gif"] = "image/gif",
            [".tiff"] = "image/tiff"
        };
    }
}
