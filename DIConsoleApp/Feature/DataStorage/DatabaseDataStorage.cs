using System.Collections.Immutable;
using DIConsoleApp.Feature.DataModel;

namespace DIConsoleApp.Feature.DataStorage;

public class DatabaseDataStorage
{
    private static string ConnectionString => "my-connection-string";

    public ImmutableArray<BasicDataModel> Load()
    {
        Console.WriteLine($"Opening database connection {ConnectionString} ...");
        Console.WriteLine($"Reading data ...");
        Thread.Sleep(800);
        Console.WriteLine($"Closing connection ...");
        Console.WriteLine("Done.");

        return new BasicDataModel[]
        {
            new ExampleDataModel("Item_001"),
            new ExampleDataModel("Item_002"),
            new ExampleDataModel("Item_003"),
        }.ToImmutableArray();
    }

    public void Save(ImmutableArray<BasicDataModel> data)
    {
        Console.WriteLine($"Opening database connection {ConnectionString} ...");
        Console.WriteLine($"Saving data ...");
        Thread.Sleep(750);
        Console.WriteLine($"Closing connection ...");
        Console.WriteLine("Done.");
    }
}