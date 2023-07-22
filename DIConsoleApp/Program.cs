// #define CONFIG_1
#define CONFIG_2
//#define CONFIG_3
//#define CONFIG_4


using DIConsoleApp.Feature.DataApplication;
using DIConsoleApp.Feature.DataStorage;
using DIConsoleApp.Feature.Serializer;

// TODO Read this from configuration file

var sourceWebService = "http://www.cool-web-service.com";
var destinationWebService = "http://www.lag-web-service.com";

var sourceConnectionString = "my-connection-string";
var destinationConnectionString = "cloud-storage-database";


#if CONFIG_1
var isConsoleApp = true;
var isXmlSerializer = false;
var sourceStorageType = DataStorageType.WebService;
var destinationStorageType = DataStorageType.FileSystem;

#elif CONFIG_2
var isConsoleApp = true;
var isXmlSerializer = false;
var sourceStorageType = DataStorageType.Database;
var destinationStorageType = DataStorageType.WebService;

#elif CONFIG_3
var isConsoleApp = true;
var isXmlSerializer = true;
var sourceStorageType = DataStorageType.Database;
var destinationStorageType = DataStorageType.FileSystem;

#elif CONFIG_4
var isConsoleApp = true;
var isXmlSerializer = false;
var sourceStorageType = DataStorageType.WebService;
var destinationStorageType = DataStorageType.WebService;
#endif




IDataSerializer serializer = (isXmlSerializer) 
    ? new XmlDataSerializer() 
    : new JsonDataSerializer();

IDataStorage source = (sourceStorageType) switch
{
    DataStorageType.FileSystem => new FileSystemDataStorage(serializer),
    DataStorageType.WebService => new WebServiceDataStorage(sourceWebService),
    DataStorageType.Database => new DatabaseDataStorage(sourceConnectionString),
    _ => throw new ArgumentOutOfRangeException()
};

IDataStorage destination = (destinationStorageType) switch
{
    DataStorageType.FileSystem => new FileSystemDataStorage(serializer),
    DataStorageType.WebService => new WebServiceDataStorage(destinationWebService),
    DataStorageType.Database => new DatabaseDataStorage(destinationConnectionString),
    _ => throw new ArgumentOutOfRangeException()
};

var app = (isConsoleApp) 
    ? new ConsoleDataApplication(source, destination) 
    : throw new NotImplementedException($"Currently only {nameof(ConsoleDataApplication)} is implemented!");

app.Run();