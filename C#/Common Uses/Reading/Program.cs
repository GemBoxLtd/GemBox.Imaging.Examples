using GemBox.Imaging;
using System;

class Program
{
    static void Main()
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        Console.Title = "Reading Image Properties - GemBox.Imaging";
        Console.WriteLine();

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
