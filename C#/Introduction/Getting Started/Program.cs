using GemBox.Imaging;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (var image = Image.Load("FragonardReader.jpg"))
        {
            // Resizing the image.
            image.Resize(64, 64);

            // Saving the resized image.
            image.Save("HelloWorld.png");
        }
    }
}
