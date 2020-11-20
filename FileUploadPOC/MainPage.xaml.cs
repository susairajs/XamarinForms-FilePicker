using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.FilePicker;
using Xamarin.Essentials;
using System.Security.Cryptography.X509Certificates;

namespace FileUploadPOC
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                string[] fileTypes = null;
                if (Device.RuntimePlatform == Device.iOS)
                {
                    fileTypes = new string[] {"com.adobe.pdf", "public.rft", "com.microsoft.word.doc", "org.openxmlformats.wordprocessingml.document" }; // same as iOS constant UTType.Image
                }
                await PickAndShow(fileTypes);
            }
            catch (Exception ex)
            {

            }
            
        }

        private async Task PickAndShow(string[] fileTypes)
        {
            try
            {
                
                var pickedFile = await CrossFilePicker.Current.PickFile(fileTypes);
                if (pickedFile != null)
                {
                    lblName.Text = pickedFile.FileName;
                    lblFilePath.Text = pickedFile.FilePath;
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
