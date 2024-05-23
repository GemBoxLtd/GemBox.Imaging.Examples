using GemBox.Imaging;
using ImagingCoreMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ImagingCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        // If using the Professional version, put your serial key below.
        static HomeController() => ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        public IActionResult Index() => this.View(new CropImageModel());

        public FileStreamResult Download(CropImageModel model)
        {
            // Load the image.
            using var imageStream = model.Image.OpenReadStream();
            using var image = Image.Load(imageStream);

            // Execute crop process.
            image.Crop(model.PosX, model.PosY, model.Width, model.Height);

            // Save image in specified file format.
            var stream = new MemoryStream();
            image.Save(stream, model.FileFormat);
            stream.Position = 0;

            // Download file.
            return File(stream, model.ContentType, $"Output{model.Extension}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            this.View(new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

namespace ImagingCoreMvc.Models
{
    public class CropImageModel
    {
        public IFormFile Image { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

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
