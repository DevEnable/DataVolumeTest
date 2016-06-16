using System;
using System.Threading.Tasks;
using System.Windows;
using DataVolume;

namespace TestClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ResetDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            ResetRepository repository = new ResetRepository();

            await repository.ResetTable();

            LastCommandOutput.Content = "Database reset";
        }

        private void OutputResult(DateTime start, DateTime stop)
        {
            
        }
    }
}
