using GemBox.Imaging;

class Program
{
    static void Main()
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (var image = Image.Load("FragonardReader.jpg"))
        {
            image.Save("Converting.png");
        }
    }
}
