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
        public static void Main()
        {
            //CityInfo city = new CityInfo();
            //city.PopulationChanging += PopulationChangingEventHandler;
            //city.CityName = "London";
            //city.Population = "50000";

            try
            {
                Statistics stats = new Statistics("..\\..\\..\\Data\\Canadacities-XML.xml", "XML");
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("*-------------------------------------------------------------*");
                    Console.WriteLine("*       Jeff Nesbitt and Gui Miranda's CanadaCities App       *");
                    Console.WriteLine("*-------------------------------------------------------------*\n");
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
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter city name: ");
                            string city = Console.ReadLine()!;
                            stats.DisplayCityInformation(city);
                            break;
                        case 2:
                            Console.Write("Enter province name: ");
                            string province1 = Console.ReadLine()!;
                            stats.DisplayLargestCityPopulation(province1);
                            break;
                        case 3:
                            Console.Write("Enter province name: ");
                            string province2 = Console.ReadLine()!;
                            stats.DisplaySmallestCityPopulation(province2);
                            break;
                        case 4:
                            Console.Write("Enter first city name: ");
                            string city1 = Console.ReadLine()!;
                            Console.Write("Enter second city name: ");
                            string city2 = Console.ReadLine()!;
                            stats.CompareCitiesPopulation(city1, city2);
                            break;
                        case 5:
                            Console.Write("Enter city name: ");
                            string cityToShow = Console.ReadLine()!;
                            stats.ShowCityOnMap(cityToShow);
                            break;
                        case 6:
                            Console.Write("Enter first city name: ");
                            string cityA = Console.ReadLine()!;
                            Console.Write("Enter second city name: ");
                            string cityB = Console.ReadLine()!;
                            double distance = stats.CalculateDistanceBetweenCities(cityA, cityB);
                            Console.WriteLine($"\nDistance between {cityA} and {cityB}: {Math.Round(distance, 2)}km\n");
                            break;
                        case 7:
                            Console.Write("Enter province name: ");
                            string province3 = Console.ReadLine()!;
                            stats.DisplayProvincePopulation(province3);
                            break;
                        case 8:
                            Console.Write("Enter province name: ");
                            string province4 = Console.ReadLine()!;
                            stats.DisplayProvinceCities(province4);
                            break;
                        case 9:
                            Console.Write("Enter province name: ");
                            string province5 = Console.ReadLine()!;
                            stats.GetCapital(province5);
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

        //Event handler method for the PopulationChanging event
        static void PopulationChangingEventHandler(object sender, CityPopulationChangeEvent e)
        {
            //Your event handling logic goes here
            Console.WriteLine($"Population of {e.CityName} is changing from {e.OldPopulation} to {e.NewPopulation}");
        }
    }
}
