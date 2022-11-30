## What is GemBox.Imaging?

GemBox.Imaging is a .NET component that enables you to read, convert, and transform image files (PNG, JPEG, and GIF) from .NET applications.

With GemBox.Imaging you get a fast and reliable component that's easy to use and doesn't depend on Microsoft Windows GDI. It requires only .NET so you can deploy your applications on any platform.

## GemBox.Imaging Features

- [Read](https://www.gemboxsoftware.com/imaging/examples/c-sharp-vb-net-read-image/201) and [write](https://www.gemboxsoftware.com/imaging/examples/c-sharp-vb-net-write-image/202) png, jpeg, gif and tiff file formats.
- Compose multiframe tiff and gif images from loaded images.
- [Read image properties](https://www.gemboxsoftware.com/imaging/examples/c-sharp-vb-net-read-image/201) without need to load whole image.

## Get Started

You are not sure how to start working with images in .NET using GemBox.Imaging? Check the code below that shows how to change image file format.

```csharp
// If using Professional version, put your serial key below.
ComponentInfo.SetLicense("FREE-LIMITED-KEY");

using (var image = Image.Load("SampleImage.png"))
{
    image.Save("SampleImage.jpg");
}
```

For more GemBox.Imaging code examples and demos, please visit our [examples page](https://www.gemboxsoftware.com/imaging/examples/c-sharp-vb-net-imaging-library/101).

## Installation

You can download GemBox.Imaging from [NuGet 📦](https://www.nuget.org/packages/GemBox.Imaging/) or from [BugFixes 🛠️](https://www.gemboxsoftware.com/imaging/downloads/bugfixes.html).

## Resources

- [Product Page](https://www.gemboxsoftware.com/imaging)
- [Examples](https://www.gemboxsoftware.com/imaging/examples)
- [Documentation](https://www.gemboxsoftware.com/imaging/docs/introduction.html)
- [API Reference](https://www.gemboxsoftware.com/imaging/docs/GemBox.Imaging.html)
- [Forum](https://forum.gemboxsoftware.com/c/gembox-imaging/12)
- [Blog](https://www.gemboxsoftware.com/gembox-imaging)
