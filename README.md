# SimpleJSON

## Table Of Contents 
 
<details>
<summary>Details</summary>

  - [Introduction](#introduction)
  - [Features](#features)
  - [Important Note](#important-note)
  - [How to save](#how-to-save)
  - [How to load](#how-to-load)
  - [How to reset](#how-to-reset)
  - [SimpleJSON Window](#simplejson-window)
    
</details>

## Introduction

SimpleJSON is a light way to do serialization in Unity.

Keep in mind that, SimpleJSON is using Unity's own serialization class "JsonUtility". Which means; what you can Serialize/Deserialize depends on the JsonUtility class.
 
## Features
 - Save
 - Load
 - Reset
 - Window
 
## Important Note

In order for SimpleJSON to save, load or reset, Types must have a few responsibilities;

1 - Types must be marked with "Serializable" attribute.

2 - Types must inherit from "ISaveable".

3 - Types must have a public parameterless constructor

## How To Save

#### Example 1

```csharp 
using UnityEngine;
using SimpleJSON;

public class PlayerController : MonoBehaviour
{
    public PlayerSaveData playerSaveData;

    public void OnGameOver()
    {
        SaveManager.Save(playerSaveData, "PlayerSaveData.json");
    }
}
```

```csharp 
using System.Collections.Generic;
using System;

[Serializable]
public class PlayerSaveData : ISaveable
{
    public int health;
    public int money;
    public List<float> importantFloats;

    public PlayerSaveData()
    {

    }

    public PlayerSaveData SetHealth(int health)
    {
        this.health = health;
        return this;
    }

    public PlayerSaveData SetMoney(int money)
    {
        this.money = money;
        return this;
    }

    public PlayerSaveData SetImportantFloats(List<float> floats)
    {
        this.importantFloats = floats;
        return this;
    }
}
```

#### Example 2

```csharp 
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class EnemyManager : MonoBehaviour
{
    public EnemySaveData[] enemySaves;
    public List<Enemy> enemies;

    public void OnGameEnd()
    {
        SaveManager.Save(enemySaves, "EnemySaves.json");
    }
}
```

```csharp 
using System;

[Serializable]
public class EnemySaveData : ISaveable
{
    public int levelCount;
    public float hitRadius;
    public string name;

    public EnemySaveData SetLevel(int level)
    {
        this.levelCount = level;
        return this;
    }

    public EnemySaveData SetHitRadius(float hitRadius)
    {
        this.hitRadius = hitRadius;
        return this;
    }

    public EnemySaveData SetName(string name)
    {
        this.name = name;
        return this;
    }
}
```


## How To Load

#### Example 1

```csharp 
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class PlayerController : MonoBehaviour
{
    public PlayerSaveData playerSaveData;

    public void OnGameStart()
    {
        var defaultPlayerSaveData = playerSaveData.SetHealth(100).SetImportantFloats(new List<float> { .5f, .4f, .3f, .2f, .1f }).SetMoney(0);

        playerSaveData = SaveManager.Load(defaultPlayerSaveData, "PlayerSaveData.json");
    }
    
}
```

#### Example 2

```csharp 
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class EnemyManager : MonoBehaviour
{
    public EnemySaveData[] enemySaves;
    public List<Enemy> enemies;

    public void OnGameStart()
    {
        var defaultEnemySaves = new List<EnemySaveData>()
        {
            new EnemySaveData().SetHitRadius(1f).SetLevel(1).SetName("Enemy1"),
            new EnemySaveData().SetHitRadius(1f).SetLevel(1).SetName("Enemy2"),
            new EnemySaveData().SetHitRadius(1f).SetLevel(1).SetName("Enemy3"),
            new EnemySaveData().SetHitRadius(1f).SetLevel(1).SetName("Enemy4"),
            new EnemySaveData().SetHitRadius(1f).SetLevel(1).SetName("Enemy5"),
        };

        enemySaves = SaveManager.Load(defaultEnemySaves.ToArray(), "EnemySaves.json");

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].enemySave = enemySaves[i];
        }
    }
}
```

## How To Reset

#### Example 1

```csharp 
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class PlayerController : MonoBehaviour
{
    public PlayerSaveData playerSaveData;

    public void OnGameReset()
    {
        SaveManager.Reset(new PlayerSaveData().SetHealth(100).SetMoney(0), "PlayerSaveData.json");
    }
}
```


#### Example 2

```csharp 
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class EnemyManager : MonoBehaviour
{
    public EnemySaveData[] enemySaves;
    public List<Enemy> enemies;


    public void OnGameReset()
    {
        var defaultEnemySaves = new List<EnemySaveData>()
        {
            new EnemySaveData().SetHitRadius(1f).SetLevel(1).SetName("Enemy1"),
            new EnemySaveData().SetHitRadius(1f).SetLevel(1).SetName("Enemy2"),
            new EnemySaveData().SetHitRadius(1f).SetLevel(1).SetName("Enemy3"),
            new EnemySaveData().SetHitRadius(1f).SetLevel(1).SetName("Enemy4"),
            new EnemySaveData().SetHitRadius(1f).SetLevel(1).SetName("Enemy5"),
        };
        
        SaveManager.Reset(defaultEnemySaves.ToArray(), "EnemySaves.json");
    }
}
```

## SimpleJSON Window

 - SimpleJSON also provides a bunch of extra Window functions to reduce time.
 - It has 4 options;

1 - Create Save Directory

 - Creates a directory called "Saves" relative to the  <a href="https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html">Persistent Datapath</a>

2 - Delete Save Directory

 - Deletes the save directory

3 - Delete Save Files

 - Deletes Save Files

 - Carefull when using this option, it deletes all of your save files

4 - View Save Files

 - Opens up the save directory






