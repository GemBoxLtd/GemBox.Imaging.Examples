Imports GemBox.Imaging

Module Program

	Sub Main()

		' If using the Professional version, put your serial key below.
		ComponentInfo.SetLicense("FREE-LIMITED-KEY")

		Using image As Image = Image.Load("FragonardReader.jpg")
			' Cropping the image
			image.Crop(150, 24, 170, 260)

			' Saving the cropped image
			image.Save("Cropped.png")
		End Using
	End Sub
End Module
