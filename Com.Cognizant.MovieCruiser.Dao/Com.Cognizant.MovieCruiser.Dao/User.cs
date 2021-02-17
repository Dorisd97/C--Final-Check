using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.MovieCruiser.Model;

namespace Com.Cognizant.MovieCruiser.Dao
{
    abstract public class User
    {
        abstract public List<Movie> GetMovieList();
        public List<Movie> movieList = new List<Movie>()
    {
        new Movie(1, "Avatar", 2787965087, true, "15/03/2017", "Science Fiction", true),
        new Movie(2, "The Avengers", 1518812988, true, "23/12/2017", "Superhero", false),
        new Movie(3, "Titanic", 2187463944, true, "21/08/2017", "Romance", false),
        new Movie(4, "Jurassic World", 1671713208, false, "02/07/2017", "Science Fiction", true),
        new Movie(5, "Avengers: End Game", 2750760348, true, "02/11/2022", "Superhero", true)
    };
    }

    public class Admin : User
    {
        int adminId;
        public int AdminId
        {
            get { return adminId; }
            set { adminId = value; }
        }

        string adminName;
        public string AdminName
        {
            get { return adminName; }
            set { adminName = value; }
        }

        public override List<Movie> GetMovieList()
        {
            return movieList;
        }

        public void DisplayMovieListByAdmin()
        {
            movieList = GetMovieList();
            string active = "";
            string teaser = "";
            Console.WriteLine("ID  Title               Box Office($)    Active    Date of launch   Genre               Has teaser");

            foreach (Movie movie in movieList)
            {
                if (movie.Active)
                {
                    active = "Yes";
                }
                else
                {
                    active = "No";
                }

                if (movie.HasTeaser == true)
                {
                    teaser = "Yes";
                }
                else
                {
                    teaser = "No";
                }

                Console.WriteLine("{0}   {1,-18}  {2,-13}    {3,-6}    {4,-14}   {5,-15}     {6}", movie.Id, movie.Title, movie.BoxOffice, active, movie.DateOfLaunch, movie.Genre, teaser);
            }
        }

        public void EditMovieListByAdmin(string title)
        {
            movieList = GetMovieList();
            foreach (Movie movie in movieList)
            {
                if (title == movie.Title)
                {
                    Console.WriteLine("Enter the Correct Title:");
                    movie.Title = Console.ReadLine();

                    Console.WriteLine("Enter the Correct Box Office Collection in $:");
                    movie.BoxOffice = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Enter 'true' if Active or enter 'false' if not active:");
                    movie.Active = Convert.ToBoolean(Console.ReadLine());

                    Console.WriteLine("Enter the Correct Date of Launch in dd/mm/yyyy format:");
                    movie.DateOfLaunch = Console.ReadLine();

                    Console.WriteLine("Enter the Correct Genre:");
                    movie.Genre = Console.ReadLine();

                    Console.WriteLine("Enter 'true' if it has teaser or enter 'false' if it has no teaser:");
                    movie.HasTeaser = Convert.ToBoolean(Console.ReadLine());

                    Console.WriteLine("Movie details edited successfully");
                    break;
                }
            }
        }
    }

    public class Customer : User
    {
        int customerId;
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        string customerName;
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public Customer() { }

        public Customer(int customerId, string customerName)
        {
            this.CustomerId = customerId;
            this.CustomerName = customerName;
        }

        public Customer(Customer customer)
        {
            CustomerId = customer.CustomerId;
            CustomerName = customer.CustomerName;
        }

        public List<Movie> favoritesMovieList = new List<Movie>()
    {
        new Movie(1, "Avatar", 2787965087, true, "15/03/2017", "Science Fiction", true),
        new Movie(2, "The Avengers", 1518812988, true, "23/12/2017", "Superhero", false),
        new Movie(3, "Titanic", 2187463944, true, "21/08/2017", "Romance", false),
    };


        public override List<Movie> GetMovieList()
        {
            return movieList;
        }
        public void DisplayMovieListByCustomer()
        {
            movieList = GetMovieList();
            string teaser = "";
            Console.WriteLine("ID  Title               Box Office($)    Genre               Has teaser");

            for (int i = 0; i < movieList.Count() - 2; i++)
            {
                if (movieList[i].HasTeaser == true)
                {
                    teaser = "Yes";
                }
                else
                {
                    teaser = "No";
                }

                Console.WriteLine("{0}   {1,-18}  {2,-13}    {3,-15}     {4}", movieList[i].Id, movieList[i].Title, movieList[i].BoxOffice, movieList[i].Genre, teaser);
            }
        }

        public List<Movie> GetFavoritesMovieList()
        {
            return favoritesMovieList;
        }

        public void AddMovieToFavoritesMovieList(string title)
        {
            movieList = GetMovieList();
            favoritesMovieList = GetFavoritesMovieList();
            int id;
            int flag = 1;


            foreach (Movie movie in favoritesMovieList)
            {
                if (movie.Title == title)
                {

                    flag = 0;
                    break;
                }
            }

            if (flag == 0)
            {
                Console.WriteLine("Movie is already added to favorites");
            }

            else if (flag == 1)
            {
                foreach (Movie movie in movieList)
                {
                    if (movie.Title == title)
                    {
                        id = movie.Id - 1;
                        favoritesMovieList.Insert(id, movieList[id]);
                        Console.WriteLine("Movie added to favorites succesfully");
                        break;
                    }
                }
            }
        }

        //public void AddMovieToFavorites(int id)
        //{
        //    movieList = GetMovieList();
        //    favoritesMovieList = GetFavoritesMovieList();
        //    int i = id - 1;
        //    string title = movieList[i].Title;
        //    int flag = 1;

        //    foreach (Movie movie in favoritesMovieList)
        //    {
        //        if (movie.Title == title)
        //        {
        //            flag = 0;
        //            break;
        //        }
        //    }

        //    if (flag == 0)
        //    {
        //        Console.WriteLine("Movie is already added to favorites");
        //    }

        //    else if (flag == 1)
        //    {
        //        favoritesMovieList.Insert(i, movieList[i]);
        //        Console.WriteLine("Movie added to favorites succesfully");
        //    }
        //}

        public void ViewFavoritesMovieList()
        {
            favoritesMovieList = GetFavoritesMovieList();
            Console.WriteLine("Favorites:");
            Console.WriteLine("ID  Title               Box Office($)    Genre");
            for (int i = 0; i < favoritesMovieList.Count(); i++)
            {
                Console.WriteLine("{0}   {1,-18}  {2,-13}    {3}", favoritesMovieList[i].Id, favoritesMovieList[i].Title, favoritesMovieList[i].BoxOffice, favoritesMovieList[i].Genre);
            }
            Console.WriteLine("No. of Favorites: " + favoritesMovieList.Count());
        }

        public void RemoveMovieFromFavoritesMovieList(int id)
        {
            favoritesMovieList = GetFavoritesMovieList();
            int i = id - 1;

            favoritesMovieList.Remove(favoritesMovieList[i]);
            Console.WriteLine("Movie removed from favorites successfully");
        }
    }
}
