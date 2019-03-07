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
            termIdLabel.Text = term.TermId.ToString();
            BuildTermPage(term);
        }

        public void BuildTermPage(Term term)
        {
            List<Course> coursesList = App.DB.GetCoursesByTerm(term);
            foreach(Course c in coursesList) {
                AddCourseGrid(c);
            }
        }

        public void AddCourseGrid(Course course)
        {
            Label courseNameLabel = new Label { Text = course.Title, HorizontalTextAlignment = TextAlignment.Start };
            Label statusLabel = new Label { Text = course.Status, HorizontalTextAlignment = TextAlignment.End };
            Label dateRangeLabel = new Label { Text = "(date range)", HorizontalTextAlignment = TextAlignment.Start };
            Button termButton = new Button { ClassId = course.CourseId.ToString(), BackgroundColor = Color.Transparent, TextColor = Color.Transparent };
            termButton.Clicked += OnCourseClicked;
            Button editButton = new Button { ClassId = course.CourseId.ToString(), Text = "Edit", HorizontalOptions = LayoutOptions.Start };
            editButton.Clicked += EditCourseClicked;
            Button deleteButton = new Button { ClassId = course.CourseId.ToString(), Text = "Delete" };
            deleteButton.Clicked += DeleteCourseClicked;
            BoxView border = new BoxView { Color = Color.Black, WidthRequest = 100, HeightRequest = 3 };


            Grid grid = new Grid { RowSpacing = 0, ColumnSpacing = 0 };
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.Children.Add(courseNameLabel, 0, 0);
            grid.Children.Add(statusLabel, 1, 0);
            grid.Children.Add(dateRangeLabel, 0, 1);
            grid.Children.Add(termButton, 0, 0);
            grid.Children.Add(editButton, 0, 2);
            grid.Children.Add(deleteButton, 1, 2);
            Grid.SetRowSpan(statusLabel, 2);
            Grid.SetRowSpan(termButton, 2);
            Grid.SetColumnSpan(termButton, 2);

            CoursesLayout.Children.Add(grid);
            CoursesLayout.Children.Add(border);
        }

        public void OnCourseClicked(object sender, EventArgs e)
        {
            var id = ((Button)sender).ClassId;
            Course course = App.DB.GetCourseByClassId(id);
            Navigation.PushAsync(new CoursePage(course));
        }

        public void EditCourseClicked(object sender, EventArgs e)
        {
            var id = ((Button)sender).ClassId;
            Course course = App.DB.GetCourseByClassId(id);
            GoToEditCourse(course);
        }
        async void GoToEditCourse(Course course)
        {
            await Navigation.PushModalAsync(new EditItemPage(course));
        }

        public void DeleteCourseClicked(object sender, EventArgs e)
        {
            var id = ((Button)sender).ClassId;
            Course course = App.DB.GetCourseByClassId(id);
            App.DB.DeleteItem(course);
        }

        public void AddCourseButtonClicked(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(termIdLabel.Text);
            GoToAddCourse(id);
        }
        async void GoToAddCourse(int id)
        {
            await Navigation.PushModalAsync(new AddItemPage("course", id));
        }
    }
}
