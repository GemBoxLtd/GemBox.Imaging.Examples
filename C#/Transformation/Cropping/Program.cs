using GemBox.Imaging;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (var image = Image.Load("FragonardReader.jpg"))
        {
            // Cropping the image
            image.Crop(150, 24, 170, 260);

            // Saving the cropped image
            image.Save($"Cropped.png");
        }
    }
}
