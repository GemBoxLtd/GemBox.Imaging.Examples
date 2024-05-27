Imports GemBox.Imaging

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using image As Image = Image.Load("FragonardReader.jpg")
            ' Resizing the image.
            image.Resize(64, 64)

            ' Saving the resized image.
            image.Save("HelloWorld.png")
        End Using

    End Sub

End Module
