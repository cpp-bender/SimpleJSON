using NUnit.Framework;
using SimpleJSON;

public class SimpleJsonTests
{
    [Test]
    public void SaveLoadTest()
    {
        var testSaveData = new TestSaveData(10);

        SaveManager.Save(testSaveData, Paths.GAMESAVEPATH);

        Assert.AreEqual(10, SaveManager.Load<TestSaveData>(Paths.GAMESAVEPATH).levelCount);
    }

    [Test]
    public void ResetTest()
    {
        SaveManager.Reset<TestSaveData>(Paths.GAMESAVEPATH, new TestSaveData(5));

        Assert.AreEqual(5, SaveManager.Load<TestSaveData>(Paths.GAMESAVEPATH).levelCount);
    }

    [Test]
    public void DeleteTest()
    {
        Assert.AreEqual(0, SaveManager.DeleteAll());
    }
}
