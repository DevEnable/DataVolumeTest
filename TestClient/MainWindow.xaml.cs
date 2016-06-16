using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using DataVolume;
using DataVolume.Model;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;

namespace TestClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
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

        private async void OptimisedSqlButton_Click(object sender, RoutedEventArgs e)
        {
            LightRepository repository = new LightRepository();
            int repeatableDataCount = NumberOfRecords / 10;

            if (repeatableDataCount < 1)
            {
                repeatableDataCount = 1;
            }

            Fixture fixture = new Fixture();

            var lookups = Enumerable.Range(1, repeatableDataCount).Select(i => fixture.Create<LightLookup>()).ToList();
            fixture.Customizations.Add(new LookupIdBuilder(lookups.Select(l => l.Id).ToArray()));
            var items = Enumerable.Range(1, NumberOfRecords).Select(i => fixture.Create<LightTvp>()).ToList();

            Stopwatch watch = new Stopwatch();

            watch.Start();

            await repository.ExecuteCommit(items, lookups);

            watch.Stop();

            LastCommandOutput.Content = $"Executed light DataTable's command in {watch.Elapsed}";
        }

        private class LookupIdBuilder : ISpecimenBuilder
        {
            private readonly int[] _lookupIds;
            private readonly Random _random = new Random();

            public LookupIdBuilder(int[] lookupIds)
            {
                _lookupIds = lookupIds;
            }

            public object Create(object request, ISpecimenContext context)
            {
                var pi = request as PropertyInfo;
                if (pi == null ||
                    pi.Name != "RepeatableId" ||
                    pi.PropertyType != typeof (int))
                {
                    return new NoSpecimen();
                }

                return _lookupIds[_random.Next(0, _lookupIds.Length)];
            }
        }

    }
}
