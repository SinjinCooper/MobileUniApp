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
            termIdLabel.Text = "Term Id: " + term.TermId.ToString();
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
            Button termButton = new Button { ClassId = course.TermId.ToString(), BackgroundColor = Color.Transparent, TextColor = Color.Transparent };
            termButton.Clicked += OnCourseClicked;
            Button editButton = new Button { ClassId = course.TermId.ToString(), Text = "Edit", HorizontalOptions = LayoutOptions.Start };
            editButton.Clicked += EditCourseClicked;
            Button deleteButton = new Button { ClassId = course.TermId.ToString(), Text = "Delete" };
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
            Course courseClicked = App.DB.GetCourseByClassId(id);
            // Navigate to course 
        }

        public void EditCourseClicked(object sender, EventArgs e)
        {

        }

        public void DeleteCourseClicked(object sender, EventArgs e)
        {

        }

        async void AddCourseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddItemPage("course"));
        }
    }
}
