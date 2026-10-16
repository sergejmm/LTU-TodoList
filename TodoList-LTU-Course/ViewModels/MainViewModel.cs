using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TodoList_LTU_Course.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public ObservableCollection<ToDoItemViewModel> ToDoItems { get; } = new();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
    public partial string? NewItemContent { get; set; }

    private bool CanAddItem() => !string.IsNullOrWhiteSpace(NewItemContent);

    [RelayCommand(CanExecute = nameof(CanAddItem))]
    private void AddItem()
    {
        ToDoItems.Add(new ToDoItemViewModel { Content = NewItemContent });
        NewItemContent = null;
    }

    [RelayCommand]
    private void RemoveItem(ToDoItemViewModel item)
    {
        ToDoItems.Remove(item);
    }
}