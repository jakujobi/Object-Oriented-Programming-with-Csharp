### Short Answer Questions
1. What role does the `IEnumerator` interface play in collection manipulation in C#?
```json
Provides a way for use to iterate through the objects
```

2. What are the different ways to control a file
```json
FileMode: CreateNew, OpenOrCreate, Truncate
FileAccess: ReadWrite, Read, Write
FileShare: Read
FileAttributes: Checks for Archive and Encrypted
```

3. Define globalization and localization in the context of internationalizing code in .NET applications.
```json
Globalization means making the program account for the language and region of the user.
- This includes things like currency, and date format

Localization: means changing the UI to reflect a user's language
- For example, close in en becomes fermer in french
```

4. Explain the significance of the `IDisposable` interface and its `Dispose` method in .NET.
```json
The IDisposable interace implements the Dispose method.
The method closes the stream and releases the resources
```

5. How does the `Stream` class abstract the concept of a sequence of bytes in .NET?


6. Describe the use of the `SortedList` collection in .NET. How does it differ from a regular `List<T>`?
```json
SortedList is a collection sorted by keys. It is not a list
List<T> is a generic collection which acts like an array
```

7. Explain the concept of "boxing" and "unboxing" in the context of non-generic collections in .NET.
```json
- During boxing, the collection is converted to an object (value type to referenced type). Then is stores it in the heap
- Unboxing converts it back to a collection. it needs explicit type casting.
```

8. What are the advantages of using generic collections over non-generic collections in .NET?
```json
Generic collections are faster and more efficient because they do not need to go through boxing and unboxing.
- Generic collections do not require typecasting
```


9. Define the terms "serialization" and "deserialization" in .NET and explain why it is important.
```json
- Can transfer object between apps
- Create copies of an object
```

10. Explain the purpose of the `IDictionary<TKey, TValue>` interface and its common use cases in .NET.

### Listing Questions
1. List all the collection types mentioned that implement the `ICollection` and `IEnumerable` interfaces.
	- `IList`
	- `IStack`
	- `IQueue`
	- `IDictionary`
2. Provide a list of operations performed by the `FileStream` class in managing file data.
   

3. Enumerate the steps involved in serializing and deserializing an object using XML in .NET.
	- Make a filestrem
	- Get the file
	- 
5. What are the various attributes you can use to control JSON serialization in .NET?
   

6. List the steps required to create a new SQLite database connection using Entity Framework Core.
   

7. Identify all the concrete classes in .NET that derive from the abstract `Stream` class.
	- `GZipStream`
	- `SslStream`
	- `FileStream`
	- `MemoryStream`
	- `BufferedStream`
	
8. List the properties of the `FileInfo` class that are commonly used to manage file metadata.
	- `Delete`
	- `LastAccessTime`
	
9. Enumerate the common methods provided by the `Queue<T>` class in .NET.
	- `Enqueue`
	- `Dequeue`
	- `Peek`

10. List the key differences between `StreamWriter` and `StreamReader`.
	- `StreamWriter`: Converts a live object into a sequence of bytes
	- `StreamReader`: Converts a sequence of bytes into a live object
	  
	
13. Provide a list of steps to serialize an object graph using JSON in .NET.
14. List the attributes you might use to control XML serialization of an object class.

15. What are the diff between Database First and Code First in EF Core:
```json
- Database First means a database already exists and we are making a model to math its structure and features
- Code First means no database exists and we are making a new one and model
```
16. List 4 Relational databases and Document databases
```json
Relational:
- SQlServer
- MySQL
- Postgresql
- SQLite

Document:
- MongoDB
- Redis
- Azure Database
- Apache
```

17. What things do we need to know when connecting to a SQLite database
	- `Filename`
	- Set using the parameter `Filename`
	

18. What things does EF Core use to build an entity model
	- Conventions
	- Annotation Attributes
	- Fluent API statements

19. What does CRUD mean?
	- Create
	- Read
	- Update
	- Delete

20. 
### Programming Questions
1. Write a C# code segment to demonstrate the use of the `List<T>` generic collection, including adding items and iterating over them.
```
```


2. Implement a simple file reading and writing operation using `FileStream` and handle potential exceptions.
```csharp
string path = combine(CurrentDirectory, "fileName");
FileStream file = new FileStream(path)
```


3. Create a C# method that serializes a list of objects to JSON format and then deserializes it back to a list.
```csharp
List<int> Names
using FastJson = System
await using (FileStram Stream = File.Creat(path)){
	Json.Serialize
}
```


4. Write a C# function using `StreamWriter` and `StreamReader` to copy text from one file to another while converting all characters to uppercase.
```
```