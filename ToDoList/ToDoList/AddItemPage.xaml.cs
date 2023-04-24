using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ToDoList
{	
	public partial class AddItemPage : ContentPage
	{
        private readonly ObservableCollection<ToDoItem> _toDoItems;


        public AddItemPage(ObservableCollection<ToDoItem> toDoItems)
        {
            InitializeComponent();

            _toDoItems = toDoItems;
        }
        private int _currentID = 0;
        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ToDoItemEntry.Text) && !string.IsNullOrEmpty(ToDoDescriptionEntry.Text))
            {
                var newToDoItem = new ToDoItem { Title = ToDoItemEntry.Text, Description = ToDoDescriptionEntry.Text, ID = ++_currentID };
                _toDoItems.Add(newToDoItem);
                ToDoItemEntry.Text = string.Empty;
                ToDoDescriptionEntry.Text = string.Empty;
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Please enter both title and description!", "OK");
            }
        }

    }
}

