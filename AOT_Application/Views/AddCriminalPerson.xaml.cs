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

namespace AOT_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]

    public partial class AddCriminalPerson : ContentPage
    {

        public CriminalPersonItem CriminalPersonItem { get; set; }

        public AddCriminalPerson()
        {
            InitializeComponent();

            CriminalPersonItem = new CriminalPersonItem
            {
                //id = "1234",
                //name = Name.ToString().Trim(),
                //surname = "testInsert",
                //code = "xxx124"
            };

            BindingContext = this;
        }

        async void Button_ClickedSave(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", CriminalPersonItem);
            await DisplayAlert("การแจ้งเตือน", "เพิ่มข้อมูลบันทึกการกระทำผิดบุคคลสำเร็จ!", "ตกลง");
            await Navigation.PopModalAsync();
        }

        async void Button_ClickedCancle(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}