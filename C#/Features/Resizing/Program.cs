using GemBox.Imaging;

class Program
{
    static void Main()
    {
        Example1();
        Example2();
    }

    static void Example1()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (var image = Image.Load("Dolphin.jpg"))
        {
            // Resize the image to 128 x 85 pixels.
            image.Resize(128, 85);

            // Save the resized image.
            image.Save("Resized.jpg");
        }
    }

    static void Example2()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (var image = Image.Load("parrots.tiff"))
        {
            // Get the middle frame and reduce its size by half.
            var frame = image.Frames[image.Frames.Count / 2];
            frame.Resize(frame.Width / 2, frame.Height / 2);

            // Save the resized image.
            image.Save("Resized.tiff");
        }
    }
}
