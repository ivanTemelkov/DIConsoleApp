using DIConsoleApp.Feature.DataModel;

namespace DIConsoleApp.Feature.Serializer;

public interface IDataSerializer
{
    string Serialize(BasicDataModel dataModel);
    BasicDataModel Deserialize(string data);
}