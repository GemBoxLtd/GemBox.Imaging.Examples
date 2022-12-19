Imports GemBox.Imaging

Module Program

	Sub Main()

		' If using the Professional version, put your serial key below.
		ComponentInfo.SetLicense("FREE-LIMITED-KEY")

		Using image As Image = Image.Load("Dolphin.jpg")
			' Resizing the image
			image.Resize(128, 85)

			' Saving the resized image
			image.Save("Resized.png")
		End Using
	End Sub
End Module
