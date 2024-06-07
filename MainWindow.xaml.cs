using FirebaseAdmin.Messaging;
using SendPentaNotification.ViewModel;
using System.Windows;

namespace SendPentaNotification;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        this.DataContext = viewModel;
    }
}