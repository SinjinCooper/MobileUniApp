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
            typeId.Text = term.TermId.ToString();
            title.Text = term.Title;
            statusPicker.SelectedItem = term.Status;
            startDatePicker.Date = term.StartDate;
            endDatePicker.Date = term.EndDate;
        }

        public EditItemPage(Course course)
        {
            InitializeComponent();
            pageTitle.Text = "Edit Course";
            typeId.Text = course.CourseId.ToString();
            otherId.Text = course.TermId.ToString();
            title.Text = course.Title;
            statusPicker.SelectedItem = course.Status;
            startDatePicker.Date = course.StartDate;
            endDatePicker.Date = course.EndDate;
        }

        public EditItemPage(Assessment assessment)
        {
            InitializeComponent();
            pageTitle.Text = "Edit Assessment";
            typeId.Text = assessment.AssessmentId.ToString();
            otherId.Text = assessment.CourseId.ToString();
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
            nonInstLayout.IsVisible = false;
            instLayout.IsVisible = true;
            pageTitle.Text = "Edit Instructor";
            typeId.Text = instructor.CourseId.ToString();
            name.Text = instructor.Name;
            phone.Text = instructor.Phone;
            email.Text = instructor.Email;
        }



        public void SaveButtonClicked(object sender, EventArgs e)
        {
            if (pageTitle.Text == "Edit Term") {
                Term editedTerm = new Term
                {
                    TermId = Convert.ToInt32(typeId.Text),
                    Title = title.Text,
                    Status = statusPicker.SelectedItem.ToString(),
                    StartDate = startDatePicker.Date,
                    EndDate = endDatePicker.Date
                };
                App.DB.EditItem(editedTerm);
            }
            else if (pageTitle.Text == "Edit Course") {
                Course editedCourse = new Course
                {
                    CourseId = Convert.ToInt32(typeId.Text),
                    Title = title.Text,
                    Status = statusPicker.SelectedItem.ToString(),
                    StartDate = startDatePicker.Date,
                    EndDate = endDatePicker.Date,
                    TermId = Convert.ToInt32(otherId.Text)
                };
                App.DB.EditItem(editedCourse);
            }
            else if (pageTitle.Text == "Edit Assessment") {
                Assessment editedAssessment = new Assessment
                {
                    AssessmentId = Convert.ToInt32(typeId.Text),
                    Title = title.Text,
                    AssessmentType = typePicker.SelectedItem.ToString(),
                    StartDate = startDatePicker.Date,
                    EndDate = endDatePicker.Date,
                    CourseId = Convert.ToInt32(otherId.Text)
                };
                App.DB.EditItem(editedAssessment);
            }
            //--------------------------------------------------------
            else if (pageTitle.Text == "Edit Instructor") {
                Instructor instructor = new Instructor
                {
                    //CourseId = Convert.ToInt32(otherId.Text)
                };
            }
            // --------------------------------------------------------

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
