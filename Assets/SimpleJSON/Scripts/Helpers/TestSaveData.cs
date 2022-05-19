using UnityEngine;
using SimpleJSON;
using System;

[Serializable]
public class TestSaveData
{
    public int levelCount;

    public TestSaveData(int levelCount)
    {
        this.levelCount = levelCount;
    }
}
