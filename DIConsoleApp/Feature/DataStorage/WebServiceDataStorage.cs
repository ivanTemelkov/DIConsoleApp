using System.Collections.Immutable;
using DIConsoleApp.Feature.DataModel;

namespace DIConsoleApp.Feature.DataStorage;

public class WebServiceDataStorage : IDataStorage
{
    private static string ServiceEndpoint => "basic-data";

    private string FullEndpointUri { get; }

    public WebServiceDataStorage(string baseUri)
    {
        FullEndpointUri = $"{baseUri}/api/v1/{ServiceEndpoint}";
    }

    public ImmutableArray<BasicDataModel> Load()
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

    public void Save(ImmutableArray<BasicDataModel> data)
    {
        Console.WriteLine($"Saving data to Web Service {FullEndpointUri}.");
        Console.WriteLine($"Sending POST request.");
        Thread.Sleep(950);
        Console.WriteLine("Done.");
    }
}