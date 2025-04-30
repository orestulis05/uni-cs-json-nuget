using Newtonsoft.Json;
using System.IO;

// Reading the contents from users.json file

// IMPORTANT: insert an absolute filepath to the json file! 
string filePath = "users.json";
string jsonResponse = File.ReadAllText(filePath);

// Getting the data from file's contents 
List<User> userData = JsonConvert.DeserializeObject<List<User>>(jsonResponse);

if (userData == null)
    return;

PrintUsersData(userData);

void PrintUsersData(List<User> data)
{
    foreach (var item in userData)
    {
        string output = String.Format(
            "Name: {0}, Age: {1}, City: {2}, Admin: {3}",
            item.Name,
            item.Age,
            item.City,
            item.IsAdmin);

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

