using UnityEngine;
using SimpleJSON;

public class PlayerController : MonoBehaviour
{
    public PlayerSaveData data;

    public PlayerSaveData[] datas;

    private void Awake()
    {
        data = SaveManager.Load(new PlayerSaveData(1, 1), "PlayerSaveData.json");

        datas = SaveManager.Load(new PlayerSaveData[] { new PlayerSaveData(1, 1) }, "PlayerSaveDatas.json");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SaveManager.Save(data, "PlayerSaveData.json");
        }
    }
}
