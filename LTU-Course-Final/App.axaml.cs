        using System.Collections.Generic;
        using System.Linq;
        using System.Threading.Tasks;
        using Avalonia;
        using Avalonia.Controls.ApplicationLifetimes;
        using Avalonia.Markup.Xaml;
        using LTU_Course_Final.Models;
        using LTU_Course_Final.Services;
        using LTU_Course_Final.ViewModels;
        using LTU_Course_Final.Views;

        namespace LTU_Course_Final;

        public partial class App : Application
        {
            private readonly MainViewModel _mainViewModel = new();
            private bool _canClose;

            private async void DesktopOnShutdownRequested(object? sender, ShutdownRequestedEventArgs e)
            {
                e.Cancel = !_canClose;
                if (!_canClose)
                {
                    IEnumerable<ToDoItem> itemToSave = _mainViewModel.ToDoItems.Select(item => item.GetToDoItem());
                    await ToDoListFileServices.saveFileAsync(itemToSave);
                    
                    _canClose = true;
                    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) desktop.Shutdown();
                }
            }

            private async Task InitMainViewModelAsync()
            {
                IEnumerable<ToDoItem> itemLoaded = await ToDoListFileServices.loadFileAsync();
                if (itemLoaded is not null)
                {
                    foreach (ToDoItem item in itemLoaded)
                        _mainViewModel.ToDoItems.Add(new ToDoItemViewModel(item));
                }
            }

            public override void Initialize()
            {
                AvaloniaXamlLoader.Load(this);
            }

            public override async void OnFrameworkInitializationCompleted()
            {
                if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                {
                    desktop.MainWindow = new MainWindow
                    {
                        DataContext = _mainViewModel,
                    };
                    desktop.ShutdownRequested += DesktopOnShutdownRequested;
                }

                base.OnFrameworkInitializationCompleted();
                await InitMainViewModelAsync();
            }
        }