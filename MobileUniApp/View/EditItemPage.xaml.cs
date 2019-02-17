using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MobileUniApp.View
{
    public partial class EditItemPage : ContentPage
    {
        public EditItemPage(Term term)
        {
            InitializeComponent();
            pageTitle.Text = "Edit Term";
            typeId.Text = "Term Id: " + term.TermId;
            title.Text = term.Title;
            statusPicker.SelectedItem = term.Status;
            startDatePicker.Date = term.StartDate;
            endDatePicker.Date = term.EndDate;
        }

        public EditItemPage(Course course)
        {
            InitializeComponent();
            pageTitle.Text = "Edit Course";
            typeId.Text = "Course Id: " + course.CourseId;
            title.Text = course.Title;
            statusPicker.SelectedItem = course.Status;
            startDatePicker.Date = course.StartDate;
            endDatePicker.Date = course.EndDate;
        }

        public EditItemPage(Assessment assessment)
        {
            InitializeComponent();
            pageTitle.Text = "Edit Assessment";
            typeId.Text = "Assessment Id: " + assessment.AssessmentId;
            title.Text = assessment.Title;
            statusPicker.IsVisible = false;
            typePicker.IsVisible = true;
            typePicker.SelectedItem = assessment.AssessmentType;
            startDatePicker.Date = assessment.StartDate;
            endDatePicker.Date = assessment.EndDate;
        }

        // Instructor editing page will look different
        public EditItemPage(Instructor instructor)
        {
            InitializeComponent();
        }



        public void SaveButtonClicked(object sender, EventArgs e)
        {

            ClosePage();
        }

        public void CancelButtonClicked(object sender, EventArgs e)
        {
            ClosePage();
        }

        async void ClosePage()
        {
            await Navigation.PopModalAsync();
        }
    }
}
