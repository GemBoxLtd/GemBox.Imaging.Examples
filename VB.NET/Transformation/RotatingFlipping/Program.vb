Imports GemBox.Imaging

Module Program

	Sub Main()

		' If using Professional version, put your serial key below.
		ComponentInfo.SetLicense("FREE-LIMITED-KEY")

		Using image As Image = Image.Load("Parrot.png")
			' Rotating the image
			image.RotateFlip(RotateFlipType.Rotate90FlipNone)

			' Saving the rotated image
			image.Save("RotatedFlipped.png")
		End Using
	End Sub
End Module
