using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ToDoList
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ToDoItem> ToDoItems = new ObservableCollection<ToDoItem>();

        public MainPage()
        {
            InitializeComponent();

            ToDoListView.ItemsSource = ToDoItems;
        }

        public async void GoAddPage(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage(ToDoItems));
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var toDoItem = button.CommandParameter as ToDoItem;
            ToDoItems.Remove(toDoItem);
        }

        public async void GoEditPage(System.Object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var selectedItem = e.SelectedItem as ToDoItem;
            var editItemPage = new EditItemPage(ToDoItems, selectedItem);
            await Navigation.PushAsync(editItemPage);
            ToDoListView.SelectedItem = null;
        }

    }

    public class ToDoItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ID = 0;
    }

}
