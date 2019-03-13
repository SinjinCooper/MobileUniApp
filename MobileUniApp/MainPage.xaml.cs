using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using MobileUniApp.View;

namespace MobileUniApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            SetListSource();
        }

        //public void BuildMainPage()
        //{
        //    List<Term> list = App.DB.GetAllTerms();
        //    TermsListView.ItemsSource = list;

        //    List<Term> termList = App.DB.GetAllTerms();
        //    foreach (Term t in termList) {
        //        AddTermGrid(t);
        //    }
        //}

        public void SetListSource()
        {
            List<Term> list = App.DB.GetAllTerms();
            ObservableCollection<Term> ocTerms = new ObservableCollection<Term>(list);
            TermsListView.ItemsSource = ocTerms;
        }

        //public void AddTermGrid(Term term)
        //{
        //    Label termNameLabel = new Label { Text = term.Title, HorizontalTextAlignment = TextAlignment.Start };
        //    Label statusLabel = new Label { Text = term.Status, HorizontalTextAlignment = TextAlignment.End };
        //    Label dateRangeLabel = new Label { Text = "(date range)", HorizontalTextAlignment = TextAlignment.Start };
        //    Button termButton = new Button { ClassId = term.TermId.ToString(), BackgroundColor = Color.Transparent, TextColor = Color.Transparent };
        //    termButton.Clicked += OnTermClicked;
        //    Button editButton = new Button { ClassId = term.TermId.ToString(), Text = "Edit", HorizontalOptions = LayoutOptions.Start };
        //    editButton.Clicked += EditTermClicked;
        //    Button deleteButton = new Button { ClassId = term.TermId.ToString(), Text = "Delete" };
        //    deleteButton.Clicked += DeleteTermClicked;
        //    BoxView border = new BoxView { Color = Color.Black, WidthRequest = 100, HeightRequest = 3 };


        //    Grid grid = new Grid { RowSpacing = 0, ColumnSpacing = 0 };
        //    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        //    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        //    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
        //    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        //    grid.Children.Add(termNameLabel, 0, 0);
        //    grid.Children.Add(statusLabel, 1, 0);
        //    grid.Children.Add(dateRangeLabel, 0, 1);
        //    grid.Children.Add(termButton, 0, 0);
        //    grid.Children.Add(editButton, 0, 2);
        //    grid.Children.Add(deleteButton, 1, 2);
        //    Grid.SetRowSpan(statusLabel, 2);
        //    Grid.SetRowSpan(termButton, 2);
        //    Grid.SetColumnSpan(termButton, 2);

        //    TermsLayout.Children.Add(grid);
        //    TermsLayout.Children.Add(border);
        //}

        public void OnTermClicked(object sender, EventArgs e)
        {
            var id = ((Button)sender).ClassId;
            Term termClicked = App.DB.GetTermByClassId(id);
            Navigation.PushAsync(new TermPage(termClicked));
        }

        public void EditTermClicked(object sender, EventArgs e)
        {
            var id = ((Button)sender).ClassId;
            Term term = App.DB.GetTermByClassId(id);
            GoToEditTerm(term);
        }
        async void GoToEditTerm(Term term)
        {
            await Navigation.PushModalAsync(new EditItemPage(term));
        }

        public void DeleteTermClicked(object sender, EventArgs e)
        {
            var id = ((Button)sender).ClassId;
            Term term = App.DB.GetTermByClassId(id);
            App.DB.DeleteItem(term);
            SetListSource();
        }

        async void AddTermButtonClicked(object sender, EventArgs e)
        {
            var modalPage = new AddItemPage("term", 0);
            modalPage.Disappearing += (sender2, e2) =>
            {
                SetListSource();
                TermsLayout.VerticalOptions = LayoutOptions.FillAndExpand;
            };
            await Navigation.PushModalAsync(modalPage);
        }
    }
}
