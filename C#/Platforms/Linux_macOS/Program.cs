using GemBox.Imaging;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (var image = Image.Load("FragonardReader.jpg"))
        {
            image.Resize(64, 64);
            image.Save("Resized.png");
        }
    }
}