namespace DIConsoleApp.Feature.DataModel;

public class ExampleDataModel : BasicDataModel
{
    public static string ExampleData => nameof(ExampleData);
    public static string Id => nameof(Id);


    public ExampleDataModel(string keyValue) : base(modelName: ExampleData, keyName: Id)
    {
        KeyValue = keyValue;
    }
}
