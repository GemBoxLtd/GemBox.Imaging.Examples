using GemBox.Imaging;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (var image = Image.Load("Parrot.png"))
        {
            // Rotate the image by 90 degrees and flip it horizontally.
            image.RotateFlip(RotateFlipType.Rotate90FlipX);

            // Save the rotated and flipped image.
            image.Save("RotatedFlipped.png");
        }
    }
}
