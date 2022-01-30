using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AOT_Application.Models;
using Xamarin.Essentials;
using System.ComponentModel;
using AOT_Application.Views;
using AOT_Application.ViewModels;
using AOT_Application.Services;
using System.IO;

namespace AOT_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]

    public partial class AddReportSecurityIncidents : ContentPage
    {
        public Item Item { get; set; }

        public AddReportSecurityIncidents()
        {
            InitializeComponent();
            Item = new Item
            {

            };

            BindingContext = this;
        }

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
            }

        }
        async void Button_ClickedSave(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await DisplayAlert("การแจ้งเตือน", "เพิ่มข้อมูลรายการแจ้งเหตุการณ์สำเร็จ!", "ตกลง");
            await Navigation.PopModalAsync();
        }

        async void Button_ClickedCancle(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}