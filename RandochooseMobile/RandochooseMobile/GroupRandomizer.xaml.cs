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
    public partial class GroupRandomizer : ContentPage
    {
        public GroupRandomizer()
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

            int inOneGroup = 0;
            int group = 1;
            string groupMembers = "1.";
            string finalText = "";

            foreach (string item in selectedItems)
            {
                if (inOneGroup < ((int)groupNum.Value))
                {
                    groupMembers = $"{groupMembers} {item}";
                    inOneGroup++;
                    if (inOneGroup < ((int)groupNum.Value))
                    {
                        groupMembers = $"{groupMembers},";
                    }
                }
                else
                {
                    finalText = $"{finalText}{groupMembers}\n";
                    group++;
                    inOneGroup = 0;
                    groupMembers = $"{group.ToString()}.";
                }
            }

            itemGroups.Text = finalText;
        }

        private void groupNum_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblForGroupNum.Text = $"Maximum items in a group: {groupNum.Value.ToString()}";
        }
    }
}