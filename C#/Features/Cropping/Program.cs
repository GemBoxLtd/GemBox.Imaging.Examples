using GemBox.Imaging;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (var image = Image.Load("FragonardReader.jpg"))
        {
            // Crop the image.
            image.Crop(150, 24, 170, 260);

            // Save the cropped image.
            image.Save("Cropped.jpg");
        }
    }
}
