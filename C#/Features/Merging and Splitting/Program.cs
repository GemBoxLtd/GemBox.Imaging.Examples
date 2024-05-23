using GemBox.Imaging;
using System;
using System.IO;
using System.Linq;

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

        // Get all images from a folder.
        var imagesEnumerable = Directory.EnumerateFiles("Frames").Select(Image.Load);

        // Merge images into a single image.
        using (var image = new Image(imagesEnumerable, true))
        {
            // Set infinite GIF loop count and add 1 second delay after the last frame.
            image.Metadata.Gif.RepeatCount = 0;
            image.Frames.Last().Metadata.Gif.FrameDelay = TimeSpan.FromSeconds(1);
            
            // Save the merged image as a GIF file.
            image.Save("Merged.gif");
        }
    }

    static void Example2()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        var imagePath = "gembox.gif";
        var frameNumber = 5;

        // Load the input image and check if the requested frame exists.
        using (var image = Image.Load(imagePath))
            if (frameNumber <= image.Frames.Count)
            {
                // Create an image from the frame at the specified index and save it to a new file.
                using (var tempImage = new Image(image.Frames[frameNumber - 1]))
                    tempImage.Save($"frame.{frameNumber:D04}.png");
            }
    }
}
