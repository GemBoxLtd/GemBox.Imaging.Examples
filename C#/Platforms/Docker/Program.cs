using GemBox.Imaging;
using System;

class Program
{
    static void Main()
    {
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (var image = Image.Load("FragonardReader.jpg"))
        {
            // Display image information.
            Console.WriteLine($"Image size: {image.Width}x{image.Height}");
        }
    }
}
