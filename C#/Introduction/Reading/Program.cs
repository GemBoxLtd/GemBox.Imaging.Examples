using System;
using GemBox.Imaging;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        var imagePath = "deer.jpg";
        using (var image = Image.Load(imagePath))
        {
            // Display image information
            Console.WriteLine($"Image path: {imagePath}");
            Console.WriteLine($"Image size: {image.Width}x{image.Height}");
            Console.WriteLine($"Image resolution: {image.DpiX}x{image.DpiY}");
        }
    }
}
