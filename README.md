## What is GemBox.Imaging?

GemBox.Imaging is a .NET component that provides an easy way to load, edit, save image files (png, jpeg, git, tiff). GemBox.Imaging also supports file format conversions and image transformations (resize, crop, rotate and flip).

## GemBox.Imaging Features

- [Read](https://www.gemboxsoftware.com/imaging/examples/c-sharp-vb-net-read-image/201) and [write](https://www.gemboxsoftware.com/imaging/examples/c-sharp-vb-net-write-image/202) png, jpeg, gif and tiff file formats.
- Compose multiframe tiff and gif images from loaded images.
- [Read image properties](https://www.gemboxsoftware.com/imaging/examples/c-sharp-vb-net-read-image/201) without need to load whole image.

## Get Started

You are not sure how to start working with images in .NET using GemBox.Imaging? Check the code below that shows how to change image file format.

```CSharp
// If using Professional version, put your serial key below.
ComponentInfo.SetLicense("FREE-LIMITED-KEY");

using (var image = Image.Load("SampleImage.png"))
{
    image.Save("SampleImage.jpg");
}
```

For more GemBox.Imaging code examples and demos, please visit our [examples page](https://www.gemboxsoftware.com/imaging/examples/c-sharp-vb-net-imaging-library/101).
 

## Installation

You can download GemBox.Imaging from [BugFixes 🛠️](https://www.gemboxsoftware.com/imaging/downloads/bugfixes.html) or from [NuGet 📦](https://www.nuget.org/packages/GemBox.Imaging/).

## Support

* [Product Overview](https://www.gemboxsoftware.com/imaging)
* [Documentation](https://www.gemboxsoftware.com/imaging/docs/introduction.html)
* [API Reference](https://www.gemboxsoftware.com/imaging/docs/introduction.html)
* [Contact Us](https://support.gemboxsoftware.com/new-ticket?ticket%5Bdepartment%5D=1&ticket%5Bproduct%5D=4)
* [Forum](https://forum.gemboxsoftware.com/c/gembox-imaging/6)
* [Blog](https://www.gemboxsoftware.com/gembox-imaging)
* [Examples](https://www.gemboxsoftware.com/imaging/examples/)
