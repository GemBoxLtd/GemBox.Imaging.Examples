﻿using GemBox.Imaging;
using ImagingMaui.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ImagingMaui
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
                GetDefaultImageAsync().Wait();

            this.sourceImage.Source = ImageSource.FromStream(() => new MemoryStream(this.imageData));
        }

        private async Task GetDefaultImageAsync()
        {
            using var ms = new MemoryStream();
            using (var stream = await FileSystem.OpenAppPackageFileAsync("fragonard_reader.jpg"))
                await stream.CopyToAsync(ms);

            this.imageData = ms.ToArray();
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
            this.button.IsEnabled = false;

            try
            {
                var filePath = await Task.Run(() => RotateImage(new MemoryStream(this.imageData)));
                await Launcher.OpenAsync(new OpenFileRequest(Path.GetFileName(filePath), new ReadOnlyFile(filePath)));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Close");
            }

            this.button.IsEnabled = true;
        }
    }
}