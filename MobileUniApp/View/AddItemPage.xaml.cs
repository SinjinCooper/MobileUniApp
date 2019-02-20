using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MobileUniApp.View
{
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage(string pageType, int id)
        {
            InitializeComponent();

            BuildPageType(pageType, id);
        }

        public void BuildPageType(string pageType, int id)
        {
            if (pageType == "assessment") {
                pageTitle.Text = "Add New Assessment";
                idLabel.Text = id.ToString();
                typeOrStatus.Text = "Type";
                statusPicker.IsVisible = false;
                typePicker.IsVisible = true;
            }
            else if (pageType == "course") {
                pageTitle.Text = "Add New Course";
                idLabel.Text = id.ToString();
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
                    EndDate = endDatePicker.Date,
                    CourseId = Convert.ToInt32(idLabel.Text)
                };
                App.DB.SaveNewItem(assessment);
            }
            else if (pageTitle.Text == "Add New Course") {
                Course course = new Course
                {
                    Title = title.Text,
                    Status = statusPicker.SelectedItem.ToString(),
                    StartDate = startDatePicker.Date,
                    EndDate = endDatePicker.Date,
                    TermId = Convert.ToInt32(idLabel.Text)
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
