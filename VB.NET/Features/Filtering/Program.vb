Imports GemBox.Imaging

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using image As Image = Image.Load("parrot.png")
            ' Adjust blue channel and contrast of the image.
            image.ApplyFilter(
                Function(x) x _
                    .Blue(50) _
                    .Contrast(20)
                )

            ' Save the adjusted image.
            image.Save("Adjusted.png")
        End Using

    End Sub

End Module
