Imports GemBox.Imaging

Module Program

	Sub Main()

		' If using Professional version, put your serial key below.
		ComponentInfo.SetLicense("FREE-LIMITED-KEY")

		Using image As Image = Image.Load("FragonardReader.jpg")
			image.Save("Converting.png")
		End Using
	End Sub
End Module
