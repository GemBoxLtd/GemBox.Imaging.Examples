Imports GemBox.Imaging
Imports System

Module Program

    Sub Main()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Dim imagePath = "deer.jpg"
        Using image = GemBox.Imaging.Image.Load(imagePath)
            ' Display image information.
            Console.WriteLine($"Image path: {imagePath}")
            Console.WriteLine($"Image size: {image.Width}x{image.Height}")
            Console.WriteLine($"Image resolution: {image.DpiX}x{image.DpiY}")
        End Using

    End Sub

End Module
