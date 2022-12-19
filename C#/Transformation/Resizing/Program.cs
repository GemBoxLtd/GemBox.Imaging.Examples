using GemBox.Imaging;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (var image = Image.Load("Dolphin.jpg"))
        {
            // Resizing the image
            image.Resize(128, 85);

            // Saving the resized image
            image.Save("Resized.png");
        }
    }
}
