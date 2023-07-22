﻿using System.Collections.Immutable;
using DIConsoleApp.Feature.DataModel;
using DIConsoleApp.Feature.Serializer;

namespace DIConsoleApp.Feature.DataStorage;

public class FileSystemDataStorage
{
    private static XmlDataSerializer XmlDataSerializer => new();
    private static JsonDataSerializer JsonDataSerializer => new();

    public ImmutableArray<BasicDataModel> Load()
    {
        var data = LoadFromFile("some-cool-filename.dat");

        var items = data.Split(new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        if (ApplicationConfiguration.IsXmlSerializer)
        {
            return items.Select(x => XmlDataSerializer.Deserialize(x)).ToImmutableArray();
        }
        else
        {
            return items.Select(x => JsonDataSerializer.Deserialize(x)).ToImmutableArray();
        }
    }

    public void Save(ImmutableArray<BasicDataModel> data)
    {
        IEnumerable<string> serializedItems;
        if (ApplicationConfiguration.IsXmlSerializer)
        {
            serializedItems = data.Select(x => XmlDataSerializer.Serialize(x));
        }
        else
        {
            serializedItems = data.Select(x => JsonDataSerializer.Serialize(x));
        }

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