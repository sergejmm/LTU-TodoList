using System;
using CommunityToolkit.Mvvm.ComponentModel;
using LTU_Course_Final.Models;

namespace LTU_Course_Final.ViewModels;

public partial class ToDoItemViewModel : ViewModelBase
{
    [ObservableProperty] public partial string? Name { get; set; }
    [ObservableProperty] public partial string? Location { get; set; }
    [ObservableProperty] public partial DateOnly? Date { get; set; }
    [ObservableProperty] public partial bool Important { get; set; }

    /// <summary>
    /// Construct for making ew objects to store in main viewmodel list
    /// </summary>
    public ToDoItemViewModel()
    {
    }


    /// <summary>
    /// Constructor used for loading from save file 
    /// </summary>
    public ToDoItemViewModel(ToDoItem item)
    {
        Name = item.Name;
        Location = item.Location;
        Date = item.Date;
        Important = item.Important;
    }

    /// <summary>
    /// Method used for saving to save file
    /// </summary>
    public ToDoItem GetToDoItem()
    {
        return new ToDoItem
        {
            Name = Name,
            Location = Location,
            Date = Date,
            Important = Important
        };
    }
}