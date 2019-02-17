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
            title.Text = term.Title;
            statusPicker.SelectedItem = term.Status;
        }

        public EditItemPage(Course course)
        {
            InitializeComponent();
            title.Text = course.Title;
        }

        public EditItemPage(Assessment assessment)
        {
            InitializeComponent();
            title.Text = assessment.Title;
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
