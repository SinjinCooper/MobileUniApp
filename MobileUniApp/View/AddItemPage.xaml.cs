using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MobileUniApp.View
{
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage(string pageType)
        {
            InitializeComponent();

            BuildPageType(pageType);
        }

        public void BuildPageType(string pageType)
        {
            if (pageType == "assessment") {
                pageTitle.Text = "Add New Assessment";
                statusPicker.IsVisible = false;
                typePicker.IsVisible = true;
            }
            else if (pageType == "course") {
                pageTitle.Text = "Add New Course";
            }
        }

        public void SaveButtonClicked(object sender, EventArgs e)
        {
            if (pageTitle.Text == "Add New Assessment") {
                Assessment assessment = new Assessment
                {
                    Title = title.Text,
                    AssessmentType = typePicker.SelectedItem.ToString()
                };

                App.DB.SaveNewItem(assessment);
            }
        }

        public void CancelButtonClicked(object sender, EventArgs e)
        {

        }
    }
}
