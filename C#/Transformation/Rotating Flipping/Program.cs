using GemBox.Imaging;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (var image = Image.Load("Parrot.png"))
        {
            // Rotating the image
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Saving the rotated image
            image.Save("RotatedFlipped.png");
        }
    }
}
