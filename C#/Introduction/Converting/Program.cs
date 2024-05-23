using GemBox.Imaging;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Load the input image and save it to a selected image file format.
        using (var image = Image.Load("FragonardReader.jpg"))
            image.Save("Converting.png");
    }
}
