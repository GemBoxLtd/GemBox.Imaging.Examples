Imports GemBox.Imaging

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using image As Image = Image.Load("FragonardReader.jpg")
            image.Resize(64, 64)
            image.Save("Resized.png")
        End Using

    End Sub

End Module