﻿using GemBox.Imaging;
using System;
using System.IO;
using System.Net;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ImagingXamarin
{
    public partial class MainPage : ContentPage
    {
        private byte[] imageData;

        public MainPage()
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            InitializeComponent();

            BindingContext = new RotateFlipViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (imageData == null)
                using (var client = new WebClient())
                    this.imageData = client.DownloadData("https://www.gemboxsoftware.com/imaging/examples/101/resources/FragonardReader.jpg");

            this.sourceImage.Source = ImageSource.FromStream(() => new MemoryStream(this.imageData));
        }

        private string RotateImage(Stream stream)
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var selectedRotationFlipping = (RotateFlipOption)rotateFlipPicker.SelectedItem;
            var destinationFilePath = Path.Combine(documentPath, $"{selectedRotationFlipping.Text}.jpg");
            using (var image = GemBox.Imaging.Image.Load(stream))
            {
                image.RotateFlip(selectedRotationFlipping.Type);
                image.Save(destinationFilePath);
            }
            return destinationFilePath;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            button.IsEnabled = false;

            try
            {
                var filePath = RotateImage(new MemoryStream(this.imageData));
                await Launcher.OpenAsync(new OpenFileRequest(Path.GetFileName(filePath), new ReadOnlyFile(filePath)));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Close");
            }

            button.IsEnabled = true;
        }

        public class RotateFlipOption
        {
            public RotateFlipType Type { get; set; }
            public string Text { get; set; }
        }

        public class RotateFlipViewModel
        {
            public ICollection<RotateFlipOption> RotateFlipOptions { get; set; }

            public RotateFlipViewModel()
            {
                // Filling the collection for picker with possible RotateFlipTypes.
                this.RotateFlipOptions = Enum.GetNames(typeof(RotateFlipType))
                    .Select(x => new RotateFlipOption
                    {
                        Text = x,
                        Type = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), x)
                    }).ToList();
            }
        }
    }
}