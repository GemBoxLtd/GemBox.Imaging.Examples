using GemBox.Imaging;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (var image = Image.Load("parrot.png"))
        {
            // Adjust blue channel and contrast of the image.
            image.ApplyFilter(x => x
                .Blue(50)
                .Contrast(20)
            );

            // Save the adjusted image.
            image.Save("Adjusted.png");
        }
    }
}
