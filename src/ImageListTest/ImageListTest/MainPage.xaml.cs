using System;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using System.Linq;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using System.Diagnostics;
using Acr.UserDialogs;
using System.ComponentModel;

namespace ImageListTest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ViewModel.OrderItemImageDocuViewModel BindingViewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();
            BindingViewModel = BindingContext as ViewModel.OrderItemImageDocuViewModel;
        }

        private void BtnRemove_Clicked(object sender, EventArgs e)
        {
            if (ImagePreviewListView.SelectedItem != null)
            {
                var selectedItem = ImagePreviewListView.SelectedItem as RequestItemImageDocument;
                var test = BindingViewModel.OrderItemImages.FirstOrDefault(
                    c => c.RequestItemImageDocumentId.Equals(((RequestItemImageDocument)ImagePreviewListView.SelectedItem)
                    .RequestItemImageDocumentId));
                ImagePreviewListView.SelectedItem = null;
                BindingViewModel.OrderItemImages.Remove(test);
            }
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            RequestItemImageDocument document = new RequestItemImageDocument();
            document.RequestItemImageDocumentId = Guid.NewGuid();
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable ||
    !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", "No camera available.", "OK");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Membrain",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Front
            });
            if (!string.IsNullOrEmpty(file.Path))
            {
                //var result = await UserDialogs.Instance.PromptAsync("Fügen Sie eine optionale Textbeschreibung hinzu.", "Beschreibung");
                document.DocumentDescription = "test";
                byte[] data = null;
                using (var stream = file.GetStream())
                {
                    var fInfo = new System.IO.FileInfo(file.Path);
                    data = new byte[fInfo.Length];
                    stream.Read(data, 0, data.Length);
                }
                document.ImageDocumentData = data;
                BindingViewModel.OrderItemImages.Add(document);

            }
        }

        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}
