Imports GemBox.Imaging
Imports System

Module Program

    Sub Main()

        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using image As Image = Image.Load("FragonardReader.jpg")
            ' Display image information.
            Console.WriteLine($"Image size: {image.Width}x{image.Height}")
        End Using

    End Sub

End Module
