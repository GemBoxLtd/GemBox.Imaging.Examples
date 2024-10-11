## What is GemBox.Imaging?

GemBox.Imaging is a .NET component that enables you to read, convert, and transform image files (PNG, JPEG, and GIF) from .NET applications.

With GemBox.Imaging you get a fast and reliable component that's easy to use and doesn't depend on Microsoft Windows GDI. It requires only .NET so you can deploy your applications on any platform.

## GemBox.Imaging Features

- [Covert](https://www.gemboxsoftware.com/imaging/examples/c-sharp-vb-net-convert-image/202) images to and from PNG, JPEG, GIF, and TIFF formats.
- [Resize](https://www.gemboxsoftware.com/imaging/examples/c-sharp-vb-net-resize-image/301), [crop](https://www.gemboxsoftware.com/imaging/examples/c-sharp-vb-net-crop-image/302), [rotate, and flip](https://www.gemboxsoftware.com/imaging/examples/c-sharp-vb-net-rotate-flip-image/303) images.
- [Read image properties](https://www.gemboxsoftware.com/imaging/examples/c-sharp-vb-net-read-image/201) without loading pixel data.
- [Apply filters](https://www.gemboxsoftware.com/imaging/examples/c-sharp-vb-net-apply-filter-to-image/203) to an image for adjusting brightness, contrast, saturation, colors, and more.
- [Merge and split frames](https://www.gemboxsoftware.com/imaging/examples/c-sharp-vb-net-merge-split-frames/204) of multi-frame image formats like GIF and TIFF.

## Get Started

You are not sure how to start working with images in .NET using GemBox.Imaging? Check the code below that shows how to load example image, resize it to thumbnail size and then save Image instance to image file.

```csharp
// If using Professional version, put your serial key below.
ComponentInfo.SetLicense("FREE-LIMITED-KEY");

//Load image
using (var image = Image.Load("FragonardReader.jpg"))

// Resize the image
image.Resize(64, 64);

// Save the resized image
image.Save("HelloWorld.png");
```

For more GemBox.Imaging code examples and demos, please visit our [examples page](https://www.gemboxsoftware.com/imaging/examples/getting-started/101).

## Installation

You can download GemBox.Imaging from [NuGet 📦](https://www.nuget.org/packages/GemBox.Imaging/) or from [Downloads 🛠️](https://www.gemboxsoftware.com/imaging/downloads/).

## Resources

- [Product Page](https://www.gemboxsoftware.com/imaging)
- [Examples](https://www.gemboxsoftware.com/imaging/examples)
- [Documentation](https://www.gemboxsoftware.com/imaging/docs/introduction.html)
- [API Reference](https://www.gemboxsoftware.com/imaging/docs/GemBox.Imaging.html)
- [Forum](https://forum.gemboxsoftware.com/c/gembox-imaging/12)
- [Blog](https://www.gemboxsoftware.com/gembox-imaging)
