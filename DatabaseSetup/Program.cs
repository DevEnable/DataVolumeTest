using System;
using System.Configuration;
using System.Reflection;
using DbUp;
using DbUp.Engine;

namespace DatabaseSetup
{
    public class Program
    {
        static int Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

            UpgradeEngine engine =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            if (!engine.IsUpgradeRequired())
            {
                Console.WriteLine("No upgrade required, database is already up to date.");
                return 0;
            }

            return PerformUpgrade(engine);
        }

        private static int PerformUpgrade(UpgradeEngine engine)
        {
            var result = engine.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();

                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
