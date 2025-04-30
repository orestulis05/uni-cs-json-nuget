# uni-cs-json-nuget

## Tasks

### 1. Create manual JSON file, and by theory example XML reader.

- Created a `users.json` file.

### 2. Add new entries to a JSON object.

- Added some mock data to the `users.json` file:
```json
[
    {
        "name": "John Doe",
        "age": 32,
        "city": "New York",
        "isAdmin": true
    },
    {
        "name": "Jane Doe",
        "age": 24,
        "city": "London",
        "isAdmin": false
    }
]
```

### 3. Deserialize all entries (need LOOP) of the JSON data into C# objects and output the data into the console.

- Made `User` class, which will contain the data of deserialized entries from the `users.json` file:
```cs
public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public bool IsAdmin { get; set; }
}
```

- Deserialized the data by the help of `Newtonsoft.Json` NuGet package:
```cs
string filePath = "users.json";
string jsonResponse = File.ReadAllText(filePath);
List<User> userData = JsonConvert.DeserializeObject<List<User>>(jsonResponse);
```

- Made a function that prints out the data of each user in the list of users:
```cs
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
```

### 4. Use inheritance to extend the User class and create specialized user_types (ex.: admin, user, etc).

Created two new classes with their own functionality that inherit `User` class:
- `AdminUser`
- `RegularUser`

### 5. Create new JSON file with user_types data and deserialize the file. Output the data to the console.

- Populated the `users.json` file with more mock data.
- Made the `PrintUsersData` function additionaly print the class that the user is in for debugging reasons.
- Made a function that deserializes the JSON data, creates roled users from it and puts them in a list that is returned in the end:
```cs
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
```