# uni-cs-json-nuget

## Tasks

1. Create manual JSON file, and by theory example XML reader.

Created a `users.json` file.

2. Add new entries to a JSON object.

Added some mock data to the `users.json` file:
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

3. Deserialize all entries (need LOOP) of the JSON data into C# objects and output the data into the console.
4. Use inheritance to extend the User class and create specialized user_types (ex.: admin, user, etc).
5. Create new JSOIN file with user_types data and deserialize the file. Output the data to the console.
