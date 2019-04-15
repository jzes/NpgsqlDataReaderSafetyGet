# NpgsqlDataReaderSafety

This is a simple tool to avoid exceptions with `get` methods on `DataReader` class.
With extension methods we can simple the `get` data action on data reader, and receive a null value of each type when call a `get` method of same type.

## Usage Example And Explanations

When, in a DataReader object we call get method like this

```c#
while(dataReader.Read()){
    people.Age = dataReader.GetInt32(0);
}
```

If database field in 0 position is null, we receive an exception. Following the documentation of Npgsql we can found a boolean method to check if the value is null called `IsDBNull`, and our code will stay like this

```c#
while(dataReader.Read()){
    if (!if(dataReader.IsDBNull(0)){
        people.Age = dataReader.GetInt32(0);
    }
}
```

The problem was solved, but we add some lines of code in our software and it got a little bit more unreadable for me.
To handle with this I created this extension methods and I'd like to share. So our code will stay like this

```c#
while(dataReader.Read()){
    people.Age = dataReader.GetSafetyInt32(0);
}
```

## To do

* Add more type of extension methods
* Add `Try` blocks to handle knowled exceptions