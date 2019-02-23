using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MobileUniApp.View
{
    public partial class CoursePage : ContentPage
    {
        public CoursePage(Course course)
        {
            InitializeComponent();
            titleLabel.Text = course.Title;
            courseIdLabel.Text = course.CourseId.ToString();
            BuildCoursePage(course);
        }

        public void BuildCoursePage(Course course)
        {
            List<Assessment> assessments = App.DB.GetAssessmentsByCourse(course);
            foreach(Assessment a in assessments) {
                AddAssessmentGrid(a);
            }

            course.Instructor = App.DB.GetInstructorByCourseId(course);
            instructorName.Text = course.Instructor.Name;
            instructorPhone.Text = course.Instructor.Phone;
            instructorEmail.Text = course.Instructor.Email;

            if (course.Notes != null) {
                notesEditor.Text = course.Notes;
            }
        }

        public void AddAssessmentGrid(Assessment assessment)
        {
            // To do
        }

        public void EditAssessmentClicked(object sender, EventArgs e)
        {
            var id = ((Button)sender).ClassId;
            Assessment assessment = App.DB.GetAssessmentByClassId(id);
            GoToEditAssessment(assessment);

        }
        async void GoToEditAssessment(Assessment assessment)
        {
            await Navigation.PushModalAsync(new EditItemPage(assessment));
        }

        public void AddAssessmentButtonClicked(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(courseIdLabel.Text);
            GoToAddAssessment(id);
        }
        async void GoToAddAssessment(int id)
        {
            await Navigation.PushModalAsync(new AddItemPage("assessment", id));
        }
    }
}
