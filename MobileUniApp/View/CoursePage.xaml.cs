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
            //course.Instructor.CourseId = course.CourseId;
            instructorName.Text = course.Instructor.Name;
            instructorPhone.Text = course.Instructor.Phone;
            instructorEmail.Text = course.Instructor.Email;
            editInstructorButton.ClassId = course.Instructor.InstructorId.ToString();

            if (course.Notes != null) {
                notesEditor.Text = course.Notes;
            }
        }

        public void AddAssessmentGrid(Assessment assessment)
        {
            Label nameLabel = new Label { Text = assessment.Title, HorizontalTextAlignment = TextAlignment.Start };
            Label typeLabel = new Label { Text = assessment.AssessmentType, HorizontalTextAlignment = TextAlignment.End };
            Label dateRangeLabel = new Label { Text = "(date range)", HorizontalTextAlignment = TextAlignment.Start };
            Button editButton = new Button { ClassId = assessment.AssessmentId.ToString(), Text = "Edit", HorizontalOptions = LayoutOptions.Start };
            editButton.Clicked += EditAssessmentClicked;
            Button deleteButton = new Button { ClassId = assessment.AssessmentId.ToString(), Text = "Delete" };
            deleteButton.Clicked += DeleteAssessmentClicked;
            BoxView border = new BoxView { Color = Color.Black, WidthRequest = 100, HeightRequest = 3 };

            Grid grid = new Grid { RowSpacing = 0, ColumnSpacing = 0 };
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.Children.Add(nameLabel, 0, 0);
            grid.Children.Add(typeLabel, 1, 0);
            grid.Children.Add(dateRangeLabel, 0, 1);
            grid.Children.Add(editButton, 0, 2);
            grid.Children.Add(deleteButton, 1, 2);
            Grid.SetRowSpan(typeLabel, 2);

            AssessmentsLayout.Children.Add(grid);
            AssessmentsLayout.Children.Add(border);
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


        public void DeleteAssessmentClicked(object sender, EventArgs e)
        {

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


        public void EditInstructorClicked(object sender, EventArgs e)
        {
            var id = ((Button)sender).ClassId;
            //Instructor instructor = App.DB.GetInstructorByCourseId(id);

        }
        async void GoToEditInstructor(Instructor instructor)
        {
            await Navigation.PushModalAsync(new EditItemPage(instructor));
        }
    }
}
