using GemBox.Imaging;
using ImagingCoreMvc.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ImagingCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment environment;

        public HomeController(IWebHostEnvironment environment)
        {
            this.environment = environment;

            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }

        public IActionResult Index()
        {
            return View(new CropImageModel());
        }

        public FileStreamResult Download(CropImageModel model)
        {
            // Load the image.
            using var imageStream = model.Image.OpenReadStream();
            using var image = Image.Load(imageStream);

            // Execute crop process.
            image.Crop(model.PosX, model.PosY, model.Width, model.Height);

            // Save image in specified file format.
            var stream = new MemoryStream();
            image.Save(stream, model.TargetFileFormat);
            stream.Position = 0;
            // Download file.
            return File(stream, model.TargetContentType, $"Output{model.TargetFormat}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private class ErrorViewModel
        {
            public ErrorViewModel()
            {
            }

            public string RequestId { get; set; }
        }
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
