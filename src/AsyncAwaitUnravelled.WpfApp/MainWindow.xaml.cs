using System.Windows;

namespace AsyncAwaitUnravelled.WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainWindowViewModel();
    }

    // Incorrect usage: Blocking the UI thread
    private void BadButton_Click(object sender, RoutedEventArgs e)
    {
        StatusText.Text = "Running...";

        #region Bad #1
        //LongRunningOperation().Wait();
        #endregion

        #region Bad #2
        int result = LongRunningGetOperation().Result;
        #endregion

        #region Bad #3
        //var result = LongRunningGetOperation().GetAwaiter().GetResult();
        #endregion

        StatusText.Text = "Completed";
    }

    // Correct usage: Not blocking the UI thread
    private async void GoodButton_Click(object sender, RoutedEventArgs e)
    {
        StatusText.Text = "Running...";

        #region Good
        await LongRunningOperation();
        #endregion

        #region Bad #4
        //LongRunningOperation().Wait();
        #endregion

        #region Bad #5
        //int result = LongRunningGetOperation().Result;
        #endregion

        StatusText.Text = "Completed";
    }

    private async Task LongRunningOperation()
    {
        await Task.Delay(5000); // Simulate a long-running task
    }

    private async Task<int> LongRunningGetOperation()
    {
        await Task.Delay(5000); // Simulate a long-running task
        return 1;
    }
}