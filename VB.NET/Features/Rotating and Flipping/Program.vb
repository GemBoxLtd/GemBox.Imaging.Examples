Imports GemBox.Imaging

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using image As Image = Image.Load("Parrot.png")
            ' Rotate the image by 90 degrees and flip it horizontally.
            image.RotateFlip(RotateFlipType.Rotate90FlipX)

            ' Save the rotated and flipped image.
            image.Save("RotatedFlipped.png")
        End Using

    End Sub

End Module
