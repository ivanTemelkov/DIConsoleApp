using DIConsoleApp.Feature.DataModel;

namespace DIConsoleApp.Feature.Serializer;

public class XmlDataSerializer
{
    public string Serialize(BasicDataModel dataModel)
    {
        Console.WriteLine($"Serializing {dataModel.GetType()} to XML ...");
        return "serialized";
    }

    public BasicDataModel Deserialize(string data)
    {
        Console.WriteLine($"Deserializing XML data : {data}");
        return new ExampleDataModel(data);
    }
}