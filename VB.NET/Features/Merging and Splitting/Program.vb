Imports System
Imports System.IO
Imports System.Linq
Imports GemBox.Imaging

Module Program
    Sub Main()

        Example1()
        Example2()

    End Sub

    Sub Example1()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Get all images from a folder.
        Dim imagesEnumerable = Directory.EnumerateFiles("Frames").Select(Function(f) Image.Load(f))

        ' Merge images into a single image.
        Using image = New Image(imagesEnumerable, True)
            ' Set infinite GIF loop count and add 1 second delay after the last frame.
            image.Metadata.Gif.RepeatCount = 0
            image.Frames.Last().Metadata.Gif.FrameDelay = TimeSpan.FromSeconds(1)

            ' Save the merged image as a GIF file.
            image.Save("Merged.gif")
        End Using
    End Sub

    Sub Example2()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Dim imagePath = "gembox.gif"
        Dim frameNumber = 5

        ' Load the input image and check if the requested frame exists.
        Using image As Image = Image.Load(imagePath)
            If frameNumber <= image.Frames.Count Then
                ' Create an image from the frame at the specified index and save it to a new file.
                Using tempImage = New Image(image.Frames(frameNumber - 1))
                    tempImage.Save($"frame.{frameNumber:D04}.png")
                End Using
            End If
        End Using
    End Sub

End Module
