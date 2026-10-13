using CommunityToolkit.Mvvm.ComponentModel;
using TodoList_LTU_Course.Models;

namespace TodoList_LTU_Course.ViewModels;

public partial class ToDoItemViewModel : ViewModelBase
{
    public ToDoItemViewModel() { }

    public ToDoItemViewModel(ToDoItem item)
    {
        IsChecked = item.IsChecked;
        Content = item.Content;
    }
    
    
    private bool _isChecked;

    public bool IsChecked
    {
        get {return _isChecked;}
        set
        {
            SetProperty(ref _isChecked, value);
        }
    }
    
    [ObservableProperty]
    public partial string? Content { get; set; }

    public ToDoItem GetToDoItem()
    {
        return new ToDoItem()
        {
            IsChecked = this.IsChecked,
            Content = this.Content
        };
    }
    
}