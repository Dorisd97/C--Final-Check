using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.MovieCruiser.Model;
using Com.Cognizant.MovieCruiser.Dao;

namespace MovieCruiser
{
    class CustomException : Exception
    {
        public CustomException(string msg) : base(msg)
        {

        }
    }

    public class Program
    {
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(40, 2);

            List<Movie> movieList = new List<Movie>();

            List<Movie> favoritesMovieList = new List<Movie>();

            Dictionary<int, Customer> customerList = new Dictionary<int, Customer>()
            {
                {1, new Customer(1,"Doris") },
                {2, new Customer(2,"Sahitya") },
                {3, new Customer(3,"Dan") },
                {4, new Customer(4, "Virat") }
            };

            Console.WriteLine("Welcome to Movie Cruiser!\n");
            Console.WriteLine("If you are an admin, enter 1. If you are a customer, enter 2");

            try
            {
                int userType = Convert.ToInt16(Console.ReadLine());
                if (userType != 1 && userType != 2)
                    throw new CustomException("Wrong Entry!");

                if (userType == 1)
                {
                    Admin admin = new Admin();
                    Console.WriteLine("Enter your name:");
                    admin.AdminName = Console.ReadLine();
                    Console.WriteLine("Enter your admin ID:");
                    admin.AdminId = Convert.ToInt16(Console.ReadLine());

                    if (admin.AdminName == "Doris" && admin.AdminId == 123)
                    {
                        int flag = 1;

                        Console.WriteLine("Logged in succcesfully as admin");

                        while (flag == 1)
                        {
                            Console.WriteLine("\nEnter 1 to view movie list \nEnter 2 to edit movie\nEnter 0 to exit");
                            int adminChoice = Convert.ToInt16(Console.ReadLine());
                            if (adminChoice < 0 || adminChoice > 2)
                                throw new CustomException("Wrong Choice selected!");

                            if (adminChoice == 1)
                            {
                                admin.DisplayMovieListByAdmin();
                            }
                            else if (adminChoice == 2)
                            {
                                admin.DisplayMovieListByAdmin();
                                Console.WriteLine("Enter the title of the movie you want to edit:");
                                string title = Console.ReadLine();
                                admin.EditMovie(title);
                            }
                            else if (adminChoice == 0)
                            {
                                flag = 0;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong Credentials!");
                    }
                }

                else if (userType == 2)
                {
                    Console.WriteLine("Enter your id:");
                    int customerID = Convert.ToInt16(Console.ReadLine());

                    if (customerList.ContainsKey(customerID))
                    {
                        Customer customer = new Customer((Customer)customerList[customerID]);
                        Console.WriteLine("Welcome " + customer.CustomerName + "!");
                        int flag = 1;

                        while (flag == 1)
                        {
                            Console.WriteLine("\nEnter 1 to view movie list \nEnter 2 to add movie to favorites\nEnter 3 to view favorites\nEnter 4 to remove item from favorites\nEnter 0 to exit");
                            int customerChoice = Convert.ToInt16(Console.ReadLine());
                            if (customerChoice < 0 || customerChoice > 4)
                                throw new CustomException("Wrong Choice selected!");

                            if (customerChoice == 1)
                            {
                                customer.DisplayMovieListByCustomer();
                            }
                            else if (customerChoice == 2)
                            {
                                customer.DisplayMovieListByCustomer();
                                Console.WriteLine("Enter the title of the movie you want to add to favorites:");
                                string title = Console.ReadLine();
                                customer.AddMovieToFavorites(title);
                            }
                            else if (customerChoice == 3)
                            {
                                customer.ViewFavorites();
                            }
                            else if (customerChoice == 4)
                            {
                                customer.ViewFavorites();
                                Console.WriteLine("Enter the id of the movie you want to remove from favorites:");
                                int id = Convert.ToInt16(Console.ReadLine());
                                customer.RemoveMovieFromFavorites(id);
                            }
                            else if (customerChoice == 0)
                            {
                                flag = 0;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong Credentials!");
                    }
                }
            }

            catch (CustomException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
