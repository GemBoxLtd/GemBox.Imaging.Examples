Imports GemBox.Imaging

Module Program

    Sub Main()

        Example1()
        Example2()

    End Sub

    Sub Example1()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using image As Image = Image.Load("Dolphin.jpg")
            ' Resize the image to 128 x 85 pixels.
            image.Resize(128, 85)

            ' Save the resized image.
            image.Save("Resized.jpg")
        End Using
    End Sub

    Sub Example2()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using image = GemBox.Imaging.Image.Load("parrots.tiff")
            ' Get the middle frame and reduce its size by half.
            Dim frame = image.Frames(image.Frames.Count \ 2)
            frame.Resize(frame.Width \ 2, frame.Height \ 2)

            ' Save the resized image.
            image.Save("Resized.tiff")
        End Using
    End Sub

End Module
