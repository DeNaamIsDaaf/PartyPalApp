namespace PartyPalApp
{
    public partial class QrPage : ContentPage
    {
        public QrPage()
        {
            InitializeComponent();
            barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
            {
                Formats = ZXing.Net.Maui.BarcodeFormat.QrCode, // restriction to only scan QR codes
                AutoRotate = true,
                Multiple = true,
            };
        }

        private void barcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            var first = e.Results?.FirstOrDefault();

            if (first is null)
                return;

            string scannedValue = first.Value;

            if (scannedValue == "https://qr.link/p3l2HP")
            {
                // Ui update
                Dispatcher.Dispatch(() =>
                {
                    Hiddengrid.IsVisible = true;
                    Hiddengrid2.IsVisible = false; 

                });
            }
            else if (scannedValue == "https://qr.codes/mcEB7d") 
            {
                Dispatcher.Dispatch(() =>
                {
                    Hiddengrid.IsVisible = false; 
                    Hiddengrid2.IsVisible = true;
                });
            }
            else
            {
                Dispatcher.Dispatch(() =>
                {
                    Hiddengrid.IsVisible = false;
                    Hiddengrid2.IsVisible = false;
                });
            }
        }


    }
}
