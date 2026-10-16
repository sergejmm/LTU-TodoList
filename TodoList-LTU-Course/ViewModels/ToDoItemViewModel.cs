using CommunityToolkit.Mvvm.ComponentModel;
using TodoList_LTU_Course.Models;

namespace TodoList_LTU_Course.ViewModels;

public partial class ToDoItemViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isChecked;
    [ObservableProperty] private string? _content;

    public ToDoItemViewModel()
    {
    }

    public ToDoItemViewModel(ToDoItem item)
    {
        _isChecked = item.IsChecked;
        _content = item.Content;
    }


    public ToDoItem GetToDoItem()
    {
        return new ToDoItem
        {
            IsChecked = _isChecked,
            Content = _content
        };
    }
}