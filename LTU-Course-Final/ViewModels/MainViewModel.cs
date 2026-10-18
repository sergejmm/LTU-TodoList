using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LTU_Course_Final.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    /// <summary>
    /// Store observable collection of toDoItem objects to display it in UI
    /// </summary>
    public ObservableCollection<ToDoItemViewModel> ToDoItems { get; } = new();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
    public partial string? NewItemName { get; set; }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
    public partial string? NewItemLocation { get; set; }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
    public partial DateTimeOffset NewItemDate { get; set; } = DateTimeOffset.Now;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
    public partial bool NewItemImportant { get; set; }


    /// <summary>
    /// Helper method to lock button if the info isn't filled 
    /// </summary>
    private bool CanAddItem() => !string.IsNullOrWhiteSpace(NewItemName) &&
                                 !string.IsNullOrWhiteSpace(NewItemLocation) &&
                                 NewItemDate != null;

    /// <summary>
    /// Command used in a button to add all the info to list
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanAddItem))]
    private void AddItem()
    {
        DateTimeOffset a;
        ToDoItems.Add(new ToDoItemViewModel
        {
            Name = NewItemName,
            Location = NewItemLocation,
            Date = ToDateOnly(NewItemDate.DateTime),
            Important = NewItemImportant
        });
    }

    /// <summary>
    /// Command used in button to remove each of the elements individually 
    /// </summary>
    [RelayCommand]
    private void RemoveItem(ToDoItemViewModel item)
    {
        ToDoItems.Remove(item);
    }

    public static DateOnly? ToDateOnly(DateTime datetime) => DateOnly.FromDateTime(datetime);
}