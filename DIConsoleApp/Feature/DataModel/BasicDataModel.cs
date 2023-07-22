namespace DIConsoleApp.Feature.DataModel;

public abstract class BasicDataModel
{
    public string ModelName { get; }
    public string KeyName { get; }

    public string? KeyValue { get; protected set; }

    protected BasicDataModel(string modelName, string keyName)
    {
        ModelName = modelName;
        KeyName = keyName;
    }
}