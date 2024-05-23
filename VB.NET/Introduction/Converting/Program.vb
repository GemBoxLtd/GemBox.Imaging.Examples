Imports GemBox.Imaging

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Load the input image and save it to a selected image file format.
        Using image As Image = Image.Load("FragonardReader.jpg")
            image.Save("Converting.png")
        End Using

    End Sub

End Module
