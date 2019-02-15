using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MobileUniApp.View
{
    public partial class TermPage : ContentPage
    {
        public TermPage(Term term)
        {
            InitializeComponent();
            titleLabel.Text = term.Title;
            BuildTermPage(term);
        }

        public void BuildTermPage(Term term)
        {
            List<Course> coursesList = App.DB.GetCoursesByTerm(term);
            foreach(Course c in coursesList) {
                // Add Course grid
            }
        }

        async void AddCourseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddItemPage("course"));
        }
    }
}
