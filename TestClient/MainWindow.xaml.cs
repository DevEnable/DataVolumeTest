using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DataVolume;
using DataVolume.Model;
using Ploeh.AutoFixture;

namespace TestClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int NumberOfRecords => int.Parse(NumRecords.Text);

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

        private async void LargeDataTablesButton_Click(object sender, RoutedEventArgs e)
        {
            HeavyRepository repository = new HeavyRepository();
            Fixture fixture = new Fixture();

            var items = Enumerable.Range(1, NumberOfRecords).Select(i => fixture.Create<HeavyTvp>());

            Stopwatch watch = new Stopwatch();

            watch.Start();

            await repository.ExecuteCommit(items);

            watch.Stop();

            LastCommandOutput.Content = $"Executed large DataTable's command in {watch.Elapsed}";
        }
    }
}
