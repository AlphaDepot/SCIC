
using System.Windows;
using System.Windows.Media;
using SCIC.ViewModels;


namespace SCIC;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    
    private MainWindowViewModel ViewModel => (MainWindowViewModel)DataContext;

    public MainWindow()
    {
        DataContext =  new MainWindowViewModel();
        InitializeComponent();
    }

    
    private void Button_Calculate(object sender, RoutedEventArgs e)
    {
        ViewModel.CalculateCommand.Execute(null);
    }
}