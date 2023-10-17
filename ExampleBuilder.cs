using System;
using System.Collections.Generic;

namespace Example.Builder;

public interface IHouseBuilder
{
    void BuildWalls();
		
    void BuildRoof();
		
    void AddWindows();
}
    
public class HouseHouseBuilder : IHouseBuilder
{
    private House _house = new House();
        
    public HouseHouseBuilder() => Reset();

    private void Reset() => _house = new House();

    public void BuildWalls() => _house.Add("Walls");

    public void BuildRoof() => _house.Add("Roof");

    public void AddWindows() => _house.Add("Windows");

    public House GetHouse()
    {
        var result = _house;

        Reset();

        return result;
    }
}
    
public class House
{
    private List<string> _house = new();
		
    public void Add(string part) => _house.Add(part);

    public string ListParts() => "House parts: " + string.Join(", ", _house);
}
    
public class Director
{
    public IHouseBuilder HouseBuilder { get; set; }

    public void BuildBasicHouse()
    {
        HouseBuilder.BuildWalls();
        HouseBuilder.BuildRoof();
    }
		
    public void BuildStandardHouse()
    {
        HouseBuilder.BuildWalls();
        HouseBuilder.BuildRoof();
        HouseBuilder.AddWindows();
    }
}

class ExampleBuilder
{
    static void Main()
    {
        var director = new Director();
        var builder = new HouseHouseBuilder();
        director.HouseBuilder = builder;
            
        Console.WriteLine("Basic House:");
        director.BuildBasicHouse();
        Console.WriteLine(builder.GetHouse().ListParts());

        Console.WriteLine("Standard House:");
        director.BuildStandardHouse();
        Console.WriteLine(builder.GetHouse().ListParts());
            
        Console.WriteLine("Custom House:");
        builder.BuildWalls();
        builder.AddWindows();
        Console.Write(builder.GetHouse().ListParts());
    }
}
