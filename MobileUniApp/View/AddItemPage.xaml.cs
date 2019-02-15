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
                typeOrStatus.Text = "Type";
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
                    AssessmentType = typePicker.SelectedItem.ToString(),
                    StartDate = startDatePicker.Date,
                    EndDate = endDatePicker.Date
                };
                App.DB.SaveNewItem(assessment);
            }
            else if (pageTitle.Text == "Add New Course") {
                Course course = new Course
                {
                    Title = title.Text,
                    Status = statusPicker.SelectedItem.ToString(),
                    StartDate = startDatePicker.Date,
                    EndDate = endDatePicker.Date
                };
                App.DB.SaveNewItem(course);
            }
            else {
                Term term = new Term
                {
                    Title = title.Text,
                    Status = statusPicker.SelectedItem.ToString(),
                    StartDate = startDatePicker.Date,
                    EndDate = endDatePicker.Date
                };
                App.DB.SaveNewItem(term);
            }


            ClosePage();
        }

        public void CancelButtonClicked(object sender, EventArgs e)
        {
            ClosePage();
        }

        private async void ClosePage()
        {
            await Navigation.PopModalAsync();
        }
    }
}
