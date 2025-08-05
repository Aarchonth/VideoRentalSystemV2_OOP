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
    public static void HandlingMenu(User user)
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
    public static void HandlingRentMovie(Library library) 
    {
        Console.WriteLine("Type in the Movie Title to rent:");
        string title = Console.ReadLine();
        library.RentMovie(title);
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

    public void RentMovie(string title)
    {
        var movie = availableMovies.FirstOrDefault((m => m.Title == title));
        if (movie != null)
        {
            availableMovies.Remove(movie);
            Console.WriteLine($"You rented: {movie.Title}");
        }
        else
        {
            Console.WriteLine("Movie not found.");
        }
    }

}
    class Program
    {
        static void Main()
        {

            Movie movie = new Movie { Title = "Lotr" };

            UserManagment managment = new UserManagment();
            UserInteraction.HandlingRegister(managment);

        }
    } 
