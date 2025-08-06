// First video rental system in C#
// Goal: Understand and apply login, registration, and movie rental logic
// By [Aarchonth]
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Microsoft.Win32;

enum Role
{
    User,
    Admin
}
class User
{
    public string Name { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    public List<Movie> RentedMovies = new List<Movie>();
}
class UserManagment
{
    public List<User> users = new List<User>();
    public void Register(string name, string password)
    {
        User user = new User 
        { 
        Name = name,
        Password = password
        };
        users.Add(user);
    }
    public User Login(string name, string password) 
    { 
        foreach (var user in users)
        {
            if(user.Name == name && user.Password == password)
            {
                return user;
            }
            
        }
        return null;
    }
    
}
class UserInteraction
{
    public static void HandlingRegister(UserManagment RegisterManager)
    {
        Console.WriteLine("Name:");
        string name = Console.ReadLine();
        Console.WriteLine("Password:");
        string password = Console.ReadLine();

        RegisterManager.Register(name, password);
    }
    public static void HandlingLogIn(UserManagment LogInManager)
    {
        Console.WriteLine("Name:");
        string name = Console.ReadLine();
        Console.WriteLine("Password:");
        string password = Console.ReadLine();

        User user = LogInManager.Login(name, password);
        if (user != null) {
            Console.WriteLine("you sucessfully Logged In");
            // handlingmenu User
        }
        else
        {
            Console.WriteLine("LogIn Failed");
        }
    }
    public static void HandlingMenu(User user,Library library)
    {
        Console.WriteLine($"Hello {user.Name}");
        Console.WriteLine("1. Rent Video");
        Console.WriteLine("2. Return Video");
        Console.WriteLine("3. LogOut");
        string select = Console.ReadLine();
        while (select != null) {
            switch (select) 
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    return;
            }
        }
    }
    public static void HandlingRentMovie(User user, Library library) 
    {
        Console.WriteLine("Type in the Movie Title to rent:");
        string title = Console.ReadLine();
        library.RentMovie(user, title);
    }
    public static void HandlingReturnMovie(User user, Library library)
    {
        foreach(Movie movie in user.RentedMovies) { Console.WriteLine($"{movie.Title}"); }
        string title = Console.ReadLine();
        library.ReturnMovie(user, title);
    }
    
}
class Movie
{
    public string Title { get; set; }
    
}
class Library
{
    public List<Movie> availableMovies = new List<Movie>();
    public void ShowMovies()
    {
        
        foreach (var movie in availableMovies)
        {
            Console.WriteLine($"{movie.Title}");
        }
    }

    public void RentMovie(User user, string title)
    {
        var movie = availableMovies.FirstOrDefault((m => m.Title == title));
        if (movie != null)
        {
            availableMovies.Remove(movie);
            user.RentedMovies.Add(movie);
            Console.WriteLine($"You rented: {movie.Title}");
        }
        else
        {
            Console.WriteLine("Movie not found.");
        }
    }
    public void ReturnMovie(User user, string title)
    {
        var movie = user.RentedMovies.FirstOrDefault((m => m.Title == title));
        if (movie != null)
        {
            user.RentedMovies.Remove(movie);
            availableMovies.Add(movie);
            Console.WriteLine($"You returned: {movie.Title}");
        }
        else
        {
            Console.WriteLine("Movie not found.");
        }
    }

}
    class Program
    {
       public  static void Start()
    {
        Movie movie = new Movie { Title = "Lotr" };
        Library library = new Library();

        UserManagment userManagment = new UserManagment();

        // Registration
        UserInteraction.HandlingRegister(userManagment);

        // Login
        User user = null;
        
        while (user == null)
        {
            Console.WriteLine("Bitte erneut einloggen:");
            string name = Console.ReadLine();
            string password = Console.ReadLine();
            user = userManagment.Login(name, password);
        }

        UserInteraction.HandlingMenu(user, library);
    }
        static void Main()
        {
        Start();
        }
    } 
