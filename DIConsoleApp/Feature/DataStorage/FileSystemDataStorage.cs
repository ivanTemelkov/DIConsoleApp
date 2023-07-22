using System.Collections.Immutable;
using DIConsoleApp.Feature.DataModel;
using DIConsoleApp.Feature.Serializer;

namespace DIConsoleApp.Feature.DataStorage;

public class FileSystemDataStorage : IDataStorage
{
    private IDataSerializer DataSerializer { get; }

    public FileSystemDataStorage(IDataSerializer dataSerializer)
    {
        DataSerializer = dataSerializer;
    }

    public ImmutableArray<BasicDataModel> Load()
    {
        var data = LoadFromFile("some-cool-filename.dat");

        var items = data.Split(new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        return items.Select(x => DataSerializer.Deserialize(x)).ToImmutableArray();
    }

    public void Save(ImmutableArray<BasicDataModel> data)
    {
        var serializedItems = data.Select(x => DataSerializer.Serialize(x));
        var allItems = string.Join(Environment.NewLine, serializedItems);
        SaveToFile(allItems, "some-cool-filename.dat");
    }

    private string LoadFromFile(string filename)
    {
        Console.WriteLine($"Loading data from file {filename} ...");
        Thread.Sleep(600);
        Console.WriteLine("Done.");

        return @"
Item_001
Item_002
Item_003
";
    }

    private void SaveToFile(string allData, string filename)
    {
        Console.WriteLine($"Saving data to file {filename} ...");
        Thread.Sleep(400);
        Console.WriteLine("Done.");
    }
}