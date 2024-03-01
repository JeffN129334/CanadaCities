namespace CanadaCities
{
    /*
      * Class Name:        Program
      * Purpose:           Entry point of the application, contains the main method to execute the program
      * Coder:             Jeff Nesbitt and Gui Miranda
      * Date:              2024-02-26
      */
    public class Program
    {
        private const string XmlFilePath = "..\\..\\..\\Data\\Canadacities-XML.xml";
        private const string JsonFilePath = "..\\..\\..\\Data\\Canadacities-JSON.json";
        private const string CsvFilePath = "..\\..\\..\\Data\\Canadacities.csv";

        public static void Main()
        {
            //CityInfo city = new CityInfo();
            //city.PopulationChanging += PopulationChangingEventHandler;
            //city.CityName = "London";
            //city.Population = "50000";

            try
            {
                DisplayMenuHeader();

                Console.WriteLine("\tChoose a file type to load the cities from:\n");
                Console.WriteLine("\t1. XML");
                Console.WriteLine("\t2. JSON");
                Console.WriteLine("\t3. CSV");

                Console.Write("\nEnter your choice: ");
                int choice = GetValidChoice();

                Statistics stats = InitializeStatistics(choice);
                Console.Clear();

                bool exit = false;

                while (!exit)
                {
                    DisplayMenuOptions();
                    choice = GetValidChoice();

                    switch (choice)
                    {
                        case 1:
                            stats.DisplayCityInformation(GetInput("Enter city name: "));
                            break;
                        case 2:
                            stats.DisplayLargestCityPopulation(GetInput("Enter province name: "));
                            break;
                        case 3:
                            stats.DisplaySmallestCityPopulation(GetInput("Enter province name: "));
                            break;
                        case 4:
                            stats.CompareCitiesPopulation(GetInput("Enter first city name: "), GetInput("Enter second city name: "));
                            break;
                        case 5:
                            stats.ShowCityOnMap(GetInput("Enter city name: "));
                            break;
                        case 6:
                            string cityA = GetInput("Enter first city name: ");
                            string cityB = GetInput("Enter second city name: ");
                            double distance = stats.CalculateDistanceBetweenCities(cityA, cityB);
                            Console.WriteLine($"\nDistance between {cityA} and {cityB}: {Math.Round(distance, 2)}km\n");
                            break;
                        case 7:
                            stats.DisplayProvincePopulation(GetInput("Enter province name: "));
                            break;
                        case 8:
                            stats.DisplayProvinceCities(GetInput("Enter province name: "));
                            break;
                        case 9:
                            stats.GetCapital(GetInput("Enter province name: "));
                            break;
                        case 10:
                            stats.RankProvincesByPopulation();
                            break;
                        case 11:
                            stats.RankProvincesByCities();
                            break;
                        case 12:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }

                    if (!exit)
                    {
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }

                    Console.Clear();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private static int GetValidChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Choose a different option.");
                Console.Write("Enter your choice: ");
            }
            return choice;
        }

        private static Statistics InitializeStatistics(int choice)
        {
            return choice switch
            {
                1 => new Statistics(XmlFilePath, "XML"),
                2 => new Statistics(JsonFilePath, "JSON"),
                3 => new Statistics(CsvFilePath, "CSV"),
                _ => throw new ArgumentException("Invalid choice."),
            };
        }

        private static void DisplayMenuHeader()
        {
            Console.WriteLine("*-------------------------------------------------------------*");
            Console.WriteLine("*       Jeff Nesbitt and Gui Miranda's CanadaCities App       *");
            Console.WriteLine("*-------------------------------------------------------------*\n");
        }

        private static void DisplayMenuOptions()
        {
            DisplayMenuHeader();

            Console.WriteLine("\t1. Display City Information");
            Console.WriteLine("\t2. Display Largest City Population");
            Console.WriteLine("\t3. Display Smallest City Population");
            Console.WriteLine("\t4. Compare Cities Population");
            Console.WriteLine("\t5. Show City On Map");
            Console.WriteLine("\t6. Calculate Distance Between Cities");
            Console.WriteLine("\t7. Display Province Population");
            Console.WriteLine("\t8. Display Province Cities");
            Console.WriteLine("\t9. Get Capital");
            Console.WriteLine("\t10. Rank Provinces By Population");
            Console.WriteLine("\t11. Rank Provinces By Cities");
            Console.WriteLine("\t12. Exit");

            Console.Write("\nEnter your choice: ");
        }

        private static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? "";
        }

        private static void PopulationChangingEventHandler(object sender, CityPopulationChangeEvent e)
        {
            Console.WriteLine($"Population of {e.CityName} is changing from {e.OldPopulation} to {e.NewPopulation}");
        }
    }
}
