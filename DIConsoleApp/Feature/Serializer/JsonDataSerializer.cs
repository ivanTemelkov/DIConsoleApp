using DIConsoleApp.Feature.DataModel;

namespace DIConsoleApp.Feature.Serializer;

public class JsonDataSerializer
{
    public string Serialize(BasicDataModel dataModel)
    {
        Console.WriteLine($"Serializing {dataModel.GetType()} to JSON ...");
        return "serialized";
    }

    public BasicDataModel Deserialize(string data)
    {
        Console.WriteLine($"Deserializing JSON data : {data}");
        return new ExampleDataModel(data);
    }
}