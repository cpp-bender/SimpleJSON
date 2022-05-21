using NUnit.Framework;
using SimpleJSON.Util;
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

        SaveManager.Save(trucks, SimplePath.GAMESAVEPATH);

        var result = SaveManager.Load<TruckData>(SimplePath.GAMESAVEPATH);
    }
}


[Serializable]
public class TruckData
{
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
