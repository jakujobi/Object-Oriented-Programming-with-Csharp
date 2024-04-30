## CSc 346 – Spring 2024 – Exam #2 Overview
**Instructor:** Gamradt  
**Related Assignments:** Assignments 4, 5 (mostly 5)  
**Exam Value:** 100 points

## Types of Questions
- **Short Answer:** Explain, describe, or define some aspect of C# and/or .NET.
- **Listing:** List the characteristics of or the different categories of some aspect of C# and/or .NET.
- **Programming:** Write complete code segments of some aspect of C# and/or .NET.
  - Note: There will be less programming on this exam.
---
# Content Covered

## Chapter 8: Collections
Common features:
- `ICollection` interface: Count property tells how many objects are in them
- `IEnumerable` interface: can be iterated using the foreach statement
- Have a ~GetEnumerator~ method that returns object that implements `IEnumerator`
- Returned objects have `MoveNext`, `Reset` and `Current` property.
Examples of Collections
- List `IList<T>`: Its an ordered collection
- Dictionaries `IDictionary<TKey, TValue>`: Also called hashmaps
	- Uses 
- Sets `<ISet<T>`: Need to have unique items
- Stacks: Last in, First Out
- Queues: First-in, First-out
To sort a collection, just add `Sorted` e.g `SortedList`

**ImageSharp**: An image processing library for .NET  through NuGet package
### **Non-Generic**
- Part of System.Collections
- Can store any type of objects
- Needs to be type cast
- Less efficient because of boxing
- Example

```csharp
ArrayList list = new ArrayList();
list.Add(1);    // Boxing integer to object
list.Add("hello");

int first = (int)list[0];  // Unboxing object to integer
string second = (string)list[1];
```

## **Generic**
- Part of `System.Collections.generic`
- Stores specific types of objects
- Doesn't need to be type casted
- More efficient coz no boxing
	- `HashSet<T>`: Provides high-performance set operations. A set is a collection that contains no duplicate elements.

```csharp
List<int> list = new List<int>();
list.Add(1);    // No boxing, type-safe

int first = list[0];  // No casting needed
```
### Internationalizing code:
- **Globalization**: Writing code to accomadate languages and region combinations
	- Combo of language and region is known as culture
	- e.g fr-CA or en-NG, en-US
	- Its also includes the date and currency formats
- **Localization**: customizing UI to support a language
	- e.g en, fr, ru
- International Organization for Standardization (ISO = equal) codes all culture combos
---
## Chapter 9: Files and Streams
### **Files**
- `DriveInfo`: static method that gets info about 
- `System` and `System.IO` namespaces take care of filesystem
- Directory, Path, and Environment 
- `FileInfo`, `DirectoryInfo`, `LastAccessTime`, Delete
- `File.Open` overloads
	- `FileMode`: controls what to do with the file (`CreatNew`, `OpenOrCreate`, `Truncate`)
	- `FileAccess`: level of access needed, like `ReadWrite`
	- `FileShare`: Locks on file to put other processes on a level of access
	- `FileAttribute`: Checks for derived types like Archive and Encrypted
### **Streams**
- `Stream`: Sequence of bytes that can be read from and written to
	- The abstract class `Stream` represents any type of stream
- Concrete classes inherited from abstract class `Stream`:
	- `FileStream`
	- `MemoryStream`
	- `BufferedStream`
	- `SslStream`
	- `GZipStream`

### **Using – Disposal:** Managing resource disposal.
- All streams used `IDisposable` to release resources with the `Dispose` method
### **Encoding/Decoding Text:** Methods and practices.
- `StreamWriter`: write to stream as plain text
- `StreamReader`: reads from stream as plain text
```csharp
StreamReader reader = new(stream, Encoding.UTF8);
StreamWriter writer = new(stream, Encoding.UTF8);
```


```csharp
string  textFile = Combine(CurrentDirectory, "textname.txt");
StreamWriter text = File.CreateText(textFile);
text.WriteLine(item);
text.Close()
OutputFileInfor(textFile);
```
### **Serializing Objects:** Techniques and implementations.
- **Object graph**: structure of multiple objects related to each other
	- Directly through direct refences
	- Indirectly through a chain of references
- **Serialization**: converting live object to bytes in a specified format
	- Stored in a file or database
- **Deserialization**: converting a sequence of bytes into live objects
### Extensible Markup Language (XML)
- Used with legacy systems
**Serializing with XML**
```csharp
XmlSerializer xs = new(type: className.GetType());
string path = Combine (CurrentDirectory, "fileName");
using (Filestream stream = File.Create(path)) {
	xs.Serialize(stream, className);
}
OutputFileInfo(path);
```

**Deserializing XML**
```csharp
using (FileStream stream = Fiel.Open(path, FileMode.Open)) {
	List<className>? loadedObjects =  xs.Deserialize(stream) as List<className>;
}
```
### JavaScript Object Notation (JSON)
- More compact 
- Used for web applications
- Minimizes size of serialized object graphs
- Native to JavaScript
**UTF** (Unicode Transformation Format)
- Best to use UTF-8
- Older libraries like Json.NET are implemented by reading UTF-16
**Controlling JSON processing**:
- Including and excluding fields
- Setting a casing policy
- Selecting a case-sensitivity policy
- Choosing between compact and prettified whitespace
```csharp
# Example of High Performance JSON procession
using FastJson = System.Text.Json.JsonSerializer;
await using (FileStream jsonLoad = File.Open(jsonPath, FileMode.Open)){
	List<className>
}
```

---
## Chapter 10: Entity Framework Core
### Focused on the usage of Entity Framework Core within .NET applications.
---