using System;
using IMDBService;

namespace IMDBApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {

            bool isExit = false;
            int choice, producerIdx, year;
            string name, plot, actorsString, dob;
            

            ApplicationService applicationService = new ApplicationService();


            while (!isExit)
            {

                Console.WriteLine("\nPress 1-6 to choose an option\n1.List Movies\n2.Add Movie\n3.Add Actor\n4.Add Producer\n5.Delete Movie\n6.Exit\n");
            
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid choice, Select the valid option again: " + ex);
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        applicationService.ListMovies();
                        break;

                    case 2:
                        Console.WriteLine("Enter Movie Name:");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter Movie Plot");
                        plot = Console.ReadLine();
                       
                        Console.WriteLine("Enter Movie Year of release");
                        year = int.Parse(Console.ReadLine());
                       
                        Console.WriteLine("Choose Producer:");

                        applicationService.ShowAllProducers();
                      
                        producerIdx = int.Parse(Console.ReadLine());
           
                        Console.WriteLine("Choose Actors");
                        applicationService.ShowAllActors();
                        actorsString = Console.ReadLine();
                       
                        applicationService.AddMovie(name,plot,year,producerIdx,actorsString);
                        break;

                    case 3:
                        Console.WriteLine("Enter Actor Name:");
                        name = Console.ReadLine();
                        
                        Console.WriteLine("Enter Date of Birth in the format dd/mm/yyyy");
                        dob = Console.ReadLine();
               
                        applicationService.AddActor(name, dob);
                        break;

                    case 4:
                        Console.WriteLine("Enter Producer Name:");
                        name = Console.ReadLine();
                    
                        Console.WriteLine("Enter Date of Birth in the format dd/mm/yyyy");
                        dob = Console.ReadLine();
               
                        applicationService.AddProducer(name, dob);
                        break;
                        
                    case 5:
                        Console.WriteLine("Choose a Movie to Delete");
                        applicationService.ShowAllMovies();
                        applicationService.DeleteMovie(int.Parse(Console.ReadLine()));
                        break;

                    case 6:
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice, Select a valid option");
                        break;

                }

                Console.WriteLine();
            }
        }
    }
}
