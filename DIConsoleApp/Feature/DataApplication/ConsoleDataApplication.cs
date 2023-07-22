using DIConsoleApp.Feature.DataStorage;

namespace DIConsoleApp.Feature.DataApplication;

public class ConsoleDataApplication : IDataApplication
{
    private IDataStorage Source { get; }
    private IDataStorage Destination { get; }

    public ConsoleDataApplication(IDataStorage source, IDataStorage destination)
    {
        Source = source;
        Destination = destination;
    }

    public void Run()
    {
        Console.WriteLine($"{nameof(ConsoleDataApplication)} is running.");
        
        Console.WriteLine($"\nSource is {Source.GetType().Name}");
        Console.WriteLine($"Destination is {Destination.GetType().Name}");

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
    }

    private void Pull()
    {
        var dataModels = Source.Load();
        Destination.Save(dataModels);
    }

    private void Push()
    {
        var data = Destination.Load();
        Source.Save(data);
    }
}
