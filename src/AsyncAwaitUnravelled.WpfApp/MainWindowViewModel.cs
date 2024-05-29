using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AsyncAwaitUnravelled.WpfApp;

public sealed partial class MainWindowViewModel : ObservableObject
{
    [RelayCommand]
    public Task DoLongStuff()
    {
        LongRunningOperation().Wait();
        return Task.CompletedTask;
    }

    private Task LongRunningOperation()
    {
        return Task.Delay(5000); // Simulate a long-running task
    }
}
