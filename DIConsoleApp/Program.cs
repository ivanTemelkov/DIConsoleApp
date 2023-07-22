﻿using DIConsoleApp.Feature.DataStorage;

var databaseDataStorage = new DatabaseDataStorage();
var fileSystemDataStorage = new FileSystemDataStorage();

Console.WriteLine("No DI ConsoleApp is running.");
        
Console.WriteLine("\nReads data from Database and saves it to disk.");

Console.WriteLine("\nPress");
Console.WriteLine("\t'l' to pull");
Console.WriteLine("\t's' to push");
Console.WriteLine("'q' is for quitters.");

while (true)
{
    if (Console.KeyAvailable) 
    {
        var key = Console.ReadKey().KeyChar;
        Console.WriteLine();

        switch (key)
        {
            case 'q' or 'Q': 
                return;

            case 'l' or 'L':
                Pull();
                break;

            case 's' or 'S':
                Push();
                break;
        }
    }
            

    Thread.Sleep(100);
}

void Pull()
{
    var dataModels = databaseDataStorage.Load();
    fileSystemDataStorage.Save(dataModels);
}

void Push()
{
    var data = fileSystemDataStorage.Load();
    databaseDataStorage.Save(data);
}