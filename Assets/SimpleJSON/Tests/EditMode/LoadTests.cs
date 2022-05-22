using NUnit.Framework;
using SimpleJSON;
using System;

public class LoadTests
{
    [Test]
    public void Load()
    {
        var result = SaveManager.Load<PlayerSaveData>("GameData.json");
    }

    [Test]
    public void LoadMultiple()
    {
        var trucks = new TruckData[]
        {
            new TruckData(100,.1f,"Truck1"),
            new TruckData(200,.2f,"Truck2"),
            new TruckData(300,.3f,"Truck3"),
        };

        //SaveManager.Save(trucks, TruckData.Path);

        var result = SaveManager.Load<TruckData>(TruckData.Path);
    }
}


[Serializable]
public class TruckData
{
    private static string path = "Truck.json";
    public static string Path { get => path; }

    public int intField;
    public float floatField;
    public string stringField;

    public TruckData(int intField, float floatField, string stringField)
    {
        this.intField = intField;
        this.floatField = floatField;
        this.stringField = stringField;
    }

}
