using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RandochooseMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NormalRandomizer : ContentPage
    {
        public NormalRandomizer()
        {
            InitializeComponent();
        }

        int count = 0;

        private void Handle_Clicked(object sender, System.EventArgs e)
        {
            string selectedItemsStr = items.Text;
            string[] selectedItems = selectedItemsStr.Split('\n');

            for (int i = 0; i < selectedItems.Length; i++)
            {
                Random rnd = new Random();

                for (int j = selectedItems.Length - 1; j > 0; j--)
                {
                    int k = rnd.Next(j);
                    string temp = selectedItems[j];
                    selectedItems[j] = selectedItems[k];
                    selectedItems[k] = temp;
                }
            }

            Random rndm = new Random();
            count = rndm.Next(0, selectedItems.Length);

            chosenItem.Text = $"{selectedItems[count]} has been chosen.";
        }
    }
}