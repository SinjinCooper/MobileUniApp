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
            courseIdLabel.Text = "Course Id: " + course.CourseId.ToString();
            BuildCoursePage(course);
        }

        public void BuildCoursePage(Course course)
        {
            List<Assessment> assessments = App.DB.GetAssessmentsByCourse(course);
            foreach(Assessment a in assessments) {
                AddAssessmentGrid(a);
            }

            AddInstructorGrid(course.Instructor);

        }

        public void AddAssessmentGrid(Assessment assessment)
        {
            // To do
        }

        public void AddInstructorGrid(Instructor instructor)
        {
            //to do 
        }

        public void EditButtonClicked(object sender, EventArgs e)
        {

        }

        public void AddAssessmentButtonClicked(object sender, EventArgs e)
        {

        }
    }
}
