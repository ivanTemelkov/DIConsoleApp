using System.Collections.Immutable;
using DIConsoleApp.Feature.DataModel;
using DIConsoleApp.Feature.Serializer;

namespace DIConsoleApp.Feature.DataStorage;

public class TargetDataStorage
{
    private static string FullEndpointUri => "http://www.cool-web-service.com/api/v1/basic-data";

    private static XmlDataSerializer XmlDataSerializer => new();
    private static JsonDataSerializer JsonDataSerializer => new();

    public ImmutableArray<BasicDataModel> Load()
    {
        if (ApplicationConfiguration.IsWebService)
        {
            return LoadFromWebService();
        }
        else
        {
            var data = LoadFromFile("some-cool-filename.dat");

            var items = data.Split(new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            return ApplicationConfiguration.IsXmlSerializer
                ? items.Select(x => XmlDataSerializer.Deserialize(x)).ToImmutableArray()
                : items.Select(x => JsonDataSerializer.Deserialize(x)).ToImmutableArray();
        }
    }

    public void Save(ImmutableArray<BasicDataModel> data)
    {
        if (ApplicationConfiguration.IsWebService)
        {
            SaveToWebService(data);
        }
        else
        {
            IEnumerable<string> serializedItems = ApplicationConfiguration.IsXmlSerializer 
                ? data.Select(x => XmlDataSerializer.Serialize(x)) 
                : data.Select(x => JsonDataSerializer.Serialize(x));

            var allItems = string.Join(Environment.NewLine, serializedItems);
            SaveToFile(allItems, "some-cool-filename.dat");
        }
        
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

    private ImmutableArray<BasicDataModel> LoadFromWebService()
    {
        Console.WriteLine($"Loading data from Web Service {FullEndpointUri}.");
        Console.WriteLine($"Sending GET request.");
        Thread.Sleep(800);
        Console.WriteLine("Done.");

        return new BasicDataModel[]
        {
            new ExampleDataModel("Item_001"),
            new ExampleDataModel("Item_002"),
            new ExampleDataModel("Item_003"),
        }.ToImmutableArray();
    }

    private void SaveToWebService(ImmutableArray<BasicDataModel> data)
    {
        Console.WriteLine($"Saving data to Web Service {FullEndpointUri}.");
        Console.WriteLine($"Sending POST request.");
        Thread.Sleep(950);
        Console.WriteLine("Done.");
    }
}
