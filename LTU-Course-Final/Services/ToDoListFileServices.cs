using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using LTU_Course_Final.Models;

namespace LTU_Course_Final.Services;

using Path = Path;

public class ToDoListFileServices
{
    private static string _jsonFileName =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Avalonia.TodoList-LTU-Course", "MyToDoList.txt");

    public static async Task saveFileAsync(IEnumerable<ToDoItem> itemsToSave)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_jsonFileName)!);
        await using FileStream fs = File.Create(_jsonFileName);
        await JsonSerializer.SerializeAsync(fs, itemsToSave);
    }

    public static async Task<IEnumerable<ToDoItem>?> loadFileAsync()
    {
        try
        {
            await using FileStream fs = File.OpenRead(_jsonFileName);
            return await JsonSerializer.DeserializeAsync<IEnumerable<ToDoItem>>(fs);
        }
        catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException)
        {
            return null;
        }
    }
}