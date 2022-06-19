using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RandochooseMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        int count = 0;

        private void Handle_Clicked(object sender, System.EventArgs e)
        {
            string selectedItemsStr = items.Text;
            string[] selectedItems = selectedItemsStr.Split('\n');

            Random rnd = new Random();
            count = rnd.Next(0, selectedItems.Length);

            chosenItem.Text = $"{selectedItems[count]} has been chosen.";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new About());
        }
    }
}
