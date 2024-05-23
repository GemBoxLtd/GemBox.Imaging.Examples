Imports GemBox.Imaging

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using image As Image = Image.Load("FragonardReader.jpg")
            ' Crop the image.
            image.Crop(150, 24, 170, 260)

            ' Save the cropped image.
            image.Save("Cropped.jpg")
        End Using

    End Sub

End Module
