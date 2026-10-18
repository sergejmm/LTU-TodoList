using System;

namespace LTU_Course_Final.Models;

public class ToDoItem
{
    public string? Name { get; set; }
    public string? Location { get; set; }
    public DateOnly? Date { get; set; }
    public bool Important { get; set; }

}