using NUnit.Framework;
using SimpleJSON;

public class SimpleJsonTests
{
    [Test]
    public void SaveLoadTest()
    {
        var testSaveData = new TestSaveData(10);

        SaveManager.Save(testSaveData, SavePath.GAMESAVEPATH);

        Assert.AreEqual(10, SaveManager.Load<TestSaveData>(SavePath.GAMESAVEPATH).levelCount);
    }

    [Test]
    public void ResetTest()
    {
        SaveManager.Reset<TestSaveData>(SavePath.GAMESAVEPATH, new TestSaveData(5));

        Assert.AreEqual(5, SaveManager.Load<TestSaveData>(SavePath.GAMESAVEPATH).levelCount);
    }
}
