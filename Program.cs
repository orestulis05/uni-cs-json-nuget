using Newtonsoft.Json;
using System.IO;
using System.Runtime.CompilerServices;

// Reading the contents from users.json file.
string filePath = "users.json";
string jsonResponse = File.ReadAllText(filePath);

// Create roled users from the data of users.json file.
List<User> roledUsers = CreateRoledUsers(jsonResponse);

// Print out the data of each user.
PrintUsersData(roledUsers);

List<User> CreateRoledUsers(string jsonData)
{
    List<User> results = new List<User>();

    List<User> userData = JsonConvert.DeserializeObject<List<User>>(jsonResponse);
    if (userData == null)
        return null;

    foreach (var user in userData)
    {
        User roledUser;

        if (user.IsAdmin)
        {
            roledUser = new AdminUser(user.Name, user.Age, user.City);
        } 
        else
        {
            roledUser = new RegularUser(user.Name, user.Age, user.City);
        }

        results.Add(roledUser);
    }

    return results;
}

void PrintUsersData(List<User> data)
{
    foreach (var item in data)
    {
        string output = String.Format(
            "Name: {0}, Age: {1}, City: {2}, Admin: {3}, Class: {4}",
            item.Name,
            item.Age,
            item.City,
            item.IsAdmin,
            item.GetType().Name
        );

        Console.WriteLine(output);
    }
}

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public bool IsAdmin { get; set; }

}

public class AdminUser : User
{
    public AdminUser(string name, int age, string city)
    {
        this.Name = name;
        this.Age = age;
        this.City = city;
        this.IsAdmin = true;
    }

    public void DoAdminThings()
    {
        Console.WriteLine("Doing some admin things.");
    }
}

public class RegularUser : User
{
    public RegularUser(string name, int age, string city)
    {
        this.Name = name;
        this.Age = age;
        this.City = city;
        this.IsAdmin = false;
    }

    public void DoRegularUserThings()
    {
        Console.WriteLine("Doing some regular user things.");
    }
}
