using GemBox.Imaging;
using ImagingCorePages.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;

namespace ImagingCorePages.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ResizeImageModel Model { get; set; }

        // If using the Professional version, put your serial key below.
        static IndexModel() => ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        public IndexModel() => this.Model = new ResizeImageModel();

        public void OnGet() { }

        public FileStreamResult OnPost()
        {
            // Load the image.
            using var imageStream = this.Model.Image.OpenReadStream();
            using var image = Image.Load(imageStream);

            // Execute resize process.
            image.Resize(this.Model.Width, this.Model.Height);

            // Save image in specified file format.
            var stream = new MemoryStream();
            image.Save(stream, this.Model.FileFormat);
            stream.Position = 0;

            // Download file.
            return File(stream, this.Model.ContentType, $"Resized{this.Model.Extension}");
        }
    }
}

namespace ImagingCorePages.Models
{
    public class ResizeImageModel
    {
        public IFormFile Image { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }

        public string Extension => Path.GetExtension(Image.FileName).ToLowerInvariant();
        public ImageFileFormat FileFormat => ImageMappingDictionary[this.Extension].FileFormat;
        public string ContentType => ImageMappingDictionary[this.Extension].ContentType;

        public static IDictionary<string, (ImageFileFormat FileFormat, string ContentType)> ImageMappingDictionary =>
            new Dictionary<string, (ImageFileFormat, string)>(StringComparer.OrdinalIgnoreCase)
            {
                [".png"] = (ImageFileFormat.Png, "image/png"),
                [".jpg"] = (ImageFileFormat.Jpeg, "image/jpeg"),
                [".jpeg"] = (ImageFileFormat.Jpeg, "image/jpeg"),
                [".gif"] = (ImageFileFormat.Gif, "image/gif"),
                [".tif"] = (ImageFileFormat.Tiff, "image/tiff"),
                [".tiff"] = (ImageFileFormat.Tiff, "image/tiff")
            };
    }
}
