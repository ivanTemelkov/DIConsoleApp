using System.Collections.Immutable;
using DIConsoleApp.Feature.DataModel;

namespace DIConsoleApp.Feature.DataStorage;

public interface IDataStorage
{
    ImmutableArray<BasicDataModel> Load();

    void Save(ImmutableArray<BasicDataModel> data);
}