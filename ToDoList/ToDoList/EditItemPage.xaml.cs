using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ToDoList
{
    public partial class EditItemPage : ContentPage
    {
        private readonly ObservableCollection<ToDoItem> _toDoItems;
        private readonly ToDoItem _toDoItem;

        public EditItemPage(ObservableCollection<ToDoItem> toDoItems, ToDoItem toDoItem)
        {
            InitializeComponent();

            _toDoItems = toDoItems;
            _toDoItem = toDoItem;
            ToDoItemEntry.Text = toDoItem.Title;
            ToDoDescriptionEntry.Text = toDoItem.Description;
        }

        private async void OnEditButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ToDoItemEntry.Text) && !string.IsNullOrEmpty(ToDoDescriptionEntry.Text))
            {
                _toDoItem.Title = ToDoItemEntry.Text;
                _toDoItem.Description = ToDoDescriptionEntry.Text;
                int index = _toDoItems.IndexOf(_toDoItem);
                _toDoItems[index] = _toDoItem;

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Please enter both title and description!", "OK");
            }
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            _toDoItems.Remove(_toDoItem);
            await Navigation.PopAsync();
        }
    }
}
