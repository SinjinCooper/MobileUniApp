using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MobileUniApp.View;

namespace MobileUniApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void AddTermButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddItemPage("assessment"));
        }
    }
}
