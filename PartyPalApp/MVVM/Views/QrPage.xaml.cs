using System;
using System.Linq;
using Microsoft.Maui.Controls;
using ZXing.Net.Maui;

namespace PartyPalApp
{
    public partial class QrPage : ContentPage
    {
        public QrPage()
        {
            InitializeComponent();
            BarcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
            {
                Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
                AutoRotate = true
            };
        }

        private void BarcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            var first = e.Results?.FirstOrDefault();

            if (first is null)
                return;

            // Check if the QR code text is "mobile applications"
            if (first.Value == "mobile applications")
            {
                // Display two frames with filler text
                FillTwoFrames();
            }
            else
            {
                // Display an alert with the detected QR code text
                DisplayAlert("Barcode Detected", first.Value, "OK");
            }
        }

        private void FillTwoFrames()
        {
            // Set the visibility of the frames to true
            Frame1.IsVisible = true;
            Frame2.IsVisible = true;
        }
    }
}
